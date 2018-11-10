<template>
  <div class="profile">
    <h1> Profile </h1>
    <b-card bg-variant="light" class="card">
      <Profile/>
    </b-card>
  </div>
</template>

<script>
import Profile from '../components/Profile';
export default {
  name: "ProfilePage",
  components: {
    Profile
  }
};
</script>

<style scoped>
.card{
  margin: 15px 15px;
}
.profile{
  margin-top: 8em;
}
.buttons{
  width: 80vw;
  margin: 0 10%;
}
h1{
  text-align: center;
}
</style>