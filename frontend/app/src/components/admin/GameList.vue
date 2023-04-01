<template>
    <div class="root">
        <v-row>
            <v-col cols="12" md="4">
                <v-text-field
                    label="Search Games...">
                </v-text-field>
            </v-col>
            <v-col cols="12" md="8" class="text-right">
                <v-btn to="/admin/addgame" variant="tonal">
                    Add Game
                </v-btn>
            </v-col>
        </v-row>
        <v-data-table-server
            :headers="state.headers"
            :items="state.items"
            :loading="state.loading"
            :items-length="1"
            :total-items="state.totalItems"
            :options.sync="state.options"
            @server-item-length="onServerItemLength"
            @server-items="onServerItems">
        </v-data-table-server>
    </div>
</template>

<script setup>
import { reactive, onMounted } from 'vue'
import { VDataTableServer } from 'vuetify/labs/VDataTable'

import GameService from '@/services/GameService'

const state = reactive({
    items: [],
    headers: [
        { text: 'ID', value: 'id' },
        { text: 'Name', value: 'name' }
    ],
    loading: true,
    totalItems: 0,
    options: {
      sortBy: ['name'],
      sortDesc: [false],
      page: 1,
      itemsPerPage: 25,
    }
})

onMounted(() => {
    // GameService
    //     .getAll()
    //     .then(response => {
    //         state.items = response.data
    //         state.totalItems = state.items.length;
    //     })
    //     .catch(e => {
    //         console.error(e)
    //     })
    //     .finally(() => {
    //         state.loading = false
    //     })
})

function onServerItemLength(length) {
    state.totalItems = length
}

function onServerItems(params) {
    const { sortBy, ascending, page, itemsPerPage } = params;
    const query = `?sort=${sortBy}&ascending=${ascending}&page=${page}&pageSize=${itemsPerPage}`;

    loading.value = true;
    axios.get(`/api/items${query}`).then(({ data }) => {
        items.value = data.data
        loading.value = false
    })
}
</script>

<style scoped>
.root {
    padding: 2rem;
}
</style>