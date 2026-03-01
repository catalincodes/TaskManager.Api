#!/bin/bash

# 1. Load Environment Variables
if [ -f .env ]; then
    export $(grep -v '^#' .env | xargs)
else
    echo "❌ Error: .env file not found."
    exit 1
fi

# 2. Cleanup Function: Kill EVERYTHING started by this script
cleanup() {
    echo -e "\n🛑 Shutting down servers..."
    # Kill the background process group
    kill $(jobs -p) 2>/dev/null
    exit
}

# Trap SIGINT (Ctrl+C) and SIGTERM
trap cleanup SIGINT SIGTERM

echo "🚀 System Syncing..."

# 3. Start Backend
(cd TaskManagementSystem.Server && dotnet run --urls="http://localhost:$BE_PORT") &

# 4. Start Frontend
(cd taskmanagementsystem.client && npm run dev -- --port $FE_PORT) &

# 5. Keep the script alive so the trap can catch Ctrl+C
echo "📡 Press Ctrl+C to stop both servers."
wait
