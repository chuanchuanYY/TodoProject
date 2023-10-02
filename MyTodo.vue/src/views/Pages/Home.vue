<script setup>
import { Plus, Check, Close } from "@element-plus/icons-vue";
import { ref } from "vue";
import { GetAllTodo, UpdateTodo } from "../../Api/Todo";
import { GetAllMemo } from "../../Api/Memo";
import { onMounted } from "vue";
import { ElMessage, ElMessageBox } from "element-plus";
import AddTodoDialog from '../../components/AddTodoDialog.vue';
import TodoUpdate from "../../components/TodoUpdate.vue";
import MemoUpdate from '../../components/MemoUpdate.vue'
import { useUserStore } from "../../stores/User";
import { ElLoading } from 'element-plus'
import AddMemoDialog from "../../components/AddMemoDialog.vue";
const UserStore = useUserStore();
const TodoList = ref([]);
const MemoList = ref([]);
const Count = ref(0);
const Complete = ref(0);
const CompletionRate = ref(0);
const MemoCount = ref(0);
const GetTodos = async () => {
  
  const res = await GetAllTodo();
  TodoList.value = res.data.content;
  Count.value = TodoList.value.length;
  const newList = TodoList.value.filter((value) => {
    return value.isCompleted === false;
  });
  TodoList.value = newList;
  Complete.value = Count.value - TodoList.value.length;
  CompletionRate.value = (Complete.value / Count.value) * 100;
 
};
const GetMemos = async () => {
  const res = await GetAllMemo();
  MemoList.value = res.data.content;
  MemoCount.value = MemoList.value.length;
};
const _onMounted=onMounted(() => {
  const loading=ElLoading.service({background:'rgba(0,0,0,0.7)'})
  GetTodos();
  GetMemos();
  loading.close()
});
const onTodoSwitchChanged = async (item) => {
  const res = await UpdateTodo(item);
  if (res.data.isSuccess) {
    ElMessage.success(item.title + "已完成");
    GetTodos();
  } else {
    ElMessage.error("请求异常");
  }
};

const dialog = ref();

const OpenAddTodoDialog = () => {
  dialog.value.open();
};
const onDialogClosed = () => {
  GetTodos();
};

const todoUpdateobj=ref()
const OpenUpdateTodo=(todo)=>{
  todoUpdateobj.value.open(todo)
 
}
const onTodoUpdateClosed=()=>{
  GetTodos();
}

/// Memo part
const addMemoDialog=ref()

const openAddMemoDialog=()=>{

  addMemoDialog.value.open()
}

const onAddMemoConFirm=()=>{
  _onMounted()
}

const memoUpdateRef=ref()

const openMemoUpdate=(item)=>{
  memoUpdateRef.value.open(item)

}
///
</script>
<template>
  <div style="background: #2a2a2a; height: 100%; width: 100%">
    <el-row style="height: 140px">
      <el-col :span="6">
        <div class="card" style="background: #0097ff">
          <el-icon color="white" size="2.5em"><Eleme /></el-icon>
          <div>汇总</div>
          <div style="font-size: 2em">{{ Count }}</div>
        </div>
      </el-col>
      <el-col :span="6">
        <div class="card" style="background: #11b136">
          <el-icon color="white" size="2.5em"><Finished /></el-icon>
          <div>已完成</div>
          <div style="font-size: 2em">{{ Complete }}</div>
        </div>
      </el-col>
      <el-col :span="6">
        <div class="card" style="background: #00b4db">
          <el-icon color="white" size="2.5em"><Histogram /></el-icon>
          <div>完成比例</div>
          <div style="font-size: 2em">{{ CompletionRate | toInterger }}%</div>
        </div>
      </el-col>
      <el-col :span="6">
        <div class="card" style="background-color: #ffa000">
          <el-icon color="white" size="2.5em"><Memo /></el-icon>
          <div>备忘录</div>
          <div style="font-size: 2em">{{ MemoCount }}</div>
        </div>
      </el-col>
    </el-row>
    <el-row style="height: 510px; width: 100%; padding-top: 10px">
      <el-col :span="12">
        <div class="ListBorder">
          <div class="ListBorderTitle">代办事项</div>
          <el-button
            type="success"
            :icon="Plus"
            circle
            @click="OpenAddTodoDialog"
          ></el-button>
          <div style="margin-top: 50px"></div>
          <el-scrollbar  height="410px">
          <div class="ListRow" v-for="item in TodoList"  @dblclick="OpenUpdateTodo(item)">
            <div style="display: inline-block">
              <div style="color:white">{{ item.title }}</div>
              <div style="color:rgba(191, 191, 191)">{{ item.content }}</div>
            </div>
            <el-switch
              v-model="item.isCompleted"
              class="mt-2"
              style="float: right"
              inline-prompt
              :active-icon="Check"
              @change="onTodoSwitchChanged(item)"
              :inactive-icon="Close"
            />
          </div>
        </el-scrollbar>
        </div>
      </el-col>
      <el-col :span="12">
        <div class="ListBorder">
          <div class="ListBorderTitle">备忘录</div>
          <el-button
            type="success"
            :icon="Plus"
            circle
            @click="openAddMemoDialog"
          ></el-button>
          <div style="margin-top: 50px"></div>
          <el-scrollbar height="410px">
          <div class="ListRow" v-for="item in MemoList" @dblclick="openMemoUpdate(item)">
            <div style="display: inline-block">
              <div style="color: white;">{{ item.title }}</div>
              <div style="color:rgba(191, 191, 191)">{{ item.content }}</div>
            </div>
          </div>
        </el-scrollbar>
        </div>
      </el-col>
    </el-row>
  </div>
  <AddTodoDialog
    ref="dialog"
    @-on-dialog-closed="onDialogClosed"
  ></AddTodoDialog>
  <TodoUpdate ref="todoUpdateobj" @on-closed="onTodoUpdateClosed"></TodoUpdate>
   <MemoUpdate ref="memoUpdateRef"></MemoUpdate>
  <AddMemoDialog ref="addMemoDialog" @on-confirmed="onAddMemoConFirm"></AddMemoDialog>
</template>

<style scoped>
.el-col {
  padding: 10px;
}
.card {
  background: #548679;
  border-radius: 10px;
  width: 100%;
  height: 100%;
  box-sizing: border-box;
  padding: 10px;
}
.card div {
  color: white;
  font-size: 1.2em;
}

.ListBorder {
  background: #3e3e3e;
  padding: 10px;
  box-sizing: border-box;
  height: 100%;
  width: 100%;
  border-radius: 10px;
}
.ListBorder .ListBorderTitle {
  float: left;
  font-size: 1.5em;
  color: white;
}
.ListBorder .el-button {
  float: right;
}
.ListRow {
  border-radius: 3px;
  margin-top: 3px;
 
}
.ListRow:hover {
  background: #505050;
}
</style>
