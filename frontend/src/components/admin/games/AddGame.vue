<template>
    <AdminHeader title="Add Game">
        <template #actions>
            <v-btn
                append-icon="mdi-database-plus"
                color="indigo">
                Save
            </v-btn>
        </template>
    </AdminHeader>
    <div class="pa-5">
    <v-form class="root"
        v-model="valid"
        @submit.prevent="handleSubmit">

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
        
    </v-form>
</div>
</template>

<script setup>
    import { ref, watch, onMounted } from 'vue'
    import { useRouter } from 'vue-router'
    import AdminHeader from '@/components/admin/AdminHeader'

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

    const router = useRouter()

    const companyService = new CompanyService()
    const gameService = new GameService()
    const platformService = new PlatformService()

    watch(name, (newValue) => {
      slug.value = newValue.replaceAll(' ', '-').replaceAll('.', '').toLowerCase()
    })

    onMounted(() => {
        companyService
            .getAll()
            .then(response => {
                companies.value = response.data
            })
            .catch(e => {
                console.error(e)
            })

        platformService
            .getAll()
            .then(response => {
                platforms.value = response.data
            })
            .catch(e => {
                console.error(e)
            })
    })

    const handleSubmit = async () => {
        gameService.create({
            name: name.value,
            description: description.value,
            slug: slug.value,
            platformId: platformId.value,
            publisherId: publisherId.value,
            developerId: developerId.value
        })
        .then(() => {
            router.push('/admin/games')
        })
        .catch(e => {
            console.error(e);
        })
    }
</script>
