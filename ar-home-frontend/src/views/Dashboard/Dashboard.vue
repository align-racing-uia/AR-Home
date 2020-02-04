<template>
    <v-row>
        <v-col cols="12" sm="6" lg="4" xl="3">
            <test-card1></test-card1>
        </v-col>
        <v-col cols="12" sm="6" lg="4" xl="3">
            <test-card1></test-card1>
        </v-col>
        <v-col cols="12" sm="6" lg="4" xl="3">
            <test-card1></test-card1>
        </v-col>
        <v-col cols="12" sm="6" lg="4" xl="3">
            <test-card1></test-card1>
        </v-col>
        <v-col cols="12" lg="8" xl="6">
            <event-calendar></event-calendar>
        </v-col>

        <v-col>
            <test-card2></test-card2>
        </v-col>
        <v-col>
            <test-card2></test-card2>
        </v-col>
    </v-row>
</template>

<script>
    import TestCard1 from '../../components/Dashboard/TestCard1'
    import TestCard2 from "../../components/Dashboard/TestCard2";
    import EventCalendar from "../../components/Dashboard/EventCalendar";
    
    export default {
        name: 'dashboard',
        components: {
            TestCard1,
            TestCard2,
            EventCalendar
        }
    }
</script>