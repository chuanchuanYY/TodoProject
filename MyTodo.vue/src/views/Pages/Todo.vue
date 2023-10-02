<script setup>
import { ref } from "vue";
import { GetAllTodo } from "../../Api/Todo";
import { ElLoading } from "element-plus";
import TodoUpdate from "../../components/TodoUpdate.vue";
import AddTodoDialog from "../../components/AddTodoDialog.vue";
const selectValue = ref("全部");
const selectOptions = ref([
  { label: "全部", value: "全部" },
  { label: "未完成", value: "未完成" },
  { label: "已完成", value: "已完成" },
]);
const serachCondition=ref('')
//获取Todo集合
const rawTodoList = ref();
const TodoList = ref();
const Init = async () => {
  const loading = ElLoading.service({ background: "Rgba(0,0,0,0.3)" });
  const res = await GetAllTodo();
  rawTodoList.value = res.data.content;
  TodoList.value = rawTodoList.value;
  loading.close();
};
Init();

const update = (todo) => {
  todoUpdate.value.open(todo);
};
const addTodoDialogRef=ref()
const Add=()=>{
    addTodoDialogRef.value.open()
}
const todoUpdate = ref();
const onUpdateClosed = () => {
  //没有要处理的
};

//数据筛选
const SearchTodo=(conditionText)=>{
    onselectChanged(selectValue.value)
    const result=TodoList.value.filter((item)=>{
       return item.title.includes(conditionText)
    })
    TodoList.value=result
}
const onselectChanged = (value) => {
  if (value === selectOptions.value[0].value) {
    TodoList.value = rawTodoList.value;
  } else if (value === selectOptions.value[1].value) {
    const result = rawTodoList.value.filter((item) => {
      return item.isCompleted === false;
    });
    TodoList.value = result;
  } else {
    const result = rawTodoList.value.filter((item) => {
      return item.isCompleted === true;
    });
    TodoList.value = result;
  }
};
</script>
<template>
  <div style="height: 100%; width: 100%">
    <div style="height: 10%; margin-left: 10px">
      <el-input v-model="serachCondition" @input="SearchTodo" placeholder="查找代办事项" style="width: 200px"> </el-input>
      <span style="color: white; margin-left: 20px">筛选：</span>
      <el-select v-model="selectValue" @change="onselectChanged">
        <el-option
          v-for="item in selectOptions"
          :label="item.label"
          :value="item.value"
        >
        </el-option>
      </el-select>
      <el-button type="success" @click="Add" style="float: right; margin-right: 20px"
        >+添加代办</el-button
      >
    </div>
    <div class="content" style="height: 85%; width: 100%; background: #2a2a2a">
      <el-scrollbar>
        <!--可以TodoCard可以封装成组件 和Memo共用-->
        <div class="TodoCard" v-for="item in TodoList">
          <div>
            <div style="display: inline-block;overflow: hidden;width: 80%;height: 20px;box-sizing: border-box;">{{ item.title }}</div>
            <el-icon class="icon" style="float: right" @click="update(item)"
              ><Edit
            /></el-icon>
          </div>
          <div style="overflow: hidden; height: 100px; color: #ffffffd6">
            {{ item.content }}
          </div>
        </div>
      </el-scrollbar>
    </div>
  </div>
  <AddTodoDialog ref="addTodoDialogRef" @-on-dialog-closed="Init"></AddTodoDialog>
  <TodoUpdate ref="todoUpdate" @on-closed="onUpdateClosed"></TodoUpdate>
</template>

<style scoped>
.content {
  box-sizing: border-box;
  padding-left: 20px;
}
.TodoCard {
  box-sizing: border-box;
  height: 140px;
  width: 170px;
  background: #10b134;
  border-radius: 10px;
  margin: 15px;
  float: left;
  padding: 5px;
  color: white;
}



.icon:hover {
  color: mediumpurple;
  transition: 1s;
}
</style>
