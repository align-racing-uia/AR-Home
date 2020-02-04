<template>
        <v-row>
            <span class="bg"></span>

            <v-col cols="5">
                <v-card dark height="100%">
                    <v-img
                            class="mt-8"
                            contain
                            height="230px"
                            src="../assets/ar_white.png"
                    >
                    </v-img>

                </v-card>
            </v-col>

            <v-col cols="7">
                <v-card dark>
                    <v-card-title>Project Overview</v-card-title>
                </v-card>

                <v-row>
                    <v-col cols="4">
                        <v-card class="text-center">
                            <v-progress-circular
                                    :value="value"
                                    size="250"
                                    color="#F8AF3C"
                                    width="25"
                                    class="my-6"
                            >
                                <p class="my-2" style="font-size: 36px; font-weight: bold">{{ value }}%</p>
                            </v-progress-circular>
                        </v-card>
                    </v-col>

                    <v-col>
                        <v-card
                                class="text-center"
                                height="100%"
                        >
                            <v-sparkline
                                    type="bar"
                                    :value="values"
                                    auto-line-width
                                    show-labels
                                    color="#F8AF3C"
                                    class="my-12"
                            >

                            </v-sparkline>
                        </v-card>
                    </v-col>
                </v-row>

            </v-col>



            <v-col cols="6">
                <v-card dark>
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
                <v-card dark>
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
        name: 'info3',
        data() {
            return {
                value: 37,
                values: [20, 70, 30, 50, 60, 50, 100],
                time: new Date(),
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
    .row {
        margin-bottom: -12px;
    }
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
    .v-data-table {
        margin: 5px;
    }
    table {
        padding: 5px;
        margin: 30px;
    }

    th {
        font-family: Quicksand;
        font-size: 42px;
        text-transform: lowercase;
        margin-bottom: 20px;
    }

    thead tr {
        background: linear-gradient(90deg, rgba(239,105,38,1) 0%, rgba(234,91,39,1) 100%);

    }

    td {
        font-family: Quicksand;
        font-size: 34px;
        padding: 5px;
    }

    tr:nth-child(odd) {
        background-color: #333333;
    }

    tr:nth-child(even) {
        background-color: #000000;
    }
</style>