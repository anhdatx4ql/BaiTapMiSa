<template>
  <div class="content-child content-center">
    <div class="table-container" ref="TableData">
      <!-- loading -->
      <div class="content-background-icon-loading">
        <div class="background-icon-loading"></div>
      </div>

      <div class="table-header">
        <div class="thead">
          <div class="tr">
            <div class="th tr-child-center">
              <span class="th-icon-sum background-icon-header-sum"></span>
            </div>
            <div class="th tr-child-center">
              <input
                type="checkbox"
                id="listCustomerId"
                :checked="false"
                :value="listCustomerId"
              />
              <label
                for="listCustomerId"
                :class="
                  listCustomerId.length == 0
                    ? 'background-icon-checked-table'
                    : 'background-icon-ckecked-header'
                "
                @click="clickCheckboxHeader"
              ></label>
            </div>
            <div class="th">Thẻ</div>
            <div class="th">Xưng hô</div>
            <div class="th">Họ và tên</div>
            <div class="th">Chức danh</div>
            <div class="th">ĐT di động</div>
            <div class="th">ĐT cơ quan</div>
            <div class="th">Email cơ quan</div>
            <div class="th">Email cá nhân</div>
            <div class="th">Tổ chức</div>
            <div class="th">Mã số thuế</div>
            <div class="th">Doanh thu</div>
            <div class="th">Địa chỉ</div>
          </div>
        </div>
      </div>
      <div class="table-content">
        <div class="tbody" ref="tbody">
          <div
            class="tr"
            v-for="c in customer"
            :key="c.customerId"
            @click="ClickDetail(c.customerId)"
          >
            <div
              class="td tr-child-center"
              :value="c.customerId"
              @click="ClickUpdate(c)"
            >
              <span class="background-icon-update"></span>
            </div>
            <div class="td tr-child-center">
              <input
                type="checkbox"
                class="trCheckbox"
                :value="c.customerId"
                :id="c.customerId"
              />
              <label
                :for="c.customerId"
                class="background-icon-checked-table"
                @click="ClickHandlerChecked"
              ></label>
            </div>
            <div class="td"></div>
            <!-- thẻ -->
            <div class="td">{{ c.vocativeName ? c.vocativeName : "-" }}</div>
            <div class="td">{{ c.fullName ? c.fullName : "-" }}</div>
            <div class="td">{{ c.positionName ? c.positionName : "-" }}</div>
            <div class="td">
              {{ c.customerPhoneNumber ? c.customerPhoneNumber : "-" }}
            </div>
            <div class="td">
              {{ c.companyPhoneNumber ? c.companyPhoneNumber : "-" }}
            </div>
            <div class="td">{{ c.companyEmail ? c.companyEmail : "-" }}</div>
            <div class="td">{{ c.customerEmail ? c.customerEmail : "-" }}</div>
            <div class="td">{{ c.organization ? c.organization : "-" }}</div>
            <div class="td">{{ c.taxCode ? c.taxCode : "-" }}</div>
            <div class="td">{{ c.turnoverName ? c.turnoverName : "-" }}</div>
            <div class="td">{{ c.address ? c.address : "-" }}</div>
          </div>
        </div>
      </div>
    </div>

    <div class="table-button">
      <div class="table-button-left">
        Tổng số: <span class="table-button-left-text">893</span>
      </div>
      <div class="table-button-right">
        <div
          class="
            table-button-right-chlid table-button-right-combobox
            combobox-table
          "
        >
          50 Bản ghi trên Trang
        </div>
        <div class="table-button-right-chlid combobox-table"></div>
      </div>
    </div>

    <div
      class="buttonHideShow buttonHideShowLeft"
      @click="checkLeft = !checkLeft"
    >
      <span class="background-icon-arrow-left icon-font-16"></span>
    </div>
    <div
      class="buttonHideShow buttonHideShowRight"
      @click="checkRight = !checkRight"
    >
      <span class="background-icon-arrow-right icon-font-16"></span>
    </div>
  </div>
</template>

<script>
import { handlerScroll, handlerClickButtonArrow } from "../../js/test";
import { UnLoading, Loading } from "../../js/Loading";

// nhúng service xử lý customer
import { CustomerService } from "../Services/CustomerService";

// nhúng service xử lý customer detail
import { CustomerDetailService } from "../Services/CustomerDetailService";

