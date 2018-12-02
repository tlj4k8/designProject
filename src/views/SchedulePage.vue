<template>
  <div class="schedulePage">
    <!-- <div class="chef">
      <img src="../assets/saltedChefEmployee.jpg" style="width: 200px; height: 120px " alt="saltedChefPic"/>
    </div> -->
    <h1>Schedule</h1>
    <b-card bg-variant="light" class="card">
        <ViewSchedule/>
    </b-card>
  </div>
</template>

<script>
import ViewSchedule from '../components/Schedule/ViewSchedule.vue';
export default {
  name: "SchedulePage",
  components: {
    ViewSchedule
  }
};
</script>

<style scoped>
.card{
  margin: 15px 15px;
}
.schedulePage{
  margin-top: 8em;
}
h1{
  text-align: center;
}

</style>