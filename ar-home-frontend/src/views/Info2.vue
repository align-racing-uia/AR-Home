<template>
    <v-row class="ar-grid">
        <span class="bg"></span>
        <v-col cols="6">
            <v-card dark height="504px">
                <v-img
                        class="mt-8"
                        contain
                        height="250px"
                        src="../assets/ar_white.png"
                >
                </v-img>
            </v-card>
        </v-col>

        <v-col cols="6">
            <v-card dark height="504px">
                <v-card-title>Project Overview</v-card-title>
                <v-row
                        align="stretch"
                        justify="space-around"
                        class="my-12"
                >
                    <v-col cols="3">
                        <v-progress-circular
                                :value="value"
                                size="200"
                                color="orange"
                                width="25"
                        >
                            <p class="my-2" style="font-size: 36px; font-weight: bold">{{ value }}%</p>
                        </v-progress-circular>
                    </v-col>
                    <v-col cols="6">
                        <v-sparkline
                                type="bar"
                                :value="values"
                                auto-line-width
                                show-labels
                                color="orange"
                                class="my-5"
                        >

                        </v-sparkline>
                    </v-col>
                </v-row>
            </v-card>
        </v-col>
        <v-col cols="6">
            <v-card dark height="504px">
                <v-card-title>Deadlines</v-card-title>
                <v-simple-table dark>
                    <thead>
                    <tr>
                        <th class="text-left">Date</th>
                        <th class="text-left">Time</th>
                        <th class="text-left">Event</th>
                        <th class="text-left">Location</th>
                    </tr>
                    </thead>
                    <tbody>
                    <tr v-for="event in getDeadlines" :key="event.name">
                        <td>{{ event.date }}</td>
                        <td>{{ event.time }}</td>
                        <td>{{ event.event }}</td>
                        <td>{{ event.location }}</td>
                    </tr>
                    </tbody>
                </v-simple-table>
            </v-card>
        </v-col>
        <v-col cols="6">
            <v-card dark height="504px">
                <v-card-title>Events</v-card-title>
                <v-simple-table dark>
                    <template v-slot:default>
                        <thead>
                        <tr>
                            <th class="text-left">Date</th>
                            <th class="text-left">Time</th>
                            <th class="text-left">Event</th>
                            <th class="text-left">Location</th>
                        </tr>
                        </thead>
                        <tbody>
                        <tr v-for="event in getEvents" :key="event.name">
                            <td>{{ event.date }}</td>
                            <td>{{ event.time }}</td>
                            <td>{{ event.event }}</td>
                            <td>{{ event.location }}</td>
                        </tr>
                        </tbody>
                    </template>
                </v-simple-table>
            </v-card>
        </v-col>
    </v-row>
</template>

<script>
    export default {
        name: 'info2',
        data() {
            return {
                value: 37,
                values: [20, 70, 30, 50, 60, 50, 100],
                events: [
                    {
                        date: '3/10',
                        time: '20:00',
                        event: 'Quiz',
                        location: 'Bluebox',
                        type: 'Event'
                    },
                    {
                        date: '3/10',
                        time: '20:00',
                        event: 'Quiz',
                        location: 'Bluebox',
                        type: 'Event'
                    },
                    {
                        date: '3/10',
                        time: '20:00',
                        event: 'Quiz',
                        location: 'Bluebox',
                        type: 'Event'
                    },
                    {
                        date: '3/10',
                        time: '20:00',
                        event: 'Konseptpresentasjon',
                        location: 'C2 036',
                        type: 'Deadline'
                    },
                    {
                        date: '3/10',
                        time: '20:00',
                        event: 'Konseptpresentasjon',
                        location: 'C2 036',
                        type: 'Deadline'
                    },
                    {
                        date: '3/10',
                        time: '20:00',
                        event: 'Konseptpresentasjon',
                        location: 'C2 036',
                        type: 'Deadline'
                    },
                    {
                        date: '3/10',
                        time: '20:00',
                        event: 'Quiz',
                        location: 'Bluebox',
                        type: 'Event'
                    },
                    {
                        date: '3/10',
                        time: '20:00',
                        event: 'Quiz',
                        location: 'Bluebox',
                        type: 'Event'
                    },
                    {
                        date: '3/10',
                        time: '20:00',
                        event: 'Quiz',
                        location: 'Bluebox',
                        type: 'Event'
                    },
                    {
                        date: '3/10',
                        time: '20:00',
                        event: 'Konseptpresentasjon',
                        location: 'C2 036',
                        type: 'Deadline'
                    },
                    {
                        date: '3/10',
                        time: '20:00',
                        event: 'Konseptpresentasjon',
                        location: 'C2 036',
                        type: 'Deadline'
                    },
                    {
                        date: '3/10',
                        time: '20:00',
                        event: 'Konseptpresentasjon',
                        location: 'C2 036',
                        type: 'Deadline'
                    },
                ],
            }
        },
        computed: {
            getEvents: function () {
                return this.events.filter(function (e) {
                    return e.type == 'Event'
                })
            },
            getDeadlines: function () {
                return this.events.filter(function (e) {
                    return e.type == 'Deadline'
                })
            }
        },
        components: {

        }
    }
</script>

<style scoped>

    .bg {
        width: 100%;
        height: 100%;
        position: absolute;
        top: 0;
        left: 0;
        background: url('../assets/bg_info.png') no-repeat center center;
        background-size: cover;
        background-color: black;
        transform: scale(1.1);
    }

    /* Card styling */
    .v-card {
        background-color: rgb(0, 0, 0, 0.35);
    }

    /* Text styling */
    .v-card__title {
        text-transform: uppercase;
        font-family: Quicksand;
        font-size: 56px;
        font-weight: bolder;
        line-height: normal;
        color: #EF6926;
    }

    .v-card__subtitle {
        font-family: Quicksand;
        font-size: 42px;
        line-height: normal;
    }

    .v-card__text {
        font-family: Quicksand;
        font-size: 34px;
        line-height: normal;
    }


    /* Table styling */
    th {
        font-family: Quicksand;
        font-size: 42px;
        text-transform: lowercase;
    }

    thead tr {
        background: linear-gradient(90deg, rgba(239,105,38,1) 0%, rgba(234,91,39,1) 100%);
    }

    td {
        font-family: Quicksand;
        font-size: 34px;
    }

    tr:nth-child(odd) {
        background-color: #333333;
    }

    tr:nth-child(even) {
        background-color: #000000;
    }

    .ar-grid.row  {
        margin: 0px;
    }

</style>