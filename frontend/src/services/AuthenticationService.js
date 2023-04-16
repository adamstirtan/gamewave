import http from '@/http-common'

class AuthenticationService {
    login(dto) {
        return http.post('/v1/auth/login', dto)
    }

    logout() {
        localStorage.removeItem('token')
    }
}

export default AuthenticationService