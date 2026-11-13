MUNICIPAL SERVICES APPLICATION - PART 3
=======================================

1. WHAT THIS PROGRAMME IS

A C# Windows Forms application for South African municipal services. Residents can:
  - Report Issues (Part 1)
  - View Reported Issues (Part 1)
  - Browse Local Events and Announcements (Part 2)
  - Track Service Requests (Part 3 which is this submission)

2. SYSTEM REQUIREMENTS

  - Windows 10 or Windows 11
  - Visual Studio 2022 with the ".NET desktop development" workload
  - The .NET SDK version targeted by the project (open MunicipalServicesApp.csproj
    and read the <TargetFramework> line)

3. HOW TO COMPILE

  1. Unzip the submission folder.
  2. Double-click MunicipalServicesApp.sln to open it in Visual Studio 2022.
  3. Wait for NuGet to finish restoring (bottom-left status bar).
  4. Choose the "Debug" configuration and "Any CPU" in the toolbar.
  5. Press Ctrl + Shift + B (Build > Build Solution). The Output window must
     show "Build succeeded" with 0 errors.

4. HOW TO RUN

  1. Press F5 (Debug > Start Debugging), or Ctrl + F5 to run without debugging.
  2. The Municipal Services Portal main menu opens.

5. HOW TO USE THE SERVICE REQUEST STATUS FEATURE

Click "Service Request Status" on the main menu.

  Seed data: 16 sample requests (SR-1001 to SR-1016) are loaded at start-up so
  every feature can be tested straight away. Every issue you report in
  "Report Issues" also becomes a new request (SR-1017, SR-1018, ...).

  A. Track a request by ID
     - Type an ID such as SR-1003 (or just 1003) into the box at the top and
       press Track Request (or the Enter key).
     - The request is selected in the list and its details, progress bar and
       history appear on the right.
     - The message under the box shows how many comparisons the AVL tree needed.

  B. Browse and filter (All Requests tab)
     - Category: shows only one category (uses the basic tree).
     - Status: shows only requests in one status.
     - Sort by: request number (AVL tree), most urgent first (heap sort) or
       newest first (red-black tree).
      Click any row to see its full details and progress history.
      To change a status, select a request, choose a New status and press
       Update Status. The history and progress bar update immediately.

  C. Urgent Queue (Heap) tab
      Shows the 10 most urgent open requests. Priority 1 is the most urgent.

  D. Related Requests (Graph) tab
      Choose a request in the drop-down, then press Breadth-First Search or
       Depth-First Search to list the requests related to it.
      Requests are related if they share a category or are within 5 km.

  E. Route Planner (Spanning Tree) tab
     Press Build with Kruskal or Build with Prim. Both list the links that
       connect all related requests with the least total distance. The total
       distance is the same for both algorithms.

  F. Data Structure Insights tab
      Shows the height of every tree, the number of AVL rotations, whether
       the red-black rules hold, and graph statistics. Press Refresh Insights
       after changing a status.

  Press Back to Menu to return to the main menu.

6. DATA STRUCTURES AND WHERE THEY LIVE

  ServiceRequest.cs          Model for one service request
  GeneralTree.cs             Basic tree: Root > Category > Requests
  BinaryTree.cs              Binary tree filled level by level
  BinarySearchTree.cs        BST keyed by request number
  AvlTree.cs                 Self-balancing AVL tree (main ID index)
  RedBlackTree.cs            Red-black tree ordered by date submitted
  MinHeap.cs                 Min-heap (priority queue and heap sort)
  RequestGraph.cs            Weighted graph, BFS, DFS, Kruskal and Prim MST
  ServiceRequestManager.cs   Keeps all structures in sync and seeds sample data
  ServiceRequestStatusForm.cs  The Service Request Status Windows Form
  IssueManager.cs            Part 1 store; now also creates service requests

7. TROUBLESHOOTING

  - "Build failed": open View > Error List, fix the first error, rebuild.
  - A form looks blurry: set Windows display scaling to 100% or 125%.
  - Nothing happens on the main menu button: make sure the project was
    rebuilt (Ctrl + Shift + B) after pulling the latest code.
  - Data is stored in memory only, so requests reset when the programme closes.

  PART 1 FEEDBACK

Feedback received:
The lecturer was happy with the five user engagement strategies provided. They were relevant to municipal services applications.

Update made:
The five user engagement strategies were kept and used to guide the design of the application.

Where in the code:
Main menu and user interface implementation.

Feedback received:
The lecturer mentioned that the application uses appropriate data structures, but there is still room for improvement. The README file also contains useful information but could include more detail.

Update made:
The data structures were reviewed and used more consistently. Additional explanations were also included to make the project easier to understand and use.

Where in the code:
IssueManager.cs and README.md.

PART 2 FEEDBACK

Feedback received:
The lecturer was satisfied with the Local Events and Announcements page. The stacks, queues and priority queues were implemented correctly and used to manage event-related information.

Update made:
The data structures were maintained and used to organise and manage event information.

Where in the code:
LocalEventsForm.cs and related data structure classes.

Feedback received:
The lecturer was happy with the use of hash tables, dictionaries and sets. They were also satisfied with how the recommendation feature analyses user search patterns and preferences to suggest related events.

Update made:
The search and recommendation features were maintained to help users find relevant events more easily.

Where in the code:
LocalEventsForm.cs and related search and recommendation classes.
