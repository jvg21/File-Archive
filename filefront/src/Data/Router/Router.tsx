import { Route, Routes } from "react-router-dom"
import { Layout } from "../../UI/Components/Global/layout"
import { ProtectedRoute } from "./protectedRoute"
import { PublicRoute } from "./publicRoute"
import { NotFoundPage } from "../../Pages/notFound.page"
import { BookPage } from "../../Pages/book.page"

export const AppRouter = () => {

    return (
        <Routes>

            <Route element={<PublicRoute />}>
                <Route path='/login' element={<p>login</p>} />
            </Route>

            <Route element={<ProtectedRoute />}>
                <Route element={<Layout />} >
                    <Route path="/" element={<p>adsdsa</p>} />
                    <Route path="/book" element={<BookPage/>} />
                    <Route path="/author" element={<p>author</p>} />
                </Route>
            </Route>

            <Route path="*"  element={<NotFoundPage/>}/>
        </Routes>


    )


} 