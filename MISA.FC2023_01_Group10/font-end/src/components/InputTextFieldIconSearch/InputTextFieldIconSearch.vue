<template>
    <div class="input__container search">
      <input v-bind="$attrs" :value="modelValue" @input="handleInput" />
      
      <div class="icon-search input-icon-search icon"></div>
    </div>
  </template>
  
  <script>
  import { debounce } from "lodash";
  export default {
    name: "InputTextFieldIconSearch",
    components: {},
    props: {
      modelValue: {
        type: String,
        default: "",
      },
    },
    methods: {
      handleInput: debounce(function (e) {
        this.$emit("update:modelValue", e.target.value);
      }, 500),
    },
  };
  </script>
  
  <style scoped>
.input__container {
    position: relative;
}

  .search {
    position: relative;
    width: 260px;
  }
  .search input {
    height: 36px;
    padding-right: 32px;
    width: 100%;
    outline: none;
    padding-left: 12px;
  }
  
  .input-icon-search {
    position: absolute;
    top: 43%;
   
    /* transform: translate(0, -50%); */
    transform: translateY(-50%);
    right: 8px;
  }
  .icon-search {
    background: url("@/assets/Sprites.64af8f61.svg") no-repeat -425px -33px;
    width: 22px;
    height: 22px;
  }
  </style>