import http from '@/http-common'

class PlatformService {
    search(name) {
        return http.get(`/platform?name=${name}`)
    } 

    getAll() {
        return http.get('/v1/platform')
    }

    get(id) {
        return http.get(`/platform/${id}`)
    }

    create(dto) {
        return http.post('/platform/', dto)
    }

    update(id, dto) {
        return http.post(`/platform/${id}`, dto)
    }

    delete(id) {
        return http.delete(`/platform/${id}`)
    }
}

export default new PlatformService()