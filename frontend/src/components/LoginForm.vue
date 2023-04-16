<template>

    <div class="fill-height d-flex align-center justify-center bg-grey-lighten-2">

        <v-sheet width="450" class="elevation-1 pa-5">

            <div class="text-h4 font-weight-bold mb-1">GameWave</div>
            <div class="text-subtitle-1 mb-5">Sign in to continue</div>

            <v-form validate-on="submit">

                <v-text-field
                    v-model="state.userName"
                    label="User name"
                ></v-text-field>

                <v-text-field
                    v-model="state.password"
                    type="password"
                    label="Password"
                ></v-text-field>

                <v-btn
                    type="submit"
                    color="blue"
                    :disabled="state.loading"
                    block
                    class="mt-2"
                    @click="onSubmit">
                    Login
                </v-btn>

            </v-form>

        </v-sheet>

    </div>

</template>

<script setup>

import { reactive } from 'vue'
import { useRouter } from 'vue-router'

import AuthenticationService from '@/services/AuthenticationService'

const router = useRouter()
const authenticationService = new AuthenticationService()

const state = reactive({
    userName: '',
    password: ''
})

const onSubmit = async () => {
    const dto = {
        userName: state.userName,
        password: state.password
    }

    state.loading = true

    await authenticationService.login(dto)
        .then(response => {
            const token = response.data
            localStorage.setItem('token', token)
            router.push("/admin")
        })
        .catch(e => {
            console.error(e)
        })
        .finally(() => {
            state.loading = false
        })
}

</script>

<style scoped>
.fill-height {
    min-height: 100vh;
    display: flex;
}
.align-center {
    align-items: center;
}
.justify-center {
    justify-content: center;
}
</style>