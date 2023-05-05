<template>

  <v-app-bar
    color="primary"
    class="elevation-0">

    <v-app-bar-nav-icon to="/" icon="mdi-sine-wave"></v-app-bar-nav-icon>
    <v-app-bar-title class="font-weight-bold">GameWave</v-app-bar-title>

    <v-spacer></v-spacer>

    <v-menu>
      <template v-slot:activator="{ props }">
        <v-btn icon="mdi-dots-vertical" v-bind="props"></v-btn>
      </template>
      <v-list>
        <v-list-item to="/auth/logout" prepend-icon="mdi-logout">
          <v-list-item-title>Logout</v-list-item-title>
        </v-list-item>
      </v-list>
    </v-menu>

  </v-app-bar>

  <v-navigation-drawer
    class="elevation-1"
    theme="light"
    permanent>

    <v-list nav>
      <v-list-item to="/" prepend-icon="mdi-view-dashboard" title="Dashboard" value="dashboard"></v-list-item>
      <v-list-item to="/games" prepend-icon="mdi-controller" title="Games" value="games"></v-list-item>
      <v-list-item to="/platform" prepend-icon="mdi-nintendo-game-boy" title="Platforms" value="platforms"></v-list-item>
      <v-list-item to="/company" prepend-icon="mdi-domain" title="Companies" value="companies"></v-list-item>
      <v-list-item to="/users" prepend-icon="mdi-account-group" title="Users" value="users"></v-list-item>
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
  name: 'AppLayout'
}

</script>
