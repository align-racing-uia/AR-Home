<template>
        <v-footer
                padless
                absolute
        >
            <img class="ar_th_footer" src="../assets/th.svg">
            <v-card
                    flat
                    tile
                    width="100%"
                    dark
                    color="#333333"
            >

                <v-container>
                    <v-card-text class="it-credits">
                        <p class="float-right">
                            <a href="#">Back to top</a>
                        </p>
                        Align Racing Shortcuts page, created by <a>AR IT</a>
                    </v-card-text>
                </v-container>


                <v-divider></v-divider>

                <div class="bottom">
                    <v-card-text class="copyright text-center">
                        <p>Copyright © <span>{{ new Date().getFullYear() }}</span> <a href="https://www.alignracing.no/" class="transition">Align Racing</a></p>
                    </v-card-text>
                </div>
            </v-card>
        </v-footer>
</template>


<script>
    export default {
        data: () => ({
            icons: [
                'mdi-home',
                'mdi-email',
                'mdi-calendar',
                'mdi-delete',
            ],
        }),
    }
</script>s

<style>
    .row {
        /*  Makes sure sure footer dosent overlap page content wrapped in row */
        margin-bottom: 270px;
    }

    .v-footer a:link {
        color: #ef6926;
        text-decoration: none;
    }
    .v-footer a:visited {
        color: #ef6926;
        text-decoration: none;
    }
    .v-footer a:hover {
        text-decoration: none;
    }

    .it-credits {
        color: darkgrey;
    }

    .bottom {
        padding: 30px 0;
        background-color: #000;
    }
    .bottom .copyright {
        color: #e5e5e5;
        font-weight: 600;
    }

    .bottom p {
        margin-bottom: 0;
        line-height: 50px;
        font-size: 16px;
        font-weight: 400;
    }
    .copyright p span {
        color: #d1caca;
    }
    .bottom .copyright p, .bottom .copyright a:hover{
        color: #6c6d83;
    }

    .ar_th_footer {
        height: 30px;
        width: -webkit-fill-available;
        width: -moz-fill-available;
    }

</style>