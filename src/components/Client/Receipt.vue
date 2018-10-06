<template>
    <div class="receipt">
        <h3> Customer Receipt Form </h3>
        <b-form @submit="onSubmit" @reset="onReset" v-if="show" class="form">
            <div class="flexGroup">
                <b-form-group id="mealCharged"
                                class="flex"
                                label="Meal Charged:"
                                label-for="mealCharged">
                    <b-form-input id="mealCharged"
                                type="text"
                                v-model="form.mealCharged">
                    </b-form-input>
                </b-form-group>
                <b-form-group id="mealCost"
                                class="flex"
                                label="Meal Cost:"
                                label-for="mealCost">
                    <b-form-input id="mealCost"
                                type="text"
                                v-model="form.mealCost">
                    </b-form-input>
                </b-form-group>
            </div>
            <div class="flexGroup">
                <b-form-group id="paylink"
                                class="flex"
                                label="Pay Link:"
                                label-for="paylink">
                    <b-form-input id="paylink"
                                type="text"
                                v-model="form.paylink">
                    </b-form-input>
                </b-form-group>
                <b-form-group id="receipt"
                                class="flex"
                                label="Upload Receipt:"
                                label-for="receipt">
                    <b-form-file v-model="form.receipt" :state="Boolean(file)" placeholder="Choose a file...">
                    </b-form-file>
                </b-form-group>
            </div>
        </b-form>
        <b-button type="submit" variant="primary">Submit</b-button>
        <b-button type="reset" variant="danger">Reset</b-button>
    </div>
</template>
<script>
export default {
  name: 'Receipt',
  data () {
    return {
        form: {
            receipt: '',
            mealCharged: '',
            paylink: '',
            mealCost: '',
            file: null
        },
        show: true,
     
    }
  }
}
</script>

<style scoped>
.receipt{
    padding: 5px 15px;
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