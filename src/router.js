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
import profileHelp from './help/profileHelp.vue';
import loginHelp from './help/loginHelp.vue';
import addClientHelp from './help/addClientHelp.vue';
import viewClientHelp from './help/viewClientHelp.vue';
import addEmployeeHelp from './help/addEmployeeHelp.vue';
import addMenuHelp from './help/addMenuHelp.vue';
import viewMenuHelp from './help/viewMenuHelp.vue';
import customerMenuHelp from './help/customerMenuHelp.vue';
import viewEmployeeHelp from './help/viewEmployeeHelp.vue';
import addScheduleHelp from './help/addScheduleHelp.vue';
import viewScheduleHelp from './help/viewScheduleHelp.vue';
import store from './store';

Vue.use(Router);

const router = new Router({
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home
    },
    {
      path: '/profileHelp',
      name: 'ProfileHelp',
      component: profileHelp
    },
    {
      path: '/loginHelp',
      name: 'loginHelp',
      component: loginHelp
    },
    {
      path: '/addClientHelp',
      name: 'addClientHelp',
      component: addClientHelp
    },
    {
      path: '/viewClientHelp',
      name: 'viewClientHelp',
      component: viewClientHelp
    },
    {
      path: '/addEmployeeHelp',
      name: 'addEmployeeHelp',
      component: addEmployeeHelp
    },
    {
      path: '/addMenuHelp',
      name: 'addMenuHelp',
      component: addMenuHelp
    },
    {
      path: '/viewMenuHelp',
      name: 'viewMenuHelp',
      component: viewMenuHelp
    },
    {
      path: '/customerMenuHelp',
      name: 'customerMenuHelp',
      component: customerMenuHelp
    },
    {
      path: '/viewEmployeeHelp',
      name: 'viewEmployeeHelp',
      component: viewEmployeeHelp
    },
    {
      path: '/addScheduleHelp',
      name: 'addScheduleHelp',
      component: addScheduleHelp
    },
    {
      path: '/viewScheduleHelp',
      name: 'viewScheduleHelp',
      component: viewScheduleHelp
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
  setTimeout(()=> {
    const publicPages = ['/', '/loginHelp'];
    const authRequired = !publicPages.includes(to.path);
    const loggedIn = localStorage.getItem('t');
    let user = store.state.userInfo;
    
    if (authRequired) {
      if(!loggedIn){
        return next('/');
      }
      next();
    }
    if(to.meta.requiresAuth){
      if(to.meta.adminAuth == true && to.meta.menuAuth == true && to.meta.chefAuth == true){
        if(user.admin === 'True' || user.menu === 'True' || (user.menu === 'False' && user.admin === 'False')){
          next();
        }
        else{
          return next('/dash');
        }
      }
      if(to.meta.adminAuth == true && to.meta.menuAuth == true && to.meta.chefAuth == false){
        if(user.admin === 'True' || user.menu === 'True'){
          next();
        }
        else{
          return next('/dash');
        }
      }
      if(to.meta.adminAuth == true && to.meta.menuAuth == false && to.meta.chefAuth == false){
        if(user.admin === 'True'){
          next();
        }
        else{
          return next('/dash');
        }
      }
      if(to.meta.adminAuth == true && to.meta.menuAuth == false && to.meta.chefAuth == true){
        if(user.admin === 'True' || (user.admin === 'False' && user.menu === 'False')){
          next();
        }
        else{
          return next('/dash');
        }
    }
    next();
  }
  next();
  
  }, 25 )
 
})


export default router
