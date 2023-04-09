import http from '@/http-common'

class CompanyService {
    search(params) {
        let query = `sort=${params.sort}&ascending=${params.ascending}&paged=${params.paged}`

        if (params.paged) {
            query += `&page=${params.page}&pageSize=${params.pageSize}`
        }

        return http.get(`/v1/company?${query}`)
    } 

    getAll() {
        return http.get('/v1/company?sort=name')
    }

    get(id) {
        return http.get(`/v1/company/${id}`)
    }

    create(dto) {
        return http.post('/v1/company/', dto)
    }

    update(id, dto) {
        return http.put(`/v1/company/${id}`, dto)
    }

    delete(id) {
        return http.delete(`/v1/company/${id}`)
    }
}

export default CompanyService