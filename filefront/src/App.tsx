import { BrowserRouter } from "react-router-dom"
import { AuthProvider } from "./Data/Context/auth.context"
import { AppRouter } from "./Data/Router/Router"
import { NotificationProvider } from "./Data/Context/notification.context"

function App() {

  return (

    <BrowserRouter>
      <AuthProvider>
        <NotificationProvider>

          <AppRouter />

        </NotificationProvider>


      </AuthProvider>
    </BrowserRouter>
  )
}

export default App
