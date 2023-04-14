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
    path: '/game',
    name: 'Game',
    component: () => import('@/views/Game.vue'),
    meta: {
      layout: 'Public'
    }
  },
  {
    path: '/admin',
    name: 'Admin Dashboard',
    component: () => import('@/components/admin/Dashboard.vue'),
    meta: {
      layout: 'Admin'
    }
  },
  {
    path: '/admin/company',
    name: 'admin-companies',
    component: () => import('@/components/admin/company/CompanyList.vue'),
    meta: {
      layout: 'Admin'
    }
  },
  {
    path: '/admin/company/:id',
    name: 'admin-company-details',
    props: true,
    component: () => import('@/components/admin/company/CompanyForm.vue'),
    meta: {
      layout: 'Admin'
    }
  },
  {
    path: '/admin/games',
    name: 'Admin Games List',
    component: () => import('@/components/admin/games/GameList.vue'),
    meta: {
      layout: 'Admin'
    }
  },
  {
    path: '/admin/games/add',
    name: 'Admin Games Add',
    component: () => import('@/components/admin/games/AddGame.vue'),
    meta: {
      layout: 'Admin'
    }
  },
  {
    path: '/admin/games/edit',
    name: 'Admin Games Edit',
    component: () => import('@/components/admin/games/EditGame.vue'),
    meta: {
      layout: 'Admin'
    }
  },
  {
    path: '/admin/platform',
    name: 'admin-platform-list',
    component: () => import('@/components/admin/platforms/PlatformList.vue'),
    meta: {
      layout: 'Admin'
    }
  },
  {
    path: '/admin/platform/:id',
    name: 'admin-platform-details',
    props: true,
    component: () => import('@/components/admin/platforms/PlatformForm.vue'),
    meta: {
      layout: 'Admin'
    }
  },
  {
    path: '/admin/users',
    name: 'admin-users-list',
    component: () => import('@/components/admin/users/UsersList.vue'),
    meta: {
      layout: 'Admin'
    }
  }
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
