import { createRouter, createWebHistory } from 'vue-router'

const routes = [
    {
        path: '/auth/login',
        name: 'login',
        component: () => import('@/components/LoginForm.vue')
    },
    {
        path: '/auth/logout',
        name: 'logout',
        component: () => import('@/components/Logout.vue')
    },
    {
        path: '/',
        name: 'Dashboard',
        component: () => import('@/components/dashboard/Dashboard.vue'),
        meta: {
            layout: 'App',
            requiresAuth: true
        }
    },
    {
        path: '/company',
        name: 'companies',
        component: () => import('@/components/company/CompanyList.vue'),
        meta: {
            layout: 'App',
            requiresAuth: true
        }
    },
    {
        path: '/company/:id',
        name: 'company-form',
        props: true,
        component: () => import('@/components/company/CompanyForm.vue'),
        meta: {
            layout: 'App',
            requiresAuth: true
        }
    },
    {
        path: '/games',
        name: 'games-list',
        component: () => import('@/components/games/GameList.vue'),
        meta: {
            layout: 'App',
            requiresAuth: true
        }
    },
    {
        path: '/games/:id',
        name: 'games-form',
        props: true,
        component: () => import('@/components/games/GameForm.vue'),
        meta: {
            layout: 'App',
            requiresAuth: true
        }
    },
    {
        path: '/platform',
        name: 'platform-list',
        component: () => import('@/components/platforms/PlatformList.vue'),
        meta: {
            layout: 'App',
            requiresAuth: true
        }
    },
    {
        path: '/platform/:id',
        name: 'platform-form',
        props: true,
        component: () => import('@/components/platforms/PlatformForm.vue'),
        meta: {
            layout: 'App',
            requiresAuth: true
        }
    },
    {
        path: '/users',
        name: 'users-list',
        component: () => import('@/components/users/UsersList.vue'),
        meta: {
            layout: 'App',
            requiresAuth: true
        }
    },
    {
        path: '/users/add',
        name: 'users-add',
        component: () => import('@/components/users/AddUserForm.vue'),
        meta: {
            layout: 'App',
            requiresAuth: true
        }
    },
    {
        path: '/users/:id',
        name: 'users-edit',
        props: true,
        component: () => import('@/components/users/EditUserForm.vue'),
        meta: {
            layout: 'App',
            requiresAuth: true
        }
    }
]

const router = createRouter({
    history: createWebHistory(process.env.BASE_URL),
    routes,
    navigationFallback: {
        rewrite: '/index.html',
        exclude: ['/images/*.{png,jpg,gif}', '/css/*']
      }
})

router.beforeEach((to, from, next) => {
    if (to.meta.requiresAuth) {
        const token = localStorage.getItem('token')
        const isAuthenticated = token != null
        if (isAuthenticated) {
            next()
        } else {
            router.push('/auth/login')
        }
    } else {
        next()
    }
})

export default router
