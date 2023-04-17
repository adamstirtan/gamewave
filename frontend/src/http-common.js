import axios from 'axios'

const environmentURLs = {
    development: 'http://localhost:57394/api',
    production: 'https://gamewave-api.azurewebsites.net/api'
}

const environment = process.env.NODE_ENV || 'development'
const token = localStorage.getItem('token')

if (token) {
  axios.defaults.headers.common['Authorization'] = `Bearer ${token}`;
}

export default axios.create({
    baseURL: environmentURLs[environment],
    timeout: 5000,
    headers: {
        'Content-Type': 'application/json'
    }
})