
import style from '../../UI/Styles/table.module.css'
import { Link } from "react-router-dom";
import type { BookEntity } from '../../Data/Types/Entity/book.entity';
import type { TableColumns } from '../../UI/Components/Table/table.component';
import { ReadingStatusEnum } from '../../Utils/Enums/readingStatus.enum';
import { WritingStatusEnum } from '../../Utils/Enums/writingStatus.enum';


export const BookColums: TableColumns<BookEntity>[] = [
    { key: 'id', header: 'Id' },
    { key: "name", header: "Name" },
    {
        key: "authors", header: "Authors",
        render: (value) => {
            const authors = value as BookEntity["authors"];

            return authors && authors.length > 0 ?
                authors.map(a =>
                    <div key={a.id} className={style.urls} >
                        <Link to={`/author/${a.id}`}>{a.name}</Link><br />
                    </div>
                )
                : '';
        }
    },
    {
        key: "urls", header: 'Urls',
        render: (value) => {
            const urls = value as BookEntity["urls"];

            return urls && urls.length > 0 &&
                <ul className={style.urls} >
                    {
                        urls.map(url =>
                            <li key={url.id}><a target="_blank" href={url.content}>{url.name.slice(0, 10)}</a></li>
                        )
                    }
                </ul>

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