export default {
  name: "ContentPageCenter",
  data() {
    return {
      checkShow: false,
      checkLeft: false,
      checkRight: false,
      customer: "",
      listCustomerId: [],
      checkReloadData: false,
    };
  },
  props: {
    customersSearch: {},
    checkShowFormData: Boolean,
    checkLoadCustomerData: Boolean
  },
  created() {
    
    //Author: Phạm Văn Đạt
    // function: lấy thông tin c;
    // created time: 11:50 15/08/2022
    this.LoadData();
  },
  methods: {
    //Author: Phạm Văn Đạt
    // function: kích nút để hiển thị thông tin chi tiết
    // created time: 11:59 15/08/2022
    ClickDetail: function (customerId) {
      let _CustomerDetailService = new CustomerDetailService();
      _CustomerDetailService.getByCustomerId(customerId).then((res) => {
        if (res) this.customer = res;
      });
    },

    //Author: Phạm Văn Đạt
    // function: kích nút để hiển thị form chỉnh sửa thông tin
    // created time: 18:55 16/08/2022
    ClickUpdate: function (CustomerInfo) {
      this.checkShow = !this.checkShow;
      this.$emit("ShowFormData", this.checkShow);
      this.$emit("CustomerInfo", CustomerInfo);
    },
    ClickHandlerChecked: function (event) {
      // xử lý thêm, xóa id trong mảng xử lý xóa, sửa
      let El = event.target.parentNode.getElementsByTagName("input")[0];
      if (El) {
        let check = El.checked;
        let ElValue = El.getAttribute("value");
        if (ElValue) {
          if (check == false) {
            console.log("add");
            this.listCustomerId.push(ElValue);
          } else {
            console.log("remove");
            console.log(El.getAttribute("value"));
            console.log("false");
            // lấy vị trí phần tử đó trong mảng
            const valueRemove = this.listCustomerId.indexOf(ElValue);
            // xóa phân tử đó đi
            this.listCustomerId.splice(valueRemove, 1);
          }

        }
      }

    },
    // xử lý checkbox header
    clickCheckboxHeader: function (event) {
      let ElChecked = event.target;
      console.log(ElChecked)
      let El = event.target.parentNode.getElementsByTagName("input")[0];
      if (El) {
        let ElsCheckbox = this.$refs.tbody.getElementsByClassName("trCheckbox");
        // nếu tồn tại các bản đã checked thì xóa hết
        if (this.listCustomerId.length > 0) {
          // lấy ra hết các ô kiểm tra xem cái nào checked thì bỏ

          for (let item of ElsCheckbox) {
            if (item.checked == true) {
              item.checked = false;
            }
          }
          // xóa gết phần tử trong mảng
          if (ElChecked.classList.contains("background-icon-ckecked-header")) {
             El.checked = true;
            this.listCustomerId.splice(0, this.listCustomerId.length);
          }
        } else {

          // thay đổi icon 

          console.log("chay")
          for (let item of ElsCheckbox) {
            if (item.checked == false) {
              const value =  item.getAttribute("value");
              if(value)
                this.listCustomerId.push(value)
              item.checked = true;
            }
          }
        }
      }

    },
    LoadData(){
      let _CustomerService = new CustomerService();
      _CustomerService.GetAll().then((res) => {
        this.customer = res;
        console.log(res);
        // load xong bỏ hết các dòng đã chọn
        this.listCustomerId.splice(0, this.listCustomerId.length);

        // bỏ checked
        let checkboxs = document.getElementsByClassName("trCheckbox");
        
        // chuyển background checked
        if (checkboxs) {
        
            for (let item of checkboxs) {
              if (item.checked == true) {
                item.checked = false;
              }
            }

          } 
        });
    }
     
  },
  // theo dõi các biến thay đổi và thực hiện hàm nếu có
  watch: {
    // theo dõi danh sách khách hàng
    customer() {
      UnLoading(this.$refs.TableData);
    },

    // hiển thị, ẩn side bar bên trái
    checkLeft() {
      handlerClickButtonArrow(this.checkLeft, this.checkRight, event);
    },

    // hiển thị, ẩn side bar bên phải
    checkRight() {
      handlerClickButtonArrow(this.checkLeft, this.checkRight, event);
    },

    // lấy thông tin khách hàng
    customersSearch() {
      this.customer = this.customersSearch;
    },
    // theo  dõi mảng để xóa danh sác, update
    listCustomerId: {
      handler: function (val) {
        this.$emit("listCustomerId", val);
      },
      deep: true
    
    },
    //check load form data
    checkLoadCustomerData(){
      this.checkReloadData = this.checkLoadCustomerData;

      this.$emit("checkLoadCustomerData",!this.checkLoadCustomerData)
    },
    async checkReloadData(){
      Loading(this.$refs.TableData)
      // load lại dữ liệu
      await this.LoadData();
      UnLoading(this.$refs.TableData)
    }
  },
  mounted() {
    handlerScroll();
  },
};
</script>

<style>
</style>