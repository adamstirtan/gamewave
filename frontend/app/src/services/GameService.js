import http from '@/http-common'

class GameService {
    search(name) {
        return http.get(`/v1/game?name=${name}`)
    } 

    getAll() {
        return http.get('/v1/game')
    }

    get(id) {
        return http.get(`/v1/game/${id}`)
    }

    create(dto) {
        return http.post('/v1/game/', dto)
    }

    update(id, dto) {
        return http.post(`/v1/game/${id}`, dto)
    }

    delete(id) {
        return http.delete(`/v1/game/${id}`)
    }
}

export default new GameService()