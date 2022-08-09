<template>
  <div class="content">
    <ContentPageLeft :customVocative="vocative" :customjobTitle="jobTitle"></ContentPageLeft>
    <ContentPageCenter></ContentPageCenter>
    <ContentPageRight></ContentPageRight>
  </div>
</template>

<script>
import ContentPageCenter from "./ContentPageCenter";
import ContentPageLeft from "./ContentPageLeft";
import ContentPageRight from "./ContentPageRight";
import { getJSONAsync } from "../Services/BaseService.js";
export default {
  name: "ContentPage",
  components: {
    ContentPageCenter,
    ContentPageLeft,
    ContentPageRight,
  },
  data() {
    return {
      vocative: Object,
      department: Object,
      jobTitle: Object,
      origin: Object,
      revenue: Object,
      typeOfBank: Object,
    };
  },
  created() {

    // lay thong tin xung ho
     getJSONAsync("https://localhost:44355/api/Vocative/getAllIVocative")
      .then((res) => {
        this.vocative = res.data.data;
      })
      .catch((e) => {
        console.log(e);
      });
    // lay thong tin phong ban
     getJSONAsync(
      "https://localhost:44355/api/Department/GetAllDepartment"
    )
      .then((res) => {
        this.department = res.data.data;
        console.log(this.department);
      })
      .catch((e) => {
        console.log(e);
      });

    // lay thong tin nguon goc tiem nang
    getJSONAsync("https://localhost:44355/api/Origin/getAllOrigin")
      .then((res) => {
        this.origin = res.data.data;
        console.log(this.origin);
      })
      .catch((e) => {
        console.log(e);
      });

    // lay thong tin chuc danh
    getJSONAsync("https://localhost:44355/api/JobTitle/getAllJobTitle")
      .then((res) => {
        this.jobTitle = res.data.data;
      })
      .catch((e) => {
        console.log(e);
      });

    // lay thong tin doanh thu cua to chuc
    getJSONAsync("https://localhost:44355/api/Revenues/getAllRevenue")
      .then((res) => {
        this.revenue = res.data.data;
      })
      .catch((e) => {
        console.log(e);
      });

    // lay loai hinh
    getJSONAsync(
      "https://localhost:44355/api/TypeOfBank/GetAllTypeOfBank"
    )
      .then((res) => {
        this.typeOfBank = res.data.data;
      })
      .catch((e) => {
        console.log(e);
      });
  },
  // cho phép sử dụng tham số
  methods: {},
  // không cho phép sử dụng tham số
  mounted() {},
};
</script>

<style>
</style>