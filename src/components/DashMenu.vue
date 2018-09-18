<template>
  <div class="dash">
    <b-button-group vertical class="dashGroup">
        <b-button to="/client">Client</b-button>
        <b-button to="/menu">Menu</b-button>
        <b-button to="/chef">Chef</b-button>
        <b-button to="/schedule">Schedule</b-button>
    </b-button-group>

  </div>
</template>

<script>

export default {
  name: "DashMenu"

};
</script>

<style scoped>
.dashGroup{

}
.btn{
    padding: 10px;
}

</style>