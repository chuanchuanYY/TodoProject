
import requst from '../Api/Requst'

export  const userLoginService=({userName,password})=>{
  return requst.post('/api/User/Login',{userName:userName,password:password})
}