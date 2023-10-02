<script setup>
import { ref } from "vue";
import { UpdateTodo } from "../Api/Todo";
const emit=defineEmits(['onClosed'])
const dialog = ref(false);
const newTodo = ref();
const open = (todo) => {
  dialog.value = true
  newTodo.value = todo
  selectValue.value=newTodo.value.isCompleted
};
const selectValue = ref(false);
const optionValue = [
  {
    value: false,
    label: "未完成",
  },
  { value: true, label: "完成" },
];
const update=async ()=>{
    newTodo.value.isCompleted=selectValue.value     
   await UpdateTodo(newTodo.value)
   emit('onClosed')
   dialog.value=false
}
defineExpose({
  open
});
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
      <div style="color: white; font-size: 1.8em">编辑代办</div>
    </template>
    <el-form>
      <el-form-item label="状态：">
        <el-select
          v-model="selectValue"
          placeholder="请选择状态"
          style="background: transparent"
        >
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
        <el-input
          v-model="newTodo.title"
          placeholder="请输入代办概要"
        ></el-input>
      </el-form-item>
      <el-form-item>
        <el-input
          v-model="newTodo.content"
          placeholder="请输入代办事项内容"
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
