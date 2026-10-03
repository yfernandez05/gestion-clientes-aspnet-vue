<template>
  <div id="app" class="d-flex flex-column min-vh-100 bg-white">

    <header class="border-bottom sticky-top bg-white">
      <div class="container-fluid px-3 px-md-4">
        <nav class="navbar navbar-expand-md navbar-light py-2 px-0">
          <router-link class="navbar-brand font-weight-bold text-dark fs-6 tracking-tight mr-4" to="/">
            GET-API<span class="text-primary">.</span>
          </router-link>
          <button class="navbar-toggler border-0 p-1 shadow-none" type="button" data-toggle="collapse"
            data-target="#appNav" aria-controls="appNav" aria-expanded="false" aria-label="Menú">
            <span class="navbar-toggler-icon"></span>
          </button>

          <div class="collapse navbar-collapse" id="appNav">
            <ul class="navbar-nav mr-auto">
              <li class="nav-item mr-1">
                <router-link class="nav-link px-3 py-1 rounded text-dark font-weight-medium" to="/"
                  exact-active-class="nav-active">
                  Inicio
                </router-link>
              </li>
              <li class="nav-item mr-1">
                <router-link class="nav-link px-3 py-1 rounded text-dark font-weight-medium" to="/cliente"
                  active-class="nav-active">
                  Clientes
                </router-link>
              </li>
            </ul>
          </div>
        </nav>
      </div>
    </header>

    <main class="container py-3">
      <router-view></router-view>
    </main>
  </div>
</template>

<style scoped>
.font-weight-medium {
  font-weight: 500;
}

.tracking-tight {
  letter-spacing: -0.02em;
}

.tracking-wider {
  letter-spacing: 0.05em;
}

.fs-7 {
  font-size: 0.75rem;
}

.nav-link {
  font-size: 0.875rem;
  transition: color 0.15s ease, background-color 0.15s ease;
}

.nav-link:hover:not(.nav-active) {
  color: #000 !important;
  background-color: #f4f5f5;
}

.nav-active {
  color: #000 !important;
  background-color: #e0e0e0;
  font-weight: 600;
}
</style>

<style>
body {
  color: #18181b;
  -webkit-font-smoothing: antialiased;
}

.form-control-feedback {
  color: #dc3545;
  font-size: 0.8rem;
  margin-top: 0.25rem;
}

.has-danger .form-control {
  border-color: #dc3545;
}
</style>