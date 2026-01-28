import type {ToDoTask} from "../types/ToDoTask.ts"

// to be replaced with DTO
const mockData: ToDoTask[] = []

// need a mapper method to convert DTO to ToDoTask

export const getTasks = async ():Promise<ToDoTask[]> => {
    //mock a call to the backend with a timeout, convert it using the mapper and return it.
    return mockData;
}