<template>
    <v-data-table
            :headers="headers"
            :items="events"
            sort-by="calories"
            class="elevation-8"
    >
        <template v-slot:top>
            <v-toolbar flat color="white">
                <v-toolbar-title>AR Information Display</v-toolbar-title>
                <v-divider
                        class="mx-4"
                        inset
                        vertical
                ></v-divider>
                <v-spacer></v-spacer>
                <v-dialog v-model="dialog" max-width="500px">
                    <template v-slot:activator="{ on }">
                        <v-btn color="primary" dark class="mb-2" v-on="on">New Event</v-btn>
                    </template>
                    <v-card>
                        <v-card-title>
                            <span class="headline">{{ formTitle }}</span>
                        </v-card-title>

                        <v-card-text>
                            <v-container>
                                <v-row>
                                    <v-col cols="12">
                                        <v-text-field v-model="editedEvent.title" label="Event title"
                                                      required></v-text-field>
                                    </v-col>

                                    <v-col cols="12" sm="6">
                                        <v-autocomplete
                                                :items="['Deadline', 'IMech', 'Event']"
                                                label="Type"
                                                v-model="editedEvent.type"
                                        ></v-autocomplete>
                                    </v-col>

                                    <v-col cols="12" sm="6">
                                        <v-autocomplete
                                                :items="['Align Racing - All', 'Board', 'Financial', 'IT', 'Marketing', 'HR', 'Technical - All', 'Chassis', 'Suspension', 'Powertrain', 'Electronical', 'Aero']"
                                                label="Group"
                                                v-model="editedEvent.group"
                                        ></v-autocomplete>
                                    </v-col>

                                    <v-col cols="12" md="6">
                                        <v-menu
                                                v-model="menu"
                                                :close-on-content-click="false"
                                                :nudge-right="40"
                                                transition="scale-transition"
                                                offset-y
                                                min-width="290px"
                                        >
                                            <template v-slot:activator="{ on }">
                                                <v-text-field
                                                        v-model="editedEvent.date"
                                                        label="Date"
                                                        prepend-icon="event"
                                                        readonly
                                                        v-on="on"
                                                ></v-text-field>
                                            </template>
                                            <v-date-picker v-model="editedEvent.date"
                                                           @input="menu = false"></v-date-picker>
                                        </v-menu>
                                    </v-col>

                                    <v-col cols="12" md="6">
                                        <v-menu
                                                ref="menu"
                                                v-model="menu2"
                                                :close-on-content-click="false"
                                                :nudge-right="40"
                                                :return-value.sync="time"
                                                transition="scale-transition"
                                                offset-y
                                                max-width="290px"
                                                min-width="290px"
                                        >
                                            <template v-slot:activator="{ on }">
                                                <v-text-field
                                                        v-model="editedEvent.time"
                                                        label="Start"
                                                        prepend-icon="access_time"
                                                        readonly
                                                        v-on="on"
                                                ></v-text-field>
                                            </template>
                                            <v-time-picker
                                                    v-if="menu2"
                                                    v-model="editedEvent.time"
                                                    format="24hr"
                                                    full-width
                                                    @click:minute="$refs.menu.save(time)"
                                            ></v-time-picker>
                                        </v-menu>
                                    </v-col>
                                </v-row>
                            </v-container>
                        </v-card-text>

                        <v-card-actions>
                            <v-spacer></v-spacer>
                            <v-btn color="blue darken-1" text @click="close">Cancel</v-btn>
                            <v-btn color="blue darken-1" text @click="save">Save</v-btn>
                        </v-card-actions>
                    </v-card>
                </v-dialog>
            </v-toolbar>
        </template>
        <template v-slot:item.action="{ item }">
            <v-icon
                    small
                    class="mr-2"
                    @click="editItem(item)"
            >
                edit
            </v-icon>
            <v-icon
                    small
                    @click="deleteItem(item)"
            >
                delete
            </v-icon>
        </template>
    </v-data-table>
</template>

<script>
    export default {
        data: () => ({
            dialog: false,
            menu: false,
            menu2: false,
            headers: [
                {
                    text: 'Title',
                    align: 'left',
                    sortable: false,
                    value: 'title',
                },
                {text: 'Date', value: 'date'},
                {text: 'Time', value: 'time'},
                {text: 'Type', value: 'type'},
                {text: 'Group', value: 'group'},
                {text: 'Actions', value: 'action', sortable: false},
            ],
            events: [],
            editedIndex: -1,
            editedEvent: {
                title: '',
                date: new Date().toISOString().substr(0, 10),
                time: null,
                type: 0,
                group: 0,
            },
            defaultEvent: {
                title: '',
                date: new Date().toISOString().substr(0, 10),
                time: null,
                type: 0,
                group: 0,
            },
        }),

        computed: {
            formTitle() {
                return this.editedIndex === -1 ? 'New Event' : 'Edit Event'
            },
        },

        watch: {
            dialog(val) {
                val || this.close()
            },
        },

        created() {
            this.getEvents()
        },

        methods: {
            getEvents() {
                this.axios
                    .get(this.$store.getters.api + "/info/events")
                    .then(response => {
                        this.events = response.data;
                    });
            },

            editItem(item) {
                this.editedIndex = this.events.indexOf(item)
                this.editedEvent = Object.assign({}, item)
                this.dialog = true
            },

            deleteItem(item) {
                const index = this.events.indexOf(item)
                confirm('Are you sure you want to delete this item?') && this.events.splice(index, 1)
            },

            close() {
                this.dialog = false
                setTimeout(() => {
                    this.editedEvent = Object.assign({}, this.defaultEvent)
                    this.editedIndex = -1
                }, 300)
            },

            save() {
                if (this.editedIndex > -1) {
                    Object.assign(this.events[this.editedIndex], this.editedEvent)
                } else {
                    this.events.push(this.editedEvent)
                }
                this.close()
            },
        },
    }
</script>