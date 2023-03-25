<template>
    <v-app-bar color="grey-lighten-2"></v-app-bar>
        <v-navigation-drawer color="grey-darken-2" permanent></v-navigation-drawer>
        <v-main>
            <slot></slot>
        </v-main>
</template>

<script setup>

</script>

<script>
  export default {
    name: 'AdminLayout'
  }
</script>