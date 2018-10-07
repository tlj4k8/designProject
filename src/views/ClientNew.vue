<template>
  <div class="clientNew">
    <h1>New Client</h1>
    <b-card bg-variant="light" class="card">
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
export default {
  name: "ClientNew",
  components: {
    Person,
    Availability,
    NeedForm
  }
};
</script>

<style scoped>
.card{
  margin: 15px 15px;
}
.clientNew{
  margin-top: 10em;
}
h1{
  text-align: center;
}

</style>