import type { AuthorEntity } from "./author.entity";

export type BookEntity = {
    Id:number,
    Name:string,
    Summary:string,
    CurrentChapter?:number,
    TotalChapters?:number,
    Rating?:number,
    Words?:number,
    ReadingStatus?:number,
    WritingStatus?:number,
    Author?:AuthorEntity[],
    URLS?:any[],
    Files?:any[],
}