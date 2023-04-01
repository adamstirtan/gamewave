<template>
    <div class="fb-header mx-0 my-0 pa-6">
        <span class="text-h4">{{ title }}</span>
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

<style scoped>
    .fb-header {
        background-color: #f0f0f0;
        width: 100%;
    }
</style>