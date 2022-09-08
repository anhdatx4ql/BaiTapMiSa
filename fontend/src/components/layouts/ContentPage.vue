<template>
  <div class="content">
    
    <ContentPageLeft
     @ArrayObjectData="ArrayObjectData = $event">
    </ContentPageLeft>
    <ContentPageCenter 

    :searchCustomerCurrent="searchCustomerCurrent"

     @CustomerDetails="customerDetails = $event"

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
      customerDetails:"",
      checkShow:Boolean, // - cho phép
      CustomerInfo:{},
      listCustomerId: "",
      checkLoadDone:true,
      ArrayObjectData:[]
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
  },
  // cho phép sử dụng tham số
  methods: {},
  // không cho phép sử dụng tham số
  mounted() {},
};
</script>

<style>
</style>