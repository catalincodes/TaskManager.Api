export interface TaskDTO {
  id: number;
  title: string;
  description?: string;
  dueDate: string;
  status: string;
  priority: string;
}
