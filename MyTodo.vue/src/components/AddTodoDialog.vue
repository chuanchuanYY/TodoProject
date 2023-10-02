<script setup>
import {ref} from 'vue'
import {AddTodo} from '../Api/Todo'
import {useUserStore} from '../stores/User'

const emit=defineEmits(['OnDialogClosed'])
const dialogFormVisible=ref(false)
const UserStore=useUserStore()
const open=()=>{
   dialogFormVisible.value=true
}

defineExpose({
    open
})
const _title=ref('')
const _content=ref('')
//添加代办对话框Model
const selectValue = ref(false);
const optionValue = [
  {
    value:false,
    label: "未完成",
  },
  { value: true, label: "完成" },
];

const confirmAdd=async ()=>{
    await AddTodo({
      id:'3fa85f64-5717-4562-b3fc-2c963f66afa6',
      user:{userName:UserStore._userName,
      password:UserStore._password},
      title:_title.value,
      content:_content.value,
      isCompleted:selectValue.value
    })
    dialogFormVisible.value=false
    emit('OnDialogClosed')
}
</script>


<template>
    <el-dialog v-model="dialogFormVisible" title="添加代办">
  <el-from>
    <el-form-item label="状态:">
      <el-select v-model="selectValue" placeholder="请选择状态">
        <el-option
          v-for="item in optionValue"
          :key="item.value"
          :label="item.label"
          :value="item.value"
        >
        </el-option>
      </el-select>
    </el-form-item>
    <el-form-item>
      <el-input v-model="_title" placeholder="请输入代办概要"></el-input>
    </el-form-item>
    <el-form-item>
      <el-input v-model="_content" placeholder="请输入代办事项内容" type="textarea" 
      rows="5"></el-input>
    </el-form-item>
  </el-from>
  <template #footer>
    <span class="dialog-footer">
      <el-button @click="dialogFormVisible = false">Cancel</el-button>
      <el-button type="primary" @click="confirmAdd">
        Confirm
      </el-button>
    </span>
  </template>
</el-dialog>
</template>