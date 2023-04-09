<template>
    
    <AdminHeader title="Companies">
        <template #actions>

            <v-btn
                v-show="state.editMode"
                form="component-form"
                type="button"
                color="error"
                append-icon="mdi-delete"
                :disabled="state.loading"
                @click="onDelete"
                class="mr-5">
                Delete
            </v-btn>

            <v-btn
                form="component-form"
                type="submit"
                color="primary"
                append-icon="mdi-database-plus"
                :disabled="state.loading"
                @click="onSubmit">
                Save
            </v-btn>
            
        </template>
    </AdminHeader>
    
    <v-card class="ma-5">
        
        <v-card-text>

            <form
                id="component-form"
                class="">
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
                            label="Slug"
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

        </v-card-text>

        <div v-show="state.editMode">
            <v-divider></v-divider>
            <v-card-subtitle class="my-5">Last Modified: {{ new Date(Date.parse(state.lastModified)).toLocaleString() }}</v-card-subtitle>
        </div>
        
    </v-card>

</template>

<script setup>

import { reactive, watch, toRefs } from 'vue'
import { useRouter } from 'vue-router'
import { useVuelidate } from '@vuelidate/core'
import { required, maxLength, url } from '@vuelidate/validators'

import AdminHeader from '@/components/admin/AdminHeader'
import CompanyService from '@/services/CompanyService'

const props = defineProps({
    id: {
        type: String,
        required: false
    }
})

const { id } = toRefs(props)

const router = useRouter()
const companyService = new CompanyService()

const state = reactive({
    editMode: !isNaN(new Number(id.value)),
    loading: false,
    name: '',
    slug: '',
    description: '',
    imageUrl: '',
    lastModified: '',
    created: ''
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

if (state.editMode) {
    state.loading = true

    companyService.get(id.value)
        .then(response => {
            state.name = response.data.name
            state.slug = response.data.slug
            state.description = response.data.description
            state.imageUrl = response.data.imageUrl
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

const onSubmit = async () => {
    const result = await v$.value.$validate()

    if (!result) {
        return
    }

    const dto = {
        name: state.name,
        slug: state.slug,
        imageUrl: state.imageUrl,
        description: state.description
    }

    state.loading = true

    if (state.editMode) {
        await companyService.update(id.value, dto)
            .then(response => {
                state.name = response.data.name
                state.slug = response.data.slug
                state.description = response.data.description
                state.imageUrl = response.data.imageUrl
                state.lastModified = response.data.lastModified
            })
            .catch(e => {
                console.error(e);
            })
            .finally(() => {
                state.loading = false
            })
    } else {
        await companyService.create(dto)
            .then(() => {
                router.push('/admin/company')
            })
            .catch(e => {
                console.error(e);
            })
            .finally(() => {
                state.loading = false
            })
    }
}

const onDelete = async () => {
    state.loading = true

    await companyService.delete(id.value)
        .then(() => {
            router.push({ path: '/admin/company', replace: true })
        })
        .catch(e => {
            console.error(e);
        })
        .finally(() => {
            state.loading = false
        })
}

</script>
