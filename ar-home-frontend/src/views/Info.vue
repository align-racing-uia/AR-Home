<template>
    <v-row>
        <span class="bg"></span>
        <v-col cols="5">
            <v-card class="ar-card " height="100%">
                <v-img
                        class="mt-8"
                        contain
                        height="250px"
                        src="../assets/ar_white.png"
                >
                </v-img>

            </v-card>
        </v-col>

        <v-col cols="7">
            <v-card>
                <iframe frameborder="0" scrolling="no" marginheight="0" marginwidth="0" width="1086" height="454"
                        type="text/html"
                        src="https://www.youtube.com/embed/qSqoMHC5PUM?autoplay=0&fs=0&iv_load_policy=3&showinfo=0&rel=0&cc_load_policy=0&start=0&end=0&origin=https://youtubeembedcode.com">
                </iframe>
            </v-card>
        </v-col>

        <v-col cols="4">
            <v-card height="558px">
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
        <v-col cols="4">
            <v-card height="100%">
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
        <v-col cols="4">
            <v-card
                    height="100%"
                    dark
            >
                <v-img
                        height="250"
                        src="https://www.trondheimhandballcup.no/wp-content/uploads/sites/2/2015/01/Teen-party1.jpg"
                ></v-img>

                <v-card-title>Party at Bemagården</v-card-title>
                <v-card-subtitle>9. November kl 14:40</v-card-subtitle>

                <v-card-text>
                    <div>Small plates, salads & sandwiches an inteimate setting with 12 indoor seats plus patio
                        seating.
                    </div>
                </v-card-text>
            </v-card>
        </v-col>
    </v-row>
</template>

<script>
    export default {
        name: 'info',
        data() {
            return {
                showArrows: false,
                items: [
                    {
                        src: 'https://cdn.vuetifyjs.com/images/carousel/squirrel.jpg',
                    },
                    {
                        src: 'https://cdn.vuetifyjs.com/images/carousel/sky.jpg',
                    },
                    {
                        src: 'https://cdn.vuetifyjs.com/images/carousel/bird.jpg',
                    },
                    {
                        src: 'https://cdn.vuetifyjs.com/images/carousel/planet.jpg',
                    },
                ],
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
        background-color: red;
        transform: scale(1.1);
    }

    .v-card {
        background-color: rgb(0, 0, 0, 0.35);
    }

    .v-card__title {
        color: #EF6926;
        text-transform: uppercase;
        font-size: 48px;
        font-weight: bold;
        line-height: normal;
    }

    .v-card__subtitle {
        color: #F8AF3C;
        font-size: 36px;
        line-height: normal;
    }

    .v-card__text {
        font-size: 24px;
        line-height: normal;
    }

    .row {
        margin: 0;
    }


    .element::-webkit-scrollbar {
        width: 0 !important
    }

    .element {
        overflow: -moz-scrollbars-none;
    }

    .element {
        -ms-overflow-style: none;
    }


    th {
        font-size: 24px;
    }

    td {
        font-size: 18px;
    }



</style>