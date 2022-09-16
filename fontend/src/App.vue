<!-- eslint-disable no-unused-vars -->
<template>
  <div class="container" @click="ClickWindow">
     <!-- loading -->
     <div class="content-background-icon-loading" v-if="(loadFull== true)?true:false">
        <div class="background-icon-loading"></div>
      </div>
    <!-- Start header -->
    <Header 
      @CustomerByName="searchCustomer = $event"
      @toastMessageInfo="toastMessageInfo=$event"
      @showToastMessageInfo="showToastMessage=$event"
    ></Header>
    <!-- End Header -->

    <!-- Start Toolbar -->
    <!-- $event: data được gửi từ component con lên: ở đây là true -->
    <Toolbar
      :checkShowFormData="checkShowForm"
      @ShowFormData="checkShowForm = $event"
      :listCustomerId="listCustomerId"
      @checkShowPopUp="checkShowPopUp = $event"
      @PopUpTitle="PopUpTitle = $event"
      :ActiveMessage="ActiveMessage"
      @ActiveMessage="ActiveMessage=$event"
      @toastMessageInfo="toastMessageInfo=$event"
      @showToastMessageInfo="showToastMessage=$event"
      @checkLoadCustomerData="checkLoadCustomerData=$event"
      @loadFullScreen="loadFull=$event"
      @removeListCustomerId="removeListCustomerId=$event"
    ></Toolbar>
    <!-- End Toolbar -->

    <!-- Start Content -->
    <ContentPage :searchCustomer="searchCustomer"
     :checkShowFormData="checkShowForm"
      @ShowFormData="checkShowFormUpdate = $event"
      @CustomerInfo="CustomerInfo = $event"
      @listCustomerId="listCustomerId = $event"
      :checkLoadCustomerData="checkLoadCustomerData"
      @checkLoadCustomerData="checkLoadCustomerData=$event"
      :removeListCustomerId="removeListCustomerId">
      </ContentPage>
    <!-- End content -->

    <!-- Start Form create  -->
    <FormCreateCustomer v-if="checkShowForm"
      @CloseFormData="checkShowForm = $event"
      @toastMessageInfo="toastMessageInfo=$event"
      @showToastMessageInfo="showToastMessage=$event"
       @checkLoadCustomerData="checkLoadCustomerData=$event"
    ></FormCreateCustomer>
    <!-- End Form create  -->


    <!-- Start Form Update  -->
    <FormUpdateCustomer :checkShowFormData="checkShowFormUpdate"
     :CustomerInfo="CustomerInfo"
    @CloseFormData="checkShowFormUpdate = $event" 
     @toastMessageInfo="toastMessageInfo=$event"
      @showToastMessageInfo="showToastMessage=$event"
      @checkLoadCustomerData="checkLoadCustomerData=$event">
      </FormUpdateCustomer>
    <!-- End Form Update  -->

    <!-- Start Toast message -->  
    <ToastMessage :toastMessageInfo="toastMessageInfo"
     :showToastMessage="showToastMessage" @showToastMessage="showToastMessage=$event"
     ></ToastMessage>
    <!-- End Toast Message -->

    <!-- Start PopUp -->
    <PopUp :checkShowPopUp="checkShowPopUp"
     @checkShowPopUp="checkShowPopUp=$event"
     :PopUpTitle="PopUpTitle"
     @ActiveMessage="ActiveMessage = $event">
     </PopUp>
    <!-- End PopUP -->

  </div>
</template>

<script>
// Nhúng thanh header
import Header from "./components/layouts/Header";

// nhúng toolbar
import Toolbar from "./components/layouts/Toolbar";

// nhúng contentpage
import ContentPage from "./components/layouts/ContentPage";

// nhúng form tạo mới customer
import FormCreateCustomer from "./components/layouts/FormCreateCustomer";

// nhúng form tạo mới customer
import ToastMessage from "./components/layouts/ToastMessage";

// nhúng pop up
import PopUp from "./components/layouts/PopUp";

// nhúng form updateCustomer
import FormUpdateCustomer from "./components/layouts/FormUpdateCustomer";
import {  handlerClickHideFullComboboxData } from "./js/handlerCombobox";

export default {
  name: "App",
  components: {
    Header,
    Toolbar,
    ContentPage,
    FormCreateCustomer,
    FormUpdateCustomer,
    ToastMessage,
    PopUp
  },
  data() {
    return {
      // xóa bỏ các khách hàng đã chọn
      removeListCustomerId:false,

      // tìm kiếm custmer
      searchCustomer: "",

      // phải lưu cho nó 1 tên biến mới đưa lên được
      checkShowForm: false,

      // kiểm tra hiển thị form upload
      checkShowFormUpdate:false,

      // thông tin kahachs hàng
      CustomerInfo:{},

      // thông tin toast message
      toastMessageInfo:"",

      // hiển thị toast message
      showToastMessage: false,

      // mảng id khách hàng
      listCustomerId: [],

      // kiểm tra hiern thị popup
      checkShowPopUp: false,

      // title popup
      PopUpTitle:"",


      // thông tin message
      ActiveMessage: false,

      // load lại dữ liệu khách hangf
      checkLoadCustomerData: false,

      // loại lại hết 
      loadFull: false,

    };
  },
  watch:{

  },
  beforeCreate() {
    
  },
  created() {
    
  },
  mounted(){

  },
  methods: {
   
    /**
     * Author: Phạm Văn Đạt
     * function:Xử lý click hiển thị/ẩn combobox
     */
    ClickWindow:function(){
      // xử lý click vào window
       window.addEventListener("click", function(e){
        try{
          if(e.target.classList){
          if(e.target.classList.contains("show-button-toolbar") || e.target.parentNode.classList.contains("show-button-toolbar")){
          let checkShowFormHandlerToolbar = document.getElementsByClassName("toolbar-left-child-options")[0];
          checkShowFormHandlerToolbar.style.display == "flex"
        }else{
          let checkShowFormHandlerToolbar = document.getElementsByClassName("toolbar-left-child-options")[0];
          if(checkShowFormHandlerToolbar != undefined){
            if(checkShowFormHandlerToolbar.style.display == "flex")
              checkShowFormHandlerToolbar.style.display = "none";
          }
        }
        }
       
       
        // kiểm tra khi click vaof combobox data multiple thì không xử lý ẩn form
        let checkEl = e.target.classList.contains("combobox-data-child-content-text");
        let checkElFilter = e.target.classList.contains("combobox-data-child-content-text-filter");
        let checkElIcon = e.target.classList.contains("background-icon-checked");
        // lấy ra thẻ vừa thao tác click
        let elClassList = e.target;

        // kiểm tra xem có click vào 1 trong 2 thằng bên dưới không
        if(!elClassList.classList.contains("combobox-data-child-content") && !checkEl && !checkElIcon && !checkElFilter )
         
         // kiểm tra xem thẻ click có nằm 2 class này không, nếu khoong thì mới xử lý
          if(!elClassList.classList.contains("combobox-data-child-content") || !e.target.parentNode.classList.contains("combobox-data-child-content")){
             if(elClassList.classList.contains("combobox-child") == false){
                handlerClickHideFullComboboxData();
              }
              
          }
          // ("combobox-child")[0]
        }catch (error) {
          console.log(error);
        }
      });
       
        
    },
    
  },
};
</script>

<style>
@import url("../src/css/main.css");
</style>
