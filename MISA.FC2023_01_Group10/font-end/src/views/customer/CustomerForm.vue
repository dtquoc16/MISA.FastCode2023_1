<template>
  <!-- Đây là cái form - -------------------- -->
  <div class="m-form">
    <div class="m-form-container" style="min-width: 850px">
      <button class="m-form__button--close" @click="onCloseForm"></button>
      <div class="m-form__header">
        <div class="m-form__title">Thông tin khách hàng</div>
      </div>
      <div class="m-form__body">
        <div class="m-row col-gap-20">
          <div class="form-group" style="width: 400px">
            <div class="m-row">
              <!-- MÃ KHÁCH HÀNG -->
              <div class="control-wrapper" style="width: 150px">
                <m-input
                  ref="txtCustomerCode"
                  label="Mã khách hàng"
                  v-model="customer.CustomerCode"
                ></m-input>
                <div class="control__text--error">
                  Thông tin này không được phép để trống.
                </div>
              </div>
              <!-- HỌ VÀ TÊN -->
              <div class="control-wrapper flex-1">
                <m-input
                  label="Họ và tên"
                  v-model="customer.FullName"
                ></m-input>
                <div class="control__text--error">
                  Thông tin này không được phép để trống.
                </div>
              </div>
            </div>
            <div class="m-row">
              <div class="control-wrapper flex-1">
                <label for="">Số điện thoại</label>
                <input type="text" class="m-input" />
              </div>
            </div>
            <div class="m-row">
              <div class="control-wrapper flex-1">
                <label for="">Email</label>
                <input type="text" class="m-input" />
              </div>
            </div>
          </div>
          <div class="form-group flex-1">
            <div class="m-row">
              <div class="control-wrapper" style="width: 180px">
                <label for="">Ngày sinh</label>
                <input type="date" class="m-input" />
              </div>
              <div class="control-wrapper flex-1">
                <label for="">Giới tính</label>
                <div class="radio-group">
                  <div class="radio-item">
                    <input name="gender" type="radio" />
                    <label for="gender">Nam</label>
                  </div>
                  <div class="radio-item">
                    <input name="gender" type="radio" />
                    <label for="gender">Nữ</label>
                  </div>
                  <div class="radio-item">
                    <input name="gender" type="radio" />
                    <label for="gender">Khác</label>
                  </div>
                </div>
              </div>
              <div
                class="control-wrapper flex-1"
                style="width: 180px; flex: 0 0 180px"
              >
                <label for="" title="Số chứng minh thư nhân dân"
                  >Số CMTND</label
                >
                <input type="text" class="m-input" />
              </div>
              <div class="control-wrapper flex-1">
                <label for="">Ngày cấp</label>
                <input type="date" class="m-input" />
              </div>
              <div class="control-wrapper flex-1">
                <label for="">Nơi cấp</label>
                <input type="text" class="m-input" />
              </div>
            </div>
          </div>
          <div class="m-row">
            <div class="control-wrapper flex-1">
              <label for="">Số tiền nợ</label>
              <input type="text" class="m-input" style="width: 180px" />
            </div>
          </div>
          <!-- CÔNG TY -->
          <div class="m-row">
            <div class="control-wrapper flex-1">
              <label for="">Công ty</label>
              <input type="text" class="m-input" />
            </div>
          </div>
          <div class="m-row">
            <div class="control-wrapper flex-1">
              <label for="">Địa chỉ</label>
              <input type="text" class="m-input" />
            </div>
          </div>
        </div>
      </div>
      <!-- FOOTER - FORM -->
      <div class="m-form__footer">
        <button
          class="m-button m-button--primary"
          style="order: 2"
          @click="btnSaveOnClick"
        >
          Cất
        </button>
        <button
          class="m-button m-button--cancel"
          style="order: 1"
          @click="onCloseForm"
        >
          Hủy
        </button>
      </div>
    </div>
  </div>
  <MISANoticeDialog
    @onCloseDialog="showNotice = false"
    v-show="showNotice"
    content="Đây là nội dung thông báo"
    :errors="inValidErrors"
  ></MISANoticeDialog>
