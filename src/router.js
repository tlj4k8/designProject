import Vue from 'vue';
import Router from 'vue-router';
import Home from './views/Home';
import ClientPage from './views/ClientPage';
import Dashboard from './views/Dashboard';
import ChefPage from './views/ChefPage';
import MenuPage from './views/MenuPage';

Vue.use(Router);

export default new Router({
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home
    },
    {
      path: '/client',
      name: 'ClientPage',
      component: ClientPage
    },
    {
      path: '/dash',
      name: 'Dashboard',
      component: Dashboard
    },
    {
      path: '/chef',
      name: 'ChefPage',
      component: ChefPage
    },
    {
      path: '/menu',
      name: 'MenuPage',
      component: MenuPage
    }
  ]
})
