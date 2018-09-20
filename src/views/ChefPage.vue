<template>
  <div class="chef">
    <h1> Chef Portal </h1>
    <div>
      <b-button-group vertical class="buttons">
        <b-button>Time Entry</b-button>
        <b-button>Profile</b-button>
        <b-button>Clients</b-button>
      </b-button-group>
    </div>
  </div>
</template>

<script>

export default {
  name: "ChefPage",
  components: {

  }
};
</script>

<style scoped>
.chef{
  margin-top: 12em;
}
.buttons{
  width: 80vw;
  margin: 0 10%;
}
h1{
  text-align: center;
}
</style>