import type { BookEntity } from "../Data/Types/Entity/book.entity";
import { useEffect, useState } from "react";
import { BookDataStore } from "../Data/Datastore/book.datastore"
import { Table,} from "../UI/Components/Table/table.component"
import pageStyle from '../UI/Styles/pages.module.css'
import { BookColums } from "../UI/Components/Table/TableColumnsProps/book.columns";


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
                tableColumn={BookColums}
                tableData={bookData ?? []}
                keyExtractor={(row) => row.id}
                initialPageSize={5}
            />
        </div>
    )
}
