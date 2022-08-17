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
                type="text" v-on:keyup.enter="SearchCustomer"
                class="input"
                placeholder="Tìm kiếm tiềm năng, liên hệ khách hàng"
              />
            </div>
          </div>
        </div>

        <div class="header-right">
          <div class="header-right-child" onclick="clickbutton(this)">
            <button
              class="button-background-header background-icon-face"
            ></button>
          </div>
          <div class="header-right-child">
            <button
              class="button-background-header background-icon-bag"
            ></button>
          </div>
          <div class="header-right-child">
            <button
              class="button-background-header background-icon-bell"
            ></button>
          </div>
          <div class="header-right-child">
            <button
              class="button-background-header background-icon-setting"
            ></button>
          </div>
          <div class="header-right-child">
            <button
              class="button-background-header background-icon-question"
            ></button>
          </div>
          <div class="header-right-child header-right-child-avatar">
            <button
              class="button-background-header background-icon-avatar"
            ></button>
          </div>
        </div>
      </div>
      <div class="header-nav">
        <div class="header-nav-item">
          <div class="header-nav-item-content background-icon-home-hover">
            <span
              class="header-nav-item-background background-icon-home"
            ></span>
            <span>Bàn làm việc</span>
          </div>
        </div>
        <div class="header-nav-item">
          <div class="header-nav-item-content background-icon-tiemnang-hover header-nav-item-content-select">
            <span
              class="header-nav-item-background background-icon-tiemnang"
            ></span>
            <span>Tiềm năng</span>
          </div>
        </div>
        <div class="header-nav-item">
          <div class="header-nav-item-content background-icon-chaohang-hover">
            <span
              class="header-nav-item-background background-icon-chaohang"
            ></span>
            <span>Chào hàng</span>
          </div>
        </div>
        <div class="header-nav-item">
          <div class="header-nav-item-content background-icon-lienhe-hover">
            <span
              class="header-nav-item-background background-icon-lienhe"
            ></span>
            <span>Liên hệ</span>
          </div>
        </div>
        <div class="header-nav-item">
          <div
            class="header-nav-item-content background-icon-khachhang-hover"
          >
            <span
              class="header-nav-item-background background-icon-khachhang"
            ></span>
            <span>Khách hàng</span>
          </div>
        </div>
        <div class="header-nav-item">
          <div class="header-nav-item-content background-icon-cohoi-hover">
            <span
              class="header-nav-item-background background-icon-cohoi"
            ></span>
            <span>Cơ hội</span>
          </div>
        </div>
        <div class="header-nav-item">
          <div class="header-nav-item-content background-icon-baogia-hover">
            <span
              class="header-nav-item-background background-icon-baogia"
            ></span>
            <span>Báo giá</span>
          </div>
        </div>
        <div class="header-nav-item">
          <div class="header-nav-item-content background-icon-donhang-hover">
            <span
              class="header-nav-item-background background-icon-donhang"
            ></span>
            <span>Đơn hàng</span>
          </div>
        </div>

        <div class="header-nav-item">
          <div class="header-nav-item-content background-icon-muctieu-hover">
            <span
              class="header-nav-item-background background-icon-muctieu"
            ></span>
            <span>Mục tiêu</span>
          </div>
        </div>
        <div class="header-nav-item">
          <div
            class="header-nav-item-content background-icon-chiendich-hover"
          >
            <span
              class="header-nav-item-background background-icon-chiendich"
            ></span>
            <span>Chiến dịch</span>
          </div>
        </div>
        <div class="header-nav-item">
          <div class="header-nav-item-content background-icon-baocao-hover">
            <span
              class="header-nav-item-background background-icon-baocao"
            ></span>
            <span>Báo cáo</span>
          </div>
        </div>
        <div class="header-nav-item">
          <div class="header-nav-item-content background-icon-khac-hover">
            <span
              class="header-nav-item-background background-icon-khac"
            ></span>
            <span>Khác</span>
          </div>
        </div>
      </div>
    </div>
</template>

<script>

import {CustomerService} from '../Services/CustomerService'
export default {
  name: 'HeaderComponent',
  props: {
    
  },
  methods:{
    //Author: Phạm Văn Đạt
    // function: lấy thông tin customer theo tên
    // created time: 11:50 15/08/2022
    
    SearchCustomer: function(event){
      let ServiceCustomer = new CustomerService();
      ServiceCustomer.FindByName(event.target.value)
      .then(res=>{
        // kiểm tra null hiển thị thông báo
        if(res.data.data == null){
          alert("Không tồn tại bản ghi nào có tên '"+event.target.value+"'");
        }else{
           this.$emit('CustomerByName',res.data.data);
        }

      })
      .catch(e=>{
        console.log(e)
      })
    }
  }
}

</script>

<style>

</style>