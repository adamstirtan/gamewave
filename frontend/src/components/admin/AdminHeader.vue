<template>
    <div class="mx-0 my-0 pa-6 bg-grey-lighten-3">
        <v-row>
            <v-col>
                <div class="text-h4">
                    {{ title }}
                </div>
                <v-btn
                    prepend-icon="mdi-arrow-left"
                    variant="plain"
                    @click="$router.go(-1)"
                    class="pl-1">
                    Back
                </v-btn>
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

const props = defineProps({
    title: {
        type: String,
        required: true
    }
})

</script>
