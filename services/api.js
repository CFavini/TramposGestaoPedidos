import axios from 'axios';

const api = axios.create({
    baseURL: 'https://localhost:7022/api', // Altere para o endereço da sua API
});

export default api;
