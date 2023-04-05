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
    path: '/admin/companies',
    name: 'Admin Companies List',
    component: () => import('@/components/admin/companies/CompanyList.vue'),
    meta: {
      layout: 'Admin'
    }
  },
  {
    path: '/admin/companies/add',
    name: 'Admin Companies Add',
    component: () => import('@/components/admin/companies/AddCompany.vue'),
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
    path: '/admin/platforms',
    name: 'Admin Platform List',
    component: () => import('@/components/admin/platforms/PlatformList.vue'),
    meta: {
      layout: 'Admin'
    }
  },
  {
    path: '/admin/platforms/add',
    name: 'Admin Platforms Add',
    component: () => import('@/components/admin/platforms/PlatformList.vue'),
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
