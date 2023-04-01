<template>
    <ListHeader title="Games" />
    <div class="pa-5">
        <v-row>
            <v-col cols="4">
                <v-text-field
                    label="Search..."
                    prepend-inner-icon="mdi-magnify"
                    outlined
                    clearable>
                </v-text-field>
            </v-col>
            <v-col cols="8" class="text-right">
                <v-btn
                    to="/admin/addgame">
                    Add Game
                </v-btn>
            </v-col>
        </v-row>
        <v-data-table-server
            :headers="state.headers"
            :items="state.items"
            :items-length="state.itemsLength"
            :loading="state.loading"
            :total-items="state.totalItems"
            :options.sync="state.options"
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

import { reactive, watch, computed } from 'vue'
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
        sortBy: ['created'],
        sortDesc: [false],
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
        sort: computed(() => state.options.sortBy || ['created']).value,
        ascending: computed(() => state.options.sortDesc || [false]).value,
        page: state.options.page,
        pageSize: state.options.itemsPerPage,
        paged: true
    }

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