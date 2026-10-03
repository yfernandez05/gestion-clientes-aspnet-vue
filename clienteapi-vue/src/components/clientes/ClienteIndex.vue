<template>
    <div>
        <main-content>
            <template v-slot:card-header-title>
                GESTION DE CLIENTES
            </template>
            <template v-slot:card-header-actions>
                <div class="d-flex align-items-center">
                    <button type="button"
                        class="btn btn-sm btn-info font-weight-medium rounded px-3 mx-1 d-inline-flex align-items-center"
                        @click="buscarcliente()">
                        <i class="fas fa-search mr-1 lg"></i>
                        <span class="d-none d-sm-inline">Buscar</span>
                    </button>

                    <button type="button"
                        class="btn btn-sm btn-danger font-weight-medium rounded px-3 mx-1 d-inline-flex align-items-center"
                        @click="limpiarfiltro()">
                        <i class="fas fa-times mr-1 lg"></i>
                        <span class="d-none d-sm-inline">Limpiar</span>
                    </button>

                    <router-link :to="{ name: 'cliente.registrar' }"
                        class="btn btn-sm btn-success font-weight-medium rounded px-3 mx-1 d-inline-flex align-items-center">
                        <i class="fas fa-plus mr-1 lg"></i>
                        <span class="d-none d-sm-inline">Nuevo</span>
                    </router-link>
                </div>
            </template>
            <template v-slot:card-body-main>
                <div class="form-row">
                    <div class="form-group col-12 col-sm-6 col-md-4 ">
                        <label>Nombre</label>
                        <input type="text" class="form-control" v-model="cliente.nombre" @keyup.enter="buscarcliente()">
                    </div>
                    <div class="form-group col-12 col-sm-6 col-md-4 ">
                        <label>Apellido</label>
                        <input type="text" class="form-control" v-model="cliente.apellidos"
                            @keyup.enter="buscarcliente()">
                    </div>
                    <div class="form-group col-12 col-sm-6 col-md-4 ">
                        <label>Edad</label>
                        <input type="text" class="form-control" v-model="cliente.edad" @keyup.enter="buscarcliente()">
                    </div>
                    <div class="form-group col-12 col-sm-6 col-md-4 ">
                        <label>Telefono</label>
                        <input type="text" class="form-control" v-model="cliente.telefono"
                            @keyup.enter="buscarcliente()">
                    </div>
                    <div class="form-group col-12 col-sm-6 col-md-4 ">
                        <label>Correo</label>
                        <input type="text" class="form-control" v-model="cliente.correo" @keyup.enter="buscarcliente()">
                    </div>
                    <div class="form-group col-12 col-sm-6 col-md-4 ">
                        <label>&nbsp;</label>
                        <div class="custom-control custom-checkbox">
                            <input type="checkbox" class="custom-control-input" id="estado" v-model="estadoCheckbox"
                                @change="buscarcliente()">
                            <label class="custom-control-label" for="estado">Incluir Eliminados</label>
                        </div>
                    </div>
                </div>

                <div class="table-responsive">
                    <table class="table table-sm table-striped table-hover table-bordered">
                        <thead>
                            <tr>
                                <th class="p-2">Acciones</th>
                                <th class="p-2">Cod</th>
                                <th class="p-2">Nombre</th>
                                <th class="p-2">Apellido</th>
                                <th class="p-2 text-nowrap">Edad</th>
                                <th class="p-2">Correo</th>
                                <th class="p-2">Estado</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr v-for="cli in clientes" :key="cli.id">
                                <td>
                                    <row-actions :rowData="cli" @rowItemActions="rowItemActions" :activeDelete="false">
                                        <button type="button" :title="cli.isactive ? 'Eliminar' : 'Restaurar'"
                                            @click="cambiarEstado(cli)"
                                            class="btn btn-sm  waves-effect waves-light border-0 mr-1"
                                            :class="cli.isactive ? 'btn-outline-danger' : 'btn-outline-success'">
                                            <i class="fas fa-lg"
                                                :class="cli.isactive ? 'fa-trash' : 'fa-solid fa-rotate-left'"></i>
                                        </button>
                                    </row-actions>
                                </td>
                                <td v-text="cli.id"></td>
                                <td v-text="cli.nombre"></td>
                                <td v-text="cli.apellidos"></td>
                                <td v-text="cli.edad"></td>
                                <td v-text="cli.correo"></td>
                                <td>
                                    <span class="badge badge-pill py-2"
                                        :class="cli.isactive ? 'badge-success' : 'badge-danger'" v-text="cli.statename">
                                    </span>
                                </td>
                            </tr>
                        </tbody>

                    </table>
                </div>
                <pagination-links :pagination="pagination" @changePerPage="changePerPage">
                </pagination-links>

            </template>
        </main-content>
    </div>
