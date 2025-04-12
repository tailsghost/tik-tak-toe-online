import axios, { AxiosError, AxiosResponse } from "axios";
import { HOST_API_KEY } from "@/config/GlobalAPIConfig";

const axiosInstance = axios.create({
    baseURL: HOST_API_KEY,
});

axiosInstance.interceptors.response.use(
    (response : AxiosResponse) => response,
    (error: AxiosError) =>
    {
        if(error.response) {
            return Promise.reject(error.response);
        }
        else if(error.request) {
            return Promise.reject(error.request);
        }
        else {
            return Promise.reject(error.message)
        }
    }
);

export default axiosInstance;