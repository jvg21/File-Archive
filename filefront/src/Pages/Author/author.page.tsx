import { useNotification } from "../../Data/Context/notification.context"

export const AuthorPage = () => {
    /*hooks*/
    const { showNotification } = useNotification()

    
    return (
        <button onClick={() => showNotification('Teste de notificação!', 'success')}>
            Testar notificação
        </button>
    )
}