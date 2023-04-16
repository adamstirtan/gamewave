<template>
    <v-sheet color="grey-lighten-3">
        <v-row class="px-6 py-5">
            <v-col>
                <v-btn
                    prepend-icon="mdi-arrow-left"
                    variant="plain"
                    @click="$router.go(-1)"
                    class="pl-1">
                    Back
                </v-btn>
                <div class="text-h4">
                    {{ title }}
                </div>
            </v-col>
            <v-col
                align-self="center"
                class="text-right">
                <slot name="actions"></slot>
            </v-col>
        </v-row>
    </v-sheet>
</template>

<script setup>

const props = defineProps({
    title: {
        type: String,
        required: true
    }
})

</script>
