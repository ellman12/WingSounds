import axios from "axios";

const axiosInstance = axios.create({
    baseURL: `${window.location.origin}:5000/api`,
    headers: {"Content-Type": "application/json"}
});

export default axiosInstance;
