import http from '@/http-common'

class PlatformService {
    search(name) {
        return http.get(`/v1/platform?name=${name}`)
    } 

    getAll() {
        return http.get('/v1/platform?sort=name')
    }

    get(id) {
        return http.get(`/v1/platform/${id}`)
    }

    create(dto) {
        return http.post('/v1/platform/', dto)
    }

    update(id, dto) {
        return http.post(`/v1/platform/${id}`, dto)
    }

    delete(id) {
        return http.delete(`/v1/platform/${id}`)
    }
}

export default new PlatformService()