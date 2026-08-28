import type { AuthorEntity } from "./author.entity";
import type { BookEntity } from "./book.entity";


export interface UrlEntity {
    id: number,
    name: string,
    content: string,
    author?: AuthorEntity,
    book?: BookEntity,
}