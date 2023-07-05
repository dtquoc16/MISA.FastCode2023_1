<template>
    <div class="page">
       
    </div>
</template>
<script>
export default {
    name: "HomeIndex",
    created() {
        // fetch('data/threads.json')
        //     .then((response) => response.json())
        //     .then((json) => console.log(json));
    },
    data() {
        return {
            data: [
                {
                    "ThreadId": 1,
                    "ThreadName": "Cần giúp đỡ về việc sử dụng thuộc tính flex?",
                    "ThreadType": 1,
                    "ThreadUser": "Nguyễn Văn Mạnh",
                    "AnswerNumber": 100,
                    "CreatedDate": ""
                },
                {
                    "ThreadId": 2,
                    "ThreadName": "Có bao nhiêu cách để thực hiện layout website?",
                    "ThreadType": 1,
                    "ThreadUser": "Đỗ Văn Cường",
                    "AnswerNumber": 8,
                    "CreatedDate": ""
                },
                {
                    "ThreadId": 3,
                    "ThreadName": "Thảo luận về hiệu năng sử dụng các component có binding 2 chiều với nhiều thông tin.",
                    "ThreadType": 2,
                    "ThreadUser": "Nguyễn Thị Nga",
                    "AnswerNumber": 12,
                    "CreatedDate": ""
                },
                {
                    "ThreadId": 4,
                    "ThreadName": "Chia sẻ việc lập trình đồng bộ trong Javascript, những điều cần lưu ý.",
                    "ThreadType": 3,
                    "ThreadUser": "Hoàng Ngọc Hân",
                    "AnswerNumber": 54,
                    "CreatedDate": ""
                },
                {
                    "ThreadId": 5,
                    "ThreadName": "Cho em hỏi về đồ án tốt nghiệp tại trường ĐH Bách Khoa.",
                    "ThreadType": 1,
                    "ThreadUser": "Trần Diễm Giang",
                    "AnswerNumber": 20,
                    "CreatedDate": ""
                }
            ]
        }
    },
}
</script>
<style scoped>
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

.thread-item+.thread-item {
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