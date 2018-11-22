<template>
    <div class="clientMenuAdd">
    <div class="end">
          <font-awesome-icon icon="question"/>
    </div>
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
                      label="Master Menu Items:"
                      label-for="menu">
              <b-form-select v-model="form.menus" :options="menuOptions" />
              <!-- <b-button  class="menuBtn" variant="primary">Select Menu</b-button> -->
          </b-form-group>
          
      </div>
      <div class="menuNotes">
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
        <b-button @click="submitMenu">Add Menu Item</b-button>
      </div>
      <div class="menuSelect">
          <b-form-group id="selectedMenus"
                      class="select"
                      :label-cols="4"
                      breakpoint="md"
                      label="Scheduled Menus:"
                      label-for="selectedMenus">
            <b-form-select v-model="form.clientMenus" :options="selectedOptions" />
          </b-form-group>
      </div>
       <div class="submit">
        <b-button  class="menuBtn" @click="removeMenu">Remove Menu</b-button>
      </div>
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

    submitMenu() {
      let token = localStorage.getItem('t');
      let headers = {'Authorization': "Bearer " + token};
      this.$axiosServer.post('https://chefemployees.com/odata/ClientMenus', {
        ScheduleId: this.form.schedule,
        ClientMenuNotes: this.form.notes,
        MenuId: this.form.menus
      },{headers: headers}
      )
      .then((response)=>{
        console.log(response);
        this.getClientMenusIds();
      })
      .catch((error)=>{
        console.log(error);
      })
    },
    // removeMenu(){
    //   this.$axiosServer.delete('https://chefemployees.com/odata/Schedules(' + this.form.schedule + ')ClientMenus', {
    //     params: {ClientMenuId: this.form.clientMenus}
    //   })
    //   .then((response)=>{
    //     console.log(response);
    //   })
    //   .catch((error)=>{
    //     console.log(error);
    //   })
    // },
    getClientMenusIds(){
      let token = localStorage.getItem('t');
      this.$axiosServer.get('https://chefemployees.com/odata/Schedules(' + this.form.schedule + ')ClientMenus', { headers: { 'Authorization': "Bearer " + token }})
      .then((response) => {
        response.data.value.forEach((value) => {
                this.selectedOptions.push({ value: value.ClientMenuId, text: value.MenuId })
            })
      })
      .catch((error) => {
        console.log(error);
      })
    }
  },
    mounted(){
      let token = localStorage.getItem('t');
      axios.get('https://chefemployees.com/odata/Menus', { headers: { 'Authorization': "Bearer " + token }})
      .then((response) => {
        response.data.value.forEach((value) => {
          this.menuOptions.push({ value: value.MenuId, text: value.Name })
        })
      })
      .catch((error) => {
          console.log(error);
      })
      //Need to filter based on employeeId so chefs can only see their schedules.
      axios.get('https://chefemployees.com/odata/Schedules', { headers: { 'Authorization': "Bearer " + token }})
      .then((response) => {
        response.data.value.forEach((value) => {
            this.scheduleOptions.push({ value: value.ScheduleId, text: value.ScheduleId })
        })
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
.end{
    display: flex;
    flex-direction: row;
    justify-content: flex-end;
}
.menuBtn{
  padding-top: 10px;
}
</style>