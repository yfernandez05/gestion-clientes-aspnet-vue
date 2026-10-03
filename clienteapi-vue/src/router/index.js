import Vue from 'vue'
import VueRouter from 'vue-router'
import HomeView from '../views/HomeView.vue'
import Index from './utils.js'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'home',
    component: HomeView
  },
  {
    path: `/cliente`,
    name: 'cliente',
    component: require('../components/clientes/ClienteIndex').default
  },
  {
    path: `/cliente/registrar`,
    name: 'cliente.registrar',
    component: require('../components/clientes/ClienteCreate').default
  },
  {
    path: `/cliente/editar/:id`,
    name: 'cliente.editar',
    component: require('../components/clientes/ClienteEdit').default
  },

]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes,
  Index
})

export default router
