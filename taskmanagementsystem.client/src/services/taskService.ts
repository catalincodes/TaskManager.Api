import type { ToDoTask } from '../types/ToDoTask.ts';
import type { TaskDTO } from '../types/TaskDTO.ts';

export function mapTaskDTOsToToDoTasks(taskDTOs: TaskDTO[]): ToDoTask[] {
  return taskDTOs.map(taskDTO => {
    return {
      id: taskDTO.id,
      title: taskDTO.title,
      description: taskDTO.description,
      dueDate: new Date(taskDTO.dueDate),
      status: taskDTO.status,
      priority: taskDTO.priority,
    };
  });
}

export const getTasks = async (): Promise<ToDoTask[]> => {
  const response = await fetch('/api/tasks');

  if (!response.ok) {
    throw new Error('Error fetching tasks');
  }

  const dataFromApi: TaskDTO[] = (await response.json()) as unknown as TaskDTO[];

  //Return mapped ToDoTasks
  return mapTaskDTOsToToDoTasks(dataFromApi);
};
