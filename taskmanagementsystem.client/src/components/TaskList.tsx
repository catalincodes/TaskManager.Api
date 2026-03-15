import type { ToDoTask } from '../types/ToDoTask';
import { TaskItem } from './TaskItem';

export interface TaskListProps {
  tasks: ToDoTask[]
}

export function TaskList({ tasks } : TaskListProps) {
  const listTasks = tasks.map( task => <TaskItem key={task.id} title={task.title} />);

  return (
    <main className="flex-1 overflow-y-auto bg-white">
      <ul className="divide-y divide-slate-50">{listTasks}</ul>
    </main>
  );
}
