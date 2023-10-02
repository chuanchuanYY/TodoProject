
<script setup>
import {ref} from 'vue'
import {UpdateMemo} from '../Api/Memo'
import { ElLoading, ElMessage } from 'element-plus';
const Memo=ref()
const dialog=ref(false)
const open=(memo)=>{
    dialog.value=true
    Memo.value=memo
}
const update= async ()=>{
   const loading= ElLoading.service(Option)
   const res=await  UpdateMemo(Memo.value)
   if(res.data.isSuccess)
   {
     ElMessage.success('修改成功')
     dialog.value=false
   }
   loading.close()
}
defineExpose({
    open
})

</script>

<template>
    <el-drawer
      modal="true"
      direction="rtl"
      show-close="true"
      v-model="dialog"
      style="background: #3e3e3e; color: white"
    >
      <template #title>
        <div style="color: white; font-size: 1.8em">编辑备忘录</div>
      </template>
      <el-form>
        <el-form-item>
          <el-input
            v-model="Memo.title"
            placeholder="请输入备忘录概要"
          ></el-input>
        </el-form-item>
        <el-form-item>
          <el-input
            v-model="Memo.content"
            placeholder="请输入备忘录内容"
            type="textarea"
            rows="5"
          ></el-input>
        </el-form-item>
        <el-form-item>
          <div style="width: 100%;">
            <el-button type="success" style="float: right;width: 20%;" @click="update"> 修改 </el-button>
          </div>
        </el-form-item>
      </el-form>
    </el-drawer>
  </template>