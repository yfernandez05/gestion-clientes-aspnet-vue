import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import './assets/css/style.css';

window.appName = 'Sistema CRUD';
window.appErrorMessage = 'ocurrió un error inesperado. intente nuevamente más tarde.';
window.appCannotDeleteMessage = 'No se puede editar un registro eliminado.';
window.appRecordIsDeletedMessage = 'El registro ya está eliminado.';
window.appApiUrl = `https://localhost:7037/rest`;
window.axios = require('axios');
/* window.axios.defaults.headers.common['X-Requested-With'] = 'XMLHttpRequest'; */

Vue.config.productionTip = false

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')
