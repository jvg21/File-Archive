import type { BookEntity } from "../Data/Types/Entity/book.entity";

import { useEffect, useState } from "react";
import { BookDataStore } from "../Data/Datastore/book.datastore"
import { Table, type TableColumn } from "../UI/Components/Table/Table"
import pageStyle from '../UI/Styles/pages.module.css'


export const BookPage = () => {
    const bookDataStore = new BookDataStore();

    const [bookData, setBookData] = useState<BookEntity[] | null>(null);

    async function getBookData() {
        const request = await bookDataStore.getAll();
        return request.data || []
    }

    useEffect(() => {
        const getData = async () => {
            var request = await getBookData();
            setBookData(request as BookEntity[])
        };
        getData();
    }, [])

    return (
        <div className={pageStyle.main}>
            <Table
                data={bookData ?? []}
                columns={columns}
                keyExtractor={(book) => book.id}
            />
        </div>
    )
}


const columns: TableColumn<BookEntity>[] = [
    { key: "id", header: "Id", width: "20px" },
    { key: "name", header: "Name" },
    { key: "summary", header: "Summary" },
    { key: "currentChapter", header: "Current Chapter", width: "20px" },
    { key: "totalChapters", header: "Total Chapters", width: "20px" },
    {
        key: "rating",
        header: "Rating",
        width: "20px",
        render: (value) => value ? `${value}/10` : '-'
    },
    {
        key: "authors",
        header: "Authors",
        render: (value) => {
            const authors = value as BookEntity["authors"];

            return authors && authors.length > 0
                ? authors.map(a => <p>author</p>
                    // <ul>
                    //     <li>{a.url?.map((url, index) => <a key={index} href={url.content}>{url.name}</a>)}</li>
                    // </ul>
                )
                : '';
        }
    },
];