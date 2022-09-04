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
            <div class="td">{{ c.vocativeName ? titleCase(c.vocativeName) : "-" }}</div>
            <div class="td">{{ c.fullName ? titleCase(c.fullName) : "-" }}</div>
            <div class="td">{{ c.positionName ? titleCase(c.positionName) : "-" }}</div>
            <div class="td container-phone-number">
              <span class="background-icon-phone-center icon-font-16"></span>
              {{ c.customerPhoneNumber ? c.customerPhoneNumber : "-" }}
            </div>
            <div class="td container-phone-number">
              <span class="background-icon-phone-center icon-font-16"></span>
              {{ c.companyPhoneNumber ? c.companyPhoneNumber : "-" }}
            </div>
            <div class="td">{{ c.companyEmail ? c.companyEmail : "-" }}</div>
            <div class="td">{{ c.customerEmail ? c.customerEmail : "-" }}</div>
            <div class="td">{{ c.organization ? titleCase(c.organization) : "-" }}</div>
            <div class="td">{{ c.taxCode ? c.taxCode : "-" }}</div>
            <div class="td">{{ c.turnoverName ? titleCase(c.turnoverName) : "-" }}</div>
            <div class="td">{{ c.address ? titleCase(c.address) : "-" }}</div>
          </div>
        </div>
      </div>
    </div>

    <div class="table-button">
      <div class="table-button-left">
        Tổng số: <span class="table-button-left-text">{{totalCount}}</span>
      </div>

      <div class="table-button-right">
        <div class="table-button-right-chlid">
          <div class="form-container-content-child-item-input">
                <div class="combobox" id="paging">
                  <div
                    class="combobox-child combobox-content"
                    @click="handlerClickCombobox"
                    check="false"
                  >
                    <div
                      class="combobox-content-select combobox-child"
                      ref="pagingId"
                    >
                      {{pageSize}} bản ghi trên Trang
                    </div>
                    <div
                      class="
                        combobox-content-icon
                        button-icon-up-black
                        icon-font-16
                        combobox-child
                      "
                    ></div>
                  </div>
                  <div class="combobox-child combobox-data" ref="pageSize">
                    <div class="combobox-data-child">
                      <div
                        class="combobox-data-child-content"
                        v-for="v in ListPaging"
                        :key="v[0]"
                        :class="{
                          selected:
                            v[0] == pageSize? true : false,
                        }"
                        @click="handlerClickComboboxData"
                        :value="v[0]"
                      >
                        <div class="combobox-data-child-content-text">
                           {{v[1]}} bản ghi trên Trang
                        </div>
                        <div
                          class="background-icon-checked icon-font-16"
                          :style="
                            v.Code == pageSize
                              ? 'display:inline-block'
                              : 'display:none'
                          "
                        ></div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
        </div>

        <div class="table-button-right-chlid">
          <button class="table-button-right-chlid-button button button-background-white" 
          :class="{'background-disabled':(checkPreData==true)?false:true}"
          @click="clickPreFirstData">
            <span class="background-icon-first icon-font-16"></span>
          </button>
          <button class="table-button-right-chlid-button button button-background-white" 
          :class="{'background-disabled':(checkPreData==true)?false:true}"
          @click="clickPreData">
            <span  class="background-icon-pre icon-font-16"></span>
          </button>
          <div class="table-button-right-chlid-text">
            <span>{{startColumn}}</span> đến <span>{{endColumn}}</span>
          </div>
          <button 
          class="table-button-right-chlid-button button button-background-white"
          :class="{'background-disabled':(checkNextData==true)?false:true}"
          @click="clickNextData">
          
            <span class="background-icon-next icon-font-16"></span>
          </button>
          <button class="table-button-right-chlid-button button button-background-white" 
          :class="{'background-disabled':(checkNextData==true)?false:true}"
          @click="clickNextLastData()">
            <span class="background-icon-last icon-font-16"></span>
          </button>
        </div>
       
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
  //  xử lý hiển thị text
import { titleCase } from "../../js/handlerString";
// nhúng status code
import { StatusCode } from "../Models/StatusCode";

