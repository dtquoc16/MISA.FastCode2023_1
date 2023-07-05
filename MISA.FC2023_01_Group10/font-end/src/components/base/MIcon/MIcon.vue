<template>
    <m-popper v-if="tooltip" hover arrow placement="top">
        
        <div :class="cClass" class="icon"  >
            <div :class="icon"></div>
        </div>

        <template #content> {{ tooltip }}</template>
    </m-popper>

    <div :class="cClass" class="icon"   v-else>
        <div :class="icon"></div>
    </div>
              
</template>

<script>
export default {
    name: "MIcon",
    props: {
        icon: {
            type: String,
            default: ""
        },
        cClass: {
            type:String,
            default: ""
        },
        tooltip: {
            type: String,
            default: ""
        }
    }
}
</script>

<style scoped>

</style>