</template>

<script>
import MainContent from '../utils/MainContent.vue';
import PaginationLinks from '../utils/PaginationLinks.vue';
import RowActions from '../utils/RowActions.vue';

export default {
    data() {
        return {
            clientes: [],
            pagination: {},
            filters: {},
            cliente: {
                nombre: '',
                apellidos: '',
                edad: '',
                correo: '',
                estado: '',
            }

        }
    },
    methods: {
        listarcliente() {
            let vm = this;
            axios.get(`${appApiUrl}/cliente`, { params: this.filters })
                .then(function (response) {
                    console.log(response.data);
                    vm.clientes = response.data;
                    //vm.pagination = response.data;
                    //delete vm.pagination.data;
                })
                .catch(function (error) {
                    console.log(error);
                });
        },
        rowItemActions(event) {
            switch (event.action) {
                case 'edit':
                    if (!event.data.isactive) {
                        warningMessage(appCannotDeleteMessage, appName);
                        break;
                    }

                    this.$router.push({ name: 'cliente.editar', params: { id: event.data.id } })
                    break;
                case 'delete':
                    this.eliminarCliente(event.data);
                    break;
            }
        },
        /* changePerPage(event) {
            this.filters.page = event.page;
            this.filters.perpage = event.perpage;
            this.listarcliente();
        }, */
        buscarcliente() {
            this.filters = {};
            //this.filters.page = 1;

            if (this.cliente.nombre.length)
                this.filters.nombre = this.cliente.nombre;

            if (this.cliente.apellidos.length)
                this.filters.apellidos = this.cliente.apellidos;

            if (this.cliente.edad.length)
                this.filters.edad = this.cliente.edad;

            if (this.cliente.correo.length)
                this.filters.correo = this.cliente.correo;

            if (this.cliente.estado)
                this.filters.estado = this.cliente.estado;

            this.listarcliente();
        },

        limpiarfiltro() {
            this.cliente.nombre = '';
            this.cliente.apellidos = '';
            this.cliente.edad = '';
            this.cliente.correo = '';
            this.cliente.telefono = '';
            this.cliente.estado = '';
            this.buscarcliente();
        },

        cambiarEstado(param) {
            let vm = this;

            let optionMessage = 'Eliminar';

            if (!param.isactive) optionMessage = 'Restaurar';


            swalAlertConfirm(`¿Seguro que quiere ${optionMessage} el cliente <b>${param.nombre}</b>?`, appName)
                .then(function (optionSelected) {

                    if (optionSelected.value) {
                        axios.delete(`${appApiUrl}/cliente/${param.id}`)
                            .then(function (response) {

                                let result = response;
                                console.log(result);

                                if (result.status) {
                                    successMessage(result.data.message, appName);
                                    vm.listarcliente();
                                } else if (result.warning) {
                                    warningMessage(result.data.message, appName);
                                    vm.listarcliente();
                                } else {
                                    errorMessage(result.data.message, appName);
                                }

                            })
                            .catch(function (error) {
                                errorMessage(appErrorMessage, appName);
                                console.log(error);
                            });
                    }
                });
        },
    },
    computed: {
        estadoCheckbox: {
            get() {
                return this.cliente.estado = '';
            },
            set(value) {
                this.cliente.estado = value ? "E" : '';
            }
        }
    },
    created() {
        this.listarcliente();
    },

    components: {
        MainContent,
        PaginationLinks,
        RowActions,
    }
}
</script>
