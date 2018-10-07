<template>
    <div class="login">
        <div class="form">
            <h1>Welcome to Salted Chef!</h1>
            <div class="flexGroup">
            <b-form ref="form" @submit.prevent="handleSubmit" :model="form" :rules="rules" v-if="show">
                <b-form-group class="flex" 
                            id="email"
                            label="Email address:"
                            label-for="email">
                <b-form-input id="email"
                            type="email"
                            v-model="form.email"
                            required
                            placeholder="Enter email">
                </b-form-input>
                </b-form-group>
                <b-form-group class="flex" 
                            id="password"
                            label="Password:"
                            label-for="password">
                <b-form-input id="password"
                            type="password"
                            v-model="form.password"
                            auto-complete="off"
                            required
                            placeholder="Enter password">
                </b-form-input>
                </b-form-group>
                <b-button type="submit" variant="primary">Login</b-button>
            </b-form>
            </div>
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
            show: true,
            rules: {
                password: [
                    { required: true,
                    message: 'Passwords must be at least 8 characters.',
                    pattern:'^(?=.*)(?=.{8,})',
                    trigger: 'blur'
                    },
                ],
                email: { required: true,
                    message: 'Please enter a valid email address.',
                    pattern:'.+\@.+\..+',
                    trigger: 'blur'
                    }
            }
        }
    },
    methods: {
        handleSubmit: function(form){
            var self = this;
            this.$ref[form].validate((valid => {
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
            this.$alert("Please complete all required fields", "Login Failed", {
            confirmButtonText: 'OK'
            });
        }
    }
}
</script>

<style scoped>
.login{
    margin-top: 10em;
}
h1{
    text-align:center;
}
.flexGroup{
    display: flex;
    flex-direction: row;
    justify-content: space-around;
    border-style: solid;
    border-width: 3px;
    border-color: #5cbdf2;
    margin: 20px 10%;
    padding: 10px 15px;
}
.flex{
    width: 50vw;
}
@media(max-width: 430px){
    .flex{
        width: 70vw;
    }
}
</style>
