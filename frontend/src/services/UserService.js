import http from '@/http-common'

class UserService {
    search(params) {
        let query = `sort=${params.sort}&ascending=${params.ascending}&paged=${params.paged}`

        if (params.paged) {
            query += `&page=${params.page}&pageSize=${params.pageSize}`
        }

        return http.get(`/v1/user?${query}`)
    }

    getAll() {
        return http.get('/v1/user?sort=name')
    }

    get(id) {
        return http.get(`/v1/user/${id}`)
    }

    create(dto) {
        return http.post('/v1/user', dto)
    }

    update(id, dto) {
        return http.put(`/v1/user/${id}`, dto)
    }

    delete(id) {
        return http.delete(`/v1/user/${id}`)
    }
}

export default UserService