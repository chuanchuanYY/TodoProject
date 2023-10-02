<script setup>
import { ref } from "vue";
import { useUserStore } from "../stores/User";
import {AddMemo} from '../Api/Memo'
const UserStore=useUserStore()
const dialogVisiblity = ref(false);
const emit=defineEmits(['onConfirmed'])
const open = () => {
  dialogVisiblity.value = true;
};
defineExpose({
  open,
});

const formModel=ref({
   id:'3fa85f64-5717-4562-b3fc-2c963f66afa6',
   user:{userName:UserStore._userName,
   password:UserStore._password},
   title:'',
   content:'',
   isCompleted:false
})

const confirm=async()=>{
    await AddMemo(formModel.value)
    emit('onConfirmed')
    dialogVisiblity.value=false
}
</script>
<template>
  <el-dialog v-model="dialogVisiblity" title="添加备忘录">
    <el-form :model="formModel">
      <el-form-item>
        <el-input v-model="formModel.title" placeholder="请输入备忘录概要"></el-input>
      </el-form-item>
      <el-form-item>
        <el-input  v-model="formModel.content" placeholder="请输入备忘录内容"
        type="textarea" rows="5"></el-input>
      </el-form-item>
    </el-form>
    <template #footer>
      <span class="dialog-footer">
        <el-button @click="dialogVisiblity = false">Cancel</el-button>
        <el-button type="primary" @click="confirm">
          Confirm
        </el-button>
      </span>
    </template>
  </el-dialog>
</template>
