import type {ToDoTask} from "../types/ToDoTask.ts"
import type {TaskDTO} from "../types/TaskDTO.ts";

const mockData: TaskDTO[] = [
    {
        "id": 1,
        "title": "Buy milk",
        "description": "Buy milk from the supermarket",
        "dueDate": "2026-02-15",
        "status": "inProgress",
        "priority": "low"
    },
    {
        "id": 2,
        "title": "Buy eggs",
        "description": "Buy eggs from the supermarket",
        "dueDate": "2026-02-31",
        "status": "toDo",
        "priority": "low"
    }
]

export function mapTaskDTOsToToDoTasks(taskDTOs: TaskDTO[]): ToDoTask[] {
    return taskDTOs.map(taskDTO => { 
        return {
            id: taskDTO.id,
            title: taskDTO.title,
            description: taskDTO.description,
            dueDate: new Date(taskDTO.dueDate),
            status: taskDTO.status,
            priority: taskDTO.priority
        }
    });
}

export const getTasks = async ():Promise<ToDoTask[]> => {
    //Simulate get data from backend
    const dataFromApi: TaskDTO[] = await new Promise<TaskDTO[]>((resolve) =>
        setTimeout(() => resolve(mockData), 1000));

    //Return mapped ToDoTasks
    return mapTaskDTOsToToDoTasks(dataFromApi);
}