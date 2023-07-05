<template>
  <router-link :to="'discuss/'+data.ThreadId">
    <div class="q-wrapper">
      <img src="@/assets/icon/question-48.png" class="icon" v-if="data.ThreadType === 1"/>
      <img src="@/assets/icon/discuss-32.png" class="icon" v-if="data.ThreadType === 2"/>
      <img src="@/assets/icon/share-64.png" class="icon" v-if="data.ThreadType === 3"/>
  
      <div class="quetion-content">
        <div class="q-title">{{ data.ThreadName }}</div>
        <div class="q-desc">
          <div class="q-author">{{ data.ThreadUser }}</div>
          <div class="q-status">Đã trả lời: {{ data.AnswerNumber }}</div>
        </div>
      </div>
    </div>
  </router-link>
   
   
  </template>
  
  <script>
  export default {
    name: "QuestionItem",
    props: {
      data: {
        type: Object
      }
    },
    data(){
      return {
       
      }
    }
  };
  </script>
  
  <style scoped>
  .q-wrapper {
    display: flex;
    align-items: center;
    background-color: white;
    border-bottom: 1px solid #ccc;
    padding: 8px;
    cursor: pointer;
  }
  .q-wrapper:hover {
      background-color: rgba(0, 0, 0, .05);
  }
  .icon {
    margin-right: 16px;
    width: 36px;
    height: 36px;
  }
  .quetion-content {
    display: flex;
    flex-direction: column;
  }
  .q-title {
    color: green;
    font-weight: 700;
    font-size: 16px;
  }
  .q-desc {
    display: flex;
  }
  .q-author {
    margin-right: 20px;
    font-size: 13px;
  }
  .q-status {
    font-size: 13px;
  }
  </style>