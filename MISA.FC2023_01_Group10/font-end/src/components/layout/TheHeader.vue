<template>
    <div class="header">
      <div class="header__left">
        <div class="toggle"></div>
        <div class="logo-2">MISA QA</div>
      </div>
      <div class="header__right">
        <div></div>
        <div class="avatar"></div>
      </div>
    </div>
</template>
<script>
import app from "@/main.js"
export default {
    name:"TheHeader",
    mounted() {
        // app.config.globalProperties.$_LANG_CODE = this.$refs.optionLaguage.value;
    },
    methods: {
        onChangeLaguage(){
            const langCode = event.currentTarget.value;
            app.config.globalProperties.$_LANG_CODE = langCode;
            console.log(event);
        }
    },
}
</script>
<style scoped>
.header{
    height: 56px;
    width: 100%;
    float: left;
    display: flex;
    align-items: center;
}

.header__left{
    width: 200px;
    height: 100%;
    display: flex;
    align-items: center;
    padding-left: 16px;
    column-gap: 16px;
    box-sizing: border-box;
}

.toggle{
    width: 24px;
    height: 24px;
    background-image: url(../../assets/img/toggle.png);
    background-size: 24px 24px;
}
.logo{
    height: 36px;
    background-image: url(../../assets/cukcuk-logo.png);
    background-size: contain;
    background-repeat: no-repeat;
    flex:1;
}

.logo-2{
    font-size: 32px;
    font-weight: 700;
    color: var(--color-primary);
}
.header__right{
    flex: 1;
    height: 100%;
    display: flex;
    align-items: center;
    justify-content: space-between;
    padding-right: 24px;
    padding-left: 24px;
}

.avatar{
    width: 36px;
    height: 36px;
    border: 1px solid var(--border-color-default);
    border-radius: 50%;
    background-image: url(../../assets/img/default-avatar.jpg);
    background-size: contain;
}
</style>