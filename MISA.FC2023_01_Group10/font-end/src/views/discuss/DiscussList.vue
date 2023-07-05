<template>
    <div>
      <div class="title-wrapper">
        <span class="page">Thảo luận/ hỏi đáp</span>
  
        <button class="icon-button btn create">
          <img src="@/assets/icon/add.png" alt="" />
          <p class="btn-label" @click="handleAddTheme">Thêm mới</p>
        </button>
      </div>
      <div class="page-content" v-if="!showDetail">
        <div class="page-content-header">
          <InputTextFieldIconSearch />
          <div class="reload">
            <img src="@/assets/icon/refresh.png" alt="" />
          </div>
        </div>
        <QuetionItem
          v-for="item in data"
          :data="item"
          :key="item.ThreadId"
         
        />
      </div>
    </div>
    <!-- <DiscussDetail :data="data[0]" v-if="showDetail"></DiscussDetail> -->
   <dialog-discuss ref="dialogRef" />
  </template>
  <script>
  import DialogDiscuss from "@/components/dialogDiscuss/DialogDiscuss.vue"
//   import DiscussDetail from "./DiscussDetail.vue";
  import QuetionItem from "@/components/quetion-item/QuetionItem.vue";
  import InputTextFieldIconSearch from "@/components/InputTextFieldIconSearch/InputTextFieldIconSearch.vue";
  import axios from 'axios';
  export default {
    name: "DiscussList",
    components: {
      QuetionItem,
      InputTextFieldIconSearch,
   
      DialogDiscuss
    },
    created() {
      // fetch('data/threads.json')
      //     .then((response) => response.json())
      //     .then((json) => console.log(json));
    },
    data() {
      return {
        data: [
          {
            ThreadId: 1,
            ThreadName: "Cần giúp đỡ về việc sử dụng thuộc tính flex?",
            ThreadType: 1,
            ThreadUser: "Nguyễn Văn Mạnh",
            AnswerNumber: 100,
            CreatedDate: "",
          },
          {
            ThreadId: 2,
            ThreadName: "Có bao nhiêu cách để thực hiện layout website?",
            ThreadType: 1,
            ThreadUser: "Đỗ Văn Cường",
            AnswerNumber: 8,
            CreatedDate: "",
          },
          {
            ThreadId: 3,
            ThreadName:
              "Thảo luận về hiệu năng sử dụng các component có binding 2 chiều với nhiều thông tin.",
            ThreadType: 2,
            ThreadUser: "Nguyễn Thị Nga",
            AnswerNumber: 12,
            CreatedDate: "",
          },
          {
            ThreadId: 4,
            ThreadName:
              "Chia sẻ việc lập trình đồng bộ trong Javascript, những điều cần lưu ý.",
            ThreadType: 3,
            ThreadUser: "Hoàng Ngọc Hân",
            AnswerNumber: 54,
            CreatedDate: "",
          },
          {
            ThreadId: 5,
            ThreadName: "Cho em hỏi về đồ án tốt nghiệp tại trường ĐH Bách Khoa.",
            ThreadType: 1,
            ThreadUser: "Trần Diễm Giang",
            AnswerNumber: 20,
            CreatedDate: "",
          },
        ],
        discuss: {},
        showDetail: false,
        itemData: []
      };
    },
    methods: {
      fetchApi() {

      },
        handleAddTheme() {
            this.$refs.dialogRef.show()
        },
      onClick(item) {
        this.discuss = item;
        this.showDetail = true;
      },
      handleBack(){
        this.showDetail = false;

      }
    },
  };
  </script>
  <style >
  .page-content-header {
    display: flex;
    align-items: center;
    justify-content: space-between;
    margin-bottom: 24px;
  }
  .reload {
    border-radius: 4px;
    display: flex;
    align-items: center;
    justify-content: center;
    padding: 8px;
    background-color: #ccc;
    cursor: pointer;
  }
  .page-content {
    padding: 24px;
    background-color: white;
    margin-top: 16px;
    border-radius: 4px;
    height: calc(100% -24px);
  }
  .btn {
    width: 120px;
    display: flex;
    align-items: center;
    justify-content: center;
    height: 36px;
    width: fit-content;
    background-color: green;
    border-radius: var(--border-radius);
    color: var(--white);
    padding: 0 16px;
    border: none;
    cursor: pointer;
    flex-wrap: nowrap;
    border-radius: 4px;
  }
  .btn p {
    color: white;
    white-space: nowrap;
  }
  .title-wrapper {
    display: flex;
  }
  .page {
    font-weight: 700;
    font-size: 24px;
  }
  .page__container {
    padding: 16px;
  }
  
  .thread-list {
    display: flex;
    flex-direction: column;
    margin-top: 10px;
  }
  
  .thread__icon {
    width: 40px;
    height: 40px;
    background-size: 40px;
    border-radius: 50%;
    flex: 0 0 40px;
    background-repeat: no-repeat;
    background-position: center;
  }
  
  .thread-item {
    display: flex;
    align-items: center;
    justify-content: flex-start;
    column-gap: 10px;
    padding: 10px 0;
  }
  
  .thread-item + .thread-item {
    border-top: 1px solid var(--border-color-default);
  }
  
  .thread-item__title {
    font-weight: 700;
    color: var(--color-primary);
  }
  
  .thread-item__info {
    display: flex;
    align-items: center;
    column-gap: 16px;
    margin-top: 4px;
    font-size: 12px;
  }
  </style>