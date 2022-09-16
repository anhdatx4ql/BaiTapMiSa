<template>
 <div class="content-child content-sider-bar-right">
      <div
        class="content-sider-bar-right-title content-sider-bar-right-child"
      >
        <div class="content-sider-bar-right-child-icon">
          <button class="button tool-tip-container">
            <span class="background-icon-phone icon-font-16"></span>
            <ToolTip :type="'top'" :text="'Gọi điện'"></ToolTip>
          </button>
        </div>
        <div class="content-sider-bar-right-child-icon">
          <button class="button tool-tip-container">
            <span class="background-icon-bill icon-font-16"></span>
            <ToolTip :type="'top'" :text="'Công việc'"></ToolTip>
          </button>
        </div>
        <div class="content-sider-bar-right-child-icon">
          <button class="button tool-tip-container">
            <span class=" background-icon-bag icon-font-16"></span>
            <ToolTip :type="'top'" :text="'Đặt lịch'"></ToolTip>
          </button>
        </div>
        <div class="content-sider-bar-right-child-icon">
          <button class="button tool-tip-container">
            <span class="background-icon-email icon-font-16"></span>
            <ToolTip :type="'topRight'" :text="'Gửi Email'"></ToolTip>
          </button>
        </div>
      </div>

      <div
        class="
          content-sider-bar-right-content content-sider-bar-right-child
        "
      >
        <div><p class="combobox-toolbar-text">Lịch sử giao dịch</p></div>
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
  // format dữ liệu
import {formatDate} from '../../js/formatData'

  // nhung tooltip
  import ToolTip from "./ToolTip"
// thư viện dùng để xử lý datetime
export default {
    name: 'ContentPageRight',
    components:{ToolTip},
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
