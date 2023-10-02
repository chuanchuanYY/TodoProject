import axios  from "axios";
import {useUserStore} from '../stores/User'

const instance =axios.create({
   baseURL:'https://localhost:7027',
    timeout:10000
})


// 添加请求拦截器
instance.interceptors.request.use( (config)=>{
    // 在发送请求之前做些什么
    const UserStore =useUserStore()
    if(UserStore.token)
    {
       config.headers.Authorization='Bearer'+' '+UserStore.token
    }
    return config;
  }, function (error) {
    // 对请求错误做些什么
    alert('发起请求错误')
    return Promise.reject(error);
  });

// 添加响应拦截器
instance.interceptors.response.use( (response)=> {
    // 2xx 范围内的状态码都会触发该函数。
    // 对响应数据做点什么
   
    return response;
  },  (error)=> {
    // 超出 2xx 范围的状态码都会触发该函数。
    // 对响应错误做点什么
    alert('响应出错')
    return Promise.reject(error);
  });

  export default instance
