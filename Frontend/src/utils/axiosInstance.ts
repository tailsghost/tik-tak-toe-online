import axios, { AxiosError, AxiosResponse } from "axios";
import https from "https";
import { HOST_API_KEY } from "@/config/GlobalAPIConfig";

const agent = new https.Agent({
  rejectUnauthorized:false
})

const axiosInstance = axios.create({
  baseURL: HOST_API_KEY,
  httpAgent:agent
});

axiosInstance.interceptors.response.use(
  (response:AxiosResponse) => response,
  (error:AxiosError) => {
    if(error.response) {
      return Promise.reject({
        status:error.response.status,
        data:error.response.data
      })
    }
    return Promise.reject({message:error.message})
  }
)

export default axiosInstance;
