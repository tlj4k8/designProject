<template>
  <div class="needform">
  <h1>Client Need Assessment</h1>
    <b-form @submit="onSubmit" @reset="onReset" v-if="show" class="need">
      <b-form-group id="preferredMeat"
                    label="Preferred Meats:"
                    label-for="preferredMeat">
        <b-form-input id="preferredMeat"
                      type="text"
                      v-model="need.meats">
        </b-form-input>
      </b-form-group>
      <b-form-group id="meatAvoid"
                    label="Meats to Avoid:"
                    label-for="meatAvoid">
        <b-form-input id="meatAvoid"
                      type="text"
                      v-model="need.meatAvoid">
        </b-form-input>
      </b-form-group>
      <b-form-group id="meatCookPreferrence"
                    label="Meat Cooked Preferrence:"
                    label-for="meatCookPreferrence">
        <b-form-input id="meatCookPreferrence"
                      type="text"
                      v-model="need.meatCookPref">
        </b-form-input>
      </b-form-group>
      <b-form-group id="preferredCheeses"
                    label="Preferred Cheeses:"
                    label-for="preferredCheeses">
        <b-form-input id="preferredCheeses"
                      type="text"
                      v-model="need.cheese">
        </b-form-input>
      </b-form-group>
      <b-form-group id="cheeseAvoid"
                    label="Cheeses to Avoid:"
                    label-for="cheeseAvoid">
        <b-form-input id="cheeseAvoid"
                      type="text"
                      v-model="need.cheeseAvoid">
        </b-form-input>
      </b-form-group>
      <b-form-group id="preferredGrains"
                    label="Preferred Grains:"
                    label-for="preferredGrains">
        <b-form-input id="preferredGrains"
                      type="text"
                      v-model="need.grains">
        </b-form-input>
      </b-form-group>
      <b-form-group id="spice"
                    label="Spice Level:"
                    label-for="spice">
        <b-form-input id="spice"
                      type="text"
                      v-model="need.spice">
        </b-form-input>
      </b-form-group>
      <b-form-group id="other"
                    label="Other to Avoid:"
                    label-for="other">
        <b-form-input id="other"
                      type="text"
                      v-model="need.other">
        </b-form-input>
      </b-form-group>
      <b-form-group id="allergies"
                    label="Allergies:"
                    label-for="allergies">
        <b-form-input id="allergies"
                      type="text"
                      v-model="need.allergies">
        </b-form-input>
      </b-form-group>
      <b-form-group id="dietRestrictions"
                    label="Dietary Restrictions:"
                    label-for="dietRestrictions">
        <b-form-input id="dietRestrictions"
                      type="text"
                      v-model="need.dietRestrictions">
        </b-form-input>
      </b-form-group>
      <b-form-group id="dietGoals"
                    label="Dietary Goals:"
                    label-for="dietGoals">
        <b-form-input id="dietGoals"
                      type="text"
                      v-model="need.dietGoals">
        </b-form-input>
      </b-form-group>
      <b-form-group id="mainDish"
                    label="Main Dish:"
                    label-for="mainDish">
        <b-form-input id="mainDish"
                      type="text"
                      v-model="need.mainDish">
        </b-form-input>
      </b-form-group>
      <b-form-group id="storageContainers"
                    label="Select if Client has Storage Containers:"
                    label-for="storageContainers">
      <b-button :pressed.sync="storageContainers" variant="primary">Toggle Me</b-button>
      <p>Pressed State: <strong>{{ storageContainers }}</strong></p>
      </b-form-group>
      <b-form-group id="groceryStore"
                    label="Grocery Store:"
                    label-for="groceryStore">
        <b-form-input id="groceryStore"
                      type="text"
                      v-model="need.groceryStore">
        </b-form-input>
      </b-form-group>
      <b-form-group id="mealStructure"
                    label="Meal Structure:"
                    label-for="mealStructure">
        <b-form-input id="mealStructure"
                      type="text"
                      v-model="need.mealStructure">
        </b-form-input>
      </b-form-group>
      <b-form-group id="notes"
                    label="Other Notes:"
                    label-for="notes">
        <b-form-textarea id="notes"
                      :rows="3"
                      :max-rows="6"
                      type="text"
                      v-model="need.notes">
        </b-form-textarea>
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
      need: {
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
        
        groceryStore: '',
        mealStructure:'',
        notes: ''
      },
      storageContainers: false,
      show: true
    }
  },
  methods: {

  }
}
</script>
<style scoped>
.form{
    padding: 0 15px;
}
h1{
    text-align: center;
}
</style>