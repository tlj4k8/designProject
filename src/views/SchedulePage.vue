<template>
  <div class="schedulePage">
    <h1>Schedule</h1>
    <Availability/>
    <TimeStamp/>
  </div>
</template>

<script>
import Availability from '@/components/Availability.vue';
import TimeStamp from '@/components/TimeStamp.vue';
export default {
  name: "SchedulePage",
  components: {
    Availability,
    TimeStamp
  }
};
</script>

<style scoped>
.schedulePage{
  margin-top: 12em;
}
h1{
  text-align: center;
}

</style>