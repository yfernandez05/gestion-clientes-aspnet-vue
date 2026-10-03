<template>
  <div class="row">
    <div :class="columnClass">
      <div class="card border border-light rounded-lg shadow-sm">

        <!-- Header minimalista de alto contraste -->
        <div v-if="$slots['card-header-title'] || $slots['card-header-actions']" 
          class="card-header bg-dark border-bottom py-3 px-4 d-flex align-items-center justify-content-between" :class="headerBgClass">
          <h2 class="h6 font-weight-bold text-white mb-0 tracking-tight">
            <slot name="card-header-title"></slot>
          </h2>
          <div>
            <slot name="card-header-actions"></slot>
          </div>
        </div>

        <!-- Cuerpo del Card -->
        <div class="card-body p-4">
          <slot name="card-body-main"></slot>

          <div v-if="$slots['card-body-actions']"
            class="pt-3 mt-3 border-top d-flex align-items-center justify-content-between">
            <slot name="card-body-actions"></slot>
          </div>
        </div>

      </div>
    </div>
  </div>
</template>

<script>

export default {
  name: 'BaseCard',
  props: {
    columnClass: {
      type: String,
      default: 'col-12'
    },
    headerBgClass: {
      type: String,
      default: 'bg-dark'
    }
  }
}
</script>


<style scoped>
.tracking-tight {
  letter-spacing: -0.01em;
}

.card {
  border-color: #e4e4e7 !important;
  background-color: #ffffff;
}

.card-header {
  border-bottom-color: #e4e4e7 !important;
}

/* Renderizado condicional sutil para líneas divisorias */
.border-top {
  border-top-color: #f4f4f5 !important;
}
</style>