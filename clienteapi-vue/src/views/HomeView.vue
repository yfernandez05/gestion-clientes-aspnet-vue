<template>
  <div class="container py-5" style="max-width: 620px;">
    <div class="pb-3 mb-4 border-bottom">
      <h1 class="h3 font-weight-bold text-dark mb-1">Panel Principal</h1>
      <p class="text-muted small mb-0">Módulos disponibles</p>
    </div>
    <div class="d-flex flex-column gap-3">
      <div class="module-card rounded-lg p-3 bg-white border d-flex align-items-center justify-content-between">
        <div>
          <span class="badge badge-neutral px-2 py-1 mb-1">Módulo 01</span>
          <h2 class="h6 font-weight-bold text-dark mb-0 tracking-tight">
            GESTIÓN DE CLIENTES
          </h2>
        </div>
        <router-link to="/cliente" class="btn btn-dark btn-sm px-4 font-weight-medium rounded-pill">
          Ingresar
        </router-link>
      </div>
      <div class="module-card rounded-lg p-3 bg-white border d-flex align-items-center justify-content-between">
        <div>
          <span class="badge badge-neutral px-2 py-1 mb-1">Módulo 02</span>
          <h2 class="h6 font-weight-bold text-dark mb-0 tracking-tight">
            GESTIÓN DE PRODUCTOS
          </h2>
        </div>
        <router-link to="/producto" class="btn btn-dark btn-sm px-4 font-weight-medium rounded-pill disabled">
          Ingresar
        </router-link>
      </div>
    </div>

  </div>
</template>

<script>
export default {
  name: 'HomeView'
}
</script>

<style scoped>
.gap-3>*+* {
  margin-top: 1rem;
}

.tracking-tight {
  letter-spacing: -0.01em;
}

.font-weight-medium {
  font-weight: 500;
}

.module-card {
  border-color: #e4e4e7 !important;
  transition: border-color 0.15s ease, box-shadow 0.15s ease;
}

.module-card:hover {
  border-color: #d4d4d8 !important;
  box-shadow: 0 2px 8px rgba(0, 0, 0, 0.04);
}

.badge-neutral {
  background-color: #f4f4f5;
  color: #71717a;
  font-size: 0.5rem;
  font-weight: 600;
  border-radius: 4px;
}

.btn-dark {
  background-color: #18181b;
  border-color: #18181b;
  font-size: 0.8rem;
}

.btn-dark:hover {
  background-color: #27272a;
  border-color: #27272a;
}
</style>