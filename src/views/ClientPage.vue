<template>
  <div class="clientPage">
    <h1>Client Page</h1>
    <b-card bg-variant="light" class="card">
    <Client/>
    <Person/>
    <Availability/>
    <NeedForm/>
    </b-card>
  </div>
</template>

<script>
import Availability from '../components/Schedule/Availability';
import Person from '../components/Person';
import NeedForm from '../components/Client/NeedForm';
import Client from '../components/Client/Client';
export default {
  name: "ClientPage",
  components: {
    Person,
    Availability,
    NeedForm,
    Client
  },
  data() {
    return {
      
    }
  }
};
</script>

<style scoped>
.card{
  margin: 15px 15px;
}
.clientPage{
  margin-top: 10em;
}
h1{
  text-align: center;
}

</style>