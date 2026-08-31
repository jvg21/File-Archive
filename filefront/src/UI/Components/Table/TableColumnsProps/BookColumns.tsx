import type { BookEntity } from "../../../../Data/Types/Entity/book.entity";
import { ReadingStatusEnum } from "../../../../Utils/Enums/readingStatus.enum";
import { WritingStatusEnum } from "../../../../Utils/Enums/writingStatus.enum";
import type { TableColumns } from "../table.component";

export const BookColums: TableColumns<BookEntity>[] = [
    { key: 'id', header: 'Id' },
    { key: "name", header: "Name" },
    {
        key: "authors", header: "Authors",
        render: (value) => {
            const authors = value as BookEntity["authors"];

            return authors && authors.length > 0
                ? authors.map(a => <p>{a.name}</p>)
                : '';
        }
    },
    {
        key: "urls", header: 'Urls',
        render: (value) => {
            const urls = value as BookEntity["urls"];

            return urls && urls.length > 0 ?
                urls.map(url => <a target="_blank" href={url.content}>{url.name}</a>)
                : '';
        }
    },
    {
        key: "summary", header: "Summary",
        render: (value) => {
            const summary = value as BookEntity['summary']
            return summary.slice(0, 30)
        },
    },
    {
        key: "currentChapter", header: "Chapters",
        render: (value, row) => {

            return `${value ?? '-'} / ${row.totalChapters ?? '??'}`

        }
    },

    {
        key: "readingStatus", header: "Reading Status",
        render: (value) => {
            const readingStatus = value as BookEntity['readingStatus'];

            return readingStatus !== undefined && readingStatus !== null
                ? ReadingStatusEnum[readingStatus as keyof typeof ReadingStatusEnum].name
                : '';
        }
    },
    {
        key: "writingStatus", header: "Writing Status",
        render: (value) => {
            const writingStatus = value as BookEntity['writingStatus']

            return writingStatus !== undefined && writingStatus !== null ?
                WritingStatusEnum[writingStatus as keyof typeof WritingStatusEnum].name
                : ''
        }
    },
    { key: "words", header: "Words" },
    { key: "rating", header: "Rating" },
]