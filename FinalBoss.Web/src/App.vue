<template>
  <v-app>
    <v-app-bar app color="primary">
      <v-icon class="mx-4" large>
          mdi-gamepad-square
        </v-icon>
      <v-toolbar-title>Final Boss</v-toolbar-title>
    </v-app-bar>
    <v-navigation-drawer app>
      <v-list>
        <v-list-item link>
          <v-list-item-content>
            <v-list-item-title>Popular</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
        <v-list-item link>
          <v-list-item-content>
            <v-list-item-title>Games</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
        <v-list-item link>
          <v-list-item-content>
            <v-list-item-title>Systems</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
      </v-list>

    </v-navigation-drawer>
    <v-main>
      <router-view />
    </v-main>
  </v-app>
</template>

<script setup lang="ts">

</script>
