<template>

</template>

<script setup>

import { onMounted } from 'vue'
import { useRouter } from 'vue-router'

import AuthenticationService from '@/services/AuthenticationService'

const router = useRouter()
const authenticationService = new AuthenticationService()

onMounted(() => {
    authenticationService.logout()
    router.push('/auth/login')
})

</script>