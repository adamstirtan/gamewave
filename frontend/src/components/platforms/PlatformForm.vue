<template>
    
    <Header :title="state.editMode ? state.staticName : 'Add Platform'">
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
    </Header>

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
            <v-col md="4">
                <v-autocomplete
                    v-model="state.category"
                    :items="state.categories"
                    :error-messages="v$.imageUrl.$errors.map(e => e.$message)"
                    item-value="id"
                    item-title="name"
                    label="Category"
                    required
                ></v-autocomplete>
            </v-col>
            <v-col md="2">
                <v-text-field
                    v-model="state.generation"
                    :error-messages="v$.generation.$errors.map(e => e.$message)"
                    label="Generation"
                    type="number"
                    min="1"
                    required
                    @input="v$.generation.$touch"
                    @blur="v$.generation.$touch"
                ></v-text-field>
            </v-col>
        </v-row>

        <v-row>
            <v-col cols="12" md="12">
                <v-textarea
                    v-model="state.description"
                    :error-messages="v$.description.$errors.map(e => e.$message)"
                    rows="10"
                    label="Description"
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

import { reactive, watch, toRefs, onMounted } from 'vue'
import { useRouter } from 'vue-router'
import { useVuelidate } from '@vuelidate/core'
import { required, maxLength, url } from '@vuelidate/validators'

import Header from '@/components/Header'
import PlatformService from '@/services/PlatformService'
import { toSlug } from '@/utils/utilities'

const props = defineProps({
    id: {
        type: String,
        required: false
    }
})

const { id } = toRefs(props)

const router = useRouter()
const platformService = new PlatformService()

const state = reactive({
    editMode: !isNaN(new Number(id.value)),
    loading: false,
    staticName: '',
    categories: [],
    name: '',
    slug: '',
    description: '',
    imageUrl: '',
    category: null,
    generation: 0,
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
    },
    category: {
        required
    },
    generation: { required }
}

const v$ = useVuelidate(rules, state)

watch(() => state.name, (newValue) => {
    state.slug = toSlug(newValue)
})

onMounted(() => {
    state.loading = true

    platformService.getCategories()
        .then(response => {
            state.categories = response.data
        })
        .catch(e => {
            console.error(e)
        })
        .finally(() => {
            state.loading = false
        })
})

const fetchData = async() => {
    state.loading = true

    platformService.get(id.value)
        .then(response => {
            state.staticName = response.data.name
            state.name = response.data.name
            state.slug = response.data.slug
            state.description = response.data.description
            state.imageUrl = response.data.imageUrl
            state.category = response.data.category
            state.generation = response.data.generation
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
        description: state.description,
        category: state.category,
        generation: state.generation
    }

    state.loading = true

    if (state.editMode) {
        await platformService.update(id.value, dto)
            .then(response => {
                state.staticName = response.data.name
                state.name = response.data.name
                state.slug = response.data.slug
                state.description = response.data.description
                state.imageUrl = response.data.imageUrl
                state.category = response.data.category
                state.generation = response.data.generation
                state.lastModified = response.data.lastModified
            })
            .catch(e => {
                console.error(e);
            })
            .finally(() => {
                state.loading = false
            })
    } else {
        await platformService.create(dto)
            .then(() => {
                router.push('/admin/platform')
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

    await platformService.delete(id.value)
        .then(() => {
            router.push({ path: '/admin/platform', replace: true })
        })
        .catch(e => {
            console.error(e);
        })
        .finally(() => {
            state.loading = false
        })
}

</script>
