import { defineStore } from "pinia";
import {ref} from 'vue'

//用户模块
export const useUserStore =defineStore('todo-user',()=>{
    //定义一个变量用于存储 jwt token 
    const token=ref('')
    const _userName=ref('')
    const _password=ref('')
    //定义一个函数，用于设置Token
    const setToken=(newToken)=>{
        token.value=newToken
    }
    const removeToken=()=>{
        token.value=''
    }
    const setUser=({userName,password})=>{
         _userName.value=userName
         _password.value=password
    }
    //把定义好的东西暴露出去
    return {
        token,
        setToken,
        removeToken,
        _userName,
        _password,
        setUser
    }
},
{
    persist:true
}
)