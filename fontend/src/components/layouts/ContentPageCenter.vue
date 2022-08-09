<template>
  <div class="content-chld content-center">
    <div class="table-container">
      <div class="table-header">
        <div class="thead">
          <div class="tr">
            <div class="th">
              <span class="th-icon-sum background-icon__header-sum"></span>
            </div>
            <div class="th">
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
          
          <div class="tr" v-for="user in this.users" :key="user.userId" @dblclick="ClickDetailUser(user)">
            <div class="td"></div>
            <div class="td">
              <input type="checkbox" :value="user.userId"/>
            </div>
            <div class="td"></div> <!-- thẻ -->
            <div class="td">{{(user.vocativeName)?user.vocativeName:"-" }}</div>            
            <div class="td">{{(user.fullName)?user.fullName:"-"}}</div>
            <div class="td">{{(user.jobTitleName)?user.jobTitleName:"-"}}</div>
            <div class="td">{{(user.userNummberPhone)?user.userNummberPhone:"-"}}</div>
            <div class="td">{{(user.companyNumberPhone)?user.companyNumberPhone:"-"}}</div>
            <div class="td">{{(user.companyEmail)?user.companyEmail:"-"}}</div>
            <div class="td">{{(user.userEmail)?user.userEmail:"-"}}</div>
            <div class="td">{{(user.organize)?user.organize:"-"}}</div>
            <div class="td">{{(user.taxCode)?user.taxCode:"-"}}</div>
            <div class="td">{{(user.revenueName)?user.revenueName:"-"}}</div>
            <div class="td">{{(user.address)?user.address:"-"}}</div>
          </div>
          
        </div>
      </div>
    </div>

    <div class="table-button">
      <div class="table-button__left">
        Tổng số: <span class="table-button__left-text">893</span>
      </div>
      <div class="table-button__right">
        <div
          class="
            table-button__right-chlid table-button__right-combobox
            combobox-table
          "
        >
          50 Bản ghi trên Trang
        </div>
        <div class="table-button__right-chlid combobox-table"></div>
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
// import axios from 'axios';
import {getJSONAsync} from '../Services/BaseService.js'
export default {

  name: "ContentPageCenter",
  data() {
    return {
      checkLeft: false,
      checkRight: false,
      users: []
    };
  },
   created() {

    // lay thong tin user
    getJSONAsync('https://localhost:44355/api/Users/GetUsers').then(res=>{
      this.users = res.data.data;
    })

  },
  methods: {
    ClickDetailUser:function (user){
      console.log('a');
      console.log(user);
    }
  },
  // theo dõi các biến thay đổi và thực hiện hàm nếu có
  watch: {
    checkLeft() {
      handlerClickButtonArrow(this.checkLeft, this.checkRight,event);
    },
    checkRight() {
      handlerClickButtonArrow(this.checkLeft, this.checkRight,event);
    },
  },
  mounted() {
    handlerScroll();
  },
};
</script>

<style>
</style>