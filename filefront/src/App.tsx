import { BrowserRouter } from "react-router-dom"
import { AuthProvider } from "./Data/Context/auth.context"
import { AppRouter } from "./Data/Router/Router"

function App() {

  return (

    <BrowserRouter>
      <AuthProvider>

        <AppRouter />

      </AuthProvider>
    </BrowserRouter>
  )
}

export default App
