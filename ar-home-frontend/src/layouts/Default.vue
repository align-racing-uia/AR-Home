<template>
    <div>
        <nav-bar></nav-bar>

        <v-container>
            <slot></slot>
        </v-container>

        <footer-bar></footer-bar>
    </div>
</template>

<script>
    import NavBar from '../components/NavBar';
    import FooterBar from '../components/FooterBar';

    export default {
        components: {
            NavBar,
            FooterBar
        }
    }
</script>