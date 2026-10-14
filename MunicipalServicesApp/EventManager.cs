using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalServicesApp
{
    public class EventManager
    {
        // ---------- ONE MANAGER FOR THE WHOLE APP ----------
        // The Local Events page asks for this manager every time it opens, so the app
        // remembers searches, viewed events and dismissed banner announcements between visits.
        private static EventManager? shared;

        public static EventManager GetShared()
        {
            if (shared == null)
            {
                shared = new EventManager();
                shared.Seed();
            }
            return shared;
        }

        // ---------- DATA STRUCTURES ----------

        // Dictionary: find an event by its id
        private Dictionary<int, EventItem> eventsById = new Dictionary<int, EventItem>();

        // SortedDictionary: events grouped by date, always in date order
        private SortedDictionary<DateTime, List<EventItem>> eventsByDate = new SortedDictionary<DateTime, List<EventItem>>();

        // HashSet (a set): every category is stored once only
        private HashSet<string> categories = new HashSet<string>();

        // SortedSet (a set): every event date is stored once only, in order
        private SortedSet<DateTime> eventDates = new SortedSet<DateTime>();

        // PriorityQueue: the banner at the top takes announcements from here, most urgent first.
        // Dismissing an announcement removes it from this queue only.
        private PriorityQueue<Announcement, int> announcements = new PriorityQueue<Announcement, int>();

        // Every announcement is also kept in this list so the full list can always be shown
        private List<Announcement> allAnnouncements = new List<Announcement>();
        private int nextAnnouncementOrder = 1;

        // Queue: the last searches the user made (first in, first out)
        private Queue<string> recentSearches = new Queue<string>();

        // Stack: events the user opened (last in, first out)
        private Stack<EventItem> recentlyViewed = new Stack<EventItem>();

        // Points that remember what the user searched for (used for recommendations)
        private Dictionary<string, int> categoryScore = new Dictionary<string, int>();
        private Dictionary<string, int> wordScore = new Dictionary<string, int>();

        private int nextId = 1;

        // ---------- ADD DATA ----------

        public void AddEvent(string title, string category, DateTime date, string location, string description)
        {
            EventItem ev = new EventItem();
            ev.Id = nextId;
            nextId++;
            ev.Title = title;
            ev.Category = category;
            ev.Date = date;
            ev.Location = location;
            ev.Description = description;

            eventsById.Add(ev.Id, ev);

            DateTime day = date.Date;
            if (!eventsByDate.ContainsKey(day))
            {
                eventsByDate.Add(day, new List<EventItem>());
            }
            eventsByDate[day].Add(ev);
            eventsByDate[day].Sort((a, b) => a.Date.CompareTo(b.Date));

            categories.Add(category);
            eventDates.Add(day);
        }

        // Dictionary lookup: get an event from its id (null if there is no such event)
        public EventItem? GetEventById(int id)
        {
            EventItem? ev;
            if (eventsById.TryGetValue(id, out ev))
            {
                return ev;
            }
            return null;
        }

        // ---------- SETS ----------

        public List<string> GetCategories()
        {
            List<string> list = new List<string>(categories);
            list.Sort();
            return list;
        }

        public DateTime FirstDate()
        {
            return eventDates.Min;
        }

        public DateTime LastDate()
        {
            return eventDates.Max;
        }

        // Next date after the given date that has events (MinValue = none)
        public DateTime NextDateAfter(DateTime date)
        {
            foreach (DateTime d in eventDates)
            {
                if (d > date.Date) return d;
            }
            return DateTime.MinValue;
        }

        // ---------- ANNOUNCEMENTS ----------

        // Lower number = comes out first. Adding the order keeps same-priority announcements in the order they were added.
        private int PriorityKey(Announcement a)
        {
            return a.Priority * 1000 + a.Order;
        }

        public void AddAnnouncement(string title, string message, int priority)
        {
            Announcement a = new Announcement();
            a.Title = title;
            a.Message = message;
            a.Priority = priority;
            a.Order = nextAnnouncementOrder;
            nextAnnouncementOrder++;

            allAnnouncements.Add(a);
            announcements.Enqueue(a, PriorityKey(a));
        }

        public int AnnouncementCount()
        {
            return announcements.Count;
        }

        // Look at the most urgent announcement for the banner (null if there are none)
        public Announcement? GetTopAnnouncement()
        {
            if (announcements.Count == 0) return null;
            return announcements.Peek();
        }

        // Remove the most urgent announcement from the banner (it stays in the full list)
        public void DismissAnnouncement()
        {
            if (announcements.Count > 0)
            {
                announcements.Dequeue();
            }
        }

        // Put every announcement back in the banner queue (used each time the page opens)
        public void RefillBanner()
        {
            announcements = new PriorityQueue<Announcement, int>();
            foreach (Announcement a in allAnnouncements)
            {
                announcements.Enqueue(a, PriorityKey(a));
            }
        }

        // All announcements, most urgent first. A temporary priority queue does the sorting,
        // so nothing is removed from the real data.
        public List<Announcement> GetAnnouncementsByPriority()
        {
            PriorityQueue<Announcement, int> temp = new PriorityQueue<Announcement, int>();
            foreach (Announcement a in allAnnouncements)
            {
                temp.Enqueue(a, PriorityKey(a));
            }

            List<Announcement> sorted = new List<Announcement>();
            while (temp.Count > 0)
            {
                sorted.Add(temp.Dequeue());
            }
            return sorted;
        }

        // ---------- SEARCH ----------

        // category = "" means all categories. useDate = false means any date.
        public List<EventItem> Search(string text, string category, bool useDate, DateTime date)
        {
            List<EventItem> results = new List<EventItem>();
            text = text.ToLower();

            foreach (KeyValuePair<DateTime, List<EventItem>> day in eventsByDate)
            {
                if (useDate && day.Key != date.Date) continue;

                foreach (EventItem ev in day.Value)
                {
                    if (category != "" && ev.Category != category) continue;

                    if (text != "")
                    {
                        string all = (ev.Title + " " + ev.Category + " " + ev.Location + " " + ev.Description).ToLower();
                        if (!all.Contains(text)) continue;
                    }

                    results.Add(ev);
                }
            }
            return results;
        }

        // ---------- REMEMBER WHAT THE USER DOES ----------

        public string[] GetRecentSearches()
        {
            return recentSearches.ToArray();
        }

        public List<EventItem> GetRecentlyViewed(int max)
        {
            return recentlyViewed.Take(max).ToList();
        }

        public void RecordSearch(string text, string category)
        {
            if (category != "")
            {
                AddPoints(categoryScore, category, 2);
            }

            if (text == "") return;

            // Queue: keep only the last 8 searches
            if (!recentSearches.Contains(text))
            {
                recentSearches.Enqueue(text);
                if (recentSearches.Count > 8)
                {
                    recentSearches.Dequeue();
                }
            }

            // Give points to each word the user typed (ignoring empty entries and very short words)
            string[] words = text.ToLower().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in words)
            {
                if (word.Length < 4) continue;

                AddPoints(wordScore, word, 1);

                // If the word looks like a category (for example "sport"), give that category points too
                foreach (string cat in categories)
                {
                    if (cat.ToLower().Contains(word))
                    {
                        AddPoints(categoryScore, cat, 2);
                    }
                }
            }
        }

        public void RecordView(EventItem ev)
        {
            // Stack: push the event on top (no duplicates in the list)
            if (recentlyViewed.Count == 0 || recentlyViewed.Peek().Id != ev.Id)
            {
                // rebuild the stack without any older copy of this event, then push it on top
                List<EventItem> keep = recentlyViewed.Reverse().Where(x => x.Id != ev.Id).ToList();
                recentlyViewed = new Stack<EventItem>(keep);
                recentlyViewed.Push(ev);
            }
            AddPoints(categoryScore, ev.Category, 1);
        }

        private void AddPoints(Dictionary<string, int> scores, string key, int points)
        {
            if (scores.ContainsKey(key))
            {
                scores[key] = scores[key] + points;
            }
            else
            {
                scores.Add(key, points);
            }
        }

        // ---------- RECOMMENDATIONS ----------

        // ---------- RECOMMENDATIONS ----------
        // Every upcoming event that the user has not opened yet gets points from what the program learned:
        //   category points = how much the user likes the category (searches + opened events) x 3
        //   word points     = how many of the user's search words are in the event x 2
        //   similar points  = 3 if it is in the same category as the event opened last, +1 if it is at the same venue
        // The events with the most points are recommended and the strongest reason is shown under each one.

        public List<Recommendation> GetRecommendations(int max)
        {
            List<Recommendation> picks = new List<Recommendation>();

            // the event the user opened most recently (top of the stack)
            EventItem? last = null;
            if (recentlyViewed.Count > 0)
            {
                last = recentlyViewed.Peek();
            }

            foreach (EventItem ev in eventsById.Values)
            {
                if (ev.Date < DateTime.Today) continue;        // skip past events
                if (recentlyViewed.Contains(ev)) continue;     // skip events the user already opened

                int categoryPoints = 0;
                if (categoryScore.ContainsKey(ev.Category))
                {
                    categoryPoints = categoryScore[ev.Category] * 3;
                }

                int wordPoints = SearchWordPoints(ev) * 2;

                int similarPoints = 0;
                if (last != null)
                {
                    similarPoints = GetSimilarity(last, ev);
                }

                int score = categoryPoints + wordPoints + similarPoints;
                if (score <= 0) continue;

                Recommendation rec = new Recommendation();
                rec.Event = ev;
                rec.Score = score;
                rec.Reason = GetReason(ev, categoryPoints, wordPoints, similarPoints);
                picks.Add(rec);
            }

            // Best score first, then the soonest date
            picks = picks.OrderByDescending(r => r.Score).ThenBy(r => r.Event.Date).ToList();

            // If the user has searched or opened events but nothing scored, suggest what is coming up soon
            bool userHasActed = recentlyViewed.Count > 0 || recentSearches.Count > 0;
            if (picks.Count == 0 && userHasActed)
            {
                foreach (EventItem soon in eventsById.Values.OrderBy(e => e.Date))
                {
                    if (soon.Date < DateTime.Today) continue;
                    if (recentlyViewed.Contains(soon)) continue;

                    Recommendation fallback = new Recommendation();
                    fallback.Event = soon;
                    fallback.Score = 0;
                    fallback.Reason = "Coming up soon";
                    picks.Add(fallback);
                }
            }

            if (picks.Count > max)
            {
                picks = picks.GetRange(0, max);
            }
            return picks;
        }

        // Points from the words the user searched for that appear in this event
        // Points from the words the user searched for that appear in this event
        private int SearchWordPoints(EventItem ev)
        {
            int points = 0;
            string all = (ev.Title + " " + ev.Description + " " + ev.Location).ToLower();
            foreach (KeyValuePair<string, int> pair in wordScore)
            {
                if (all.Contains(pair.Key)) points += pair.Value;
            }
            return points;
        }

        // The searched word with the most points that appears in this event ("" if none)
      
        private int GetSimilarity(EventItem last, EventItem other)
        {
            int points = 0;
            if (other.Category == last.Category) points += 3;
            if (other.Location == last.Location) points += 1;
            return points;
        }

        // A short sentence that explains why an event was recommended
        private string GetReason(EventItem ev, int categoryPoints, int wordPoints, int similarPoints)
        {
            string word = BestSearchWord(ev);

            if (wordPoints > 0 && categoryPoints > 0)
            {
                return "You like " + ev.Category + " and searched \"" + word + "\"";
            }
            if (wordPoints > 0)
            {
                return "Matches your search \"" + word + "\"";
            }
            if (similarPoints >= 3)
            {
                return "More " + ev.Category + " events";
            }
            if (similarPoints > 0)
            {
                return "Same venue as the event you opened";
            }
            return "You like " + ev.Category + " events";
        }

        // The searched word with the most points that appears in this event ("" if none)
        // The searched word with the most points that appears in this event ("" if none)
        private string BestSearchWord(EventItem ev)
        {
            string all = (ev.Title + " " + ev.Description + " " + ev.Location).ToLower();
            string best = "";
            int bestPoints = 0;
            foreach (KeyValuePair<string, int> pair in wordScore)
            {
                if (all.Contains(pair.Key) && pair.Value > bestPoints)
                {
                    best = pair.Key;
                    bestPoints = pair.Value;
                }
            }
            return best;
        }
        // How related is "other" to the event the user opened? 0 = not related.
        private int GetSimilarity(EventItem current, EventItem other, out string reason)
        {
            int points = 0;
            reason = "";

            if (current.Category == other.Category)
            {
                points += 3;
                reason = "Same category as \"" + current.Title + "\" (" + current.Category + ")";
            }

            // shared meaningful words in the title, description or location
            HashSet<string> currentWords = MeaningfulWords(current);
            HashSet<string> otherWords = MeaningfulWords(other);
            currentWords.IntersectWith(otherWords);

            if (currentWords.Count > 0)
            {
                points += currentWords.Count;
                if (reason == "")
                {
                    reason = "Similar to \"" + current.Title + "\"";
                }
            }
            return points;
        }

        // Words of 5 or more letters from the event text (short filler words are ignored)
        private HashSet<string> MeaningfulWords(EventItem ev)
        {
            string text = (ev.Title + " " + ev.Description + " " + ev.Location).ToLower();
            char[] separators = new char[] { ' ', '.', ',', '-', '"', '(', ')' };

            HashSet<string> words = new HashSet<string>();
            foreach (string w in text.Split(separators, StringSplitOptions.RemoveEmptyEntries))
            {
                if (w.Length >= 5)
                {
                    words.Add(w);
                }
            }
            return words;
        }

        private bool MatchesSearchWords(EventItem ev)
        {
            string all = (ev.Title + " " + ev.Description + " " + ev.Location).ToLower();
            foreach (string word in wordScore.Keys)
            {
                if (all.Contains(word)) return true;
            }
            return false;
        }

        private int GetScore(EventItem ev)
        {
            int score = 0;

            if (categoryScore.ContainsKey(ev.Category))
            {
                score += categoryScore[ev.Category] * 3;
            }

            string all = (ev.Title + " " + ev.Description + " " + ev.Location).ToLower();
            foreach (KeyValuePair<string, int> pair in wordScore)
            {
                if (all.Contains(pair.Key)) score += pair.Value;
            }
            return score;
        }

        // A short sentence that explains why an event was recommended
        private string GetReason(EventItem ev)
        {
            bool likesCategory = categoryScore.ContainsKey(ev.Category);

            // find the searched word that matches this event and has the most points
            string all = (ev.Title + " " + ev.Description + " " + ev.Location).ToLower();
            string bestWord = "";
            int bestPoints = 0;
            foreach (KeyValuePair<string, int> pair in wordScore)
            {
                if (all.Contains(pair.Key) && pair.Value > bestPoints)
                {
                    bestWord = pair.Key;
                    bestPoints = pair.Value;
                }
            }

            if (likesCategory && bestWord != "")
            {
                return "Because you like " + ev.Category + " events and searched \"" + bestWord + "\"";
            }
            if (likesCategory)
            {
                return "Because you like " + ev.Category + " events";
            }
            return "Matches your search for \"" + bestWord + "\"";
        }

        // ---------- SAMPLE DATA ----------

        private DateTime Day(int daysFromToday, int hour)
        {
            return DateTime.Today.AddDays(daysFromToday).AddHours(hour);
        }

        private void Seed()
        {
            AddEvent("Water Supply Maintenance Briefing", "Utilities", Day(2, 10), "Civic Centre",
                "Engineers explain planned maintenance and how to prepare for water interruptions.");
            AddEvent("Community Clean-Up Day", "Environment", Day(4, 8), "Ward 12 Park",
                "Join your neighbours to clean the park. Gloves and bags are provided.");
            AddEvent("Youth Soccer Tournament", "Sports", Day(4, 9), "Municipal Sports Ground",
                "Under-15 teams compete for the mayoral trophy. Free entry.");
            AddEvent("Heritage Day Cultural Market", "Culture", Day(7, 10), "Town Square",
                "Local crafters, food stalls and live traditional music.");
            AddEvent("Free Health Screening Clinic", "Health", Day(7, 8), "Community Health Centre",
                "Free blood pressure and glucose checks. No appointment needed.");
            AddEvent("Ward Committee Public Meeting", "Community", Day(9, 18), "Ward 5 Hall",
                "Raise service delivery concerns with your ward committee.");
            AddEvent("Recycling Drive and E-Waste Collection", "Environment", Day(11, 9), "Civic Centre Parking",
                "Drop off recyclables, old electronics and batteries.");
            AddEvent("Community Jazz Evening", "Culture", Day(14, 19), "Town Hall Auditorium",
                "Live jazz from local musicians. Free tickets.");
            AddEvent("Charity Fun Run", "Sports", Day(18, 7), "Riverside Park",
                "5 km and 10 km routes. Proceeds support local projects.");
            AddAnnouncement("Planned water interruption",
                "Ward 5 will have no water on the day of the briefing. Store water in advance.", 1);
            AddAnnouncement("Road closure",
                "Main Street closes for the Heritage Day Market. Use alternative routes.", 2);
            AddAnnouncement("Refuse collection",
                "Collection days shift by one day in the week of the public holiday.", 2);
            AddAnnouncement("Library hours",
                "The public library now opens at 08:00 on Saturdays.", 3);
            AddEvent("Blood Donation Drive", "Health", Day(12, 9), "Community Health Centre",
        "Donate blood and save lives. Refreshments are provided.");
            AddEvent("Electricity Outage Information Session", "Utilities", Day(13, 10), "Civic Centre",
                "Learn about the outage schedule and how to report faults.");
            AddEvent("Neighbourhood Safety Forum", "Community", Day(15, 18), "Ward 12 Hall",
                "Meet police and community leaders to discuss local safety.");
        }
    }
}
