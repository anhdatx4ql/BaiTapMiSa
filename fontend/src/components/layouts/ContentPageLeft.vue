<template>
  <div class="content-chlid content-sider-bar-left">
    <div class="content-sider-bar-left-top">
      <div class="combobox filter-save combobox-filter-top">
        <div
          class="combobox-child combobox-content"
          @click="handlerClickCombobox"
          check="false"
        >
          <div class="combobox-content-select">BỘ LỌC ĐÃ LƯU</div>
          <div
            class="combobox-content-icon button-icon-up-black icon-font-16"
          ></div>
        </div>

        <div class="combobox-child combobox-data">
          <div class="combobox-data-search">
            <label class="label-input combobox-data-search-label">
              <input
                type="text"
                class="input input-icon"
                placeholder="Tìm kiếm"
              />
              <span class="background-icon-search-input"></span>
            </label>
          </div>
          <div class="combobox-data-child">
            <div
              class="combobox-data-child-content select-content-data"
              @click="handlerClickComboboxData"
              value="Bố cục"
            >
              Bố cục
            </div>
            <div
              class="combobox-data-child-content"
              @click="handlerClickComboboxData"
              value="Chức danh"
            >
              Chức danh
            </div>
            <div
              class="combobox-data-child-content"
              @click="handlerClickComboboxData"
              value="Doanh thu"
            >
              Doanh thu
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="content-sider-bar-left-center">
      <div class="filter-title">
        <div class="filter-title-text">LỌC TIỀM NĂNG THEO</div>
        <div class="filter-title-icon">
          <span class="background-icon-search-input"></span>
        </div>
      </div>

      <div class="filter-content">
        <div class="filter-content-child">
          <div class="filter-content-child-checkbox">
            <div class="filter-content-child-checkbox-input">
              <input type="checkbox" />
            </div>
            <div class="filter-content-child-checkbox-text">Thẻ</div>
          </div>
          <div class="filter-content-child-box">
            <!-- <!- content thẻ -> -->
          </div>
        </div>


