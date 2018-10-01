<template>
  <div class="clientPage">
    <h1>Client Page</h1>
    <Client/>
    <Person/>
    <Schedule/>
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
// import Clients from '@/components/Clients.vue';
import Schedule from '../components/Schedule';
import Person from '../components/Person';
import NeedForm from '../components/NeedForm';
import Client from '../components/Client';
export default {
  name: "ClientPage",
  components: {
    Person,
    Schedule,
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