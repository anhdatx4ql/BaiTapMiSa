<!-- eslint-disable no-unused-vars -->
<template>
  <div class="container">
    <!-- Start header -->
    <Header></Header>
    <!-- End Header -->
   
    <!-- Start Toolbar -->
     <Toolbar></Toolbar>
    <!-- End Toolbar -->
    
    <!-- Start Content -->
    <ContentPage></ContentPage>
    <!-- End content -->

  </div>
</template>

<script>
import { info, students,hello } from "./js/demo"
import Header from "./components/Header"
import Toolbar from "./components/Toolbar"
import ContentPage from "./components/ContentPage"

hello();
export default {
  name: "App",
  components: {
    Header,
    Toolbar,
    ContentPage
  },
  data() {
    return {
      username: "",
      // phải lưu cho nó 1 tên biến mới đưa lên được
      customInfo: info,
      customStudents: students,
    };
  },
  methos: {

  },
  create(){

  }
};
</script>

<style>
@import url("../src/css/main.css")
</style>
