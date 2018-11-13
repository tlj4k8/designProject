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
              <b-form-select multiple v-model="form.menus" :options="options" />
              <b-button class="menuBtn" type="submit" variant="primary">Select Menu</b-button>
              </b-form-group>
      </div>
      <div class="menuSelect">
          <b-form-group id="selectedMenus"
                      class="select"
                      :label-cols="4"
                      breakpoint="md"
                      label="Selected Menus:"
                      label-for="selectedMenus">
              <b-form-select multiple v-model="form.selectedMenus" :options="selectedOptions" />
              <b-button class="menuBtn" type="submit" variant="primary">Remove Menu</b-button>
              </b-form-group>
      </div>
    </div>
    <div class="submit">
      <b-button type="submit">Submit</b-button>
    </div>
    </b-form>
  </div>
</template>

<script>
export default {
  name: "clientMenuAdd",
  data() {
    return {
      form: {
        schedule: null,
        menus: null,
        selectedMenus: []
      },
      options: [],
      selectedOptions: [],
      scheduleOptions: [
        { value: "schedule1", text: "schedule1" },
        { value: "schedule2", text: "schedule2" }
      ],
      show: true
    };
  },
  methods: {
    handleSubmit: function(form) {
      var self = this;
      this.$ref[form].validate(valid => {
        if (valid) {
          //http request goes here
        } else {
          this.emptyFields();
          return false;
        }
      });
    },
    emptyFields() {
      this.$alert(
        "Please complete all required fields",
        "Registration failed",
        {
          confirmButtonText: "OK"
        }
      );
    }
  }
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