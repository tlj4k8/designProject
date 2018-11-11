import Vue from 'vue';
import Router from 'vue-router';
import Home from './views/Home';
import Dashboard from './views/Dashboard';
import ProfilePage from './views/ProfilePage';
import ClientPage from './views/ClientPage';
import MenuPage from './views/MenuPage';
import ClientMenu from './views/ClientMenu';
import MenuEdit from './views/MenuEdit.vue';
import MenuDash from './views/MenuDash.vue';
import ClientDash from './views/ClientDash.vue';
import ClientNew from './views/ClientNew.vue';
import Employee from './views/Employee.vue';
import EmployeeDash from './views/EmployeeDash.vue';
import EmployeeNew from './views/EmployeeNew.vue';
import SchedulePage from './views/SchedulePage.vue';
import ScheduleNew from './views/ScheduleNew.vue';
import ScheduleDash from './views/ScheduleDash.vue';

Vue.use(Router);

const router = new Router({
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home,
      meta: { 
        requiresAuth: true
      }
    },
    {
      path: '/scheduleNew',
      name: 'scheduleNew',
      component: ScheduleNew,
      meta: { 
        requiresAuth: true
      }
    },
    {
      path: '/scheduleDash',
      name: 'scheduleDash',
      component: ScheduleDash,
      meta: { 
        requiresAuth: true
      }
    },
    {
      path: '/clientDash',
      name: 'clientDash',
      component: ClientDash,
      meta: { 
        requiresAuth: true
      }
    },
    {
      path: '/newclient',
      name: 'clientNew',
      component: ClientNew,
      meta: { 
        requiresAuth: true
      }
    },
    {
      path: '/clientMenu',
      name: 'clientMenu',
      component: ClientMenu,
      meta: { 
        requiresAuth: true
      }
    },
    {
      path: '/clientPage',
      name: 'clientPage',
      component: ClientPage,
      meta: { 
        requiresAuth: true
      }
    },
    {
      path: '/menuDash',
      name: 'menuDash',
      component: MenuDash,
      meta: { 
        requiresAuth: true
      }
    },
    {
      path: '/menu',
      name: 'MenuPage',
      component: MenuPage,
      meta: { 
        requiresAuth: true
      }
    },
    {
      path: '/menuEdit',
      name: 'menuEdit',
      component: MenuEdit,
      meta: { 
        requiresAuth: true
      }
    },
    {
      path: '/availability',
      name: 'Availability',
      component: SchedulePage,
      meta: { 
        requiresAuth: true
      }
    },
    {
      path: '/dash',
      name: 'Dashboard',
      component: Dashboard,
      meta: { 
        requiresAuth: true
      }
    },
    {
    path: '/employee',
    name: 'Employee',
    component: Employee,
    meta: { 
      requiresAuth: true
    }
    },
    {
      path: '/employeeNew',
      name: 'EmployeeNew',
      component: EmployeeNew,
      meta: { 
        requiresAuth: true
      }
    },
    {
      path: '/profile',
      name: 'ProfilePage',
      component: ProfilePage,
      meta: { 
        requiresAuth: true
      }
    },
    {
      path: '/employeeDash',
      name: 'EmployeeDash',
      component: EmployeeDash,
      meta: { 
        requiresAuth: true
      }
    }
  ]
})

router.beforeEach((to, from, next) => {
  // redirect to login page if not logged in and trying to access a restricted page
  const publicPages = ['/'];
  const authRequired = !publicPages.includes(to.path);
  const loggedIn = localStorage.getItem('t');

  if (authRequired && !loggedIn) {
    return next('/');
  }

  next();
})

export default router
