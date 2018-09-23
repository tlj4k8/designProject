<template>
  <div class="personPage">
    <Person/>
  </div>
</template>

<script>
import Person from '@/components/Person.vue';
export default {
  name: "PersonPage",
  components: {
    Person
  }
};
</script>

<style scoped>
.personPage{
  margin-top: 10em;
}

</style>