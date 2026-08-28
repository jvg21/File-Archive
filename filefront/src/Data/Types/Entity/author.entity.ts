import type { BookEntity } from "./book.entity";
import type { UrlEntity } from "./url.entity";

export interface AuthorEntity  {
    id:number,
    name:string,
    url?: UrlEntity[],
    books?:BookEntity[]
}