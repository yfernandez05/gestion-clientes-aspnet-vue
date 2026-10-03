<template>
    <form-cliente cardTitle="Editar cliente" :cliente="cliente" @saveData="saveData"/>
</template>


<script>
    import FormCliente from './_FormCliente.vue';

    export default {
        data() {
            return {
                cliente: {}
            }
        },
        created() {
            this.cliente.id = this.$route.params.id;

            if (isNaN(this.cliente.id)) {
                this.backToList();
            }

            this.obtenercliente(this.cliente.id);
        },
        methods: {
            obtenercliente(id) {
                

                let vm = this;
                axios.get(`${appApiUrl}/cliente/${id}`)
                    .then(function (response) {
                        
                        //console.log(response);
                        if (response.data == null || response.data == '') {
                            warningMessage(`No se encontró ningúna cliente con el código ${id}`, appName);
                            this.backToList();
                        }
                        vm.cliente = response.data;

                        if(!vm.cliente.isactive){
                            warningMessage(appCannotDeleteMessage, appName);
                            vm.backToList();
                        }
                    })
                    .catch(function (error) {
                        //hidePreloader();
                        errorMessage(appErrorMessage, appName);
                        vm.backToList();
                        console.log(error);
                    })
            },
            saveData(event) {
                
                //console.log('save data', event);

                let vm = this;
                axios.put(`${appApiUrl}/cliente/${this.cliente.id}`, event)
                    .then(function (response) {
                        
                        console.log(response);
                        let result = response;

                        if (result.status) {
                            successMessage(result.data.message, appName);

                            vm.$router.push({
                                name: 'cliente'
                            });
                        } else
                            errorMessage(result.data.message, appName);
                    })
                    .catch(function (error) {
                        errorMessage(appErrorMessage, appName);
                        console.log(error);
                    })
            },
            backToList(){
                this.$router.push({
                    name: 'cliente'
                });
            },

        },
        components: {
            FormCliente
        }
    }

</script>
