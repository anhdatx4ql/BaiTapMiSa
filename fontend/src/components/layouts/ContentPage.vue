<template>
  <div class="content">
    <ContentPageLeft :customCarrer="carrer" :customVocative="vocative"></ContentPageLeft>
    <ContentPageCenter :customersSearch="customers"
     @CustomerDetails="customerDetails = $event"
     :checkShowFormData="checkShowFormData"
     @ShowFormData="checkShow = $event"
     @CustomerInfo="CustomerInfo = $event"
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
import {CarrerService} from '../Services/CarrerService';

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
      carrer: Object,
      customers:Object,
      vocative:Object,
      customerDetails:Object,
      checkShow:Boolean, // - cho phép
      CustomerInfo:Object
    };
  },
  props:{
      Customers: {
        
      },
      checkShowFormData: Boolean
  },
  watch:{
    // theo dõi object khách hàng
    Customers(){
     this.customers = this.Customers;
    },

    //theo dõi object chi tiết khách hàng
    customerDetails(){
      console.log(this.customerDetails)
    },

    // theo dõi check show form
    checkShowFormData(){
    },

    // theo doi ShowFormData
    checkShow(){
      this.$emit('ShowFormData',true);
    },

    // the doi thong tin chi tiet de chinh sua
    CustomerInfo(){
      this.$emit('CustomerInfo',this.CustomerInfo);
    }
  },
  created() {

    //Author: Phạm Văn Đạt
    // function: lấy thông tin ngành nghề;
    // created time: 11:50 15/08/2022
    let _CarrerService = new CarrerService();
    _CarrerService.getAll()
    .then(res=>{
        if(res.data.data)
          this.carrer = res.data.data;
      console.log('carrer: ',this.carrer)
    })
    .catch(e=>{
      console.log(e)
    });

    
    //Author: Phạm Văn Đạt
    // function: lấy thông tin xưng hô
    // created time: 11:50 15/08/2022
    let _VocativeService = new VocativeService();
    _VocativeService.getAll()
    .then(res=>{
      if(res.data.data)
        this.vocative = res.data.data;
      console.log(this.vocative);
    })
    .catch(e=>{
      console.log(e)
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