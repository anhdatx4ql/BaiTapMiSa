<template>
  <div class="content-child content-center">
    <div class="table-container">
      <div class="table-header">
        <div class="thead">
          <div class="tr">
            <div class="th tr-child-center">
              <span class="th-icon-sum background-icon-header-sum"></span>
            </div>
            <div class="th tr-child-center">
              <input type="checkbox" />
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
        <div class="tbody">
          
          <div class="tr" v-for="c in customer" :key="c.customerId" @click="ClickDetail(c.customerId)">
            <div class="td tr-child-center" :value="c.customerId" @click="ClickUpdate(c)">
              <span class="background-icon-update"></span>
            </div>
            <div class="td tr-child-center">
              <input type="checkbox" :value="c.customerId"/>
            </div>
            <div class="td"></div> <!-- thẻ -->
            <div class="td">{{(c.vocativeName)?c.vocativeName:"-" }}</div>            
            <div class="td">{{(c.fullName)?c.fullName:"-"}}</div>
            <div class="td">{{(c.positionName)?c.positionName:"-"}}</div>
            <div class="td">{{(c.customerPhoneNumber)?c.customerPhoneNumber:"-"}}</div>
            <div class="td">{{(c.companyPhoneNumber)?c.companyPhoneNumber:"-"}}</div>
            <div class="td">{{(c.companyEmail)?c.companyEmail:"-"}}</div>
            <div class="td">{{(c.customerEmail)?c.customerEmail:"-"}}</div>
            <div class="td">{{(c.organization)?c.organization:"-"}}</div>
            <div class="td">{{(c.taxCode)?c.taxCode:"-"}}</div>
            <div class="td">{{(c.turnoverName)?c.turnoverName:"-"}}</div>
            <div class="td">{{(c.address)?c.address:"-"}}</div>
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

// nhúng service xử lý customer
import {CustomerService} from '../Services/CustomerService';


// nhúng service xử lý customer detail
import {CustomerDetailService} from '../Services/CustomerDetailService';


export default {

  name: "ContentPageCenter",
  data() {
    return {
      checkShow:false,
      checkLeft: false,
      checkRight: false,
      customer: []
    };
  },
  props:{
    customersSearch:{},
    checkShowFormData:Boolean
  },
  created() {

    //Author: Phạm Văn Đạt
    // function: lấy thông tin c;
    // created time: 11:50 15/08/2022
    let ServiceCustomer = new CustomerService();
    ServiceCustomer.GetAll()
    .then(res=>{
      if(res.data.data)
        this.customer = res.data.data;
    })
    .catch(e=>{
      console.log(e)
    })


  },
  methods: {
    //Author: Phạm Văn Đạt
    // function: kích nút để hiển thị thông tin chi tiết
    // created time: 11:59 15/08/2022
    ClickDetail:function (customerId){
      let _CustomerDetailService = new CustomerDetailService();
      _CustomerDetailService.getByCustomerId(customerId)
        .then(res=>{
          if(res.data.data){
            this.$emit('CustomerDetails',res.data.data);
          }
          else console.log('không có dữ liệu')
        })
        .catch(e=>{
          console.log(e)
        })
    },

    //Author: Phạm Văn Đạt
    // function: kích nút để hiển thị form chỉnh sửa thông tin
    // created time: 18:55 16/08/2022
    ClickUpdate:function (CustomerInfo){
      this.checkShow = !this.checkShow;
      this.$emit('ShowFormData',this.checkShow);
      this.$emit('CustomerInfo',CustomerInfo);
    }


  },
  // theo dõi các biến thay đổi và thực hiện hàm nếu có
  watch: {
    // hiển thị, ẩn side bar bên trái
    checkLeft() {
      handlerClickButtonArrow(this.checkLeft, this.checkRight,event);
    },

    // hiển thị, ẩn side bar bên phải
    checkRight() {
      handlerClickButtonArrow(this.checkLeft, this.checkRight,event);
    },

    // lấy thông tin khách hàng
    customersSearch(){
      this.customer = this.customersSearch;
    }
  },
  mounted() {
    
    handlerScroll();
  },
};
</script>

<style>
</style>