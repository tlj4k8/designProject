<template>
    <div class="clientMenuAdd">
    <b-form ref="form" @submit="handleSubmit(form)" :model="form" v-if="show" class="form">
    <h3> Select Schedule </h3>
    <hr/>
    <div class="schedule">
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
        schedule: null,
        menus: null,
        notes: '',
        selectedMenus: []
      },
      options: [],
      selectedOptions: [],
      scheduleOptions: [],
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
.schedule {
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