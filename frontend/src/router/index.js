import { createRouter, createWebHistory } from 'vue-router'

const routes = [
    {
        path: '/',
        name: 'Home',
        component: () => import('@/views/Home.vue'),
        meta: {
            layout: 'Public'
        }
    },
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
        path: '/admin',
        name: 'Admin Dashboard',
        component: () => import('@/components/admin/Dashboard.vue'),
        meta: {
            layout: 'Admin',
            requiresAuth: true
        }
    },
    {
        path: '/admin/company',
        name: 'admin-companies',
        component: () => import('@/components/admin/company/CompanyList.vue'),
        meta: {
            layout: 'Admin',
            requiresAuth: true
        }
    },
    {
        path: '/admin/company/:id',
        name: 'company-form',
        props: true,
        component: () => import('@/components/admin/company/CompanyForm.vue'),
        meta: {
            layout: 'Admin',
            requiresAuth: true
        }
    },
    {
        path: '/admin/games',
        name: 'games-list',
        component: () => import('@/components/admin/games/GameList.vue'),
        meta: {
            layout: 'Admin',
            requiresAuth: true
        }
    },
    {
        path: '/admin/games/:id',
        name: 'games-form',
        props: true,
        component: () => import('@/components/admin/games/GameForm.vue'),
        meta: {
            layout: 'Admin',
            requiresAuth: true
        }
    },
    {
        path: '/admin/platform',
        name: 'platform-list',
        component: () => import('@/components/admin/platforms/PlatformList.vue'),
        meta: {
            layout: 'Admin',
            requiresAuth: true
        }
    },
    {
        path: '/admin/platform/:id',
        name: 'platform-form',
        props: true,
        component: () => import('@/components/admin/platforms/PlatformForm.vue'),
        meta: {
            layout: 'Admin',
            requiresAuth: true
        }
    },
    {
        path: '/users',
        name: 'users-list',
        component: () => import('@/components/users/UsersList.vue'),
        meta: {
            layout: 'Admin',
            requiresAuth: true
        }
    },
    {
        path: '/users/add',
        name: 'users-add',
        component: () => import('@/components/users/AddUserForm.vue'),
        meta: {
            layout: 'Admin',
            requiresAuth: true
        }
    },
    {
        path: '/users/:id',
        name: 'users-edit',
        props: true,
        component: () => import('@/components/users/EditUserForm.vue'),
        meta: {
            layout: 'Admin',
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
