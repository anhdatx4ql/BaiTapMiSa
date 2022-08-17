<template>
 <div class="content-child content-sider-bar-right">
      <div
        class="content-sider-bar-right-title content-sider-bar-right-child"
      >
        <div class="content-sider-bar-right-child-icon">
          <div class="background-icon-phone icon-font-16"></div>
        </div>
        <div class="content-sider-bar-right-child-icon">
          <div class="background-icon-bill icon-font-16"></div>
        </div>
        <div class="content-sider-bar-right-child-icon">
          <div class="background-icon-bag icon-font-16"></div>
        </div>
        <div class="content-sider-bar-right-child-icon">
          <div class="background-icon-email icon-font-16"></div>
        </div>
      </div>

      <div
        class="
          content-sider-bar-right-content content-sider-bar-right-child
        "
      >
 
        <!-- <!- nếu customerDetail trống thì hiển thị không có dữ liệu -> -->
        <div class="notifi-content-container" v-for="customerDetail in customerDetails" :key="customerDetail.CustomerDetailID" >
          <div class="notifi-content-left">
            <span class="notifi-content-left-icon"></span>
          </div>
          <div class="notifi-content-right">
            <div class="notifi-content-right-title">Ghi Chú</div>
            <div class="notifi-content-right-text">
              {{customerDetail.customerDetailName}} - {{formatDate(customerDetail.createdAt)}}
            </div>
          </div>
        </div>
      </div>
    </div>
</template>
<script>
import {formatDate} from '../../js/formatData'
// thư viện dùng để xử lý datetime
export default {
    name: 'ContentPageRight',
    data(){
      return{
        customerDetailsLeft:Object
      }
      
    },
    methods:{
     formatDate
    },
    props:{
      customerDetails:{}
    },
    created(){
      this.customerDetailsLeft = this.customerDetails;

    },
    watch:{
      customerDetails(){
        console.log(this.customerDetails)
      }
    },
    filters:{
     
    }
}
</script>

<style>
</style>
