import { type ReactNode } from "react"
import style from '../../Styles/modal.module.css'


interface ModalFrame {
    children: ReactNode,
    closeModal: (modal: boolean) => void
}

export const ModalFrame = ({ children, closeModal }: ModalFrame) => {


    return (
        <div className={style.modalBackground} onClick={() => closeModal(false)}>
            <div className={style.modal} onClick={(e) => e.stopPropagation()}>
                <header className={style.header}>

                    <button onClick={() => closeModal(false)}> X </button>
                </header>
                {children}
            </div>

        </div>
    )
}