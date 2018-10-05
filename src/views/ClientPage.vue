<template>
  <div class="clientPage">
    <h1>Client Page</h1>
    <Client/>
    <Person/>
    <Availability/>
    <b-button variant="primary" @click="modalShow = !modalShow">
      Need Form
    </b-button>
    <b-modal v-model="modalShow">
      <div>
        <NeedForm/>
      </div>
    </b-modal>
  </div>
</template>

<script>
import Availability from '../components/Availability';
import Person from '../components/Person';
import NeedForm from '../components/NeedForm';
import Client from '../components/Client';
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
      modalShow: false
    }
  }
};
</script>

<style scoped>
.clientPage{
  margin-top: 10em;
}
h1{
  text-align: center;
}

</style>