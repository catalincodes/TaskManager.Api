export interface TaskItemProps {
  title: string;
}

export function TaskItem({ title } : TaskItemProps) {
  return <li className="p-4 bg-white border-b border-slate-100 last:border-0 flex items-center hover:bg-slate-50 transition-colors">
    <div className="w-5 h-5 rounded-full border-2 border-blue-500 mr-4 flex-shrink-0" />
    <span className="text-slate-700 font-medium">{title}</span>
  </li>;
}
