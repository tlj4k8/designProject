<template>
    <div class="login">
        <div class="logo">
            <img src="../assets/saltedChefEmployee.jpg" alt="saltedChefPic"/>
        </div>
        <div class="form">
            <div class="flexGroup">
            <b-form ref="form" @submit="handleLogin(form)" :model="form" v-if="show" class="form">
            <b-row class="flex">
                <b-col sm="2"><label for="username">USERNAME</label></b-col>
                <b-col sm="10">
                    <b-form-input class="input" id="username" type="text" v-model="form.username" required placeholder="Enter username"/>
                </b-col>
            </b-row>
            <b-row class="flex">
                <b-col sm="2"><label for="password">PASSWORD</label></b-col>
                <b-col sm="10">
                    <b-form-input class="input" id="password" type="password" auto-complete="off" v-model="form.password" required placeholder="Enter password"/>
                </b-col>
            </b-row>
            <div class="buttonDiv">
                <div class="buttonInfo">
                    <b-button type="submit" class="loginButton">Login</b-button>
                    <p>Forgot Password? Click<a class="passwordText" @click="modalShow = !modalShow"> here</a></p>
                </div>
            </div>
            </b-form>
        </div>
        </div>
        <div>
            <b-modal v-model="modalShow" id="myModal">
                <p class="text">Please contact administrator to reset password:</p>
                <p class="text">(Email goes here)</p>
            </b-modal>
        </div>
    </div>
</template>

<script>
import {mapState} from 'vuex';
import * as decoded from 'jwt-decode';
export default {
  name: 'Login',
    data () {
        return {
            form: {
                username: '',
                password: '',
            },
            show: true,
            modalShow: false,
            rules: {
                password: [
                    { required: true,
                    message: 'Passwords must be at least 8 characters.',
                    pattern:'^(?=.*)(?=.{8,})',
                    trigger: 'blur'
                    }
                ]
            }
        }
    },
    methods: {
        handleLogin() {
            var self = this;
            this.$axiosServer.get('https://chefemployees.com/api/Auth/Login', {
                params:{
                    Username: this.form.username,
                    Password: this.form.password
                }
            })
            .then((response)=>{
                console.log(response.data)
                console.log(decoded(response.data))
                this.$store.dispatch('loginToken', response.data)
                this.$store.dispatch('storeUserInfo',response.data);
                this.successfulLogin();
            })
            .catch((error)=>{
                this.failedLogin();
            })
         },
        successfulLogin() {
            alert("Logged In!")
            this.$router.push('/dash');
        },
        failedLogin(errorMessage) {
            alert(errorMessage, "Login failed");
        }
    },
    computed: mapState({
        getToken(state){
            return state.jwt;
        }
    })
}
</script>

<style scoped>
.text{
    text-align: center;
}
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
.buttonInfo{
    display: flex;
    flex-direction: column;
    justify-content: center;   
}
.loginButton{
    width: 100%;
    color:black;
    background-color: white;
    border-color: lightgray;
}
a.passwordText{
    color: blue;
}
@media(max-width: 1200px){
    .flex{
        width: 50vw;
        padding: 10px 1px;
    }
}
@media(max-width: 1000px){
    .flex{
        width: 70vw;
        padding: 10px 1px;
    }
}
@media(max-width: 800px){
    .flex{
        width: 90vw;
        padding: 5px 1px;
    }
}
</style>
