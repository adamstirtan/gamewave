import http from '@/http-common'

class DashboardService {
    getGamesByPlatform() {
        return http.get('/v1/dashboard/gamesbyplatform')
    }
}

export default DashboardService