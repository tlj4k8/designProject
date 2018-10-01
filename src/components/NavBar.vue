<template>
    <div class="bar">    
        <div class="menu">
            <b-dropdown id="ddown-divider" text="Menu" class="m-2">
                <router-link to="/dash"><b-dropdown-item-button>Dashboard</b-dropdown-item-button></router-link>
                <router-link to="/chef"><b-dropdown-item-button>Chef</b-dropdown-item-button></router-link>
                <router-link to="/person"><b-dropdown-item-button>Person</b-dropdown-item-button></router-link>
                <router-link to="/client"><b-dropdown-item-button>Client</b-dropdown-item-button></router-link>
                <router-link to="/employee"><b-dropdown-item-button>Employee</b-dropdown-item-button></router-link>
                <router-link to="/menu"><b-dropdown-item-button>Menu</b-dropdown-item-button></router-link>
                <b-dropdown-divider></b-dropdown-divider>
                <router-link to="/"><b-dropdown-item-button>Login/Logout</b-dropdown-item-button></router-link>
            </b-dropdown>
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
    width: 100%;
    height: 5em;
    background: #dee9fc;
}
</style>
