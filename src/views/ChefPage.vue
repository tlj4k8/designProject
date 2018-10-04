<template>
  <div class="chef">
    <h1> Chef Portal </h1>
    <div>
      <Person/>
      <Schedule/>
      <TimeStamp/>
      <Receipt/>
      <MenuAdd/>
    </div>
  </div>
</template>

<script>
import Schedule from '../components/Schedule';
import Person from '../components/Person';
import TimeStamp from '../components/TimeStamp';
import Receipt from '../components/Receipt';
import MenuAdd from '../components/MenuAdd';
export default {
  name: "ChefPage",
  components: {
    Schedule,
    Person,
    TimeStamp,
    Receipt,
    MenuAdd
  }
};
</script>

<style scoped>
.chef{
  margin-top: 12em;
}
.buttons{
  width: 80vw;
  margin: 0 10%;
}
h1{
  text-align: center;
}
</style>