
import style from '../../UI/Styles/table.module.css'
import type { BookEntity } from '../../Data/Types/Entity/book.entity';
import type { TableColumns } from '../../UI/Components/Table/table.component';

import type { AuthorEntity } from '../../Data/Types/Entity/author.entity';


export const AuthorColumns: TableColumns<AuthorEntity>[] = [
    { key: 'id', header: 'Id' },
    { key: "name", header: "Name" },
    {
        key: "books", header: "Books",
        render: (value) => { 
            const authors = value as BookEntity["authors"];
            return authors.length || 0;
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
    }
]

