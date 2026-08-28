import style from '../../Styles/table.module.css'

export type TableColumn<T> = {
    key: keyof T
    header: string
    render?: (value: T[keyof T], row: T) => React.ReactNode
    width?: string
}

type TableProps<T> = {
    data: T[]
    columns: TableColumn<T>[]
    keyExtractor?: (row: T) => string | number
    emptyMessage?: string
}

export function Table<T extends object>({
    data,
    columns,
    keyExtractor,
    emptyMessage = "No Data"
}: TableProps<T>) {

    if (!data || data.length === 0) {
        return (
            <div className={style.empty}>
                {emptyMessage}
            </div>
        )
    }

    return (
        <div className={style.tableWrapper}>
            <table className={style.table}>
                <thead>
                    <tr>
                        {columns.map((col) => (
                            <th
                                key={String(col.key)}
                                style={{ width: col.width }}
                            >
                                {col.header}
                            </th>
                        ))}
                    </tr>
                </thead>

                <tbody>
                    {data.map((row, index) => (
                        <tr
                            key={
                                keyExtractor
                                    ? keyExtractor(row)
                                    : index
                            }
                        >
                            {columns.map((col) => (
                                <td key={String(col.key)}>
                                    {col.render
                                        ? col.render(row[col.key], row)
                                        : String(row[col.key] ?? '-')
                                    }
                                </td>
                            ))}
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    )
}