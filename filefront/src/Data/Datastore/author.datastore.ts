import { Config } from "../../Config/config";
import { RequestReturn } from "../Types/requestReturn";

export class AuthorDataStore {

    private readonly URL = `${Config.apiHost}/author`

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

            response.status = request.status;
            if (response.status !== 200) {

                const data = await request.json()
                response.message = data.message || "Error retrieving data";
                return response;
            };

            response.data = [...await request.json()];
            response.message = "Data Retrived"

        } catch (e) {

            response.message = "Error retrieving data";
        }
        return response;

    }

    async getById(id: number): Promise<RequestReturn> {
        const response = new RequestReturn();

        try {
            const request = await fetch(`${this.URL}/${id}`, {
                method: 'GET',
                headers: {
                    'Content-Type': 'application/json'
                },
                // credentials: 'include'
            })

            response.status = request.status;
            if (response.status !== 200) {

                const data = await request.json()
                response.message = data.message || "Error retrieving data";
                return response;
            };

            response.data = [...await request.json()];
            response.message = "Data Retrived"

        } catch (e) {

            response.message = "Error retrieving data";
        }
        return response;
    }

}