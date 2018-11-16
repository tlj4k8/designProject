<template>
    <div class="clientMenuAdd">
    <b-form ref="form" @submit.prevent="handleSubmit" :model="form" v-if="show" class="form">
    <h3> Select Schedule </h3>
    <hr/>
    <div class="clientMenuAdd">
        <b-form-group id="schedule"
                        label="Schedule:"
                        label-for="schedule">
            <b-form-select 
                    v-on:input="getClientMenusIds"
                    v-model="form.schedule" 
                    :options="scheduleOptions"/>
        </b-form-group>
    </div>
    <h3> Menu </h3>
    <hr/>
    <div class="menuSelection">
      <div class="menuSelect">
          <b-form-group id="menu"
                      class="select"
                      :label-cols="4"
                      breakpoint="md"
                      label="Menus:"
                      label-for="menu">
              <b-form-select v-model="form.menus" :options="menuOptions" />
              <!-- <b-button  class="menuBtn" variant="primary">Select Menu</b-button> -->
              </b-form-group>
      </div>
      <div class="menuSelect">
          <b-form-group id="selectedMenus"
                      class="select"
                      :label-cols="4"
                      breakpoint="md"
                      label="Selected Menus:"
                      label-for="selectedMenus">
              <b-form-select v-model="form.clientMenus" :options="selectedOptions" />
              <b-button  class="menuBtn" variant="primary">Remove Menu</b-button>
              </b-form-group>
      </div>
      <b-form-group id="notes"
                    label="Menu Notes:"
                    label-for="notes">
        <b-form-textarea id="notes"
                      :rows="3"
                      :max-rows="6"
                      type="text"
                      v-model="form.notes"/>
      </b-form-group>
    </div>
    <div class="submit">
      <b-button type="submit">Add Menu Item</b-button>
    </div>
    </b-form>
  </div>
</template>

<script>
import axios from 'axios';
export default {
  name: "clientMenuAdd",
  data() {
    return {
      form: {
        schedule: null,
        menus: null,
        clientMenus: null,
        selectedMenus: null,
        notes: ''
      },
      menuOptions: [],
      clientMenuOptions: [],
      selectedOptions: [],
      scheduleOptions: [],
      show: true
    };
  },
  methods: {
    handleSubmit() {
      this.$axiosServer.post('https://chefemployees.com/odata/ClientMenus', {
        ScheduleId: this.form.schedule,
        ClientMenuNotes: this.form.notes,
        MenuId: this.form.menus,
      })
      .then((response)=>{
        console.log(response);
        this.getClientMenusIds();
      })
      .catch((error)=>{
        console.log(error);
      })
    },
    // addMenu(){
    //   this.selectedOptions.push(this.form.menus);
    //   console.log('button works');
    // },
    // removeMenu(){
    //   this.selectedOptions = this.selectedOptions.filter(item => item !== this.form.selectedMenus)
    // },
    getClientMenusIds(){
      this.$axiosServer.get('https://chefemployees.com/odata/Schedules(' + this.form.schedule + ')ClientMenus')
      .then((response) => {
        console.log(response);
        //Need to display menu name and be able to select clientmenuid to update/delete menu item from schedule
        // this.clientMenuOptions = response.data.value.map(value => value.ClientMenuId);
        // console.log(this.clientMenuOptions);
        this.selectedOptions = response.data.value.map(value => value.MenuId);
        console.log(this.selectedOptions);
      })
      .catch((error) => {
        console.log(error);
      })
    }
  },
    mounted(){
      axios.get('https://chefemployees.com/odata/Menus')
      .then((response) => {
          this.menuOptions = response.data.value.map(value => value.MenuId);
      })
      .catch((error) => {
          console.log(error);
      })
      axios.get('https://chefemployees.com/odata/Schedules')
      .then((response) => {
          this.scheduleOptions = response.data.value.map(value => value.ScheduleId);
      })
      .catch((error) => {
          console.log(error);
      })
    },
};
</script>
<style scoped>
.clientMenuAdd {
  padding: 0 0;
}
.menuSelect {
  display: flex;
  justify-content: space-evenly;
}
.select {
  width: 100vw;
}
hr{
  background-color: #0d50bc;
  height: 1px;
}
.submit{
    display: flex;
    flex-direction: row;
    justify-content: flex-end;
}
.menuBtn{
  padding-top: 10px;
}
</style>