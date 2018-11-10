<template>
    <div class="login">
        <div class="logo">
            <img src="../assets/saltedChefLogo.jpg" alt="saltedChefPic"/>
        </div>
        <div class="form">
            <div class="flexGroup">
            <b-form ref="form" @submit="handleLogin(form)" :model="form" v-if="show" class="form">
            <b-row>
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
                <b-button type="submit" class="loginButton">Login</b-button>
            </div>
            </b-form>
        </div>
        </div>
    </div>
</template>

<script>
import {mapState} from 'vuex';
export default {
  name: 'Login',
    data () {
        return {
            form: {
                usernam: '',
                password: '',
            },
            show: true,
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

// export class AuthService {

//   constructor(
//     private http: HttpClient
//   ) { }

//   logIn(username: string, password: string): Observable<any> {
//     const params = new HttpParams().set('username', username).set('password', password);
//     return this.http.get(api_url + '/Auth/Login', { params: params });
//   }

//   logOut() {
//     localStorage.clear();
//   }

//   isAuthenticated() {
//     return !!localStorage.getItem('auth');
//   }

//   getExpiration() {

//   }


    methods: {
        handleLogin() {
            var self = this;
            // this.$axiosServer.post('https://chefemployees.com/api/Auth/Login', {
            //     Usename: this.form.username,
            //     Password: this.form.password
            // })
            // .then((response) =>{
            //     this.$axiosServer.get('https://chefemployees.com/api/Auth/Login')
            //     console.log(response.data.token);
            //     self.$store.dispatch('loginToken', response.data.token);
            //     self.successfulLogin();
            // })
            // .catch((error) => {
            //     console.log("error");
            //     self.failedLogin("Invalid Username or Password");
            //     return error;
            // });
            this.$axiosServer.get('https://chefemployees.com/api/Auth/Login', {
                params:{
                    Username: this.form.username,
                    Password: this.form.password
                }
            })
            .then((response)=>{
                console.log(response.data)
                this.$store.dispatch('loginToken', response.data)
                this.successfulLogin();
            })
            .catch((error)=>{
                console.log(error)
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
