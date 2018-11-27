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
import HelpManuel from './HelpManuel.vue';
import Decoded from 'jwt-decode';

Vue.use(Router);

const router = new Router({
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home
    },
    {
      path: '/help',
      name: 'help',
      component: HelpManuel
    },
    {
      path: '/scheduleNew',
      name: 'scheduleNew',
      component: ScheduleNew,
      meta: { 
        requiresAuth: true, adminAuth: true, chefAuth: false, menuAuth: false
      }
    },
    {
      path: '/scheduleDash',
      name: 'scheduleDash',
      component: ScheduleDash,
      meta: { 
        requiresAuth: true, adminAuth: true, chefAuth: true, menuAuth: false
      }
    },
    {
      path: '/clientDash',
      name: 'clientDash',
      component: ClientDash,
      meta: { 
        requiresAuth: true, adminAuth: true, menuAuth: true, chefAuth: true
      }
    },
    {
      path: '/newclient',
      name: 'clientNew',
      component: ClientNew,
      meta: { 
        requiresAuth: true, adminAuth: true, menuAuth: false, chefAuth: false
      }
    },
    {
      path: '/clientMenu',
      name: 'clientMenu',
      component: ClientMenu,
      meta: { 
        requiresAuth: true, adminAuth: true, menuAuth: true, chefAuth: true
      }
    },
    {
      path: '/clientPage',
      name: 'clientPage',
      component: ClientPage,
      meta: { 
        requiresAuth: true, adminAuth: true, menuAuth: true, chefAuth: true
      }
    },
    {
      path: '/menuDash',
      name: 'menuDash',
      component: MenuDash,
      meta: { 
        requiresAuth: true, adminAuth: true, menuAuth: true, chefAuth: true
      }
    },
    {
      path: '/menu',
      name: 'MenuPage',
      component: MenuPage,
      meta: { 
        requiresAuth: true, adminAuth: true, menuAuth: true, chefAuth: true
      }
    },
    {
      path: '/menuEdit',
      name: 'menuEdit',
      component: MenuEdit,
      meta: { 
        requiresAuth: true, adminAuth: true, menuAuth: true, chefAuth: false
      }
    },
    {
      path: '/viewSchedule',
      name: 'SchedulePage',
      component: SchedulePage,
      meta: { 
        requiresAuth: true, adminAuth: true, chefAuth: true, menuAuth: false
      }
    },
    {
      path: '/dash',
      name: 'Dashboard',
      component: Dashboard,
      meta: { 
        requiresAuth: true, adminAuth: true, menuAuth: true, chefAuth: true
      }
    },
    {
      path: '/employee',
      name: 'Employee',
      component: Employee,
      meta: { 
        requiresAuth: true, adminAuth: true, menuAuth: false, chefAuth: false
      }
    },
    {
      path: '/employeeNew',
      name: 'EmployeeNew',
      component: EmployeeNew,
      meta: { 
        requiresAuth: true, adminAuth: true, menuAuth: false, chefAuth: false
      }
    },
    {
      path: '/profile',
      name: 'ProfilePage',
      component: ProfilePage,
      meta: { 
        requiresAuth: true, adminAuth: true, menuAuth: true, chefAuth: true
      }
    },
    {
      path: '/employeeDash',
      name: 'EmployeeDash',
      component: EmployeeDash,
      meta: { 
        requiresAuth: true, adminAuth: true, menuAuth: false, chefAuth: false
      }
    }
  ]
})
router.beforeEach((to, from, next) => {
  const publicPages = ['/'];
  const authRequired = !publicPages.includes(to.path);
  const loggedIn = localStorage.getItem('t');
  if(!loggedIn){
    return next();
  }

  const userType = Decoded(loggedIn);

  if (authRequired && !loggedIn) {
    return next('/');
  }
  else if(to.meta.adminAuth == true && to.meta.menuAuth == true && to.meta.chefAuth == true){
    if(userType.admin === 'True' || userType.menu === 'True' || (userType.menu === 'False' && userType.admin === 'False')){
      next();
    }
    else{
      return next('/dash');
    }
  }
  else if(to.meta.adminAuth == true && to.meta.menuAuth == true && to.meta.chefAuth == false){
    if(userType.admin === 'True' || userType.menu === 'True'){
      next();
    }
    else{
      return next('/dash');
    }
  }
  else if(to.meta.adminAuth == true && to.meta.menuAuth == false && to.meta.chefAuth == false){
    if(userType.admin === 'True'){
      next();
    }
    else{
      return next('/dash');
    }
  }
  else if(to.meta.adminAuth == true && to.meta.menuAuth == false && to.meta.chefAuth == true){
    if(userType.admin === 'True' || (userType.admin === 'False' && userType.menu === 'False')){
      next();
    }
    else{
      return next('/dash');
    }
  }
  next();
})


export default router
