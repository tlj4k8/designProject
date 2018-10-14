<template>
    <div class="clientMenuAdd">
    <b-form ref="form" @submit.prevent="handleSubmit" :model="form" v-if="show" class="form">
    <div class="clientMenuAdd">
        <b-form-group id="client"
                        label="Client:"
                        label-for="client">
            <b-form-select
                    v-model="form.client" 
                    :options="clientOptions"/>
        </b-form-group>
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
    <div class="menuSelect">
        <b-form-group id="menu"
                    class="select"
                    :label-cols="4"
                    breakpoint="md"
                    label="Menus:"
                    label-for="menu">
            <b-form-select multiple v-model="form.menus" :options="options" class="mb-1" />
            <b-button type="submit" variant="primary">Select Items</b-button>
            </b-form-group>
    </div>
    <div class="selectedMenus">
        <b-form-group id="selectedMenus"
                    class="select"
                    :label-cols="4"
                    breakpoint="md"
                    label="Selected Menus:"
                    label-for="selectedMenus">
            <b-form-select multiple v-model="form.selectedMenus" :options="selectedOptions" class="mb-1" />
            <b-button type="submit" variant="primary">Remove Item</b-button>
            </b-form-group>
    </div>
    <b-button type="submit" variant="primary">Submit</b-button>
    <b-button type="reset" variant="danger">Reset</b-button>
    </b-form>
  </div>
</template>

<script>
export default {
  name: "clientMenuAdd",
  data() {
    return {
      form: {
        client: null,
        schedule: null,
        menus: null,
        selectedMenus: null
      },
      options: [
        { value: "client1", text: "Client1" },
        { value: "client2", text: "client2" },
        { value: "client3", text: "client3" },
        { value: "client4", text: "client4" },
        { value: "client5", text: "client6" }
      ],
      selectedOptions: [],
      scheduleOptions: [
        { value: "schedule1", text: "schedule1" },
        { value: "schedule2", text: "schedule2" }
      ],
      clientOptions: [
        { value: "option1", text: "option1" },
        { value: "option2", text: "option2" }
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
</style>