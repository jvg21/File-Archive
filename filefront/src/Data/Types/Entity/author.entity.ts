import type { BookEntity } from "./book.entity";
import type { UrlEntity } from "./url.entity";

export interface AuthorEntity  {
    id:number,
    name:string,
    urls?: Partial<UrlEntity>[],
    books?:Partial<BookEntity>[]
}