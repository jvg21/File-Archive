import { Config } from "../../config/config";
import { RequestReturn } from "../Types/RequestReturn";

export class BookDataStore {

    private readonly URL = `${Config.apiHost}/book`

    async getAll(): Promise<RequestReturn> {
        const response = new RequestReturn();
        try {
            const request = await fetch(`${this.URL}`, {
                method: 'GET',
                headers: {
                    'Content-Type': 'application/json'
                },
                // credentials: 'include'
            })

            response.status = request.status

            if (response.status !== 200) {
                response.message
                return response;
            };
            response.data = await request.json();

            
            response.message = "Data Retrived"
        } catch (e) {
            console.log("erro")
        }

        return response;

    }

    //  async getAll(): Promise<RequestReturn> {
    //     const response = new RequestReturn();
    //     try {
    //         const request = await fetch(`${this.URL}`,{
    //             method:'GET',
    //             headers:{
    //                 'Content-Type':'application/json'
    //             },
    //             credentials:'include'
    //         },
    //     )

    //     } catch (e) {

    //     } finally {
    //         return response;
    //     }

    // }
}