// các hàm xử lý click combobox
import {
  ClickShowHideComboboxData,
  selectValueComboboxData,
} from "../../js/test";

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
      currentPage:1,
      keyword:null,
      pageSize:10,
      checkPreData:false,
      checkNextData:false,
      totalCount:0,
      startColumn:0,
      endColumn:0,
      totalPages:0,
      ListPaging: new Map(),
      checkLoadData: false
    };
  },  
  props: {
    searchCustomerCurrent: {},
    checkShowFormData: Boolean,
    checkLoadCustomerData: Boolean
  },
  created() {
    this.ListPaging.set(10,10);
    this.ListPaging.set(20,20);
    this.ListPaging.set(50,50);
    this.ListPaging.set(100,100);
    // function: lấy thông tin c;
    this.checkLoadData= true;

  },
  methods: {

    // xử lý hiển thị text
    titleCase,

     /**
   * Hiển thị dữ liệu trang đầu tiên
   */
    clickPreFirstData(){
      if(this.checkPreData == true){
        this.currentPage = 1;
        this.checkLoadData = true;
      }
    },

     /**
   * Hiển thị dữ liệu trang trước đó
   */
    clickPreData(){
      if(this.checkPreData == true){
        this.currentPage =  this.currentPage-1;
        this.checkLoadData = true;

      }
    },

    /**
   * Hiển thị dữ liệu trang tiếp theo
   */
    clickNextData(){
      if(this.checkNextData == true){
        this.currentPage =  this.currentPage+1;
        this.checkLoadData = true;
      }
    },

  /**
   * Hiển thị dữ liệu cuối cùng
   */
    clickNextLastData(){
      if(this.checkNextData == true){
        this.currentPage =  this.totalPages;
        this.checkLoadData = true;
      }
    },
    /**
     * Author: Phạm Văn Đạt
     * function:  xử lý đóng form data
     * created time: 11:28 17/08/2022
     */
    handlerClickCombobox: function (event) {
      try {

        // hiển thị combobox data
        ClickShowHideComboboxData(event);
      } catch (error) {
        console.log(error);
      }
    },

     handlerClickComboboxData: function (event) {
      try {

        // chuyển curent và page về default 
        this.currentPage =  1;

        // lấy giá trị El
        let El = event.target;
        while(!El.getAttribute("value")){
            El = El.parentNode;
        }

        this.pageSize = El.getAttribute("value");
        selectValueComboboxData(event);
      } catch (error) {
        console.log(error);
      }
    },

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
            this.listCustomerId.push(ElValue);
          } else {
            console.log(El.getAttribute("value"));
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
    async LoadData(keyword,currentPage,pageSize){
      let _CustomerService = new CustomerService();
       await _CustomerService.PagingCustomer(keyword,currentPage,pageSize).then((res) => {
        if(res.statusCode == StatusCode.GetSuccess){
          this.customer = res.data.data;
          this.totalCount = res.data.totalCount
          this.startColumn = (res.data.currentPageNumber-1)*res.data.pageSize +1;
          this.endColumn =  (res.data.currentPageNumber*res.data.pageSize < this.totalCount)?res.data.currentPageNumber*res.data.pageSize:this.totalCount;
          this.checkPreData = res.data.hasPrePage;
          this.totalPages = res.data.totalPages;
          this.checkNextData = res.data.hasNextpage;
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
          }
          
        });
    }
     
  },
  // theo dõi các biến thay đổi và thực hiện hàm nếu có
  watch: {

    async checkLoadData(){
      if(this.checkLoadData == true){
        await this.LoadData(this.keyword, this.currentPage,this.pageSize);
        this.checkLoadData=false;
        console.log("checkload")

      }
  
    },
    // Load lại dữ liệu mỗi khi chọn trang mới
    pageSize(){
      this.checkLoadData = true;
    },

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
    searchCustomerCurrent() {
      this.keyword = this.searchCustomerCurrent;
      this.checkLoadData = true;
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
       Loading(this.$refs.TableData)
        // load lại dữ liệu
        this.checkLoadData = true;
        UnLoading(this.$refs.TableData)
        this.$emit("checkLoadCustomerData",false);
    }
   
  },
  mounted() {
    handlerScroll();
  },
};
</script>

<style>

</style>