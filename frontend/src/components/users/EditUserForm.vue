<template>
    
    <AdminHeader title="Add User">
        <template #actions>

            <v-btn
                prepend-icon="mdi-refresh"
                variant="plain"
                :disabled="state.loading"
                @click="fetchData"
                class="mr-5">
                Refresh
            </v-btn>

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

    <v-row class="pa-6">
        <v-col cols="6">
            <v-chip prepend-icon="mdi-database">
                {{ id }}
            </v-chip>
        </v-col>
        <v-col align-self="center" class="text-right">
            <span class="text-subtitle-2">
                Last modified:
                {{ new Date(Date.parse(state.lastModified)).toLocaleString() }}
            </span>
        </v-col>
    </v-row>

    <v-divider class="mb-5"></v-divider>

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
            <v-col md="7">
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
                    type="tel"
                    v-model="state.phoneNumber"
                    :error-messages="v$.phoneNumber.$errors.map(e => e.$message)"
                    :counter="255"
                    label="Phone number"
                    required
                    @input="v$.phoneNumber.$touch"
                    @blur="v$.phoneNumber.$touch"
                ></v-text-field>
            </v-col>
        </v-row>

    </form>

    <v-divider></v-divider>
    <v-row class="pa-5">
        <v-col align-self="center">
            <span class="text-subtitle-2">
                Created:
                {{ new Date(Date.parse(state.created)).toLocaleString() }}
            </span>
        </v-col>
        <v-col class="text-right">
            <v-btn
                form="component-form"
                type="button"
                variant="tonal"
                color="red"
                append-icon="mdi-delete"
                :disabled="state.loading"
                @click="onDelete">
                Delete
            </v-btn>
        </v-col>
    </v-row>
    

</template>

<script setup>

import { reactive, toRefs } from 'vue'
import { useRouter } from 'vue-router'
import { useVuelidate } from '@vuelidate/core'
import { required, maxLength, email } from '@vuelidate/validators'

import AdminHeader from '@/components/admin/AdminHeader'
import UserService from '@/services/UserService'

const props = defineProps({
    id: {
        type: String,
        required: false
    }
})

const { id } = toRefs(props)

const router = useRouter()
const userService = new UserService()

const state = reactive({
    editMode: id.value !== 'add',
    loading: false,
    userName: '',
    email: '',
    phoneNumber: '',
    lastModified: '',
    created: ''
})

const rules = {
    userName: {
        required,
        maxLengthValue: maxLength(255)
    },
    email: {
        required,
        email
    },
    phoneNumber: {
        maxLengthValue: maxLength(255)
    }
}

const v$ = useVuelidate(rules, state)

const fetchData = async() => {
    state.loading = true

    userService.get(id.value)
        .then(response => {
            state.userName = response.data.userName
            state.email = response.data.email
            state.phoneNumber = response.data.phoneNumber
            state.lastModified = response.data.lastModified
            state.created = response.data.created
        })
        .catch(e => {
            console.error(e)
        })
        .finally(() => {
            state.loading = false
        })
}

fetchData()

const onSubmit = async () => {
    if (!await v$.value.$validate()) {
        return
    }

    state.loading = true

    const dto = {
        userName: state.userName,
        email: state.email,
        phoneNumber: state.phoneNumber
    }

    await userService.update(id.value, dto)
        .then(response => {
            state.userName = response.data.userName
            state.email = response.data.email
            state.phoneNumber = response.data.phoneNumber
            state.lastModified = response.data.lastModified
            state.created = response.data.created
        })
        .catch(e => {
            console.error(e);
        })
        .finally(() => {
            state.loading = false
        })
}

const onDelete = async () => {
    state.loading = true

    await userService.delete(id.value)
        .then(() => {
            router.push({ path: '/users', replace: true })
        })
        .catch(e => {
            console.error(e);
        })
        .finally(() => {
            state.loading = false
        })
}

</script>
