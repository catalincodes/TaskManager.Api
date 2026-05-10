import type { ToDoTask } from '../types/ToDoTask.ts';
import type { TaskDTO } from '../types/TaskDTO.ts';
import api from '../api.ts';
import axios from 'axios';

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
  try {
    const response = await api.get<TaskDTO[]>('/api/tasks');

    const dataFromApi = response.data;

    return mapTaskDTOsToToDoTasks(dataFromApi);
  } catch (error) {
    if (axios.isAxiosError(error)) {
      console.error(`API Error : ${error.response?.status} - ${error.message}`);
    } else {
      console.error('Unknown error');
    }

    return [];
  }
};
