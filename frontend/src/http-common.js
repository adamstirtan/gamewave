import axios from 'axios'

const environmentURLs = {
    development: 'https://localhost:5001/api',
    production: 'https://gamewave-api.azurewebsites.net/api'
}

const environment = process.env.NODE_ENV || 'development'

export default axios.create({
    baseURL: environmentURLs[environment],
    timeout: 5000,
    headers: {
        'Content-Type': 'application/json'
    }
})