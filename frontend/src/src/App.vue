<template>
  <v-app>

    <v-app-bar app
      density="comfortable"
      color="light-blue-darken-4"
      :flat="true">

      <v-icon class="mx-4" large>
          mdi-gamepad-square
        </v-icon>

      <v-toolbar-title>
        Final Boss
      </v-toolbar-title>

      <v-spacer></v-spacer>

        <v-btn icon>
          <v-icon>mdi-plus</v-icon>
        </v-btn>

    </v-app-bar>

    <v-navigation-drawer nav rail color="blue-grey-lighten-4">
      <v-list>
        <v-list-item prepend-icon="mdi-home" title="Home" value="home"></v-list-item>
        <v-list-item prepend-icon="mdi-gamepad" title="Games" value="home"></v-list-item>
        <v-list-item prepend-icon="mdi-home" title="Home" value="home"></v-list-item>
        <v-list-item prepend-icon="mdi-home" title="Home" value="home"></v-list-item>
      </v-list>
    </v-navigation-drawer>

    <v-main>
      <router-view />
      <Game />
    </v-main>

  </v-app>
</template>

<script setup lang="ts">
  import Game from '@/components/Game.vue'
</script>
