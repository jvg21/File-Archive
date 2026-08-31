import type { BookEntity } from "../../Data/Types/Entity/book.entity";
import { useEffect, useState } from "react";
import { BookDataStore } from "../../Data/Datastore/book.datastore"
import { Table, type TableActions, } from "../../UI/Components/Table/table.component"
import pageStyle from '../../UI/Styles/pages.module.css'
import { AiFillEdit } from "react-icons/ai";
import { FaRegTrashAlt } from "react-icons/fa";
import { BookColums } from "./book.columns";
import type { RequestReturn } from "../../Data/Types/RequestReturn";
import { useNotification } from "../../Data/Context/notification.context";


export const BookPage = () => {

    /**/

    const { showNotification } = useNotification()
    /*Datastores*/
    const bookDataStore = new BookDataStore();

    /*book table data*/
    const [bookData, setBookData] = useState<BookEntity[] | null>(null);
    const [selectedBook, SetSelectedBook] = useState<BookEntity>()

    /**PageStates */
    const [formModal, setFormModal] = useState<boolean>(false);
    const [_, setModalPage] = useState<'edit' | 'delete'>('edit');




    /**CRUD FUNCIOTIONS */
    const getBookData = async () => {
        const request: RequestReturn = await bookDataStore.getAll();

        if (request.status !== 200) {
            showNotification(request.message, 'failure')
            return
        }
        setBookData(request.data as BookEntity[])
    };



    useEffect(() => {
        getBookData();

    }, [])


    const BookTableActions: TableActions<BookEntity>[] = [
        { key: 'update', header: "Update", action: (row) => { SetSelectedBook(row); setModalPage('edit'); setFormModal(true) }, icon: AiFillEdit },
        { key: 'delete', header: "Delete", action: (row) => { SetSelectedBook(row); setModalPage('delete'); setFormModal(true) }, icon: FaRegTrashAlt }
    ]

    return (
        <div className={pageStyle.main}>

            <Table

                tableColumn={BookColums}
                actions={BookTableActions}
                tableData={bookData ?? []}
                keyExtractor={(row) => row.id}
                initialPageSize={15}
            />

            {
                formModal && <p>edit</p>
            }

        </div>
    )
}
