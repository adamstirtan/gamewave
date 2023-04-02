<template>
    <ListHeader title="Games">
        <template #actions>
            <v-btn
                to="/admin/addgame"
                variant="outlined">
                Add Game
            </v-btn>
        </template>
    </ListHeader>
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
            :loading="state.loading"
            :items="state.items"
            :items-length="state.itemsLength"
            :total-items="state.totalItems"
            :sort-by.sync="state.options.sortBy"
            :sort-desc.sync="state.options.sortDesc"
            @update:options="onUpdateOptions"
            @update:page="onUpdatePage"
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

import { reactive, watch } from 'vue'
import { VDataTableServer } from 'vuetify/labs/VDataTable'

import ListHeader from '@/components/admin/ListHeader'
import GameService from '@/services/GameService'

const state = reactive({
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
    loading: false,
    itemsLength: 0,
    totalItems: 0,
    options: {
        sortBy: ['name'],
        sortDesc: ['desc'],
        page: 1,
        itemsPerPage: 10,
    },
    serverItemsLength: 0
})

const gameService = new GameService()

async function onUpdateOptions(options) {
    state.options = options

    await fetchData()
}

// TODO: is this needed with the method above?
function onUpdatePage(page) {
    state.options.page = page
}

async function fetchData() {
    state.loading = true
    
    const params = {
        sort: state.options.sortBy[0],
        //ascending: state.options.sortDesc[0],
        page: state.options.page,
        pageSize: state.options.itemsPerPage,
        paged: true
    }
    debugger;

    try {
        const response = await gameService.search(params)

        state.items = response.data.items
        state.totalItems = response.data.totalItems
        state.itemsLength = response.data.pageSize
        state.options.sortBy[0] = response.data.sort

        state.options.sortDesc = [response.data.ascending]
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

<style scoped>

.fb-header {
    margin: 1rem;
}
</style>