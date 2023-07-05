<template>
  <div class="page">
    <div class="page__header">
      <div class="page__title">Quản lý khách hàng</div>
      <div class="page__button">
        <button
          @click="btnAddOnClick"
          class="m-button m-button-icon m-button--primary icon icon-20 icon--add"
        >
          Thêm mới
        </button>
      </div>
    </div>
    <div class="page__container">
      <div class="m-table">
        <div class="m-table__toolbar">
          <div class="toolbar__left">
            <div id="selectionInfo" class="selected-info">
              <div>
                <span>Đã chọn </span><span class="number-selected">2</span>
              </div>
              <button class="btn--nobg btn--noborder text--red">Bỏ chọn</button>
              <button class="m-button m-button-icon icon icon-24 icon--delete">
                Xóa tất cả
              </button>
            </div>
            <input id="txtSearch" type="text" class="m-input" hidden="" />
          </div>
          <div class="toolbar__right">
            <button class="m-button m-button-icon icon icon-24 icon--delete">
              Xóa
            </button>
            <button
              class="btn--notext icon icon-20 icon--export"
              title="XUẤT KHẨU"
            ></button>
            <button
              class="btn--notext icon icon-20 icon--refresh"
              title="LÀM MỚI DỮ LIỆU"
            ></button>
          </div>
        </div>
        <div class="m-table__container">
          <table border="0" id="tbCustomerList">
            <colgroup>
              <col name="col-1" width="50" />
              <col name="col-2" width="150" />
              <col name="col-3" width="350" />
              <col name="col-4" width="100" />
              <col name="col-5" width="150" />
              <col name="col-6" width="500" />
              <col name="col-7" width="500" />
            </colgroup>
            <thead>
              <tr>
                <th>
                  <input type="checkbox" />
                </th>
                <th>Mã khách hàng</th>
                <th>Họ và tên</th>
                <th>Giới tính</th>
                <th>Ngày sinh</th>
                <th>Công ty</th>
                <th>Dư nợ</th>
              </tr>
            </thead>
            <tbody></tbody>
            <tr
              v-for="(customer, index) in customers"
              :key="customer.CustomerId"
            >
              <td><input type="checkbox" /></td>
              <td>{{ customer.CustomerCode }}</td>
              <td>{{ customer.FullName }}</td>
              <td>2</td>
              <td>31/5/2022</td>
              <td>{{ customer.CompanyName }}</td>
              <td>
                <button @click="onDelete(index)">Xóa</button>
                <button @click="onUpdate(customer)">Sửa</button>
              </td>
            </tr>
          </table>
        </div>
        <div class="m-table__paging">
          <div class="paging">
            <div class="paging__left">
              Tổng: <span class="paging__record-total">100</span>
            </div>
            <div class="paging__right">
              <div class="record-offset">Số bản ghi/trang</div>
              <div class="record-limit">
                <select class="paging__limit" name="" id="">
                  <option value="10">10</option>
                  <option value="10">20</option>
                  <option value="10">50</option>
                </select>
              </div>
              <div>
                <button class="paging__button paging__button--prev"></button>
                <button class="paging__button paging__button--next"></button>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
  <CustomerForm
    v-if="showCustomerForm"
    :hideForm="hideFormDetail"
    @emitCloseForm="hideFormDetail"
    :customerEdit="customerForUpdate"
  ></CustomerForm>
  <MISANoticeDialog
    v-show="showNotice"
    content="Đây là nội dung thông báo"
  ></MISANoticeDialog>
</template>
<script>
import CustomerForm from "./CustomerForm.vue";
import MISANoticeDialog from "@/components/base/notice/MISANoticeDialog.vue";
export default {
  name: "CustomerList",
  provide: {
    provideProps: "MISA",
  },
  components: { CustomerForm, MISANoticeDialog },
  created() {
    this.$_emitter.on("onCloseEmitter", () => {
      this.showCustomerForm = false;
    });
    this.$_axios
      .get("https://cukcuk.manhnv.net/api/v1/customers")
      .then((res) => {
        console.log(res);
        this.customers = res.data;
      });
  },
  unmounted() {
    this.$_emitter.off("onCloseEmitter");
  },
  methods: {
    onDelete(index) {
      this.customers.splice(index, 1);
    },
    onUpdate(customer) {
      // Hiển thị form thông tin chi tiết:
      this.showCustomerForm = true;
      this.customerForUpdate = customer;
    },
    btnAddOnClick() {
      this.customerForUpdate = {};
      this.showCustomerForm = true;
    },
    hideFormDetail() {
      this.showCustomerForm = false;
    },
  },
  data() {
    return {
      showCustomerForm: false,
      showNotice: false,
      customers: [],
      customerForUpdate: {},
    };
  },
};
</script>
<style></style>
