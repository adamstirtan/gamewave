import http from '@/http-common'

class GameService {
    search(params) {
        let query = `sort=${params.sort}&ascending=${params.ascending}&paged=${params.paged}`

        if (params.paged) {
            query += `&page=${params.page}&pageSize=${params.pageSize}`
        }

        return http.get(`/v1/game?${query}`)
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

export default GameService