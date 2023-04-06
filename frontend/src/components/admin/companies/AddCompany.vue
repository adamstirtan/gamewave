<template>
    
    <AdminHeader title="Companies">
        <template #actions>
            <v-btn
                form="component-form"
                type="submit"
                color="primary"
                append-icon="mdi-database-plus"
                :disabled="state.loading"
                @click="submit">
                Save
            </v-btn>
        </template>
    </AdminHeader>
    
    <v-card class="ma-5">
        <form
            id="component-form"
            class="pa-5">
            <v-row>
                <v-col cols="12" md="5">
                    <v-text-field
                        v-model="state.name"
                        :error-messages="v$.name.$errors.map(e => e.$message)"
                        :counter="255"
                        label="Name"
                        required
                        @input="v$.name.$touch"
                        @blur="v$.name.$touch"
                    ></v-text-field>
                </v-col>
                <v-col cols="12" md="4">
                    <v-text-field
                        v-model="state.slug"
                        :error-messages="v$.slug.$errors.map(e => e.$message)"
                        :counter="255"
                        :readonly="true"
                        label="Slug (Read only)"
                        tabindex="-1"
                        required
                        @input="v$.slug.$touch"
                        @blur="v$.slug.$touch"
                    ></v-text-field>
                </v-col>
            </v-row>

            <v-row>
                <v-col cols="12" md="5">
                    <v-text-field
                        v-model="state.imageUrl"
                        :error-messages="v$.imageUrl.$errors.map(e => e.$message)"
                        :counter="255"
                        label="Image URL"
                        required
                        @input="v$.imageUrl.$touch"
                        @blur="v$.imageUrl.$touch"
                    ></v-text-field>
                </v-col>
            </v-row>

            <v-row>
                <v-col cols="12" md="12">
                    <v-textarea
                        v-model="state.description"
                        :error-messages="v$.description.$errors.map(e => e.$message)"
                        label="Description"
                        @input="v$.description.$touch"
                        @blur="v$.description.$touch"
                    ></v-textarea>
                </v-col>
            </v-row>

        </form>
    </v-card>

</template>

<script setup>

import { reactive, watch } from 'vue'
import { useRouter } from 'vue-router'
import { useVuelidate } from '@vuelidate/core'
import { required, maxLength, url } from '@vuelidate/validators'

import AdminHeader from '@/components/admin/AdminHeader'
import CompanyService from '@/services/CompanyService'

const router = useRouter()
const companyService = new CompanyService()

const state = reactive({
    loading: false,
    name: '',
    slug: '',
    description: '',
    imageUrl: ''
})

const rules = {
    name: {
        required,
        maxLengthValue: maxLength(255)
    },
    slug: {
        required,
        maxLengthValue: maxLength(255)
    },
    description: { },
    imageUrl: { required, url }
}

const v$ = useVuelidate(rules, state)

watch(() => state.name, (newValue) => {
    state.slug = newValue.trim().toLowerCase().replace(' ', '-').replace(/[^a-z0-9-_]/g, '')
})

const submit = async () => {
    const result = await v$.value.$validate()
    if (!result) {
        return
    }

    state.loading = true

    await companyService.create({
        name: state.name,
        slug: state.slug,
        imageUrl: state.imageUrl,
        description: state.description
    })
    .then(() => {
        router.push('/admin/companies')
    })
    .catch(e => {
        console.error(e);
    })
    .finally(() => {
        state.loading = false
    })
}

</script>