<!-- <!- Xưng hô ->  -->
         <div class="filter-content-child filter-content-active">
          <div class="filter-content-child-checkbox">
            <div class="filter-content-child-checkbox-input">
              <input type="checkbox" />
            </div>
            <div class="filter-content-child-checkbox-text">Xưng hô</div>
          </div>
          <div class="filter-content-child-box">
            <div
              class="combobox filter-save filter-content-child-box-combobox"
            >
              <div class="combobox-child combobox-content border-color-c"
                @click="handlerClickCombobox"
                check="false">
                <div class="combobox-content-select">Là</div>
                <div class="combobox-content-icon
                    button-icon-up-black
                    icon-font-16"></div>
              </div>

              <div
                class="combobox-child combobox-data filter-content-child-data"
              >
                <div
                  class="
                    combobox-data-search
                    filter-content-child-data-child
                  "
                >
                  <label class="label-input combobox-data-search-label">
                    <input
                      type="text"
                      class="input input-icon"
                      placeholder="Tìm kiếm"
                    />
                    <span class="background-icon-search-input"></span>
                  </label>
                </div>
                <div
                  class="combobox-data-child filter-content-child-data-child"
                >
                  <div
                    class="combobox-data-child-content"
                    v-for="vocative in customVocative"
                    :key="vocative.vocativeId"
                    @click="handlerClickComboboxData"
                    :value="vocative.vocativeId"
                  >
                    {{ vocative.vocativeName }}
                  </div>
                </div>
              </div>
            </div>


            <div class="filter-content-child-box-textarea">
              <div
                class="
                  filter-content-child-box-textarea-content
                  border-color-c
                "
              ></div>
            </div>
          </div>
        </div> 

        <!-- <!- Họ và tên -> -->
        <div class="filter-content-child">
          <div class="filter-content-child-checkbox">
            <div class="filter-content-child-checkbox-input">
              <input type="checkbox" />
            </div>
            <div class="filter-content-child-checkbox-text">Họ và tên</div>
          </div>
          <div class="filter-content-child-box">
            <!-- <!- content thẻ -> -->
          </div>
        </div>

        <!-- <!- Chức danh -> -->      
        <!-- <div class="filter-content-child filter-content-active">
          <div class="filter-content-child-checkbox">
            <div class="filter-content-child-checkbox-input">
              <input type="checkbox" />
            </div>
            <div class="filter-content-child-checkbox-text">Chức danh</div>
          </div>
          <div class="filter-content-child-box">
            <div
              class="combobox filter-save filter-content-child-box-combobox"
            >
              <div class="combobox-child combobox-content border-color-c"
                @click="handlerClickCombobox"
                check="false">
                <div class="combobox-content-select">Là</div>
                <div class="combobox-content-icon
                    button-icon-up-black
                    icon-font-16"></div>
              </div>

              <div
                class="combobox-child combobox-data filter-content-child-data"
              >
                <div
                  class="
                    combobox-data-search
                    filter-content-child-data-child
                  "
                >
                  <label class="label-input combobox-data-search-label">
                    <input
                      type="text"
                      class="input input-icon"
                      placeholder="Tìm kiếm"
                    />
                    <span class="background-icon-search-input"></span>
                  </label>
                </div>
                <div
                  class="combobox-data-child filter-content-child-data-child"
                >
                  <div
                    class="combobox-data-child-content"
                    v-for="jobTitle in customjobTitle"
                    :key="jobTitle.jobTitleId"
                    @click="handlerClickComboboxData"
                    :value="jobTitle.jobTitleId"
                  >
                    {{ jobTitle.jobTitleName }}
                  </div>
                </div>
              </div>
            </div>
            <div class="filter-content-child-box-textarea">
              <div
                class="
                  filter-content-child-box-textarea-content
                  border-color-c
                "
              ></div>
            </div>
          </div>
        </div> -> -->

        <!-- <!- điện thoại di động -> -->
        <div class="filter-content-child">
          <div class="filter-content-child-checkbox">
            <div class="filter-content-child-checkbox-input">
              <input type="checkbox" />
            </div>
            <div class="filter-content-child-checkbox-text">ĐT di động</div>
          </div>
          <div class="filter-content-child-box">
            <!-- <!- content thẻ -> -->
          </div>
        </div>

        <!-- <!- điện thoại cơ quan -> -->
        <div class="filter-content-child">
          <div class="filter-content-child-checkbox">
            <div class="filter-content-child-checkbox-input">
              <input type="checkbox" />
            </div>
            <div class="filter-content-child-checkbox-text">Đt cơ quan</div>
          </div>
          <div class="filter-content-child-box">
            <!-- <!- content thẻ -> -->
          </div>
        </div>

        <!-- <!- email cơ quan -> -->
        <div class="filter-content-child">
          <div class="filter-content-child-checkbox">
            <div class="filter-content-child-checkbox-input">
              <input type="checkbox" />
            </div>
            <div class="filter-content-child-checkbox-text">Email cơ quan</div>
          </div>
          <div class="filter-content-child-box">
            <!-- <!- content thẻ -> -->
          </div>
        </div>

        <!-- <!- email cá nhân -> -->
        <div class="filter-content-child">
          <div class="filter-content-child-checkbox">
            <div class="filter-content-child-checkbox-input">
              <input type="checkbox" />
            </div>
            <div class="filter-content-child-checkbox-text">Email cá nhân</div>
          </div>
          <div class="filter-content-child-box">
            <!-- <!- content thẻ -> -->
          </div>
        </div>

        <!-- <!- tổ chức -> -->
        <div class="filter-content-child">
          <div class="filter-content-child-checkbox">
            <div class="filter-content-child-checkbox-input">
              <input type="checkbox" />
            </div>
            <div class="filter-content-child-checkbox-text">Tổ chức</div>
          </div>
          <div class="filter-content-child-box">
            <!-- <!- content thẻ -> -->
          </div>
        </div>

        <!-- <!- Địa chỉ -> -->
        <div class="filter-content-child">
          <div class="filter-content-child-checkbox">
            <div class="filter-content-child-checkbox-input">
              <input type="checkbox" />
            </div>
            <div class="filter-content-child-checkbox-text">Địa chỉ</div>
          </div>
          <div class="filter-content-child-box">
            <!-- <!- content thẻ -> -->
          </div>
        </div>

        <!-- <!- Tỉnh/Thành phố -> -->
        <div class="filter-content-child">
          <div class="filter-content-child-checkbox">
            <div class="filter-content-child-checkbox-input">
              <input type="checkbox" />
            </div>
            <div class="filter-content-child-checkbox-text">
              Tỉnh/Thành phố
            </div>
          </div>
          <div class="filter-content-child-box">
            <!-- <!- content thẻ -> -->
          </div>
        </div>

        <!-- <!- Quận/Huyện -> -->
        <div class="filter-content-child">
          <div class="filter-content-child-checkbox">
            <div class="filter-content-child-checkbox-input">
              <input type="checkbox" />
            </div>
            <div class="filter-content-child-checkbox-text">Quận/Huyện</div>
          </div>
          <div class="filter-content-child-box">
            <!-- <!- content thẻ -> -->
          </div>
        </div>

        <!-- <!- Phường/Xã -> -->
        <div class="filter-content-child">
          <div class="filter-content-child-checkbox">
            <div class="filter-content-child-checkbox-input">
              <input type="checkbox" />
            </div>
            <div class="filter-content-child-checkbox-text">Phường/Xã</div>
          </div>
          <div class="filter-content-child-box">
            <!-- <!- content thẻ -> -->
          </div>
        </div>
