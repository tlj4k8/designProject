<template>
  <div class="schedulePage">
    <h1>Schedule</h1>
    <Availability/>
    <TimeStamp/>
    <Receipt/>
  </div>
</template>

<script>
import Availability from '@/components/Availability.vue';
import TimeStamp from '@/components/TimeStamp.vue';
import Receipt from '@/components/Receipt.vue';
export default {
  name: "SchedulePage",
  components: {
    Availability,
    TimeStamp,
    Receipt
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