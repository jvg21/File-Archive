import style from '../../Styles/table.module.css'

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

}

export function Table<T extends Object>({
    tableData,
    tableColumn,
    keyExtractor,
    emptyMessage = "No Data",

}: TableProps<T>) {

    if (tableData.length <= 0) {
        return <div className={style.empty}>{emptyMessage}</div>
    }

    

    return (
        <div className={style.tableWrapper}>

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
                        tableData.map((row, index) =>
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