<template>
    <v-col cols="12" sm="6" md="4" xl="3">
        <v-hover v-slot:default="{ hover }">
            <v-card
                    hover
                    outlined
                    height="100%"
            >
                <v-card-title v-text="link.name"></v-card-title>
                <v-card-text v-text="link.text"></v-card-text>
                <v-card-actions>
                    <v-btn
                            block
                            outlined
                            color="#EF6926"
                            :href="link.url"
                    >GO</v-btn>
                </v-card-actions>
            </v-card>
        </v-hover>


    </v-col>
</template>

<script>
    export default {
        props: {
            link: Object
        }
    };
</script>

<style>
    .v-card {
        padding: 5px;
    }
</style>