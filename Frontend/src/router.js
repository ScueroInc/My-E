import Vue from 'vue'
import Router from 'vue-router'
import Home from './views/Home.vue'
import User from './components/User.vue'
import Schedule from './components/Schedule.vue'
import Rol from './components/Rol.vue'
import Order from './components/Order.vue'
import MedicalEquipment from './components/MedicalEquipment.vue'
import MachineReview from './components/MachineReview.vue'
import FinalReport from './components/FinalReport.vue'


Vue.use(Router)

export default new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/',
      name: 'Home',
      component: Home
    },
    {
      path: '/finalreports',
      name: 'finalreports',
      component: FinalReport
    },

    {
      path: '/machinereviews',
      name: 'machinereviews',
      component: MachineReview
    },

    {
      path: '/roles',
      name: 'roles',
      component: Rol
    },

    {
      path: '/users',
      name: 'users',
      component: User
    },
   
    {
      path: '/schedules',
      name: 'schedules',
      component: Schedule
    },

    {
      path: '/orders',
      name: 'orders',
      component: Order
    },
    {
      path: '/medicalequipments',
      name: 'medicalequipments',
      component: MedicalEquipment
    }
  ]
})
