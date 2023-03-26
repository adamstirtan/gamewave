<script setup>
    defineProps(['name', 'description'])
</script>

<template>
    <h1>{{ name }}</h1>
    <p>{{ description }}</p>
</template>