<template>
    <div class="clientMenuAdd">
    <b-form ref="form" @submit="handleSubmit(form)" :model="form" v-if="show" class="form">
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
    <div class="menuSelection">
      <div class="menuSelect">
          <b-form-group id="menu"
                      class="select"
                      :label-cols="4"
                      breakpoint="md"
                      label="Menus:"
                      label-for="menu">
              <b-form-select multiple v-model="form.menus" :options="options" />
              <b-button type="submit" variant="primary">Select Items</b-button>
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
              <b-button type="submit" variant="primary">Remove Item</b-button>
              </b-form-group>
      </div>
    </div>
    <b-button type="submit" variant="primary">Submit</b-button>
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
        selectedMenus: []
      },
      options: [],
      selectedOptions: [],
      scheduleOptions: [],
      clientOptions: [],
      show: true
    };
  },
  methods: {
    handleSubmit(form) {
      var self = this;
      
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
</style>