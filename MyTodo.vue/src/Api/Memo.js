import requst from '../Api/Requst'
import { useUserStore } from '../stores/User'
const UserStore =useUserStore()
export const GetAllMemo=()=>{
    return requst.get('/api/Memo/GetAllByUser',{
      params:{
          userName:UserStore._userName,
          Password:UserStore._password
      }
    })
  }
  export const UpdateMemo=(data)=>{
   return requst.post('/api/Memo/Update',data)
  }
  
  export const AddMemo=(data)=>{
   return requst.post('/api/Memo/Add',data)
  }