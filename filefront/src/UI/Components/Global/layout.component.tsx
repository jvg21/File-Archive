import { useState } from "react"
import { Outlet } from "react-router-dom"
import { Sidebar } from "./sidebar.component"
import style from '../../Styles/layout.module.css'
import { useNotification } from "../../../Data/Context/notification.context"

export const Layout = () => {
    const { showNotification } = useNotification();
    const [isCollapsed, setIsCollapsed] = useState(true);

    return (
        <div className={style.main}>
            {/* {showNotification} */}


            <Sidebar isCollapsed={isCollapsed} setIsCollapsed={setIsCollapsed} />
            <div className={`${style.outlet} ${isCollapsed ? style.outletCollapsed : ''}`}>
                <Outlet />
                <button onClick={() => showNotification('Teste de notificação!', 'success')}>
                    Testar notificação
                </button>
            </div>


        </div>
    )
}