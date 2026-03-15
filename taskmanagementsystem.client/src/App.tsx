import { useEffect, useState } from 'react';
import { getTasks } from './services/taskService';
import type { ToDoTask } from './types/ToDoTask.ts';
import { TaskList } from './components/TaskList.tsx';

function App() {
  const [tasks, setTasks] = useState<ToDoTask[]>([]);
  const [isLoading, setIsLoading] = useState<boolean>(true);
  const [error, setError] = useState<string>('');

  useEffect(() => {
    const fetchTasks = async () => {
      try {
        const result = await getTasks();
        setTasks(result);
      } catch (error) {
        if (error instanceof Error) {
          setError(error.message);
        } else {
          setError('Unexpected error');
        }
        setTasks([]);
      } finally {
        setIsLoading(false);
      }
    };

    void fetchTasks();
  }, []);

  if (isLoading) {
    return <p>Loading...</p>;
  }

  if (error) {
    return <p>Error: {error}</p>;
  }

  // const listTasks = tasks.map(task => <TaskItem key={task.id} title={task.title} />);

  return (
    <div className="min-h-dvh bg-slate-50 flex justify-center py-0 md:py-10">
      <div
        className="relative w-full max-w-md bg-white shadow-xl md:rounded-3xl overflow-hidden
                            flex flex-col border border-slate-200"
      >
        <header className="px-6 py-8 bg-gradient-to-r from-blue-600 to-indigo-700 text-white">
          <h1 className="text-2xl font-bold tracking-tight">Task Manager</h1>
        </header>

        <TaskList tasks={tasks} />

        <button
          aria-aria-label="Add Task"
          className="absolute bottom-8 right-6 w-14 h-14 bg-blue-600 text-white rounded-full shadow-lg flex items-center justify-center text-3xl font-light hover:bg-blue-700 transition-transform active:scale-90 z-10"
        >
          +
        </button>
      </div>
    </div>
  );
}

export default App;
