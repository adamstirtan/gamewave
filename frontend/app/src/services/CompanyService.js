import http from '@/http-common'

class CompanyService {
    search(name) {
        return http.get(`/v1/company?name=${name}`)
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
        return http.post(`/v1/company/${id}`, dto)
    }

    delete(id) {
        return http.delete(`/v1/company/${id}`)
    }
}

export default new CompanyService()