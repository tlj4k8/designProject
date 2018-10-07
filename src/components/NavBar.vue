<template>
    <div class="bar">    
        <div class="menu">
                <router-link to="/dash" class="flex"><b-button>Dashboard</b-button></router-link>
                <router-link to="/" class="flex"><b-button>Login</b-button></router-link>
        </div>
    </div>
</template>

<script>
export default {
    name: "NavBar"
}    
</script>

<style scope>
.bar {
    display: flex;
    position: fixed;
    top: 0;
    z-index: 15;
    width: 100vw;
    height: 5em;
    background: #5ad0ed;
    justify-content: flex-end;
}
.menu{
    padding: 20px 20px;

}
.flex{
    padding: 5px 5px;
}
</style>
