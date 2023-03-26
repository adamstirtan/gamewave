import http from '@/http-common'

class GameService {
    search(name) {
        return http.get(`/game?name=${name}`)
    } 

    getAll() {
        return http.get('/game')
    }

    get(id) {
        return http.get(`/game/${id}`)
    }

    create(dto) {
        return http.post('/game/', dto)
    }

    update(id, dto) {
        return http.post(`/game/${id}`, dto)
    }

    delete(id) {
        return http.delete(`/game/${id}`)
    }
}

export default new GameService()