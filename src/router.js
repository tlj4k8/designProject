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
        requiresAuth: true, adminAuth: true, menuAuth: true, chefAuth: false
      }
    },
    {
      path: '/menuEdit',
      name: 'menuEdit',
      component: MenuEdit,
      meta: { 
        requiresAuth: true, adminAuth: true, menuAuth: true, chefAuth: true
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
  // const publicPages = ['/'];
  // const authRequired = !publicPages.includes(to.path);
  // const loggedIn = localStorage.getItem('t');

  // if (authRequired && !loggedIn) {
  //   return next('/');
  // }

  // next();
if(to.meta.requiresAuth){
  const token = localStorage.getItem('t');
  const user = Decoded(token);
  // console.log(user);
  if(!user){
    next({name: 'home'})
  }
  else if(to.meta.adminAuth){
    const token = localStorage.getItem('t');
    const user = Decoded(token);
    if(user.admin == 'True'){
      next()
    }else{
      next('/dash')
    }
  }
  else if(to.meta.menuAuth){
    const token = localStorage.getItem('t');
    const user = Decoded(token);
    if(user.menu == 'True'){
      next()
    }else{
      next('/dash')
    }
  }
  else if(to.meta.chefAuth){
    const token = localStorage.getItem('t');
    const user = Decoded(token);
    if(user.menu == 'False' && user.admin == 'False'){
      next()
    }else{
      next('/dash')
    }
  }
  else{
    next();
  }
}
  next();



  // const publicPages = ['/'];
  // const authRequired = !publicPages.includes(to.fullPath);

  // const token = localStorage.getItem('t');
  // console.log(token)
  // if (authRequired && !token) {
  //   return next('/');
  // }  
  // if (to.fullPath === '/employeeDash') {
  //   if (userType.admin !== 'true') {
  //     return next('/dash');
  //   }
  // }
  // next();
})

















  // redirect to login page if not logged in and trying to access a restricted page
  // const publicPages = ['/'];
  // const authRequired = !publicPages.includes(to.path);
  // const loggedIn = localStorage.getItem('t');

  // if (authRequired && !loggedIn) {
  //   return next('/');
  // }

  // next();
// })

export default router
