<template>
    <v-app id="inspire">
        <v-navigation-drawer
                v-model="drawer"
                app
                clipped
                dark
        >
            <v-img
                    src="../assets/AR_sidebar_bg.png"
                    height="100%"
            >
                <v-list
                        flat
                        nav
                >
                    <v-list-item
                            v-for="item in links"
                            :key="item.text"
                            :to="item.to"
                            color="orange"
                            link
                            exact
                    >
                        <v-list-item-action>
                            <v-icon>{{ item.icon }}</v-icon>
                        </v-list-item-action>
                        <v-list-item-content>
                            <v-list-item-title>
                                {{ item.text }}
                            </v-list-item-title>
                        </v-list-item-content>
                    </v-list-item>

                    <v-list-item
                            class="mt-4"
                            link
                            to="/"
                    >
                        <v-list-item-action>
                            <v-icon color="grey darken-1">mdi-arrow-left</v-icon>
                        </v-list-item-action>
                        <v-list-item-title class="grey--text text--darken-1">Back to Home</v-list-item-title>
                    </v-list-item>
                </v-list>

            </v-img>
        </v-navigation-drawer>

        <v-app-bar
                app
                clipped-left
                color="rgb(239, 105, 38)"
                dense
        >
            <v-app-bar-nav-icon @click.stop="drawer = !drawer"/>
            <v-icon class="mx-4">mdi-home</v-icon>


            <v-toolbar-title class="mr-12 align-center">
                <span class="title">Align Racing</span>
            </v-toolbar-title>

            <v-spacer/>

            <v-btn icon>
                <v-icon>mdi-magnify</v-icon>
            </v-btn>

            <v-btn icon>
                <v-icon>mdi-dots-vertical</v-icon>
            </v-btn>
        </v-app-bar>

        <v-content>
            <v-container>
                <v-row>
                    <v-col>
                        <!-- Content goes here -->
                        <slot></slot>
                    </v-col>
                </v-row>
            </v-container>
        </v-content>

    </v-app>
</template>

<script>
    //import SideBar from "../components/SideBar";
    export default {
        props: {
            source: String,
        },
        data: () => ({
            drawer: null,
            links: [
                {icon: 'dashboard', text: 'Dashboard', to: '/dashboard'},
                {icon: 'home', text: 'Home', to: '/dashboard/link'},
                {icon: 'mdi-television', text: 'Information Board', to: '/dashboard/event'},
            ],
        }),
        created() {
            //this.$vuetify.theme.dark = true
        },
        components: {
            //SideBar,
        }
    }
</script>