import { createRouter, createWebHistory } from 'vue-router'

const routes = [
  {
    path: '/',
    name: 'Home',
    component: () => import('@/views/Home.vue'),
    meta: {
      layout: 'Public'
    }
  }, {
    path: '/game',
    name: 'Game',
    component: () => import('@/views/Game.vue'),
    meta: {
      layout: 'Public'
    }
  }, {
    path: '/admin/addgame',
    name: 'Add Game',
    component: () => import('@/views/AddGame.vue'),
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
