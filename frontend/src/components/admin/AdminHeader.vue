<template>
    <div class="mx-0 my-0 pa-6 bg-grey-lighten-2 elevation-1">
        <v-row>
            <v-col>
                <div class="text-h4 text-grey-darken-3 font-weight-bold">
                    {{ title }}
                </div>
                <AdminBreadcrumbs></AdminBreadcrumbs>
            </v-col>
            <v-col
                align-self="center"
                class="text-right">
                <slot name="actions"></slot>
            </v-col>
        </v-row>
    </div>
</template>

<script setup>

import AdminBreadcrumbs from '@/components/admin/AdminBreadcrumbs'

const props = defineProps({
    title: {
        type: String,
        required: true
    }
})

</script>
