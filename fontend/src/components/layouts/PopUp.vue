<template>
      <div id="pop-up">
            <div v-if="checkShowPopUpCurrent">
                <div class="pop-up-container">
                    <div class="pop-up-top">
                        <div class="pop-up-top-title">{{PopUpTitle}}</div>
                        <div class="pop-up-top-close">
                            <button class="background-icon-close icon-font-16" @click="clickHidePopUp"></button>
                        </div>
                    </div>
                    <div class="pop-up-bottom">
                        <button class="pop-up-bottom-active" @click="clickActive">Đồng ý</button>
                        <button class="pop-up-bottom-cancel" @click="clickHidePopUp">Hủy bỏ</button>
                    </div>
                    
                </div>
            </div>
             
      </div>
</template>

<script>

export default {
   name: "PopUPComponent",
   props: {
    checkShowPopUp:Boolean,
    PopUpTitle:String
  },
  watch:{
    checkShowPopUp(){
        this.checkShowPopUpCurrent = this.checkShowPopUp;
    }
  },
  data(){
    return {
       checkShowPopUpCurrent: false
    }
  },    
   mounted() {
   
  },
  methods:{
    // click  ẩn popUp
    clickHidePopUp(){
        try{
            this.$emit("checkShowPopUp",false)
        }catch(error){
            console.log(error)
        }
        
    },

    // gửi true đồng ý cho xóa
    clickActive(){
        try{
            console.log("gui")
            this.$emit("checkShowPopUp",false)
            this.$emit("ActiveMessage", true)
        }catch(error){
            console.log(error)
        }
    }
  }
}
</script>

<style>
@import url("../../css//base/popup");
</style>
