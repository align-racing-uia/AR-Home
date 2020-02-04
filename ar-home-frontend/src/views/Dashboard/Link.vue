<template>
    <v-row>
        <v-col>
            <link-list></link-list>
        </v-col>
    </v-row>
</template>

<script>
    import LinkList from "../../components/Dashboard/LinkList";

    export default {
        name: 'link',
        components: {
            LinkList,
        }
    }
</script>


<style>
    v-card {
        margin-left: 200px;
        padding-left: 200px;
    }
</style>