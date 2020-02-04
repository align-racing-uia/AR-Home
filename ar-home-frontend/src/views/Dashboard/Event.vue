<template>
    <v-row>
        <v-col cols="12" xl="6">
            <event-list></event-list>
        </v-col>
        <v-col cols="12" xl="6">
            <event-calendar></event-calendar>
        </v-col>
    </v-row>
</template>

<script>
    import EventList from "../../components/Dashboard/EventList";
    import EventCalendar from "../../components/Dashboard/EventCalendar";

    export default {
        name: 'event',
        components: {
            EventList,
            EventCalendar
        }
    }
</script>
