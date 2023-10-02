<script setup>
import { Picture as IconPicture } from "@element-plus/icons-vue";
import {useUserStore} from '../stores/User'

const UserStore=useUserStore()

</script>
<template>
  <div class="common-layout">
    <el-container style="height: 100%; width: 100%">
      <el-aside width="200px" style="height: 100%; padding: 0;margin: 0;">
        <el-menu
          active-text-color="#80ff80"
          background-color="#3e3e3e"
          default-active="1"
          text-color="#fff"
          style="padding-top: 30px; height: 100%"
          router="true"
        >
          <div style="text-align: center; color: white">
            <el-image style="border-radius: 50%; height: 60px; width: 60px">
              <template #error>
                <div class="image-slot">
                  <el-icon><icon-picture /></el-icon>
                </div>
              </template>
            </el-image>
            <div placeholder="455455">{{UserStore.UserName}}</div>
          </div>

          <el-menu-item index="/Main/Home">
            <el-icon><House /></el-icon>
            <template #title>首页</template>
          </el-menu-item>
          <el-menu-item index="/Main/Todo">
            <el-icon><List /></el-icon>
            <template #title>代办事项</template>
          </el-menu-item>
          <el-menu-item index="/Main/Memo">
            <el-icon><Memo /></el-icon>
            <template #title>备忘录</template>
          </el-menu-item>
          <el-menu-item index="/Main/Setting">
            <el-icon><Setting /></el-icon>
            <template #title>设置</template>
          </el-menu-item>
        </el-menu>
      </el-aside>
      <el-container >
        <el-header style="background: #2a2a2a;">
        <div style="color: white;font-size: 2em;">TOdo</div>
        </el-header>
        <el-main style="padding: 0;margin: 0;background: #2a2a2a;"><RouterView></RouterView></el-main>
      </el-container>
    </el-container>
  </div>
</template>

<style scoped>
.common-layout {
  height: 100vh;
  width: 100vw;
}

.image-slot {
  display: flex;
  justify-content: center;
  align-items: center;
  width: 100%;
  height: 100%;
  background: var(--el-fill-color-light);
  color: var(--el-text-color-secondary);
  font-size: 30px;
}
</style>
