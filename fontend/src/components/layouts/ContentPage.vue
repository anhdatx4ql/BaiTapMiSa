<template>
  <div class="content">
    
    <ContentPageLeft
     @ArrayObjectData="ArrayObjectData = $event">
    </ContentPageLeft>

    <ContentPageCenter
    :removeListCustomerId="removeListCustomerId"
    :searchCustomerCurrent="searchCustomerCurrent"

     @customerDetails="customerDetails = $event"

     :checkShowFormData="checkShowFormData"

     @ShowFormData="checkShow = $event"

     @CustomerInfo="CustomerInfo = $event"

     @listCustomerId="listCustomerId = $event"

     :checkLoadCustomerData="checkLoadCustomerData"

     @checkLoadCustomerData="checkLoadDone=$event"

     :ArrayObjectData="ArrayObjectData"

     ></ContentPageCenter>

    <ContentPageRight :customerDetails="customerDetails"></ContentPageRight>
  </div>
</template>

<script>
// nhúng các component con
import ContentPageCenter from "./ContentPageCenter";
import ContentPageLeft from "./ContentPageLeft";
import ContentPageRight from "./ContentPageRight";


export default {
  name: "ContentPage",
  components: {
    ContentPageCenter,
    ContentPageLeft,
    ContentPageRight,
  },
  data() {
    return {
      searchCustomerCurrent:"",
      customerDetails:{},
      checkShow:Boolean, // - cho phép
      CustomerInfo:{},
      listCustomerId: "",
      checkLoadDone:true,
      ArrayObjectData:[],
      removeListCustomerIdCurrent:true
    };
  },
  props:{
      searchCustomer: String,
      checkShowFormData: Boolean,
      checkLoadCustomerData:Boolean,
      removeListCustomerId:Boolean
  },
  watch:{

    removeListCustomerIdCurrent(value){
      console.log(value)
    },
  
    // Author: Phạm Văn Đạt
    // function: theo dõi tìm kiếm khách hàng
    searchCustomer(){
      this.searchCustomerCurrent = this.searchCustomer;
    },

     // Author: Phạm Văn Đạt
    // function: kiểm tra load dữ liệu
    checkLoadDone(){
      this.$emit("checkLoadCustomerData",false);
      this.checkLoadDone = true;
    },

     // Author: Phạm Văn Đạt
    // theo doi ShowFormData
    checkShow(){
      this.$emit('ShowFormData',true);
    },

     // Author: Phạm Văn Đạt
    // the doi thong tin chi tiet de chinh sua
    CustomerInfo(){
      this.$emit('CustomerInfo',this.CustomerInfo);
    },

     // Author: Phạm Văn Đạt
    // theo dõi danh sách id customer 
    listCustomerId:{
       handler: function (val) {
        this.$emit("listCustomerId", val);
      },
      deep: true
    }
  },
  created() {
  },
  // cho phép sử dụng tham số
  methods: {},
  // không cho phép sử dụng tham số
  mounted() {},
};
</script>

<style>
</style>