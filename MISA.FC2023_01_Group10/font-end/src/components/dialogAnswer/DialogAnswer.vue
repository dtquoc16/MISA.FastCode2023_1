<template>
    <div class="overlay" v-if="isShow">
      <div class="dialog__container">
        <div class="dialog">
          <div class="dialog__header">
            <div class="dialog__title__name">Thông tin chủ đề</div>
            <m-icon icon="icon-close" tooltip="Đóng form" @click="hidden" />
          </div>
          <ValidatorForm
            :validation-schema="schema"
            ref="formRef"
            v-slot="{ handleSubmit }"
          >
            <form @submit="handleSubmit($event, onSubmit)">
              <m-input-text-field-with-validation
                name="FullName"
                ref="EmployeeCodeRef"
                v-model="themes.FullName"
                placeholder="Nhập họ và tên"
              />
              <m-input-text-field-with-validation
                name="Title"
                ref="EmployeeCodeRef"
                v-model="themes.Title"
                placeholder="Nhập nội dung"
              />
              
              <div class="dialog__action__custom">
                <m-button type="button" class="btn--red" @click="hidden">Huỷ bỏ</m-button>
                <m-button class="btn--primary">Lưu</m-button>
              </div>
            </form>
          </ValidatorForm>
        </div>
      </div>
    </div>
  </template>
  
  <script>
  import MInputTextFieldWithValidation from "../base/input/MInputTextFieldWithValidation.vue";
  import { Form as ValidatorForm } from "vee-validate";
  import MIcon from "../base/MIcon/MIcon.vue";
  import MButton from "../base/button/MButton.vue";
  import * as Yup from "yup";
  export default {
    name: "DialogAnswer",
    components: {
      MInputTextFieldWithValidation,
      ValidatorForm,
      MIcon,
      MButton,
    },
    data() {
      const schema = Yup.object().shape({
        Title: Yup.string().required("Thông tin này không được để trống"),
      });
      return {
        themes: {},
        isShow: false,
        schema,
      };
    },
    methods: {
      onSubmit(values) {
        // Submit values to API...
        alert(JSON.stringify(values, null, 2));
      },
      show() {
        this.isShow = true;
      },
      hidden() {
        this.isShow = false;
      },
    },
  };
  </script>
  
  <style scoped>
  @import url("./dialog.css");
  </style>
  