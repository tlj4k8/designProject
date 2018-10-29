<template>
    <div class="login">
        <div class="logo">
            <img src="../assets/saltedChefLogo.jpg" alt="saltedChefPic"/>
        </div>
        <div class="form">
            <div class="flexGroup">
            <b-form ref="form" @submit.prevent="handleSubmit" :model="form" :rules="rules" v-if="show">
            <b-row class="flex">
                <b-col sm="2"><label for="email">USERNAME</label></b-col>
                <b-col sm="10">
                    <b-form-input class="input" id="email" type="email" v-model="form.email" required placeholder="Enter email"/>
                </b-col>
            </b-row>
            <b-row class="flex">
                <b-col sm="2"><label for="password">PASSWORD</label></b-col>
                <b-col sm="10">
                    <b-form-input class="input" id="password" type="password" auto-complete="off" v-model="form.password" required placeholder="Enter password"/>
                </b-col>
            </b-row>
            </b-form>
        </div>
        <div class="buttonDiv">
            <b-button to="/dash" type="submit" class="loginButton">Login</b-button>
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
    margin-top: 9em;
}
h1{
    text-align:center;
}
.input{
    border-top:none;
    border-right: none;
    border-left: none;
}
.flexGroup{
    margin: 20px 10%;
    padding: 10px 15px;
}
.flex{
    width: 55vw;
    padding: 15px 15px;
}
.logo, .buttonDiv, .flexGroup{
    display: flex;
    flex-direction: row;
    justify-content: space-around;
}
.loginButton{
    width: 15%;
    color:black;
    background-color: white;
    border-color: lightgray;
}

@media(max-width: 430px){
    .flex{
        width: 90vw;
        padding: 5px 1px;
    }
    .loginButton{
        width: 95%;
    }
    img{
        width: 70%;
    }
}
</style>
