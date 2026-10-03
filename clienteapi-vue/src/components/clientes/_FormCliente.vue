<template>
    <main-content columnClass="col-12 col-xl-10">
        <template v-slot:card-header-title>
            <span v-text="cardTitle"></span>
        </template>

        <template v-slot:card-body-main>
            <div class="form-row">
                <div class="form-group col-12 col-sm-6 col-md-4" :class="{'has-danger':errorExists('nombre')}">
                    <label>Nombre<small class="text-danger">(*)</small></label>
                    <input type="text" class="form-control" v-model="cliente.nombre" @:keyup.enter ="doSaveData" />
                    <small class="form-control-feedback" v-if="errorExists('nombre')" v-text="showError('nombre').errorDetail"></small>
                </div>
                <div class="form-group col-12 col-sm-6 col-md-4" :class="{'has-danger':errorExists('apellidos')}">
                    <label>Apellidos <small class="text-danger">(*)</small></label>
                    <input type="text" class="form-control" v-model="cliente.apellidos" @:keyup.enter ="doSaveData" />
                    <small class="form-control-feedback" v-if="errorExists('apellidos')" v-text="showError('apellidos').errorDetail"></small>
                </div>
                <div class="form-group col-12 col-sm-6 col-md-4" :class="{'has-danger':errorExists('telefono')}">
                    <label>Telefono <small class="text-danger">(*)</small></label>
                    <input type="text" class="form-control" maxlength="9" v-model="cliente.telefono" @:keyup.enter ="doSaveData" />
                    <small class="form-control-feedback" v-if="errorExists('telefono')"  v-text="showError('telefono').errorDetail"></small>
                </div>
                <div class="form-group col-12 col-sm-6 col-md-4" :class="{'has-danger':errorExists('correo')}">
                    <label>Correo <small class="text-danger">(*)</small></label>
                    <input type="text" class="form-control" v-model="cliente.correo" @:keyup.enter ="doSaveData" />
                    <small class="form-control-feedback" v-if="errorExists('correo')" v-text="showError('correo').errorDetail"></small>
                </div>
                <div class="form-group col-4 col-sm-2 col-md-2" :class="{'has-danger':errorExists('edad')}">
                    <label>Edad <small class="text-danger">(*)</small></label>
                    <input type="text" class="form-control" maxlength="2" v-model="cliente.edad" @:keyup.enter ="doSaveData" />
                    <small class="form-control-feedback" v-if="errorExists('edad')" v-text="showError('edad').errorDetail"></small>
                </div>
            </div>
            <hr class="mt-2">
        </template>

        <template v-slot:card-body-actions>
            <router-link :to="{name: 'cliente'}" class="btn waves-effect waves-light btn-info mr-2">
                <i class="fas fa-reply"></i> <span class="button-text">Atrás</span>
            </router-link>

            <div>
                <button type="button" class="btn btn-success waves-effect waves-light" @click="doSaveData">
                    <i class="fa fa-save"></i>
                    Guardar
                </button>
                <button type="reset" class="btn waves-effect waves-light btn-outline-secondary ml-2">
                    <i class="fa fa-window-close"></i> <span class="button-text">Cancelar</span>
                </button>
            </div>
        </template>

    </main-content>
</template>

<script>
import MainContent from '../utils/MainContent';

export default {
        props: {
            cardTitle: {
                default: 'Cliente'
            },
            cliente: {
                type: Object,
                default() {
                    return {
                        nombre: '',
                        apellidos: '',
                        edad: '',
                        correo: '',
                        telefono: '',
                    }
                }
            }
        },
        data(){
            return {
                errors:[]
            }
        },
        methods: {
            doSaveData() {

                if (this.validateFields().length > 0) {
                    return;
                }

                let clienteData = {
                    nombre: this.cliente.nombre,
                    apellidos: this.cliente.apellidos,
                    edad: this.cliente.edad,
                    telefono: this.cliente.telefono,
                    correo: this.cliente.correo,
                }

                this.$emit('saveData', clienteData);
            },

            validateFields() {
                this.errors = [];

                if (!this.cliente.nombre) {
                    this.setError('nombre', 'El campo nombre es obligatorio');
                }
                if (!this.cliente.apellidos) {
                    this.setError('apellidos', 'El campo apellidos es obligatorio');
                }
                if (!this.cliente.edad) {
                    this.setError('edad', 'El campo edad es obligatorio');
                }
                if (!this.cliente.telefono) {
                    this.setError('telefono', 'El campo telefono es obligatorio');
                }
                if (!this.cliente.correo) {
                    this.setError('correo', 'El campo correo es obligatorio');
                }

                return this.errors;
            },
            setError(keyModel, errorDetail) {
                this.errors.push({
                    keyModel: keyModel,
                    errorDetail: errorDetail
                });
            },
            errorExists(keyModel){
                return this.errors.filter(err => err.keyModel === keyModel).length;
            },
            showError(keyModel){
                return this.errors.find(err => err.keyModel === keyModel);
            },
        },
        mounted(){
           
        },
        components: {
            MainContent,
        }
    }
</script>