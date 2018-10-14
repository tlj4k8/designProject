<template>
  <div class="needform">
  <h3>Client Need Assessment</h3>
  <hr/>
    <b-form ref="needForm" @submit.prevent="handleSubmit" :model="needForm" v-if="show" class="form">
    <div class="flexGroup">
      <b-form-group id="stove"
                    class="flex"
                    label="Select if Client has a Stove:"
                    label-for="stove">
        <b-form-checkbox id="need.stove"
                    type="checkbox"
                    v-model="need.stove"/>
      </b-form-group>
      <b-form-group id="organic"
                    class="flex"
                    label="Select if Client is Organic:"
                    label-for="organic">
        <b-form-checkbox id="need.organic"
                    type="checkbox"
                    v-model="need.organic"/>
      </b-form-group>
      <b-form-group id="storageContainers"
                    class="flex"
                    label="Select if Client has Storage Containers:"
                    label-for="storageContainers">
        <b-form-checkbox id="need.storageContainers"
                    type="checkbox"
                    v-model="need.storageContainers"/>
      </b-form-group>
    </div>
      <b-form-group id="preferredMeat"
                    label="Preferred Meats:"
                    label-for="preferredMeat">
        <b-form-input id="preferredMeat"
                      type="text"
                      v-model="need.meats"/>
      </b-form-group>
      <b-form-group id="meatAvoid"
                    label="Meats to Avoid:"
                    label-for="meatAvoid">
        <b-form-input id="meatAvoid"
                      type="text"
                      v-model="need.meatAvoid"/>
      </b-form-group>
      <b-form-group id="meatCookPreferrence"
                    label="Meat Cooked Preferrence:"
                    label-for="meatCookPreferrence">
        <b-form-input id="meatCookPreferrence"
                      type="text"
                      v-model="need.meatCookPref"/>
      </b-form-group>
      <b-form-group id="preferredCheeses"
                    label="Preferred Cheeses:"
                    label-for="preferredCheeses">
        <b-form-input id="preferredCheeses"
                      type="text"
                      v-model="need.cheese"/>
      </b-form-group>
      <b-form-group id="cheeseAvoid"
                    label="Cheeses to Avoid:"
                    label-for="cheeseAvoid">
        <b-form-input id="cheeseAvoid"
                      type="text"
                      v-model="need.cheeseAvoid"/>
      </b-form-group>
      <b-form-group id="preferredGrains"
                    label="Preferred Grains:"
                    label-for="preferredGrains">
        <b-form-input id="preferredGrains"
                      type="text"
                      v-model="need.grains"/>
      </b-form-group>
      <b-form-group id="spice"
                    label="Spice Level:"
                    label-for="spice">
        <b-form-input id="spice"
                      type="text"
                      placeholder="ex. (1 - 10)"
                      v-model="need.spice"/>
      </b-form-group>
      <b-form-group id="other"
                    label="Other to Avoid:"
                    label-for="other">
        <b-form-input id="other"
                      type="text"
                      v-model="need.other"/>
      </b-form-group>
      <b-form-group id="allergies"
                    label="Allergies:"
                    label-for="allergies">
        <b-form-input id="allergies"
                      type="text"
                      v-model="need.allergies"/>
      </b-form-group>
      <b-form-group id="dietRestrictions"
                    label="Dietary Restrictions:"
                    label-for="dietRestrictions">
        <b-form-input id="dietRestrictions"
                      type="text"
                      v-model="need.dietRestrictions"/>
      </b-form-group>
      <b-form-group id="dietGoals"
                    label="Dietary Goals:"
                    label-for="dietGoals">
        <b-form-input id="dietGoals"
                      type="text"
                      v-model="need.dietGoals"/>
      </b-form-group>
      <b-form-group id="mainDish"
                    label="Main Dish:"
                    label-for="mainDish">
        <b-form-input id="mainDish"
                      type="text"
                      v-model="need.mainDish"/>
      </b-form-group>
      <b-form-group id="groceryStore"
                    label="Grocery Store:"
                    label-for="groceryStore">
        <b-form-input id="groceryStore"
                      type="text"
                      v-model="need.groceryStore"/>
      </b-form-group>
      <b-form-group id="mealStructure"
                    label="Meal Structure:"
                    label-for="mealStructure">
        <b-form-input id="mealStructure"
                      type="text"
                      v-model="need.mealStructure"/>
      </b-form-group>
      <b-form-group id="notes"
                    label="Other Notes:"
                    label-for="notes">
        <b-form-textarea id="notes"
                      :rows="3"
                      :max-rows="6"
                      type="text"
                      v-model="need.notes"/>
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
        handleSubmit: function(needForm){
            var self = this;
            this.$ref[needForm].validate((valid => {
                if(valid){
                    //http request goes here
                }
                else{
                    this.emptyFields();
                    return false;
                }
            }))
        },
        emptyFields() {
            this.$alert("Please complete all required fields", "Registration failed", {
            confirmButtonText: 'OK'
            });
        }
    }
}
</script>
<style scoped>
hr{
    background-color: #0d50bc;
    height: 1px;
}
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