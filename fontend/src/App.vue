<!-- eslint-disable no-unused-vars -->
<template>
  <div class="container">
    <!-- Start header -->
    <Header></Header>
    <!-- End Header -->

    <!-- Start Toolbar -->
    <!-- $event: data được gửi từ component con lên: ở đây là true -->
    <Toolbar
      :checkShowFormData="checkShowForm"
      @ShowFormData="checkShowForm = $event"
    ></Toolbar>
    <!-- End Toolbar -->

    <!-- Start Content -->
    <ContentPage @SelectInfoUser="User = $event"></ContentPage>
    <!-- End content -->

    <!-- Start Form create - update -->
    <FormData
      :checkShowFormData="checkShowForm"
      @CloseFormData="checkShowForm = $event"
    ></FormData>
    <!-- End Form create - update -->
  </div>
</template>

<script>
import { info, students } from "./js/demo";
import Header from "./components/layouts/Header";
import Toolbar from "./components/layouts/Toolbar";
import ContentPage from "./components/layouts/ContentPage";
import FormData from "./components/layouts/FormData";

/** VÒNG ĐỜI
 * 1: beforeCraete -  Tại thời điểm này, data, event chưa được thiết lập.
 *  2: created // được chạy khi data, event đã thiết lập thành công.
 * 3: BeforeMount: sẽ chạy sau khi data, event được thiết lập và trước khi gắn kết vào DOM.
 *                 Trong hook này chúng ta vẫn chưa - truy cập được phần tử trong DOM.
 * 4: mounted: có thể truy cập vào phẩn tử trong DOM
 * 5: beforeUpdate: Sau khi đối tượng đã được gắn vào DOM, khi dữ liệu thay đổi, và trước khi render,
 *                  patch lại và hiển thị ra cho người dùng.
 * 6: Updated: Chạy ngay sau khi beforeUpdate . Sử dụng khi bạn cần truy cập DOM sau khi thay đổi thuộc tính
 * 7: beforeUnMount: Là giai đoạn trước khi instance bị hủy.
 *                  Đây là nơi để quản lý tài nguyên xóa tài nguyên, dọn dẹp các component.
 * 8: UnMounted: , mọi thành phần đã được hủy bỏ hết. Khi console.log() đối tượng này thì sẽ không nhận được thuộc tính hay dữ liệu gì.
 * mỗi khi dữ liệu thay đổi thì wath chạy => wath dùng để theo dõi các biến
 */

export default {
  name: "App",
  components: {
    Header,
    Toolbar,
    ContentPage,
    FormData,
  },
  data() {
    return {
      username: "",
      // phải lưu cho nó 1 tên biến mới đưa lên được
      customInfo: info,
      customStudents: students,
      checkShowForm: false,
      User: Object
    };
  },
  methods: {
    
  }, mounted(){
    console.log('xong')
  }
};
</script>

<style>
@import url("../src/css/main.css");
</style>
