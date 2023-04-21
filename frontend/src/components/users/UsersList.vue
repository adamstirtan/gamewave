<template>
    
    <AdminHeader title="Users">
        <template #actions>
            
            <v-btn
                to="/users/add"
                append-icon="mdi-plus-box"
                color="success">
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
            @update:options="onUpdateOptions"
            class="elevation-1">

            <template v-slot:item.userName="{ item }">
                <router-link :to="`/users/${item.raw.id}`">{{ item.raw.userName }}</router-link>
             </template>

             <template v-slot:item.lastModified="{ item }">
                <span>{{ new Date(Date.parse(item.raw.lastModified)).toLocaleString() }}</span>
            </template>

            <template v-slot:item.created="{ item }">
                <span>{{ new Date(Date.parse(item.raw.created)).toLocaleString() }}</span>
            </template>

        </v-data-table-server>
    </v-card>

    <v-snackbar
        v-model="state.snackbar">
        {{ state.snackbarText }}
        <template v-slot:actions>
            <v-btn
                color="red"
                @click="state.snackbar = false">
                Close
            </v-btn>
        </template>
    </v-snackbar>

</template>

<script setup>

import { reactive, computed } from 'vue'
import { VDataTableServer } from 'vuetify/labs/VDataTable'

import AdminHeader from '@/components/admin/AdminHeader'
import UserService from '@/services/UserService'

const state = reactive({
    loading: false,
    snackbar: false,
    snackbarText: '',
    headers: [
        {
            title: 'User Name',
            key: 'userName',
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

const userService = new UserService()

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

    userService.search(params)
        .then(response => {
            state.items = response.data.items
            state.itemsLength = response.data.totalItems
        })
        .catch(e => {
            state.snackbarText = e
            state.snackbar = true
        })
        .finally(() => {
            state.loading = false
        })
}

</script>
