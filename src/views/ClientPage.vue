<template>
  <div class="clientPage">
    <h1>Client Page</h1>
    <b-card bg-variant="light" class="card">
    <Client/>
    <Person/>
    <Availability/>
    <VisitDate/>
    <NeedForm/>
    </b-card>
  </div>
</template>

<script>
import Availability from '../components/Schedule/Availability';
import Person from '../components/Person';
import NeedForm from '../components/Client/NeedForm';
import Client from '../components/Client/Client';
import VisitDate from '../components/Client/VisitDate';
export default {
  name: "ClientPage",
  components: {
    Person,
    Availability,
    NeedForm,
    Client,
    VisitDate
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