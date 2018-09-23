<template>
    <div class="login">
        <div class="form">
            <h1>Welcome to Salted Chef!</h1>
            <h2>Login</h2>
            <b-form @submit="onSubmit" @reset="onReset" v-if="show">
                <b-form-group id="exampleInputGroup1"
                            label="Email address:"
                            label-for="exampleInput1">
                <b-form-input id="exampleInput1"
                            type="email"
                            v-model="form.email"
                            required
                            placeholder="Enter email">
                </b-form-input>
                </b-form-group>
                <b-form-group id="exampleInputGroup2"
                            label="Password:"
                            label-for="exampleInput2">
                <b-form-input id="exampleInput2"
                            type="password"
                            v-model="form.password"
                            required
                            placeholder="Enter password">
                </b-form-input>
                </b-form-group>
                <b-button type="submit" variant="primary">Submit</b-button>
            </b-form>
        </div>
    </div>
</template>

<script>
export default {
  name: 'Login',
    data () {
        return {
            form: {
                email: '',
                password: '',
            },
            show: true
        }
    }
}
</script>

<style scoped>
.form{
    width: 50%;
    border: 1px solid grey;
    padding: 30px;
}
.login{
    display: flex;
    justify-content: center;
    align-items: center;
    margin-top: 12em;
}
h1, h2{
    text-align:center;
}


</style>