<template>
    <div class="mx-0 my-0 pa-8 bg-grey-lighten-3 elevation-2">
        <v-row>
            <v-col cols="8">
                <span class="text-h4">{{ title }}</span>
            </v-col>
            <v-col cols="4" class="text-right">
                <slot name="actions"></slot>
            </v-col>
        </v-row>
    </div>
</template>

<script setup>
const props = defineProps({
    title: {
        type: String,
        required: true
    }
})
</script>
