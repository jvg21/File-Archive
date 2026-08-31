import { useEffect, useState } from 'react'
import style from '../../Styles/table.module.css'
import { TablePagination } from './pagination.component'

export type TableColumns<T> = {
    key: keyof T,
    header: string,
    render?: (value: T[keyof T], row: T) => React.ReactNode
    className?: string
}

export type TableProps<T> = {
    tableData: T[],
    tableColumn: TableColumns<T>[],
    emptyMessage?: string,
    keyExtractor?: (row: T) => string | number,
    initialPageSize: number
}

export function Table<T extends Object>({
    tableData,
    tableColumn,
    keyExtractor,
    emptyMessage = "No Data",
    initialPageSize = 10

}: TableProps<T>) {



    //***PAGINATION*** */
    const [currentPage, setCurrentPage] = useState<number>(1)
    const [pageSize,setPageSize] = useState(initialPageSize)

    const startIndex = (currentPage - 1) * pageSize
    const totalPages = Math.ceil(tableData.length / pageSize)

    const paginatedData = tableData.slice(startIndex, startIndex + pageSize)

    useEffect(() => {
        setCurrentPage(1)
    }, [tableData])


    {/**NO DATA*/}
    if (tableData.length <= 0) {
        return <div className={style.empty}>{emptyMessage}</div>
    }

    return (
        <div className={style.tableWrapper}>

            { /***PAGINATION**** */}
            <TablePagination
                setPageSize={setPageSize}
                currentPage={currentPage}
                totalPages={totalPages}
                setCurrentPage={setCurrentPage}
            />

            {/******TABLE***** */}
            <table className={style.table}>
                <thead >
                    <tr>
                        {tableColumn.map((col, index) =>
                            <th key={index} className={col.className ? style[col.className] : ''}>{col.header}</th>
                        )}
                    </tr>

                </thead>
                <tbody>
                    {
                        paginatedData.map((row, index) =>
                            <tr key={
                                keyExtractor ? keyExtractor(row) : index

                            }>
                                {
                                    tableColumn.map((col) =>

                                        <td key={String(col.key)} className={col.className ? style[col.className] : ''}>
                                            {
                                                col.render ?
                                                    col.render(row[col.key], row)
                                                    :
                                                    String(row[col.key] ?? '-')
                                            }

                                        </td>
                                    )
                                }

                            </tr>
                        )
                    }
                </tbody>

            </table>


        </div>
    )
}