🏗️ Architectural Decision Records (ADR)

1. Unified Environment Pattern (The "Linux First" Choice)
Decision: We replaced launchSettings.json and User Secrets with a single .env file and a dev.sh entrypoint.

Reasoning: To ensure portability between Windows and Fedora Linux and to align with production DevOps practices (Process over IDE magic).

The Command: Always run ./dev.sh. It handles port injection (BE_PORT, FE_PORT) and ensures a clean shutdown of "ghost" processes.

2. The "Hollow" Configuration
Decision: Kept a minimal launchSettings.json and appsettings.json.

Reasoning: The .NET SDK requires these files to exist, but they are "hollowed out" to prevent hardcoded port conflicts. The .env file is the Single Source of Truth.

3. Pragmatic CRUD vs. TDD
Decision: No Unit Tests until the "CRUD works" phase is complete.

Reasoning: High-velocity prototyping means specs change 30+ times a week. Refactoring tests during this phase is a "velocity killer."
