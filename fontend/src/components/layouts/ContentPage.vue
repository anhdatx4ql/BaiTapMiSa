<template>
  <div class="content">
    
    <ContentPageLeft :customCarrer="carrer" :customVocative="vocative"></ContentPageLeft>
    <ContentPageCenter :searchCustomerCurrent="searchCustomerCurrent"
     @CustomerDetails="customerDetails = $event"
     :checkShowFormData="checkShowFormData"
     @ShowFormData="checkShow = $event"
     @CustomerInfo="CustomerInfo = $event"
     @listCustomerId="listCustomerId = $event"
     :checkLoadCustomerData="checkLoadCustomerData"
     @checkLoadCustomerData="checkLoadDone=$event"
     ></ContentPageCenter>

    <ContentPageRight :customerDetails="customerDetails"></ContentPageRight>
  </div>
</template>

<script>
// nhúng các component con
import ContentPageCenter from "./ContentPageCenter";
import ContentPageLeft from "./ContentPageLeft";
import ContentPageRight from "./ContentPageRight";

// nhúng service xử lý ngành nghề
// import {CarrerService} from '../Services/CarrerService';

// nhúng service xử lý ngành nghề
import {VocativeService} from '../Services/VocativeService';

export default {
  name: "ContentPage",
  components: {
    ContentPageCenter,
    ContentPageLeft,
    ContentPageRight,
  },
  data() {
    return {
      carrer: "",
      searchCustomerCurrent:"",
      vocative:"",
      customerDetails:"",
      checkShow:Boolean, // - cho phép
      CustomerInfo:{},
      listCustomerId: "",
      checkLoadDone:true
    };
  },
  props:{
      searchCustomer: String,
      checkShowFormData: Boolean,
      checkLoadCustomerData:Boolean
  },
  watch:{
    searchCustomer(){
      this.searchCustomerCurrent = this.searchCustomer;
    },
    checkLoadDone(){
      this.$emit("checkLoadCustomerData",false);
      this.checkLoadDone = true;
    },
    // theo doi ShowFormData
    checkShow(){
      this.$emit('ShowFormData',true);
    },

    // the doi thong tin chi tiet de chinh sua
    CustomerInfo(){
      this.$emit('CustomerInfo',this.CustomerInfo);
    },

    // theo dõi danh sách id customer 
    listCustomerId:{
       handler: function (val) {
        this.$emit("listCustomerId", val);
      },
      deep: true
    }
  },
  created() {
    //Author: Phạm Văn Đạt
    // function: lấy thông tin xưng hô
    // created time: 11:50 15/08/2022
    let _VocativeService = new VocativeService();
    _VocativeService.getAll().then((res)=>{
              if(res)
                this.vocative = res;
            })

  },
  // cho phép sử dụng tham số
  methods: {},
  // không cho phép sử dụng tham số
  mounted() {},
};
</script>

<style>
</style>