🗺️ Project Roadmap: Task Management System
Phase 1: Back-end API (The Foundation)
Goal: Develop a robust CRUD engine in .NET.

- [x] Scaffold project & initial endpoints (GET, POST, PUT, DELETE)
- [x] Implement body-based requests for POST/PUT
- [x] Standardize HTTP Status Codes (204 for missing objects)
- [x] Implement server-side filtering (Title, Date, Priority)
- [ ] Data Integrity—Implement [Required] and [StringLength] validation in Models. (after edit screen in Phase 3)

Phase 2: Basic UI & Tooling (The Handshake)
Goal: Establish the environment and the communication layer.

- [x] Scaffold React/Vite project & Tailwind CSS
- [x] DevOps: Orchestrate CORS, vite.config.ts, and Program.cs to eliminate hardcoded ports.
- [x] Tooling: Platform migration (Windows -> Linux) and IDE consolidation (VS2026).
- [x] Service Layer: Create TypeScript interfaces and the Fetch/API service.
- [x] UI Shell: Create the main view and folder structure.

Phase 3: CRUD & Componentization (Current Focus)
Goal: Move from a "Flat Prototye" to a "Modular System."

- [x] Status Persistence: Back-end DTOs and Logic now support task status.
- [x] Refactor: Break App.tsx into modular components (TaskDashboard, TaskList, TaskItem).
- [x] Feature: Reusable API endpoint for PATCH operations.
- [ ] Interactions: Implement Toggle (Complete).
- [ ] Feature: Add an edit screen.
- [ ] Interactions: Add New, Edit (Pencil icon).
- [ ] Soft Delete: Replace hard deletion with isDeleted visibility logic.🗺️ Project Roadmap: Task Management System
- [ ] Polishing: Replace strings in the domain model with specialized data types for DueDate, Priority and Status 

Future Vision
- MySQL database persistence 
- Infinite subtask depth - for large scale projects (Breadcrumbs, Only see the current level to prevent recursive querying)
- Moving the needle view
- Recurrence
- Today view
- Notifications
- Daily CRON event
- Focus mode
- Search & Filtering
- ✨ AI Day-at-a-glance
- ✨ AI Planning

Important notes
- an item has ID, ParentID, TLParentId among other stuff
- add breadcrumbs
- search should show the results and for each one the parent level top-level task's name