</template>
<script>
import MISANoticeDialog from "@/components/base/notice/MISANoticeDialog.vue";
export default {
  name: "CustomerForm",
  components: {
    MISANoticeDialog,
  },
  emits: ["emitCloseForm"],
  props: ["customerEdit", "hideForm"],
  created() {
    this.customer = this.customerEdit;
    if (this.formMode == this.$_MISAEnum.FORM_MODE.ADD) {
      // Lẫy mã nhân viên mới:
      this.$_axios
        .get("https://cukcuk.manhnv.net/api/v1/Customers/NewCustomerCode")
        .then((res) => {
          this.customer.CustomerCode = res.data;
        })
        .catch((res) => {
          this.processErrorResponse(res);
        });
    }
    // document.getElementById("txtCustomerCode").focus();
  },
  mounted() {
    this.$refs["txtCustomerCode"].focus();
  },
  beforeUpdate() {},
  updated() {},
  computed: {
    formMode() {
      if (this.customerEdit?.CustomerId) {
        return 0;
      } else {
        return 1;
      }
    },
    toUpperName() {
      console.log("count: ", this.count);
      return this.customer.FullName?.toUpperCase();
    },
  },
  watch: {
    customer: {
      handler: function (newValue, oldValue) {
        console.log("newValue: ", newValue);
        console.log("oldValue: ", oldValue);
      },
      deep: true,
    },
  },
  methods: {
    btnSaveOnClick() {
      try {
        console.log(1111111);
        // validate dữ liệu:
        this.onValidateData();
        // Dữ liệu đã hợp lệ thì gọi apui thực hiện cất dữ liệu:
        if (this.inValidErrors.length == 0) {
          if (this.formMode == this.$_MISAEnum.FORM_MODE.Add) {
            console.log("Edit!");
          } else {
            this.$_axios
              .post("https://cukcuk.manhnv.net/api/v1/customers", this.customer)
              .then((res) => {
                console.log(res);
                this.customers = res.data;
              })
              .catch((res) => {
                this.processErrorResponse(res);
              });
          }
        } else {
          this.showNotice = true;
        }
      } catch (error) {
        alert("Lỗi");
      }
    },
    processErrorResponse(res) {
      const status = res.response.status;
      const data = res.response.data;
      switch (status) {
        case 500:
          this.inValidErrors = [];
          this.inValidErrors.push(data.userMsg);
          this.showNotice = true;
          break;
        case 400:
          this.inValidErrors = [];
          this.inValidErrors.push(data.userMsg);
          this.showNotice = true;
          break;
        default:
          break;
      }
      console.log(res);
    },
    onValidateData() {
      this.inValidErrors = [];
      // Các thông tin bắt buộc nhập:
      if (
        this.customer.CustomerCode == "" ||
        this.customer.CustomerCode == null
      ) {
        this.inValidErrors.push(
          this.$_MISAResource[this.$_LANG_CODE].CustomerInValidError.Empty
        );
      }
      if (this.customer.FullName == "" || this.customer.FullName == null) {
        this.inValidErrors.push(
          this.$_MISAResource[this.$_LANG_CODE].FullNameInvalidError.Empty
        );
      }
      // Các thông tin cần đúng định dạng (Email)

      // Ngày tháng (Ngày sinh không được lớn hơn ngày hiện tại)
    },
    onCloseForm() {
      if (this.formMode == this.$_MISAEnum.FORM_MODE.Add) {
        console.log("Edit!");
      } else {
        console.log("Add!");
      }
      // this.$emit("emitCloseForm");
      this.$_emitter.emit("onCloseEmitter");
    },
    toUpperNameMethod() {
      this.count++;
      console.log("count: ", this.count);
      return this.customer.FullName?.toUpperCase();
    },
  },
  data() {
    return {
      customer: {},
      fullName: "",
      count: 1,
      showNotice: false,
      inValidErrors: [],
    };
  },
};
</script>
