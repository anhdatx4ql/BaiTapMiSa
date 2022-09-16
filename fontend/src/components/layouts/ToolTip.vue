<template>

          <div class="tool-tip-text-top tool-tip-text" v-if="(type=='top')?true:false">
            <span>{{text}}</span>
            <span class="tool-tip-text-top-arrow tool-tip-text-top-arrow-top"></span>
          </div>

          <div class="tool-tip-text-top-left tool-tip-text" v-if="(type=='topLeft')?true:false">
            <span>{{text}}</span>
            <span class="tool-tip-text-top-arrow tool-tip-text-top-arrow-top"></span>
          </div>

          <div class="tool-tip-text-top-right tool-tip-text" v-if="(type=='topRight')?true:false">
            <span>{{text}}</span>
            <span class="tool-tip-text-top-arrow tool-tip-text-top-arrow-top"></span>
          </div>

          <div class="tool-tip-text-bottom tool-tip-text" v-else-if="(type=='bottom')?true:false"> 
            <span>{{text}}</span>
            <span class="tool-tip-text-top-arrow tool-tip-text-top-arrow-bottom"></span>
          </div>

          <div class="tool-tip-text-bottom-right tool-tip-text" v-else-if="(type=='bottomRight')?true:false"> 
            <span>{{text}}</span>
            <span class="tool-tip-text-top-arrow tool-tip-text-top-arrow-bottom"></span>
          </div>

          <div class="tool-tip-text-bottom-left tool-tip-text" v-else-if="(type=='bottomLeft')?true:false"> 
            <span>{{text}}</span>
            <span class="tool-tip-text-top-arrow tool-tip-text-top-arrow-bottom"></span>
          </div>

          <div class="tool-tip-text-left tool-tip-text" v-else-if="(type=='left')?true:false">
            <span>{{text}}</span>
            <span class="tool-tip-text-top-arrow"></span>
          </div>

          <div class="tool-tip-text-right tool-tip-text" v-else-if="(type=='right')?true:false">
            <span>{{text}}</span>
            <span class="tool-tip-text-top-arrow"></span>
          </div>

    
</template>

<script>
export default {
  name: "ToolTipComponent",
  props: {
    text: String,
    type: String
  },
  watch: {},
  data() {
    return {
    };
  },
  mounted() {},
  methods: {},
};
</script>

<style>
@import url("../../css//base/tooltip");
</style>
