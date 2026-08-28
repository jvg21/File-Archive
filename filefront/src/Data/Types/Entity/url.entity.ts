import type { AuthorEntity } from "./author.entity";
import type { BookEntity } from "./book.entity";


export interface UrlEntity {
    Id: number,
    Name: string,
    Content: string,
    Author?: AuthorEntity,
    Book?: BookEntity,
}