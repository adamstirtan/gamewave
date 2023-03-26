<template>
    <v-form v-model="valid" class="px-4 py-4">

        <h1>Add Game</h1>

        <v-row>
            <v-col cols="12" md="6">
                <v-text-field
                    v-model="name"
                    :value="name"
                    :counter="255"
                    label="Name"
                ></v-text-field>
            </v-col>
        </v-row>

        <v-row>
            <v-col cols="12" md="12">
                <v-textarea
                    v-model="description"
                    :value="description"
                    label="Description"
                ></v-textarea>
            </v-col>
        </v-row>

        <!-- <v-row>
            <v-col cols="12" md="4">
                <v-text-field
                    v-model="name"
                    :value="name"
                    :counter="255"
                    label="Name"
                ></v-text-field>
            </v-col>
            <v-col cols="12" md="4">
                <v-text-field
                    v-model="name"
                    :value="name"
                    :counter="255"
                    label="Name"
                ></v-text-field>
            </v-col>
            <v-col cols="12" md="4">
                <v-text-field
                    v-model="name"
                    :value="name"
                    :counter="255"
                    label="Name"
                ></v-text-field>
            </v-col>
        </v-row> -->

        <v-card-actions>
    <v-spacer></v-spacer>
    <v-btn to="/">
      Cancel
    </v-btn>
    <v-btn type="submit" color="primary" :disabled="!valid">
      Save
    </v-btn>
  </v-card-actions>
    </v-form>
</template>

<script setup>
    import { ref } from 'vue'
    import PlatformService from '@/services/PlatformService';

    const valid = ref(false)
    const name = ref('')
    const description = ref('')

    function hide() {

    }

    const platforms = PlatformService
        .getAll()
        .then(response => {
            console.log(response)
        })
        .catch(e => {
            console.log(e)
        })

</script>