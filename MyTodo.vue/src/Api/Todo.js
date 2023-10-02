import requst from '../Api/Requst'
import { useUserStore } from '../stores/User'
const UserStore =useUserStore()
export const GetAllTodo=()=>{
  return requst.get('/api/Todo/GetAllByUser',{
    params:{
        userName:UserStore._userName,
        Password:UserStore._password
    }
  })
}
export const UpdateTodo=(data)=>{
 return requst.post('/api/Todo/Update',data)
}

export const AddTodo=(data)=>{
 return requst.post('/api/Todo/Add',data)
}