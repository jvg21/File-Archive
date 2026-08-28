import type { BookEntity } from "../Data/Types/Entity/book.entity";

import { useEffect, useState } from "react";
import { BookDataStore } from "../Data/Datastore/book.datastore"



export const BookPage = () => {

    const bookDataStore = new BookDataStore();

    const [bookData, setBookData] = useState<BookEntity[]>();

    const getBookData = async () => {
        const request = await bookDataStore.getAll();
        return request.data || []
    }
    useEffect(() => {

        const getData = async () => setBookData(await getBookData());
        getData();
    }, [])
    
   
    return (
        <p>bookPage</p>
    )
}