import type { ModalFlow } from "../../Data/Types/modalFlow"
import type { BookEntity } from '../../Data/Types/Entity/book.entity'
import { getAllReadingStatus } from "../../Data/Enums/readingStatus.enum";
import { getAllWritingStatus } from "../../Data/Enums/writingStatus.enum";
import style from '../../UI/Styles/modal.module.css'
import { useState } from "react";
import type { UrlEntity } from "../../Data/Types/Entity/url.entity";


interface BookFormProps {

    flow: ModalFlow,
    onSubmit: () => void,
    initialEntity: BookEntity
}


export const BookForm = (props: BookFormProps) => {

    const { flow, onSubmit, initialEntity } = props;

    const [entity, setEntity] = useState<BookEntity>(initialEntity)
    const [ulrField, setUrlField] = useState<UrlEntity>();


    function handdleAddUrl() {
        if (!ulrField?.name || !ulrField.content) return;

        const urls = entity.urls || [];
        urls.push(ulrField);
        setEntity((prev) => ({ ...prev, urls }));
    }

    return (
        <>
            <h3>
                Book
            </h3>
            <form onSubmit={() => onSubmit()} className={style.modalForm}>

                {flow !== 'create' &&
                    <div className={style.field}>
                        <label>Id: </label>
                        <input type='text' value={entity.id ?? -1} disabled />
                    </div>
                }

                <div className={style.field}>
                    <label>Name: </label>
                    <input type='text' value={entity?.name ?? ""}
                        onChange={(e) => { setEntity((prev) => ({ ...prev, name: e.target.value })) }}
                    />
                </div>

                <div className={style.field}>
                    <label>Summary: </label>
                    <input type='text' value={entity?.summary ?? ""} />
                </div>

                <div className={style.field}>
                    <label>Url: </label>
                    <input type='text' value={ulrField?.name ?? ""} placeholder="name"
                        onChange={(e) => { setUrlField((prev) => ({ name: e.target.value, content: prev?.content ?? "" })) }}
                    />
                    <input type='text' value={ulrField?.content ?? ""} placeholder="content"
                        onChange={(e) => { setUrlField((prev) => ({ content: e.target.value, name: prev?.content ?? "" })) }}
                    />

                    <button type="button" onClick={handdleAddUrl}>Add Url</button>
                </div>

                {
                    entity.urls && entity.urls.length > 0 &&
                    entity.urls.map((url) =>
                        <p>{url.name} - {url.content}</p>
                    )
                }

                <div className={style.field}>
                    <label>Current Chapter: </label>
                    <input type='text' value={entity?.currentChapter ?? ""} />
                </div>

                <div className={style.field}>
                    <label>Total Chapters: </label>
                    <input type='text' value={entity?.totalChapters ?? ""} />
                </div>

                <div className={style.field}>
                    <label>Writing Status: </label>

                    <select value={entity?.readingStatus ?? ""}>
                        <option value="" disabled>Writing Status.....</option>
                        {
                            getAllWritingStatus().map((status) =>
                                <option value={status.id}>
                                    {status.name}
                                </option>
                            )
                        }
                    </select>
                </div>

                <div className={style.field}>
                    <label>Reading Status: </label>
                    <select value={entity?.readingStatus ?? ""}>
                        <option value="" disabled>Writing Status.....</option>
                        {
                            getAllReadingStatus().map((status) =>
                                <option value={status.id}>
                                    {status.name}
                                </option>
                            )
                        }
                    </select>
                </div>

                <div className={style.field}>
                    <label>Words: </label>
                    <input type='text' value={entity?.words ?? ""} />
                </div>

                <div className={style.field}>
                    <label>Rating: </label>
                    <input type='text' value={entity?.rating ?? ""} />
                </div>

            </form>
        </>
    )



}