import { useEffect, useState } from "react";
import { getTasks } from "./services/taskService";
import type { ToDoTask } from "./types/ToDoTask.ts";

function App() {
    const [tasks, setTasks] = useState<ToDoTask[]>([]);
    const [isLoading, setIsLoading] = useState<boolean>(true);
    const [error, setError] = useState<string>("");

    useEffect(() => {
        const fetchTasks = async () => {
            try {
                const result = await getTasks();
                setTasks(result);
            }
            catch (error) {
                if (error instanceof Error)
                    setError(error.message);
                else
                    setError("Unexpected error");
                setTasks([]);
            }
            finally {
                setIsLoading(false);
            }
        }

        void fetchTasks();
    }, []);

    if (isLoading)
        return <p>Loading...</p>;

    if (error)
        return <p>Error: {error}</p>;

    const listTasks = tasks.map(task => <li key={task.id}>{task.title}</li>);

    return (
        <>
            <h1>Task Manager</h1>
            <ul>{listTasks}</ul>
        </>
    )
}

export default App
