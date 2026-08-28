import type { AuthorEntity } from "./author.entity";
import type { FileArchive } from "./fileArchive.entity";
import type { UrlEntity } from "./url.entity";


export interface BookEntity  {
    Id: number,
    Name: string,
    Summary: string,
    CurrentChapter?: number,
    TotalChapters?: number,
    Rating?: number,
    Words?: number,
    ReadingStatus?: number,
    WritingStatus?: number,
    Authors?: AuthorEntity[],
    URLS?: UrlEntity[],
    Files?: FileArchive[],
}