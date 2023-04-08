<template>

    <v-breadcrumbs
        :items="breadcrumbs"
        divider="-"
        class="pl-0 pb-0 pt-2 text-uppercase">

        <template v-slot:divider>
            <v-icon icon="mdi-chevron-right"></v-icon>
        </template>
        
    </v-breadcrumbs>
    
</template>

<script setup>

import { computed } from 'vue'
import { useRoute } from 'vue-router'

const route = useRoute()

const breadcrumbs = computed(() => {
    const paths = route.path.split('/').filter(path => path)

    return paths.map((path, index) => ({
        text: path,
        disabled: index === paths.length - 1,
        to: `/${paths.slice(0, index + 1).join('/')}`,
        class: index === 0 ? 'pl-0' : ''
    }))
})

</script>