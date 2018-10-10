<template>
  <div class="schedulePage">
    <h1>Schedule</h1>
    <b-card bg-variant="light" class="card">
        <AddSchedule/>
    </b-card>
  </div>
</template>

<script>
import AddSchedule from '../components/Schedule/AddSchedule.vue';
export default {
  name: "SchedulePage",
  components: {
    AddSchedule
  }
};
</script>

<style scoped>
.card{
  margin: 15px 15px;
}
.schedulePage{
  margin-top: 10em;
}
h1{
  text-align: center;
}

</style>