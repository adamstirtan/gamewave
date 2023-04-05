<template>
    <component :is="layout">
        <router-view />
    </component>
</template>

<script setup>
    import { computed } from 'vue'
    import { useRoute } from 'vue-router'

    const route = useRoute()
    
    const layout = computed(() => {
        const file = route?.meta?.layout
        
        if (file) {
            return `${file}Layout`
        }

        return 'div'
    })
</script>

<script>
  export default {
    name: 'AppLayout'
  }
</script>