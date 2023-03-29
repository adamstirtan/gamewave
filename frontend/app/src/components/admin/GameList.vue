<template>
    <div class="root">
        <v-row>
            <v-col cols="12" md="8">
                <v-data-table
                    :headers="state.headers"
                    :items="state.records"
                    class="elevation-1">
                </v-data-table>
            </v-col>
            <v-col cols="12" md="4">
                <v-card>
                    <v-card-title>Add Game</v-card-title>
                    <v-card-subtitle>Create a new game</v-card-subtitle>
                    <v-card-text>
                        Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur ipsum erat, bibendum eu dignissim vel, blandit sed massa. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas.
                    </v-card-text>
                    <v-card-actions>
                        <v-btn to="/admin/addgame">Add Game</v-btn>
                    </v-card-actions>
                </v-card>
            </v-col>
        </v-row>
    </div>
</template>

<script setup>
    import { reactive, onMounted } from 'vue'
    import { VDataTable } from 'vuetify/labs/VDataTable'

    import GameService from '@/services/GameService'
    
    const state = reactive({
        headers: [
            { text: 'ID', value: 'id' },
            { text: 'Name', value: 'name' }
        ],
        records: []
    })

    onMounted(() => {
      GameService
        .getAll()
        .then(response => {
            state.records = response.data
        })
        .catch(e => {
          console.error(e)
        })
    })
</script>

<style scoped>
    .root {
        padding: 2rem;
    }
</style>