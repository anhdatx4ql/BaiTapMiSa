<template>
  <div class="toolbar">
    <div class="toolbar-left toolbar-child" v-if="(listCustomerId.length == 0)?true:false">
    <!-- //Start Th1 -->
    <div class="toolbar-left-child">
        <div class="combobox-toolbar">
          <span class="combobox-toolbar-text">Tất cả tiềm năng</span>
          <span class="combobox-toolbar-icon button-icon-down-black"></span>
        </div>
      </div>
      <div class="toolbar-left-child">
        <button class="button-toolbar-left">Sửa</button>
      </div>
      <div class="toolbar-left-child">
        <button class="button-icon-refesh">
          <span class="button-icon-icon icon-refesh"></span>
        </button>
      </div>
    <!-- // End  TH1   -->

    </div> 

    <div class="toolbar-left toolbar-child toolbar-left toolbar-child-change" v-else>
      <!-- Start TH 2 -->
      <div class="toolbar-left-child">
        <span class="combobox-toolbar-text">Đã chọn {{listCustomerId.length}}</span>
      </div>

      <div class="toolbar-left-child">
        <button class="button-toolbar-left" @click="clickRemoveListCustomerId">Bỏ chọn</button>
      </div>

      <div class="toolbar-left-child">
        <button class="button-toolbar-left toolbar-left-child-button">
          <span
            class="button-toolbar-left-icon background-icon-update icon-font-16"
          ></span>
          <span class="button-toolbar-left-text">Cập nhật thông tin</span>
        </button>
      </div>

      <div class="toolbar-left-child">
        <button
          class="button button-dots button-background-white"
          @click="showOptions"
        >
          <span class="button-icon-icon button-icon-icon-dots"></span>
        </button>
        <div class="toolbar-left-child-options">
          <button class="button-toolbar-left toolbar-left-child-button">
            <span
              class="
                button-toolbar-left-icon
                background-icon-export
                icon-font-16
              "
            ></span>
            <span class="button-toolbar-left-text">Xuất khẩu</span>
          </button>

          <button @click="ClickDeleteMul"
            class="
              button-toolbar-left
              toolbar-left-child-button toolbar-left-child-button-delete
            "
          >
            <span
              class="
                button-toolbar-left-icon
                background-icon-delete
                icon-font-16
              "
            ></span>
            <span class="button-toolbar-left-text">Xóa</span>
          </button>
        </div>
      </div>
    </div>

    <div class="toolbar-right toolbar-child">
      <div class="toolbar-right-child">
        <div class="combo-button">
          <button
            @click="ClickShowForm()"
            class="
              button button-icon button-background-primary button-icon-left
            "
          >
            <span class="button-icon-icon button-icon-icon-sum"></span>
            <span class="button-icon-text">Thêm</span>
          </button>
          <button
            class="button-arrow button-background-primary button-icon-right"
          >
            <span class="button-icon-icon button-icon-down"></span>
          </button>
        </div>
      </div>
      <div class="toolbar-right-child">
        <button class="button button-dots button-background-white">
          <span class="button-icon-icon button-icon-icon-dots"></span>
        </button>
      </div>
      <div class="toolbar-right-child ">
        <button class="button button-dots button-background-white">
          <span class="button-icon-icon button-icon-tiles"></span>
          <span class="button-icon-icon button-icon-down-black"></span>
        </button>
      </div>
    </div>
  </div>
</template>

<script>
// nhúng service xử lý Customer
import { CustomerService } from "../Services/CustomerService";

// nhúng status code
import { StatusCode } from "../Models/StatusCode";

// nhúng Toastmessage
import { ToastMessage } from "../Models/ToastMessage";

export default {
  name: "ToolbarComponent",
  props: {
    checkShowFormData: Boolean,
    listCustomerId: Array,
    ActiveMessage:Boolean
  },
  data(){
    return{
      ActiveMessageCurrent:false,
      ToastMessageCustomer: ToastMessage
    }
  },
  watch: {
    // theo dõi list xóa, update
    listCustomerId: {
      handler: function (val) {
        console.log(val);
      },
      deep: true,
    },
    ActiveMessage(){
      this.ActiveMessageCurrent = this.ActiveMessage;
    },
    ActiveMessageCurrent(){
      if(this.ActiveMessageCurrent == true){
        
        console.log("xoas");

          // xóa dữ liệu
         let _CustomerService = new CustomerService();
         _CustomerService.Delete(this.listCustomerId).then(res=>{
          if(res.data.statusCode == StatusCode.DeleteSuccess){
            console.log(res)
             this.ToastMessageCustomer.Type = "success";
            this.ToastMessageCustomer.Message = res.data.message;
            
            // load lại dữ liệu trong form
            this.$emit("checkLoadCustomerData",true);
          
          }else{
            this.ToastMessageCustomer.Type = "error";
            this.ToastMessageCustomer.Message = res.data.message;
          }
            
          })

          // gửi hiển thị thông báo
          this.$emit("toastMessageInfo", this.ToastMessageCustomer);
          this.$emit("showToastMessageInfo", true);

         this.$emit("ActiveMessage",!this.ActiveMessage);
      }
      console.log(this.listCustomerId)
    }
  },
  methods: {
    // click hiển thị form
    ClickShowForm: function () {
      this.$emit("ShowFormData", !this.checkShowFormData);
    },
    // Hiển thị form chọn xuất khẩu, xóa
    showOptions: function (event) {
      let el = event.target;
      console.log(el);
      if (el) {
        let item = el.getElementsByClassName("toolbar-left-child-options")[0];
        while (!item) {
          el = el.parentNode;
          item = el.getElementsByClassName("toolbar-left-child-options")[0];
        }

        if (item.style.display == "" || item.style.display == "none") {
          item.style.display = "flex";
        } else {
          item.style.display = "none";
        }
      }
    },

    // xử lý bỏ chọn
    clickRemoveListCustomerId: function(){
      
    },

    // xuwr lys xoas
    ClickDeleteMul(){
      this.$emit("checkShowPopUp",true);
      this.$emit("PopUpTitle","Bạn có chắc chắn muốn xóa Tiềm năng này không?");
    }
  },
};
</script>

<style>
</style>

