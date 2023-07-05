<template>
    <div class="page">
        <h2>Báo cáo</h2>
        <button id="nvmanh" @click="btnClickOnClick">Click!</button>
        <li v-for="(item, index) in reports" :key="index">{{ item }}</li>
    </div>
</template>
<script>
export default {
    name:"ReportList",
    props:{
        name:{
            type:String,
            default:"MISA Report"
        }
    },
    methods: {
        getName(){
            return this.name;
        },
        btnClickOnClick(){
            this.count++;
            this.reports.push(`Báo cáo ${this.count}`);
        }
    },
    beforeCreate() {
        console.log("1.beforeCreate");
        console.log("prop: ",this.name);
        console.log("getName: ",this.getName);
        console.log("data: ",this.reports);
        let button= document.getElementById("nvmanh");
        console.log("button: ",button);
    },
    created() {
        console.log("2.created");
        console.log("prop: ",this.name);
        console.log("getName: ",this.getName);
        console.log("data: ",this.reports);
        let button= document.getElementById("nvmanh");
        console.log("button: ",button);
    },

    beforeMount() {
        console.log("3.beforeMount");
        console.log("prop: ",this.name);
        console.log("getName: ",this.getName);
        console.log("data: ",this.reports);
        let button= document.getElementById("nvmanh");
        console.log("button: ",button);
    },

    mounted() {
        console.log("4.mounted");
        console.log("prop: ",this.name);
        console.log("getName: ",this.getName);
        console.log("data: ",this.reports);
        let button= document.getElementById("nvmanh");
        console.log("button: ",button);
    },
    beforeUpdate() {
        console.log("beforeUpdate");
    },
    updated() {
        console.log("updated");
    },
    beforeUnmount() {
        console.log("7.beforeUnmount");
        console.log("prop: ",this.name);
        console.log("getName: ",this.getName);
        console.log("data: ",this.reports);
        let button= document.getElementById("nvmanh");
        console.log("button: ",button);
    },

    unmounted() {
        console.log("8.unmounted");
        console.log("prop: ",this.name);
        console.log("getName: ",this.getName);
        console.log("data: ",this.reports);
        let button= document.getElementById("nvmanh");
        console.log("button: ",button);
    },

    data() {
        return {
            reports:["Báo cáo 1", "Báo cáo 2"],
            count: 10
        }
    },
}
</script>
<style scoped>
    .page{
        width: 100%;
        height: 100%;
        background-color: #fff;
        border-radius: 4px;
        padding: 16px;
    }
</style>