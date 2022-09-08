<template>
      <div id="toast-message" >
        <!-- CustomerInfo -->
            <div class="toast-message-container" ref="notifi" :class="(toastMessageInfo.Type!= null)?toastMessageInfo.Type+'-container':''" :style="(toastMessageInfo.Type!=null)?'display:inline-block':'display:none'">
                <div class="toast-message-icon">
                    <span class="background-icon-size-16" ref="notifiIcon" :class="(toastMessageInfo.Type!=  null)?toastMessageInfo.Type:''"></span>
                </div>
                <div class="toast-message-text">
                    <span ref="notifiText">{{toastMessageInfo.Message}}</span>
                </div>
                <div class="toast-message-close">
                    <span class="close background-icon-size-16" @click="ClickHideToastMessage"></span>
                </div>
            </div>
            <!-- end info  -->           
      </div>
</template>

<script>

export default {
   name: "ToastMessageComponent",
   props: {
    toastMessageInfo:{},
    showToastMessage:Boolean
  },
  watch:{
    toastMessageInfo(){

        this.AutoHideToastMessage();    

    },
    showToastMessage(){
        this.AutoHideToastMessage();
        this.$emit("showToastMessage", false);
    }
  },
  data(){
    return {
       
    }
  },    
   mounted() {
   
  },
  methods:{
    
     AutoHideToastMessage(){
        let Element = this.$refs.notifi;
        if(Element){
            Element.style.display = "flex"; 
            setTimeout(function(){
                Element.style.display = "none";    
            }, 3000);
        }
    },
    ClickHideToastMessage: function(event){
        let Element = event.target.parentNode.parentNode;
        if(Element){
            Element.style.display = "none"; 
        }
        
    }
  }
}
</script>

<style>
@import url("../../css//base/toastMessage");
</style>
