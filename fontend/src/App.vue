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
    ></Toolbar>
    <!-- End Toolbar -->

    <!-- Start Content -->
    <ContentPage :searchCustomer="searchCustomer"
     :checkShowFormData="checkShowForm"
      @ShowFormData="checkShowFormUpdate = $event"
      @CustomerInfo="CustomerInfo = $event"
      @listCustomerId="listCustomerId = $event"
      :checkLoadCustomerData="checkLoadCustomerData"
      @checkLoadCustomerData="checkLoadCustomerData=$event">
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
import {  handlerClickHideFullComboboxData } from "./js/test";

/** VÒNG ĐỜI  
 * 1: beforeCraete -  Tại thời điểm này, data, event chưa được thiết lập.
 * 2: created // được chạy khi data, event đã thiết lập thành công.
 * 3: BeforeMount: sẽ chạy sau khi data, event được thiết lập và trước khi gắn kết vào DOM.
 *                 Trong hook này chúng ta vẫn chưa - truy cập được phần tử trong DOM.
 * 4: mounted: có thể truy cập vào phẩn tử trong DOM
 * 5: beforeUpdate: Sau khi đối tượng đã được gắn vào DOM, khi dữ liệu thay đổi, và trước khi render,
 *                  patch lại và hiển thị ra cho người dùng.
 * 6: Updated: Chạy ngay sau khi beforeUpdate . Sử dụng khi bạn cần truy cập DOM sau khi thay đổi thuộc tính
 * 7: beforeUnMount: Là giai đoạn trước khi instance bị hủy.
 *                  Đây là nơi để quản lý tài nguyên xóa tài nguyên, dọn dẹp các component.
 * 8: UnMounted: , mọi thành phần đã được hủy bỏ hết. Khi console.log() đối tượng này thì sẽ không nhận được thuộc tính hay dữ liệu gì.
 * mỗi khi dữ liệu thay đổi thì wath chạy => wath dùng để theo dõi các biến
 */

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
      searchCustomer: "",
      // phải lưu cho nó 1 tên biến mới đưa lên được
      checkShowForm: false,
      checkShowFormUpdate:false,
      CustomerInfo:{},
      toastMessageInfo:"",
      showToastMessage: false,
      listCustomerId: [],
      checkShowPopUp: false,
      PopUpTitle:"",
      ActiveMessage: false,
      checkLoadCustomerData: false,
      loadFull: false,
    };
  },
  watch:{

    checkShowForm(){
      console.log(this.checkShowForm)
    }
  },
  beforeCreate() {
    
  },
  created() {
    
  },
  mounted(){

  },
  methods: {
   
    // Xử lý click show hide combobox
    ClickWindow:function(){
      // xử lý click vào window
       window.addEventListener("click", function(e){
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
      
      });
    },
    
  },
};
</script>

<style>
@import url("../src/css/main.css");
</style>
