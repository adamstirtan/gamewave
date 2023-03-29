<template>
    <v-form class="root"
        v-model="valid"
        @submit.prevent="handleSubmit">

        <h1>Add Game</h1>
        <v-divider class="mb-10"></v-divider>

        <v-row>
            <v-col cols="12" md="6">
                <v-text-field
                    v-model="name"
                    :value="name"
                    :counter="255"
                    label="Name">
                </v-text-field>
            </v-col>
            <v-col cols="12" md="4">
                <v-text-field
                    v-model="slug"
                    :value="slug"
                    :counter="255"
                    label="Slug">
                </v-text-field>
            </v-col>
        </v-row>

        <v-row>
            <v-col cols="12" md="12">
                <v-textarea
                    v-model="description"
                    :value="description"
                    label="Description">
                </v-textarea>
            </v-col>
        </v-row>

        <v-row>
            <v-col cols="12" md="4">
                <v-select
                    v-model="platformId"
                    :items="platforms"
                    item-value="id"
                    item-title="name"
                    label="Platform">
                </v-select>
            </v-col>
            <v-col cols="12" md="4">
                <v-select
                    v-model="publisherId"
                    :items="companies"
                    item-value="id"
                    item-title="name"
                    label="Publisher">
                </v-select>
            </v-col>
            <v-col cols="12" md="4">
                <v-select
                    v-model="developerId"
                    :items="companies"
                    item-value="id"
                    item-title="name"
                    label="Developer">
                </v-select>
            </v-col>
        </v-row>

        <v-card-actions>
    <v-spacer></v-spacer>
    <v-btn to="/">
      Cancel
    </v-btn>
    <v-btn type="submit" color="primary" :disabled="!valid">
      Save
    </v-btn>
  </v-card-actions>
    </v-form>
</template>

<script setup>
    import { ref, watch, onMounted } from 'vue'

    import CompanyService from '@/services/CompanyService'
    import GameService from '@/services/GameService'
    import PlatformService from '@/services/PlatformService'

    const platforms = ref([])
    const companies = ref([])

    const valid = ref(false)
    const name = ref('')
    const slug = ref('')
    const description = ref('')
    const platformId = ref(null)
    const publisherId = ref(null)
    const developerId = ref(null)

    watch(name, (newValue) => {
      slug.value = newValue.replaceAll(' ', '-').toLowerCase()
    })

    onMounted(() => {
        CompanyService
            .getAll()
            .then(response => {
                companies.value = response.data
            })
            .catch(e => {
                console.log(e)
            })

        PlatformService
            .getAll()
            .then(response => {
                platforms.value = response.data
            })
            .catch(e => {
                console.log(e)
            })
    })

    const handleSubmit = async () => {
        GameService.create({
            name: name.value,
            description: description.value,
            slug: slug.value,
            platformId: platformId.value,
            publisherId: publisherId.value,
            developerId: developerId.value
        })
        .then(response => {
            console.log(response)
        })
        .catch(e => {
            console.log(e);
        })
    }

</script>

<style scoped>
    .root {
        padding: 2rem;
    }
    h1 {
        font-size: 2em;
        margin-bottom: 2rem;
    }
</style>