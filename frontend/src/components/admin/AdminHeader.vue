<template>
    <div class="mx-0 my-0 pa-8 bg-grey-lighten-2 elevation-1">
        <v-row>
            <v-col cols="8">
                <div>
                    <span class="text-h4 text-grey-darken-3 font-weight-bold">{{ title }}</span>
                </div>
                <div>
                    <AdminBreadcrumbs></AdminBreadcrumbs>
                </div>
            </v-col>
            <v-col cols="4" class="text-right">
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
