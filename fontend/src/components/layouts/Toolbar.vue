<template>
    <div class="toolbar">
      <div class="toolbar-left toolbar-child">
        <div class="toolbar-left-child">
          <div class="combobox-toolbar">
            <span class="combobox-toolbar-text">Tất cả tiềm năng</span>
            <span class="combobox-toolbar-icon button-icon-down-black"></span>
          </div>
        </div>
        <div class="toolbar-left-child">
          <button class="button-toolbar-left">Sửa</button>
        </div>
        <div class="toolbar-left-child">
          <button class="button-icon-refesh">
            <span class="button-icon-icon icon-refesh"></span>
          </button>
        </div>
      </div>
      <div class="toolbar-right toolbar-child">
        <div class="toolbar-right-child">
          <div class="combo-button">
            <button  @click="ClickShowForm()"
              class="
                button button-icon
                button-background-primary
                button-icon-left
              "
            >
              <span class="button-icon-icon button-icon-icon-sum"></span>
              <span class="button-icon-text">Thêm</span>
            </button>
            <button
              class="button-arrow button-background-primary button-icon-right"
            >
              <span class="button-icon-icon button-icon-down"></span>
            </button>
          </div>
        </div>
        <div class="toolbar-right-child">
          <button class="button button-dots button-background-white">
            <span class="button-icon-icon button-icon-icon-dots"></span>
          </button>
        </div>
        <div class="toolbar-right-child">
          <button class="button button-dots button-background-white">
            <span class="button-icon-icon button-icon-tiles"></span>
            <span class="button-icon-icon button-icon-down-black"></span>
          </button>
        </div>
      </div>
    </div>
</template>

<script>

export default {
   name: "ToolbarComponent",
   props: {
    checkShowFormData: Boolean 
  },
   methods:{
    ClickShowForm: function(){
        this.$emit('ShowFormData',!this.checkShowFormData);
    }
   }
}
</script>

<style>

</style>

