<template>
    <button v-bind="$attrs">
        <slot></slot>
    </button>
</template>
<script>
export default {
    name: "MButton"
}
</script>


<style scoped>
@import "./button.css";
</style>
