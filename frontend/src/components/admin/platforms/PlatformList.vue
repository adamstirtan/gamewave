<template>

    <AdminHeader title="Platforms">
        <template #actions>
            <v-btn
                to="/admin/platforms/add"
                append-icon="mdi-plus-box"
                color="indigo">
                Add
            </v-btn>
        </template>
    </AdminHeader>

    <div class="pa-5">
        <v-data-table-server
            :headers="state.headers"
            :loading="state.loading"
            :items="state.items"
            :items-length="state.itemsLength"
            :sort-by.sync="state.options.sortBy"
            :sort-desc.sync="state.options.sortDesc"
            :must-sort="true"
            @update:options="onUpdateOptions"
            @click:row="onRowClicked"
            class="elevation-1">

            <template v-slot:item.lastModified="{ item }">
                <span>{{ new Date(Date.parse(item.raw.lastModified)).toLocaleString() }}</span>
            </template>

            <template v-slot:item.created="{ item }">
                <span>{{ new Date(Date.parse(item.raw.created)).toLocaleString() }}</span>
            </template>

        </v-data-table-server>

    </div>
    
</template>

<script setup>

import { reactive, watch, computed } from 'vue'
import { useRouter } from 'vue-router'
import { VDataTableServer } from 'vuetify/labs/VDataTable'

import AdminHeader from '@/components/admin/AdminHeader'
import PlatformService from '@/services/PlatformService'

const state = reactive({
    loading: false,
    headers: [
        {
            title: 'ID',
            align: 'start',
            key: 'id',
            sortable: true,
            width: '80',
            minWidth: '80'
        },
        {
            title: 'Name',
            key: 'name',
        },
        {
            title: 'Modified',
            key: 'lastModified',
            width: '215',
            minWidth: '215'
        },
        {
            title: 'Created',
            key: 'created',
            width: '215',
            minWidth: '215'
        }
    ],
    items: [],
    itemsLength: 0,
    options: {
        sortBy: [{
            key: 'lastModified',
            order: 'desc'
        }],
        groupBy: [false],
        page: 1,
        itemsPerPage: 10
    }
})

const router = useRouter()
const platformService = new PlatformService()

async function onUpdateOptions(options) {
    state.options = options
    await fetchData()
}

function onRowClicked(item, row) {
    router.push(`/admin/platforms/${row.item.value}`)
}

async function fetchData() {
    state.loading = true
    
    const params = {
        ascending: computed(() => {
            if (state.options.sortBy && state.options.sortBy.length > 0) {
                return state.options.sortBy[0].order === 'asc' ? true : false
            }
            return false
        }).value,
        sort: computed(() => {
            if (state.options.sortBy && state.options.sortBy.length > 0) {
                return state.options.sortBy[0].key
            }
            return ''
        }).value,
        page: state.options.page,
        pageSize: state.options.itemsPerPage,
        paged: true
    }

    try {
        const response = await platformService.search(params)

        state.items = response.data.items
        state.itemsLength = response.data.totalItems
    } catch (error) {
        console.error(error);
    }

    state.loading = false
}

watch(
    () => state.options.itemsPerPage,
    () => {
        fetchData()
    }
)

</script>
