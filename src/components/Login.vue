<template>
    <div class="login">
        <div v-if="!isLoggedIn" class="loggedOut">
        <div class="logo">
            <img src="../assets/saltedChefEmployee.jpg" alt="saltedChefPic"/>
        </div>
        <div class="form">
            <div class="flexGroup">
            <b-form ref="form" :model="form" v-if="show" class="form">
            <b-row class="flex">
                <b-col sm="2"><label for="username">USERNAME</label></b-col>
                <b-col sm="10">
                    <b-form-input maxlength='200' class="input" id="username" type="text" v-model="form.username" :formatter="format" required placeholder="Enter username"/>
                </b-col>
            </b-row>
            <b-row class="flex">
                <b-col sm="2"><label for="password">PASSWORD</label></b-col>
                <b-col sm="10">
                    <b-form-input maxlength='200' class="input" id="password" type="password" oncopy="return false" onpaste="return false" auto-complete="off" v-model="form.password" required placeholder="Enter password"/>
                </b-col>
            </b-row>
            <div class="buttonDiv">
                <div class="buttonInfo">
                    <b-button type="button" @click="handleLogin(form)" class="loginButton">Login</b-button>
                    <p>Forgot Password? <a class="passwordText" @click="modalShow = !modalShow"><b>Click here</b></a></p>
                </div>
            </div>
            </b-form>
        </div>
        </div>
        <div>
            <b-modal v-model="modalShow" id="myModal">
                <div class="end">
                    <font-awesome-icon @click="help" class="qmark" icon="question"/>
                </div>
                <p class="text">Please contact administrator to reset password:</p>
                <p class="text"><a href="mailto:info@saltedchef.com" target="_top">info@saltedchef.com</a></p>
            </b-modal>
        </div>
        </div>
        <div v-else-if="isLoggedIn" class="loggedIn">
            <Dashboard />
        </div>
    <Spinner v-if="loading"/>
    </div>
</template>

<script>
import {mapState} from 'vuex';
import * as decoded from 'jwt-decode';
import Spinner from '././Spinner';
import Dashboard from '../views/Dashboard';
export default {
    name: 'Login',
    components:{
      Spinner,
      Dashboard
    },
    data () {
        return {
            form: {
                username: '',
                password: '',
            },
            show: true,
            modalShow: false,
            loading: false
        }
    },
    methods: {
        format (value, event) {
            return value.toLowerCase()
        },
        help(){
            window.open('https://salted-chef.herokuapp.com/#/loginHelp', "_blank");
        },
        handleLogin() {
            this.loading = true;
            let token = localStorage.getItem('t');
            this.$axiosServer.get('https://chefemployees.com/api/Auth/Login', {
                params:{
                    Username: this.form.username,
                    Password: this.form.password
                }
            }, { headers: { 'Authorization': "Bearer " + token }})
            .then((response)=>{
                this.loading = false;
                this.$store.dispatch('loginToken', response.data)
                this.$store.dispatch('storeUserInfo',response.data);
                this.successfulLogin();
            })
            .catch((error)=>{
                this.loading = false;
                this.failedLogin();
            })
         },
        successfulLogin() {
            this.loading = false;
            this.$router.push('/dash');
        },
        failedLogin() {
            this.loading = false; 
            if (this.form.username === ''){
                alert('Error: Please enter a username');
            }
            else if (this.form.password === ''){
                alert('Error: Please enter a password');
            }
            else{
                alert('Error: Please check that username and/or password are correct.');
            }
        }
    },
    computed: mapState({
        getToken(state){
            return state.jwt;
        },
        isLoggedIn (state){
            return !(state.jwt === null);
        },
        
    })
}
</script>

<style scoped>
.qmark{
    cursor: pointer;
}
.text{
    text-align: center;
}
.login{
    margin-top: 8em;
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
.end{
    display: flex;
    flex-direction: row;
    justify-content: flex-end;
}
.loginButton{
    width: 100%;
    color:black;
    background-color: white;
    border-color: lightgray;
}
a.passwordText{
    color: blue;
    cursor: pointer;
}
@media(max-width: 440px){
    img{
        width: 200px;
        height: 120px;
    }
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
