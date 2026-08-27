import { Outlet } from "react-router-dom"
import { Sidebar } from "./sidebar"
import style from '../../Styles/layout.module.css'

export const Layout = () => {
    return (
        <div className={style.main}>
            <Sidebar />
            <div>
                <Outlet />
            </div>
        </div>

    )
}