import { useEffect, useMemo, useState } from "react";
import { Table, type TableActions, } from "../../UI/Components/Table/table.component"
import pageStyle from '../../UI/Styles/pages.module.css'
import { AiFillEdit } from "react-icons/ai";
import { FaRegTrashAlt } from "react-icons/fa";
import type { RequestReturn } from "../../Data/Types/RequestReturn";
import { useNotification } from "../../Data/Context/notification.context";
import { ModalFrame } from "../../UI/Components/Global/modal.component";
import type { BookEntity } from "../../Data/Types/Entity/book.entity";
import { BookColumns } from "./book.columns";
import { BookDataStore } from "../../Data/Datastore/book.datastore";
import type { ModalFlow } from "../../Data/Types/modalFlow";
import { BookForm } from "./book.form";
import { generateEmptyBook } from "./book.functions";

type Entity = BookEntity;
const TableColumns = BookColumns;

export const BookPage = () => {

    /*hooks*/
    const { showNotification } = useNotification()

    /*Datastores*/
    const DataStore = new BookDataStore();

    /*book table data*/
    const [tableData, setTableData] = useState<Entity[] | null>(null);
    const [selectedEntity, SetSelectedEntity] = useState<Entity>(generateEmptyBook())

    /**PageStates */
    const [formModal, setFormModal] = useState<boolean>(false);
    const [modalPage, setModalPage] = useState<ModalFlow>('edit');


    /**CRUD FUNCIOTIONS */
    const getBookData = async () => {
        const request: RequestReturn = await DataStore.getAll();

        if (request.status !== 200) {
            showNotification(request.message, 'failure')
            return
        }
        setTableData(request.data as Entity[])
    };


    useEffect(() => {
        getBookData();

    }, [])

    const TableActions: TableActions<Entity>[] = [
        { key: 'update', header: "Update", action: (row) => { SetSelectedEntity(row); setModalPage('edit'); setFormModal(true) }, icon: AiFillEdit },
        { key: 'delete', header: "Delete", action: (row) => { SetSelectedEntity(row); setModalPage('delete'); setFormModal(true) }, icon: FaRegTrashAlt }
    ]

    const TableMemo = useMemo(() =>
        <Table
            tableColumn={TableColumns}
            actions={TableActions}
            tableData={tableData ?? []}
            onRowClick={SetSelectedEntity}
            keyExtractor={(row) => row.id}
            initialPageSize={15}
        />, [tableData])

    return (
        <div className={pageStyle.main}>

            <button type="button" className={pageStyle.button} onClick={() => { setModalPage('create'); SetSelectedEntity(generateEmptyBook()); setFormModal(true) }}>Add +</button>

            {/* /***LOAD THE TABLE COMPONENT* */}
            {TableMemo}

            {
                formModal &&
                <ModalFrame
                    closeModal={setFormModal}
                >
                    <BookForm
                        initialEntity={selectedEntity}
                        flow={modalPage}
                        onSubmit={() => console.log(modalPage)}

                    />
                </ModalFrame>
            }

        </div>
    )
}
