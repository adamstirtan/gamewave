<template>

  <v-app-bar
    color="#3F88C5"
    theme="dark"
    class="elevation-0">

    <v-app-bar-nav-icon
      icon="mdi-menu"
      @click.stop="showDrawer = !showDrawer"
    ></v-app-bar-nav-icon>
    
    <v-app-bar-title class="font-weight-bold">GameWave</v-app-bar-title>

    <v-spacer></v-spacer>

    <v-btn icon>
      <v-icon>mdi-magnify</v-icon>
    </v-btn>

  </v-app-bar>

  <v-navigation-drawer
    class="elevation-1"
    theme="dark"
    color="#393E41">

    <v-list nav>
      <v-list-item to="/admin" prepend-icon="mdi-view-dashboard" title="Collection" value="collection"></v-list-item>
      <v-list-item to="/admin/games" prepend-icon="mdi-controller" title="Games" value="games"></v-list-item>
      <v-list-item to="/admin/platform" prepend-icon="mdi-nintendo-game-boy" title="Platforms" value="platforms"></v-list-item>
      <v-list-item to="/admin/company" prepend-icon="mdi-domain" title="Companies" value="companies"></v-list-item>
      <v-list-item to="/admin/users" prepend-icon="mdi-account-group" title="Users" value="users"></v-list-item>
    </v-list>

    <template v-slot:append>
      <v-divider></v-divider>
      <v-list>
        <v-list-item
          prepend-avatar="/profile.jpg"
          title="Adam Stirtan">
          <template v-slot:append>
            <v-btn
              icon="mdi-menu-up"
              size="small"
              variant="text">
            </v-btn>
          </template>
        </v-list-item>
      </v-list>
    </template>

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
