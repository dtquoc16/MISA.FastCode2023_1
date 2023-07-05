<template>
    <div class="overlay" v-if="isShow">
      <div class="dialog__container" >
        <div class="dialog">
          <div class="dialog__header" >
            <slot name="header"></slot>
          </div>
         
          <div>
            <div class="dialog__content">
              <slot name="content"></slot>
            </div>
          </div>
        </div>  
      </div>
    </div>
  </template>
  <script>
  // import MButton from '../button/MButton.vue';
  
  export default {
    name: "MFormDialog",
    components: {
      
      
    },
    props: {
      title: {
        type: String,
        default: "",
      },
    },
    data() {
      return {
        isShow: false,
      }
    },
  
    methods: {
      /**
       * show: để hiện thị form dialog
       * @author: TMThuc (28/05/2023)
       */
      show() {
        this.isShow = true;
      },
      /**
       * hidden: để ẩn form dialog
       * @author: TMThuc (28/05/2023)
       */
      hidden() {
        this.isShow = false;
      },
      
    }
  };
  </script>
  <style scoped>
  @import url("./m-form-dialog.css");
  </style>
  