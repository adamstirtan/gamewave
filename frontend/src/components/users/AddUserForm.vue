<template>
    
    <AdminHeader title="Add User">
        <template #actions>

            <v-btn
                form="component-form"
                type="submit"
                color="success"
                append-icon="mdi-database-plus"
                :disabled="state.loading"
                @click="onSubmit">
                Save
            </v-btn>
            
        </template>
    </AdminHeader>

    <form
        id="component-form"
        class="ma-5">

        <v-row>
            <v-col md="5">
                <v-text-field
                    v-model="state.userName"
                    :error-messages="v$.userName.$errors.map(e => e.$message)"
                    :counter="255"
                    label="User Name"
                    required
                    @input="v$.userName.$touch"
                    @blur="v$.userName.$touch"
                ></v-text-field>
            </v-col>
            <v-col md="5">
                <v-text-field
                    type="email"
                    v-model="state.email"
                    :error-messages="v$.email.$errors.map(e => e.$message)"
                    :counter="255"
                    label="Email"
                    required
                    @input="v$.email.$touch"
                    @blur="v$.email.$touch"
                ></v-text-field>
            </v-col>
        </v-row>
        <v-row>
            <v-col md="5">
                <v-text-field
                    type="password"
                    v-model="state.password"
                    :error-messages="v$.password.$errors.map(e => e.$message)"
                    :counter="255"
                    label="Password"
                    required
                    @input="v$.password.$touch"
                    @blur="v$.password.$touch"
                ></v-text-field>
            </v-col>
        </v-row>

    </form>

</template>

<script setup>

import { reactive } from 'vue'
import { useRouter } from 'vue-router'
import { useVuelidate } from '@vuelidate/core'
import { required, maxLength, email } from '@vuelidate/validators'

import AdminHeader from '@/components/admin/AdminHeader'
import UserService from '@/services/UserService'

const router = useRouter()
const userService = new UserService()

const state = reactive({
    loading: false,
    userName: '',
    password: '',
    email: ''
})

const rules = {
    userName: {
        required,
        maxLengthValue: maxLength(255)
    },
    password: {
        required
    },
    email: {
        required,
        email
    }
}

const v$ = useVuelidate(rules, state)

const onSubmit = async () => {
    const result = await v$.value.$validate()

    if (!result) {
        return
    }

    state.loading = true

    const dto = {
        userName: state.userName,
        email: state.email,
        password: state.password
    }

    await userService.create(dto)
        .then(() => {
            router.push('/users')
        })
        .catch(e => {
            console.error(e);
        })
        .finally(() => {
            state.loading = false
        })
}

</script>
