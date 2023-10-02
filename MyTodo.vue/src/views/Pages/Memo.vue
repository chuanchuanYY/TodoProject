
<script setup>
  import {ref} from 'vue'
  import {GetAllMemo} from '../../Api/Memo'
  import MemoUpdate from '../../components/MemoUpdate.vue'
  import AddMemoDialog from '../../components/AddMemoDialog.vue'
  //初始化MemoList
const rawMemoList=ref()
const MemoList=ref()
const init= async ()=>{
   const res= await GetAllMemo()
   rawMemoList.value=res.data.content
   MemoList.value=rawMemoList.value
}
init()

const MemoUpdateRef=ref()
const update=(item)=>{
    MemoUpdateRef.value.open(item)
}
const AddMemoDialogRef=ref()
const Add=()=>{
    AddMemoDialogRef.value.open()
}
const onAdded=()=>{
    init()
}
//数据筛选
const serachText=ref('')
const SearchMemo=(conditionText)=>{
   const result=rawMemoList.value.filter((item)=>{
      return item.title.includes(conditionText)||item.content.includes(conditionText)
   })
   MemoList.value=result
}
</script>
<template>
    <div style="height: 100%; width: 100%">
   <div style="height: 10%; margin-left: 10px">
     <el-input v-model="serachText" @input="SearchMemo" placeholder="查找备忘录" style="width: 200px"> </el-input>
     <el-button type="success" @click="Add" style="float: right; margin-right: 20px"
       >+添加备忘录</el-button
     >
   </div>
   <div class="content" style="height: 85%; width: 100%; background: #2a2a2a">
     <el-scrollbar>
       <div class="MemoCard" v-for="item in MemoList">
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
 <MemoUpdate ref="MemoUpdateRef"></MemoUpdate>
 <AddMemoDialog ref="AddMemoDialogRef" @on-confirmed="onAdded"></AddMemoDialog>
</template>


<style scoped>
.content {
  box-sizing: border-box;
  padding-left: 20px;
}
.MemoCard {
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
