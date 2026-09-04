import { useEffect, useState } from "react";
import { Table, type TableActions, } from "../../UI/Components/Table/table.component"
import pageStyle from '../../UI/Styles/pages.module.css'
import { AiFillEdit } from "react-icons/ai";
import { FaRegTrashAlt } from "react-icons/fa";
import type { RequestReturn } from "../../Data/Types/requestReturn";
import { useNotification } from "../../Data/Context/notification.context";
import { ModalFrame } from "../../UI/Components/Global/modal.component";
import type { AuthorEntity } from "../../Data/Types/Entity/author.entity";
import { AuthorDataStore } from "../../Data/Datastore/author.datastore";
import { AuthorColumns } from "./author.columns";

type Entity = AuthorEntity;
const TableColumns = AuthorColumns;

export const AuthorPage = () => {

    /*hooks*/
    const { showNotification } = useNotification()

    /*Datastores*/
    const DataStore = new AuthorDataStore();

    /*book table data*/
    const [tableData, setTableData] = useState<Entity[] | null>(null);
    const [selectedEntity, SetSelectedEntity] = useState<Entity>()

    /**PageStates */
    const [formModal, setFormModal] = useState<boolean>(false);
    const [modalPage, setModalPage] = useState<'edit' | 'delete'>('edit');


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

    return (
        <div className={pageStyle.main}>

            <Table

                tableColumn={TableColumns}
                actions={TableActions}
                tableData={tableData ?? []}
                keyExtractor={(row) => row.id}
                initialPageSize={15}
            />

            {
                formModal &&
                <ModalFrame
                    closeModal={setFormModal}
                >
                    p
                </ModalFrame>
            }

        </div>
    )
}
