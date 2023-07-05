<template>
   <div class="main-content">
      <router-view></router-view>
    </div>
</template>
<script>
export default {
    name:"TheMain",
    components:{}
}
</script>
<style>
.main-content{
    width: calc(100% - 200px);
    height: calc(100vh - 56px);
    padding: 24px;
    background-color: #EEEFF1;
    float: left;
    box-sizing: border-box;
    clear: right;
}
</style>