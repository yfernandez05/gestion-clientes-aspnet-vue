<template>
    <form-cliente cardTitle="Registrar cliente" @saveData="saveData"/>
</template>

<script>
    import FormCliente from './_FormCliente.vue';

    export default {
        methods: {
            saveData(event) {
                console.log('save data', event);
                let vm = this;
                axios.post(`${appApiUrl}/cliente`, event)
                    .then(function (response) {
         
                        let result = response;
                        console.log(result);
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
            }
        },
        components: {
            FormCliente
        }
    }

</script>
