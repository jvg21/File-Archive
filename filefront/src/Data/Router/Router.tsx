import { Route, Routes } from "react-router-dom"
import { Layout } from "../../UI/Components/Global/layout"
import { ProtectedRoute } from "./protectedRoute"
import { PublicRoute } from "./publicRoute"

export const AppRouter = () => {

    return (
        <Routes>

            <Route element={<PublicRoute />}>
                <Route path='/login' element={<p>login</p>} />
            </Route>

            <Route element={<ProtectedRoute />}>
                <Route path='/' element={<Layout />} />
            </Route>
        </Routes>


    )


}