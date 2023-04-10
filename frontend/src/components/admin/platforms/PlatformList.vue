<template>

<AdminHeader title="Platforms">
        <template #actions>
            
            <v-btn
                to="/admin/platform/add"
                append-icon="mdi-plus-box"
                color="indigo">
                Add
            </v-btn>

        </template>
    </AdminHeader>

    <v-card class="ma-5">
        <v-data-table-server
            :headers="state.headers"
            :loading="state.loading"
            :items="state.items"
            :items-length="state.itemsLength"
            :sort-by.sync="state.options.sortBy"
            :sort-desc.sync="state.options.sortDesc"
            :must-sort="true"
            :hover="true"
            @update:options="onUpdateOptions"
            class="elevation-1">

            <template v-slot:item.id="{ item }">
                <span class="text-subtitle-2">
                    {{ item.raw.id }}
                </span>
             </template>

            <template v-slot:item.name="{ item }">
                <router-link :to="`/admin/platform/${item.raw.id}`">{{ item.raw.name }}</router-link>
             </template>

            <template v-slot:item.lastModified="{ item }">
                <span>{{ new Date(Date.parse(item.raw.lastModified)).toLocaleString() }}</span>
            </template>

            <template v-slot:item.created="{ item }">
                <span>{{ new Date(Date.parse(item.raw.created)).toLocaleString() }}</span>
            </template>

        </v-data-table-server>
    </v-card>
    
</template>

<script setup>

import { reactive, computed } from 'vue'
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
            width: '215'
        },
        {
            title: 'Created',
            key: 'created',
            width: '215'
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

const platformService = new PlatformService()

async function onUpdateOptions(options) {
    state.options = options
    await fetchData()
}

async function fetchData() {
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

    state.loading = true

    platformService.search(params)
        .then(response => {
            state.items = response.data.items
            state.itemsLength = response.data.totalItems
        })
        .catch(e => {
            console.error(e)
        })
        .finally(() => {
            state.loading = false
        })
}

</script>
