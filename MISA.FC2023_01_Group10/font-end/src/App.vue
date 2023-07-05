<template>
  <div>
    <TheHeader></TheHeader>
    <TheSidebar></TheSidebar>
    <TheMain></TheMain>
    <MISAToast v-if="1==0"></MISAToast>
  </div>
</template>

<script>
import TheHeader from "@/components/layout/TheHeader.vue"
import TheSidebar from "@/components/layout/TheSidebar.vue"
import TheMain from "@/components/layout/TheMain.vue"
import MISAToast from "@/components/base/toast/MISAToast.vue"
export default {
  name: 'App',
  components: {
    TheHeader,TheSidebar,TheMain,MISAToast
  }
}
</script>

<style>
@import "./css/main.css";
</style>
