import http from '@/http-common'

class PlatformService {
    search(params) {
        let query = `sort=${params.sort}&ascending=${params.ascending}&paged=${params.paged}`

        if (params.paged) {
            query += `&page=${params.page}&pageSize=${params.pageSize}`
        }

        return http.get(`/v1/platform?${query}`)
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
        return http.put(`/v1/platform/${id}`, dto)
    }

    delete(id) {
        return http.delete(`/v1/platform/${id}`)
    }
}

export default PlatformService