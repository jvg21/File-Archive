import type { AuthorEntity } from "./author.entity";
import type { BookEntity } from "./book.entity";


export interface FileArchive  {
    Id: number,
    Name: string,
    StorageName: string,
    Extension: string,
    MimeType: string,
    Path: string,
    StorageBytes:number
    Author?: AuthorEntity,
    Book?: BookEntity,
}