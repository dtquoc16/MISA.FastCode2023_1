<template>
  <div class="m-dialog">
    <div class="m-dialog-container">
      <button class="m-dialog__button--close" @click="onCloseDialog"></button>
      <div class="m-dialog__header">Tiêu đề Dialog</div>
      <div class="m-dialog__body">
        <div class="m-dialog__body--notice">
          <div class="m-dialog__icon icon icon--question"></div>
          <div class="m-dialog__text">
           <li v-for="(item,index) in errors" :key="index">{{ item }}</li>
        </div>
        </div>
      </div>
      <div class="m-dialog__footer">
        <button class="m-button m-button--cancel">Hủy bỏ</button>
        <button class="m-button m-dialog__button--confirm m-button--primary">
          Xác nhận
        </button>
      </div>
    </div>
  </div>
</template>
<script>
export default {
    name:"MISANotice",
    props:["errors"],
    inject:["provideProps"],
    created() {
      console.log("provideProps:",this.provideProps);
    },
    methods:{
        saveDate(){
        },
        onCloseDialog(){
          this.$emit("onCloseDialog");
        }
    },
    data() {
        return {
            isValid: true,
            name:"Nguyễn Văn Mạnh",
            customer:{
                fullName:"ABC",
                Age: 18
            }
        }
    },
}
</script>
