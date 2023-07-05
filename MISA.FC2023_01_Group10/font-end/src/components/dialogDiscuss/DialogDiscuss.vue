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
              required
              label="Họ và tên"
              ref="EmployeeCodeRef"
              v-model="themes.FullName"
            />
            <m-input-text-field-with-validation
              name="Title"
              required
              label="Tiêu đề"
              ref="EmployeeCodeRef"
              v-model="themes.Title"
            />
            <div class="radio__container">
              <div class="radio__label">Loại chủ đề</div>

              <div class="radio__input">
                <div class="radio">
                  <input :value="1" id="male" type="radio" />
                  <label for="male" class="radio-label">Hỏi đáp</label>
                </div>
                <div class="radio">
                  <input :value="0" id="female" type="radio" />
                  <label for="female" class="radio-label">Thảo luận</label>
                </div>

                <div class="radio">
                  <input :value="-1" id="other" type="radio" />
                  <label for="other" class="radio-label">Chia sẻ</label>
                </div>
              </div>
            </div>
            <div>
              <Field v-model="name" type="text" name="Content" v-slot="{ field }">
                <textarea
                  v-bind="field"
                  id="w3review"
                  name="w3review"
                  rows="4"
                  cols="80"
                >
                </textarea>
              </Field>
              <div class="error-message">
                <ErrorMessage name="Content" />

              </div>
            </div>
            <div class="dialog__action">
              <m-button type="button" @click="hidden">Huỷ bỏ</m-button>
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
import { Form as ValidatorForm, Field, ErrorMessage } from "vee-validate";
import MIcon from "../base/MIcon/MIcon.vue";
import MButton from "../base/button/MButton.vue";
import * as Yup from "yup";
export default {
  name: "DialogDiscuss",
  components: {
    MInputTextFieldWithValidation,
    ValidatorForm,
    MIcon,
    MButton,
    Field,
    ErrorMessage
  },
  data() {
    const schema = Yup.object().shape({
      FullName: Yup.string().required("Thông tin này không được để trống"),
      Title: Yup.string().required("Thông tin này không được để trống"),
      Content: Yup.string().required("Thông tin này không được để trống"),
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
@import url("./dialogEmployee.css");
</style>
