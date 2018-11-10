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
import EmployeeView from './views/EmployeeView.vue';
import EmployeeNew from './views/EmployeeNew.vue';
import SchedulePage from './views/SchedulePage.vue';
import ScheduleNew from './views/ScheduleNew.vue';
import ScheduleDash from './views/ScheduleDash.vue';

Vue.use(Router);

export default new Router({
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home
    },
    {
      path: '/scheduleNew',
      name: 'scheduleNew',
      component: ScheduleNew
    },
    {
      path: '/scheduleDash',
      name: 'scheduleDash',
      component: ScheduleDash
    },
    {
      path: '/clientDash',
      name: 'clientDash',
      component: ClientDash
    },
    {
      path: '/newclient',
      name: 'clientNew',
      component: ClientNew
    },
    {
      path: '/clientMenu',
      name: 'clientMenu',
      component: ClientMenu
    },
    {
      path: '/clientPage',
      name: 'clientPage',
      component: ClientPage
    },
    {
      path: '/menuDash',
      name: 'menuDash',
      component: MenuDash
    },
    {
      path: '/menu',
      name: 'MenuPage',
      component: MenuPage
    },
    {
      path: '/menuEdit',
      name: 'menuEdit',
      component: MenuEdit
    },
    {
      path: '/availability',
      name: 'Availability',
      component: SchedulePage
    },
    {
      path: '/dash',
      name: 'Dashboard',
      component: Dashboard
    },
    {
    path: '/employee',
    name: 'Employee',
    component: Employee
    },
    {
      path: '/employeeNew',
      name: 'EmployeeNew',
      component: EmployeeNew
      },
    {
      path: '/profile',
      name: 'ProfilePage',
      component: ProfilePage
    },
    {
      path: '/employeeView',
      name: 'EmployeeView',
      component: EmployeeView
    },
    {
      path: '/employeeDash',
      name: 'EmployeeDash',
      component: EmployeeDash
    }
  ]
})
