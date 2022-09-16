<template>
        <div class="header">
      <div class="header-top">
        <div class="header-left">
          <div class="header-left-icon"></div>
          <div class="header-left-logo"></div>
          <div class="header-left-text"></div>
        </div>

        <div class="header-center">
          <div class="container-input">
            <div class="label-input label-input-icon">
              <label class="background-icon-search-input"></label>
              <input
                type="text" v-on:keyup.enter="SearchCustomer" v-model="textSearch"
                class="input"
                placeholder="Tìm kiếm tiềm năng, liên hệ khách hàng"
              />
            </div>
          </div>
        </div>

        <div class="header-right">
          <div class="header-right-child">
            <button @click="showNotFound"
              class="button-background-header background-icon-face"
            >
            <ToolTip :type="'bottom'" :text="'Facebook'"></ToolTip>
          </button>
          </div>
          <div class="header-right-child">
            <button @click="showNotFound"
              class="button-background-header background-icon-bag-header background-icon-face"
            > <ToolTip :type="'bottom'" :text="'Lịch'"></ToolTip></button>
          </div>
          <div class="header-right-child">
            <button @click="showNotFound"
              class="button-background-header background-icon-bell"
            >
            <ToolTip :type="'bottom'" :text="'Thông báo'"></ToolTip></button>
          </div>
          <div class="header-right-child">
            <button @click="showNotFound"
              class="button-background-header background-icon-setting"
            >
            <ToolTip :type="'bottom'" :text="'Cài đặt'"></ToolTip>
          </button>
          </div>
          <div class="header-right-child">
            <button @click="showNotFound"
              class="button-background-header background-icon-question"
            ><ToolTip :type="'bottom'" :text="'Câu hỏi'"></ToolTip></button>
          </div>
          <div class="header-right-child header-right-child-avatar">
            <button @click="showNotFound"
              class="button-background-header background-icon-avatar"
            >
            <ToolTip :type="'bottomRight'" :text="'Ảnh đại diện'"></ToolTip>
          </button>
          </div>
        </div>
      </div>
      <div class="header-nav">
        <div class="header-nav-item">
          <button class="header-nav-item-content background-icon-home-hover" @click="showNotFound">
            <span
              class="header-nav-item-background background-icon-home"
            ></span>
            <span>Bàn làm việc</span>
          </button>
        </div>
        <div class="header-nav-item">
          <button class="header-nav-item-content background-icon-tiemnang-hover header-nav-item-content-select">
            <span
              class="header-nav-item-background background-icon-tiemnang"
            ></span>
            <span>Tiềm năng</span>
          </button>
        </div>
        <div class="header-nav-item">
          <button class="header-nav-item-content background-icon-chaohang-hover" @click="showNotFound">
            <span
              class="header-nav-item-background background-icon-chaohang"
            ></span>
            <span>Chào hàng</span>
          </button>
        </div>
        <div class="header-nav-item">
          <button class="header-nav-item-content background-icon-lienhe-hover" @click="showNotFound">
            <span
              class="header-nav-item-background background-icon-lienhe"
            ></span>
            <span>Liên hệ</span>
          </button>
        </div>
        <div class="header-nav-item">
          <button
            class="header-nav-item-content background-icon-khachhang-hover" @click="showNotFound"
          >
            <span
              class="header-nav-item-background background-icon-khachhang"
            ></span>
            <span>Khách hàng</span>
        </button>
        </div>
        <div class="header-nav-item">
          <button class="header-nav-item-content background-icon-cohoi-hover" @click="showNotFound">
            <span
              class="header-nav-item-background background-icon-cohoi"
            ></span>
            <span>Cơ hội</span>
          </button>
        </div>
        <div class="header-nav-item">
          <button class="header-nav-item-content background-icon-baogia-hover" @click="showNotFound">
            <span
              class="header-nav-item-background background-icon-baogia"
            ></span>
            <span>Báo giá</span>
          </button>
        </div>
        <div class="header-nav-item">
          <button class="header-nav-item-content background-icon-donhang-hover" @click="showNotFound">
            <span
              class="header-nav-item-background background-icon-donhang"
            ></span>
            <span>Đơn hàng</span>
          </button>
        </div>

        <div class="header-nav-item">
          <button class="header-nav-item-content background-icon-muctieu-hover" @click="showNotFound">
            <span
              class="header-nav-item-background background-icon-muctieu"
            ></span>
            <span>Mục tiêu</span>
          </button>
        </div>
        <div class="header-nav-item">
          <button
            class="header-nav-item-content background-icon-chiendich-hover" @click="showNotFound"
          >
            <span
              class="header-nav-item-background background-icon-chiendich"
            ></span>
            <span>Chiến dịch</span>
        </button>
        </div>
        <div class="header-nav-item">
          <button class="header-nav-item-content background-icon-baocao-hover" @click="showNotFound">
            <span
              class="header-nav-item-background background-icon-baocao"
            ></span>
            <span>Báo cáo</span>
          </button>
        </div>
        <div class="header-nav-item">
          <button class="header-nav-item-content background-icon-khac-hover" @click="showNotFound">
            <span
              class="header-nav-item-background background-icon-khac"
            ></span>
            <span>Khác</span>
          </button>
        </div>
      </div>
    </div>
</template>

<script>
// nhúng Toastmessage
import { ToastMessage } from "../Models/ToastMessage";

  // nhung tooltip
import ToolTip from "./ToolTip"

export default {
  name: 'HeaderComponent',
  components:{
    ToolTip
  },
  data(){
    return {
      textSearch:"",
      ToastMessageCustomer: ToastMessage,
    }
  },
  props: {
    
  },
  watch:{
  },
  methods:{
    // click show notfound
    showNotFound(){
      this.ToastMessageCustomer.Type = "info";
      this.ToastMessageCustomer.Message = "Chúng tôi sẽ sớm ra mắt";
      this.$emit("toastMessageInfo", this.ToastMessageCustomer);
      this.$emit("showToastMessageInfo", true);
    },
    //Author: Phạm Văn Đạt
    // function: lấy thông tin customer theo tên
    // created time: 11:50 15/08/2022
    
    SearchCustomer: function(event){
      console.log("enter", event)
      this.$emit('CustomerByName',this.textSearch);
      
    }
  }
}

</script>

<style>

</style>