<template>
  <div id="tool-tip" v-if="(text!=null)?true:false">
      <div class="tool-tip-container">
        <div class="tool-tip-icon">
            <span class="background-icon-tool-tip"></span>
        </div>
        <div class="tool-tip-text">
          <div class="tool-tip-text-top" v-if="(type=='top')?true:false">
            <span>{{text}}</span>
            <span class="tool-tip-text-top-arrow"></span>
          </div>
          <div class="tool-tip-text-bottom" v-else-if="(type=='bottom')?true:false">{{text}}</div>
          <div class="tool-tip-text-left" v-else-if="(type=='left')?true:false">{{text}}</div>
          <div class="tool-tip-text-right"  v-else-if="(type=='right')?true:false">{{text}}</div>

        </div>
      </div>
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
