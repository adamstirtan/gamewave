<template>
    <v-sheet
        class="ma-5">
        <Bar
            v-if="state.loaded"
            height="200px"
            :options="state.chartOptions"
            :data="state.chartData"
        />
    </v-sheet>
</template>

<script setup>

import { reactive, onMounted } from 'vue'
import { Bar } from 'vue-chartjs'
import { Chart as ChartJS, Title, Tooltip, Legend, BarElement, CategoryScale, LinearScale } from 'chart.js'

import DashboardService from '@/services/DashboardService'

ChartJS.register(Title, Tooltip, Legend, BarElement, CategoryScale, LinearScale)

const state = reactive({
    loaded: false,
    chartData: null,
    chartOptions: {
        responsive: true
    }
})

const dashboardService = new DashboardService()

onMounted(() => {
    state.loading = true

    dashboardService.getGamesByPlatform()
        .then(response => {
            const chartData = {
                labels: response.data.labels,
                datasets: [
                    {
                        label: 'Games by platform',
                        backgroundColor: '#cccccc',
                        data: response.data.values
                    }
                ]
            }
            state.chartData = chartData
        })
        .catch(e => {
            console.error(e)
        })
        .finally(() => {
            state.loaded = true
        })
})

</script>