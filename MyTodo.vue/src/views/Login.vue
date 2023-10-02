<script setup>
import {ref} from 'vue'
import {userLoginService} from '../Api/User'
import { ElMessage } from 'element-plus'
import {useUserStore} from '../stores/User'
import router from '../router/index'
import {ElLoading} from 'element-plus'
const UserStore=useUserStore()
const UserModel=ref({
    userName:'',
    password:''
})
const form=ref({})
const rules={
    userName:[
        {required: true,message:'Pleace input Account'}
    ],
    password:[
        {required: true,message:'Pleace input Paassword'}
    ]
}
const OnLogin = async ()=>{
    //form.value.validata()
    const lodaing=ElLoading.service(Option)
    const res=await userLoginService(UserModel.value)
    UserStore.setToken(res.data.token)
    if(res.data.token)
    {
      router.push('/Main')
      UserStore.setUser(res.data.content)
      ElMessage.success('登录成功')
    }else {
        ElMessage.error('账号或密码错误')
    }
    lodaing.close()
}

</script>
<template>
    <el-row justify="space-between" style="height: 100vh;">
    <el-col :span="12">
     <img src="../assets/LoginBack.png" style="width: 60vw;height: 50vh;margin-top: 25vh;">
    </el-col>
    <el-col :span="6" :pull="3">
        <el-form style="margin-top: 30vh;"
          ref="form"
         :model="UserModel"
         :rules="rules">
            <el-form-item  >
                <div style="font-weight: bold;font-size: 2em;">Login</div>
            </el-form-item>
            <el-form-item  prop="userName" >
                <el-input v-model="UserModel.userName" placeholder="pleace input UserName"></el-input>
            </el-form-item>
            <el-form-item prop="password" >
                <el-input v-model="UserModel.password" show-password placeholder="Pleace input Password"></el-input>
            </el-form-item>
            <el-form-item>
                <el-button type="primary" style="width: 100%;" @click="OnLogin">Login</el-button>
            </el-form-item>
            <el-form-item>
                <div>Register</div>
            </el-form-item>
        </el-form>
    </el-col>
    </el-row>
</template>