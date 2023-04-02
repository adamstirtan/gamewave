<template>
    <AdminHeader title="Games">
        <template #actions>
            <v-btn
                to="/admin/addgame"
                variant="outlined">
                Add Game
            </v-btn>
        </template>
    </AdminHeader>
    <div class="pa-5">
        <v-row>
            <v-col cols="5">
                <v-text-field
                    label="Search..."
                    prepend-inner-icon="mdi-magnify"
                    outlined
                    clearable>
                </v-text-field>
            </v-col>
        </v-row>
        <v-data-table-server
            :headers="state.headers"
            :items-per-page-options="state.itemsPerPageOptions"
            :loading="state.loading"
            :items="state.items"
            :items-length="state.itemsLength"
            :total-items="state.totalItems"
            :must-sort="true"
            :sort-by.sync="state.options.sortBy"
            :sort-desc.sync="state.options.sortDesc"
            @update:options="onUpdateOptions"
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
import { VDataTableServer } from 'vuetify/labs/VDataTable'

import AdminHeader from '@/components/admin/AdminHeader'
import GameService from '@/services/GameService'

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
    serverItemsLength: 0,
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

const gameService = new GameService()

async function onUpdateOptions(options) {
    state.options = options
    await fetchData()
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
        const response = await gameService.search(params)

        state.items = response.data.items
        state.totalItems = response.data.totalItems
        state.itemsLength = response.data.pageSize
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
