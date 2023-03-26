<template>
  
  <v-app-bar color="primary">
    <v-app-bar-nav-icon icon="mdi-gamepad"></v-app-bar-nav-icon>
    <v-app-bar-title>Final Boss Administration</v-app-bar-title>
    <v-spacer></v-spacer>
    <v-btn icon>
      <v-icon>mdi-magnify</v-icon>
    </v-btn>
    <v-btn icon>
      <v-icon>mdi-dots-vertical</v-icon>
    </v-btn>
  </v-app-bar>

  <v-navigation-drawer color="grey-lighten-2">
    <v-list density="compact" nav>
      <v-list-subheader>PLATFORM</v-list-subheader>
      <v-list-item prepend-icon="mdi-controller" title="Games" value="games"></v-list-item>
      <v-list-item prepend-icon="mdi-gamepad-outline" title="Game Modes" value="game-modes"></v-list-item>
      <v-list-item prepend-icon="mdi-select-group" title="Genres" value="genres"></v-list-item>
      <v-list-item prepend-icon="mdi-image" title="Media" value="media"></v-list-item>
      <v-list-item prepend-icon="mdi-nintendo-game-boy" title="Platforms" value="platforms"></v-list-item>
      <v-list-item prepend-icon="mdi-domain" title="Companies" value="companies"></v-list-item>
      <v-list-item prepend-icon="mdi-account-child" title="Age Ratings" value="age-ratings"></v-list-item>
    </v-list>
    <v-divider></v-divider>
    <v-list density="compact" nav>
      <v-list-subheader>ADMINISTRATION</v-list-subheader>
      <v-list-item prepend-icon="mdi-account-group" title="Users" value="users"></v-list-item>
      <v-list-item prepend-icon="mdi-cog" title="Settings" value="settings"></v-list-item>
    </v-list>
  </v-navigation-drawer>

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