import type { BookEntity } from "./book.entity";
import type { UrlEntity } from "./url.entity";

export interface AuthorEntity  {
    Id:number,
    Name:string,
    URLS?: UrlEntity[],
    Books?:BookEntity[]
}