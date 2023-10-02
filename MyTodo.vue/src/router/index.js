import { createRouter, createWebHistory } from "vue-router";

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    { path: "/", component: () => import("../views/Login.Vue") },
    { 
      path: "/Main",
       component: () => import("../views/Layout.vue"),
       children:[
        {
          path:'/Main/Home',
          component:()=>import('../views/Pages/Home.vue')
        },
        {
          path:'/Main/Todo',
          component:()=>import('../views/Pages/Todo.vue')
        },
        {
          path:'/Main/Memo',
          component:()=>import('../views/Pages/Memo.vue')
        },
        {
          path:'/Main/Setting',
          component:()=>import('../views/Pages/Setting.vue')
        }
       ]
    },
  ],
});

export default router;
