<template>
    <div class="loading">
            <div class="spinner">
                <circle2></circle2>
            </div>
    </div>
</template>
<script>
import {Circle2} from 'vue-loading-spinner';
export default {
    name: 'Spinner',
    components:{
      Circle2
    }
}
</script>
<style scoped>
.loading{
    position: fixed;
    top: 0;
    left: 0;
    right: 0;
    bottom: 0;
    height: 100vh;
    width: 100vw;
    background: rgb(136, 136, 136);
    overflow: auto;
    z-index: 10;
    opacity: 0.80;
    display: flex;
    justify-content: center;
}
.spinner{
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-self: center;    
}
.spinner.spinner--circle-2{
    width: 100px !important;
    height: 100px !important;
    border-width: 10px !important;
    border-color: rgb(53, 73, 94) rgb(23, 172, 209) rgb(23, 172, 209) !important;
}
</style>