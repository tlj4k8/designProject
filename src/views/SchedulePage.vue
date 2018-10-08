<template>
  <div class="schedulePage">
    <h1>Schedule</h1>
    <b-card bg-variant="light" class="card">
        <ScheduleVisit/>
        <EmployeeSelect/>
        <TimeStamp/>
        <Receipt/>
    </b-card>
  </div>
</template>

<script>
import ScheduleVisit from '@/components/Schedule/ScheduleVisit.vue';
import TimeStamp from '@/components/Schedule/TimeStamp.vue';
import Receipt from '@/components/Client/Receipt.vue';
import EmployeeSelect from '@/components/Employee/EmployeeSelect.vue';
export default {
  name: "SchedulePage",
  components: {
    ScheduleVisit,
    TimeStamp,
    Receipt,
    EmployeeSelect
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