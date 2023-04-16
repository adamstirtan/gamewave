import http from '@/http-common'

class UserService {
    search(params) {
        let query = `sort=${params.sort}&ascending=${params.ascending}&paged=${params.paged}`

        if (params.paged) {
            query += `&page=${params.page}&pageSize=${params.pageSize}`
        }

        return http.get(`/v1/users?${query}`)
    }

    getAll() {
        return http.get('/v1/users?sort=name')
    }

    get(id) {
        return http.get(`/v1/users/${id}`)
    }

    create(dto) {
        return http.post('/v1/users', dto)
    }

    update(id, dto) {
        return http.put(`/v1/users/${id}`, dto)
    }

    delete(id) {
        return http.delete(`/v1/users/${id}`)
    }
}

export default UserService