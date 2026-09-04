import type { ModalFlow } from "../../Data/Types/modalFlow"
import style from '../../UI/Styles/modal.module.css'
import { useState } from "react";
import type { UrlEntity } from "../../Data/Types/Entity/url.entity";
import type { AuthorEntity } from "../../Data/Types/Entity/author.entity";


interface AuthorFormProps {

    flow: ModalFlow,
    entity: AuthorEntity,
    setEntity: React.Dispatch<React.SetStateAction<AuthorEntity>>,
    onSubmit: () => void,

}


export const AuthorForm = (props: AuthorFormProps) => {

    const { flow, onSubmit, entity, setEntity } = props;

    const [ulrField, setUrlField] = useState<Partial<UrlEntity>>();

    function handdleAddUrl() {
        if (!ulrField?.name || !ulrField.content) return;

        const urls = entity.urls || [];
        urls.push(ulrField);
        setEntity((prev) => ({ ...prev, urls }));
    }

    return (
        <>
            <h3>
                Author
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
                    <label>Url: </label>
                    <input type='text' value={ulrField?.name ?? ""} placeholder="name"

                        onChange={(e) => {
                            setUrlField((prev) => ({ name: e.target.value, content: prev?.content ?? "" }));
                        }}
                    />
                    <input type='text' value={ulrField?.content ?? ""} placeholder="content"
                        onChange={(e) => {
                            setUrlField((prev) => ({ name: prev?.name ?? "", content: e.target.value }))
                        }}
                    />

                    <button type="button" onClick={() => { handdleAddUrl(); setUrlField({ content: "", name: "" }) }}>Add Url</button>
                </div>

                {
                    entity.urls && entity.urls.length > 0 &&
                    entity.urls.map((url, index) =>
                        <div key={index}>

                            <p>{url.name} - {url.content}</p>
                            <button onClick={() => setEntity((prev) => ({ ...prev, urls: entity.urls?.filter((_, i) => i !== index) }))}> X </button>
                        </div>
                    )
                }


                <button type="button" onClick={() => onSubmit()}>Submit</button>

            </form >
        </>
    )



}