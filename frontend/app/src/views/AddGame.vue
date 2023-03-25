<template>
  <v-container class="root">
    <h1>Add Game</h1>
    <v-divider class="pb-8"></v-divider>
    <AddGame></AddGame>
  </v-container>
</template>

<script setup>
  import AddGame from '@/components/AddGame.vue'
</script>

<style>
  .root {
    padding: 2rem;
  }
</style>