<!-- 
        <!- Nguồn gốc -> -->
        <div class="filter-content-child">
          <div class="filter-content-child-checkbox">
            <div class="filter-content-child-checkbox-input">
              <input type="checkbox" />
            </div>
            <div class="filter-content-child-checkbox-text">Nguồn gốc</div>
          </div>
          <div class="filter-content-child-box">
            <!-- <!- content thẻ -> -->
          </div>
        </div>

        <!-- <!- Loại hình -> -->
        <div class="filter-content-child">
          <div class="filter-content-child-checkbox">
            <div class="filter-content-child-checkbox-input">
              <input type="checkbox" />
            </div>
            <div class="filter-content-child-checkbox-text">Loại hình</div>
          </div>
          <div class="filter-content-child-box">
            <!-- <!- content thẻ -> -->
          </div>
        </div>

        <!-- <!- Lĩnh vực -> -->
        <div class="filter-content-child">
          <div class="filter-content-child-checkbox">
            <div class="filter-content-child-checkbox-input">
              <input type="checkbox" />
            </div>
            <div class="filter-content-child-checkbox-text">Lĩnh vực</div>
          </div>
          <div class="filter-content-child-box">
            <!-- <!- content thẻ -> -->
          </div>
        </div>

        <!-- <!- Mô tả -> -->
        <div class="filter-content-child">
          <div class="filter-content-child-checkbox">
            <div class="filter-content-child-checkbox-input">
              <input type="checkbox" />
            </div>
            <div class="filter-content-child-checkbox-text">Mô tả</div>
          </div>
          <div class="filter-content-child-box">
            <!-- <!- content thẻ -> -->
          </div>
        </div>

        <!-- Bố cục -->
        <div class="filter-content-child">
          <div class="filter-content-child-checkbox">
            <div class="filter-content-child-checkbox-input">
              <input type="checkbox" />
            </div>
            <div class="filter-content-child-checkbox-text">Bố cục</div>
          </div>
          <div class="filter-content-child-box">
            <!-- content thẻ -->
          </div>
        </div>

        <!-- chủ sở hữu -->
        <div class="filter-content-child">
          <div class="filter-content-child-checkbox">
            <div class="filter-content-child-checkbox-input">
              <input type="checkbox" />
            </div>
            <div class="filter-content-child-checkbox-text">Chủ sở hữu</div>
          </div>
          <div class="filter-content-child-box">
            <!-- content thẻ -->
          </div>
        </div>

        <!-- doanh thu -->
        <div class="filter-content-child">
          <div class="filter-content-child-checkbox">
            <div class="filter-content-child-checkbox-input">
              <input type="checkbox" />
            </div>
            <div class="filter-content-child-checkbox-text">Doanh thu</div>
          </div>
          <div class="filter-content-child-box">
            <!-- content thẻ -->
          </div>
        </div>

        <!-- Dùng chung -->
        <div class="filter-content-child">
          <div class="filter-content-child-checkbox">
            <div class="filter-content-child-checkbox-input">
              <input type="checkbox" />
            </div>
            <div class="filter-content-child-checkbox-text">Dùng chung</div>
          </div>
          <div class="filter-content-child-box">
            <!-- content thẻ -->
          </div>
        </div>

        <!-- Facebook -->
        <div class="filter-content-child">
          <div class="filter-content-child-checkbox">
            <div class="filter-content-child-checkbox-input">
              <input type="checkbox" />
            </div>
            <div class="filter-content-child-checkbox-text">Facebook</div>
          </div>
          <div class="filter-content-child-box">
            <!-- content thẻ -->
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import {
  ClickShowHideComboboxData,
  selectValueComboboxData,
} from "../../js/test";


export default {
  name: "ContentPageLeft",
  data(){
    return{
        vocative:Object
    };
    
  },
  props: {
    customVocative:{}
  },
  watch:{
    // theo dõi object xưng hô
    customVocative(){
      this.vocative = this.customVocative;
    }
  },
  created() {},
  methods: {
    // xử lý click combobox hiển thị - ẩn
    handlerClickCombobox: function (event) {
      ClickShowHideComboboxData(event);
    },
    // xử lý click lấy thông tin tronc combobox
    handlerClickComboboxData: function (event) {
      selectValueComboboxData(event);
    },
  },
};
</script>

<style>
</style>