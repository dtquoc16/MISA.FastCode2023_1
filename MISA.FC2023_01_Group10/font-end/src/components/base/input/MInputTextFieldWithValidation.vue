<template>
    <div class="input__container">
      <label v-if="label" :for="name">
        <m-popper v-if="tooltip" hover arrow placement="top">
          {{ label }}<span v-if="required">*</span>
          <template #content> {{ tooltip }}</template>
        </m-popper>
        <div v-else> {{ label }}<span v-if="required">*</span> </div>
      </label>
      <Field
        :id="name"
        :name="name"
        :type="type"
        v-model="innerValue"
        v-slot="{ field, errors }"
        validateOnInput
      >
        <input
          v-bind="field"
          ref="inputRef"
          :class="{ 'input-invalid': errors.length > 0 }"
          :placeholder="placeholder"
        />
      </Field>
      <ErrorMessage :name="name" />
    </div>
  </template>
  <script>
  import { Field, ErrorMessage } from "vee-validate";
  export default {
    name: "MInputTextFieldWithValidation",
    components: { Field, ErrorMessage },
    props: {
      modelValue: {
        type: [String, Number],
        default: "",
      },
      id: {
        type: String,
        default: "",
      },
      name: {
        type: String,
        default: "",
      },
      label: {
        type: String,
        default: "",
      },
      required: {
        type: Boolean,
        default: false,
      },
      placeholder: {
        type: String,
        default: "",
      },
      type: {
        type: String,
        default: "text",
      },
      tooltip: {
        type: String,
        default: ""
      }
    },
    created() {
      if (this.modelValue) {
        this.innerValue = this.modelValue;
      }
    },
    data() {
      return {
        innerValue: "",
      };
    },
    methods: {
      /**
       * updateInput: update dữ liệu lên component cha
       * @author: TMThuc (31/05/2023)
       */
      updateInput(event) {
        this.$emit("update:modelValue", event.target.value);
      },
      /**
       * focus: forcus vào input
       * @author: TMThuc (31/05/2023)
       */
      focus() {
        this.$refs.inputRef.focus();
      },
    },
    watch: {
      innerValue(val) {
        this.$emit("update:modelValue", val);
      },
      modelValue(newVal) {
        this.innerValue = newVal;
      },
    },
  };
  </script>
  
  <style>
  @import url("./input.css");
  </style>
  