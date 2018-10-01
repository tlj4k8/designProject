<template>
  <div class="client">
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
export default {
  name: "ClientPage",
  components: {
    Person,
    Schedule,
    NeedForm
  },
  data() {
    return {
      modalShow: false
    }
  }
};
</script>

<style scoped>
.client{
  margin-top: 10em;
}

</style>