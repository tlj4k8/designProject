<template>
  <div class="needform">
  <h3>Client Need Assessment</h3>
    <b-form @submit="onSubmit" @reset="onReset" v-if="show" class="form">
    <div class="flexGroup">
      <b-form-group id="stove"
                    class="flex"
                    label="Select if Client has a Stove:"
                    label-for="stove">
        <b-form-checkbox id="form.stove"
                    type="checkbox"
                    v-model="form.stove"/>
      </b-form-group>
      <b-form-group id="organic"
                    class="flex"
                    label="Select if Client is Organic:"
                    label-for="organic">
        <b-form-checkbox id="form.organic"
                    type="checkbox"
                    v-model="form.organic"/>
      </b-form-group>
      <b-form-group id="storageContainers"
                    class="flex"
                    label="Select if Client has Storage Containers:"
                    label-for="storageContainers">
        <b-form-checkbox id="storageContainers"
                    type="checkbox"
                    v-model="form.storageContainers"/>
      </b-form-group>
    </div>
      <b-form-group id="preferredMeat"
                    label="Preferred Meats:"
                    label-for="preferredMeat">
        <b-form-input id="preferredMeat"
                      type="text"
                      v-model="form.meats"/>
      </b-form-group>
      <b-form-group id="meatAvoid"
                    label="Meats to Avoid:"
                    label-for="meatAvoid">
        <b-form-input id="meatAvoid"
                      type="text"
                      v-model="form.meatAvoid"/>
      </b-form-group>
      <b-form-group id="meatCookPreferrence"
                    label="Meat Cooked Preferrence:"
                    label-for="meatCookPreferrence">
        <b-form-input id="meatCookPreferrence"
                      type="text"
                      v-model="form.meatCookPref"/>
      </b-form-group>
      <b-form-group id="preferredCheeses"
                    label="Preferred Cheeses:"
                    label-for="preferredCheeses">
        <b-form-input id="preferredCheeses"
                      type="text"
                      v-model="form.cheese"/>
      </b-form-group>
      <b-form-group id="cheeseAvoid"
                    label="Cheeses to Avoid:"
                    label-for="cheeseAvoid">
        <b-form-input id="cheeseAvoid"
                      type="text"
                      v-model="form.cheeseAvoid"/>
      </b-form-group>
      <b-form-group id="preferredGrains"
                    label="Preferred Grains:"
                    label-for="preferredGrains">
        <b-form-input id="preferredGrains"
                      type="text"
                      v-model="form.grains"/>
      </b-form-group>
      <b-form-group id="spice"
                    label="Spice Level:"
                    label-for="spice">
        <b-form-input id="spice"
                      type="text"
                      v-model="form.spice"/>
      </b-form-group>
      <b-form-group id="other"
                    label="Other to Avoid:"
                    label-for="other">
        <b-form-input id="other"
                      type="text"
                      v-model="form.other"/>
      </b-form-group>
      <b-form-group id="allergies"
                    label="Allergies:"
                    label-for="allergies">
        <b-form-input id="allergies"
                      type="text"
                      v-model="form.allergies"/>
      </b-form-group>
      <b-form-group id="dietRestrictions"
                    label="Dietary Restrictions:"
                    label-for="dietRestrictions">
        <b-form-input id="dietRestrictions"
                      type="text"
                      v-model="form.dietRestrictions"/>
      </b-form-group>
      <b-form-group id="dietGoals"
                    label="Dietary Goals:"
                    label-for="dietGoals">
        <b-form-input id="dietGoals"
                      type="text"
                      v-model="form.dietGoals"/>
      </b-form-group>
      <b-form-group id="mainDish"
                    label="Main Dish:"
                    label-for="mainDish">
        <b-form-input id="mainDish"
                      type="text"
                      v-model="form.mainDish"/>
      </b-form-group>
      <b-form-group id="groceryStore"
                    label="Grocery Store:"
                    label-for="groceryStore">
        <b-form-input id="groceryStore"
                      type="text"
                      v-model="form.groceryStore"/>
      </b-form-group>
      <b-form-group id="mealStructure"
                    label="Meal Structure:"
                    label-for="mealStructure">
        <b-form-input id="mealStructure"
                      type="text"
                      v-model="form.mealStructure"/>
      </b-form-group>
      <b-form-group id="notes"
                    label="Other Notes:"
                    label-for="notes">
        <b-form-textarea id="notes"
                      :rows="3"
                      :max-rows="6"
                      type="text"
                      v-model="form.notes"/>
      </b-form-group>
      <b-button type="submit" variant="primary">Submit</b-button>
      <b-button type="reset" variant="danger">Reset</b-button>
    </b-form>
  </div>
</template>

<script>
export default {
  name: 'needForm',
  data () {
    return {
      form: {
        meats: '',
        meatAvoid: '',
        meatCookPref: '',
        cheese: '',
        cheeseAvoid: '',
        grains: '',
        spice: '',
        other: '',
        allergies: '',
        dietRestrictions: '',
        dietGoals: '',
        mainDish: '',
        storageContainers: false,
        stove: false,
        organic: false,
        groceryStore: '',
        mealStructure:'',
        notes: ''
      },
      show: true
    }
  },
  methods: {

  }
}
</script>
<style scoped>
.flexGroup{
    display: flex;
    flex-direction: row;
    justify-content: space-around;
}
.flex{
    flex-grow: 1;
    padding: 0 2px;
}
</style>