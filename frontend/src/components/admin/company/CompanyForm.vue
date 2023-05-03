<template>
    
    <AdminHeader :title="state.editMode ? state.staticName : 'Add Company'">
        <template #actions>

            <v-btn
                v-show="state.editMode"
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

    <div v-show="state.editMode">
        <v-row class="pa-6">
            <v-col cols="2">
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
    </div>

    <form
        id="component-form"
        class="ma-5">

        <v-row>
            <v-col md="4">
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
            <v-col md="4">
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
            <v-col md="6">
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
                    rows="10"
                    @input="v$.description.$touch"
                    @blur="v$.description.$touch"
                ></v-textarea>
            </v-col>
        </v-row>
    </form>

    <div v-show="state.editMode">
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
                    v-show="state.editMode"
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
    </div>

</template>

<script setup>

import { reactive, watch, toRefs } from 'vue'
import { useRouter } from 'vue-router'
import { useVuelidate } from '@vuelidate/core'
import { required, maxLength, url } from '@vuelidate/validators'

import AdminHeader from '@/components/admin/AdminHeader'
import CompanyService from '@/services/CompanyService'
import { toSlug } from '@/utils/utilities'

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
    staticName: '',
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
    imageUrl: {
        url
    }
}

const v$ = useVuelidate(rules, state)

watch(() => state.name, (newValue) => {
    state.slug = toSlug(newValue)
})

const fetchData = async() => {
    state.loading = true

    companyService.get(id.value)
        .then(response => {
            state.staticName = response.data.name
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

if (state.editMode) {
    fetchData()
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
                state.staticName = response.data.name
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
