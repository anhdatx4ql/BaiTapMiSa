<template>
  <div class="toolbar">
    <div
      class="toolbar-left toolbar-child"
      v-if="listCustomerId.length == 0 ? true : false"
    >
      <!-- //Start Th1 -->
      <div class="toolbar-left-child">
        <div class="combobox-toolbar">
          <span class="combobox-toolbar-text">Tất cả tiềm năng</span>
          <span class="combobox-toolbar-icon button-icon-down-black"></span>
        </div>
      </div>
      <div class="toolbar-left-child">
        <button class="button-toolbar-left">
          Sửa
        </button>
      </div>
      <div class="toolbar-left-child">
        <button class="button-icon-refesh tool-tip-container" @click="loadData">
          <span class="button-icon-icon icon-refesh"></span>
          <ToolTip :type="'top'" :text="'Tải lại dữ liệu'"></ToolTip>
        </button>
      </div>
      <!-- // End  TH1   -->
    </div>

    <div
      class="toolbar-left toolbar-child toolbar-left toolbar-child-change"
      v-else
    >
      <!-- Start TH 2 -->
      <div class="toolbar-left-child">
        <span class="combobox-toolbar-text"
          >Đã chọn {{ listCustomerId.length }}</span
        >
      </div>

      <div class="toolbar-left-child">
        <button class="button-toolbar-left" @click="ClickremoveListCustomerId">
          Bỏ chọn
        </button>
      </div>

      <div class="toolbar-left-child">
        <button class="button-toolbar-left toolbar-left-child-button" @click="ShowFormUpdateMul = true">
          <span
            class="button-toolbar-left-icon background-icon-update icon-font-16"
          ></span>
          <span class="button-toolbar-left-text">Cập nhật thông tin</span>
        </button>
      </div>

      <div class="toolbar-left-child">
        <button
          class="button button-dots button-background-white show-button-toolbar"
          @click="ShowOptions"
        >
          <span class="button-icon-icon button-icon-icon-dots"></span>
        </button>
        <div class="toolbar-left-child-options">
          <button class="button-toolbar-left toolbar-left-child-button" @click="ClickExportExcel">
            <span
              class="
                button-toolbar-left-icon
                background-icon-export
                icon-font-16
              "
            ></span>
            <span class="button-toolbar-left-text">Xuất khẩu</span>
          </button>

          <button
            @click="ClickDeleteMul"
            class="
              button-toolbar-left
              toolbar-left-child-button toolbar-left-child-button-delete
            "
          >
            <span
              class="
                button-toolbar-left-icon
                background-icon-delete
                icon-font-16
              "
            ></span>
            <span class="button-toolbar-left-text">Xóa</span>
          </button>
        </div>
      </div>
    </div>

    <div class="toolbar-right toolbar-child">
      <div class="toolbar-right-child">
        <div class="combo-button">
          <button
            @click="ClickShowForm()"
            class="
              button button-icon button-background-primary button-icon-left
            "
          >
            <span class="button-icon-icon button-icon-icon-sum"></span>
            <span class="button-icon-text">Thêm</span>
          </button>
          <button
            class="button-arrow button-background-primary button-icon-right tool-tip-container"
            @click="ShowNotFound"
          >
            <span class="button-icon-icon button-icon-down"></span>
            <ToolTip :type="'top'" :text="'Xem thêm'"></ToolTip>
          </button>
        </div>
      </div>
      <div class="toolbar-right-child">
        <button class="button button-dots button-background-white tool-tip-container" @click="ShowNotFound">
          <span class="button-icon-icon button-icon-icon-dots"></span>
          <ToolTip :type="'top'" :text="'Menu'"></ToolTip>
        </button>
      </div>
      <div class="toolbar-right-child">
        <button class="button button-dots button-background-white tool-tip-container" @click="ShowNotFound">
          <span class="button-icon-icon button-icon-tiles"></span>
          <span class="button-icon-icon button-icon-down-black"></span>
          <ToolTip :type="'top'" :text="'Khác'"></ToolTip>
        </button>
      </div>
    </div>

    <!-- Start Xử lý update nhiều -->
    <div class="toolbar-update-mul" v-if="ShowFormUpdateMul">
      <div class="toolbar-update-mul-container">
        <div class="toolbar-update-mul-container-title">
          <div class="toolbar-update-mul-container-title-text">
            Cập nhật thông tin
          </div>
          <div class="toolbar-update-mul-container-title-icon">
            <button class="icon-font-16 background-icon-close" @click="ShowFormUpdateMul =  false;ShowField = null"></button>
          </div>
        </div>
        <div class="toolbar-update-mul-container-content">
          <!-- Strat Combobox các trường có thể update nhanh -->
          <div class="toolbar-update-mul-container-content-field">
            <div class="form-container-content-child-item">
              <div class="form-container-content-child-item-input">
                <div class="combobox" id="fields">
                  <div
                    class="combobox-child combobox-content"
                    @click="HandlerClickCombobox"
                    check="false"
                  >
                    <div
                      class="combobox-content-select combobox-child"
                      ref="field"
                    >
                      - Chọn trường -
                    </div>
                    <div
                      class="
                        combobox-content-icon
                        button-icon-up-black
                        icon-font-16
                        combobox-child
                      "
                    ></div>
                  </div>

                  <div class="combobox-child combobox-data" ref="fields">
                    <!-- <div class="combobox-data-search">
                      <label class="label-input combobox-data-search-label">
                        <input
                          type="text"
                          class="input input-icon"
                          placeholder="Tìm kiếm"
                        />
                        <span class="background-icon-search-input"></span>
                      </label>
                    </div> -->
                    <div class="combobox-data-child">
                    
                      <div
                        class="combobox-data-child-content"
                        v-for="v in fielsUpdate"
                        :key="v[0]"
                        @click="HandlerClickComboboxData"
                        :value="v[0]"
                      >
                        <div class="combobox-data-child-content-text">
                          {{ v[1] }}
                        </div>
                        <div class="background-icon-checked icon-font-16"></div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
          <!-- End Combobox các trường có thể update nhanh -->

          <!-- Start Value Combobox -->
          <div class="toolbar-update-mul-container-content-field-value">
            <!-- Start Xưng hô -->
            <div class="form-container-content-child-item" v-if="(ShowField == 'VocativeId')">
              <div class="form-container-content-child-item-input">
                <div class="combobox" id="vocative">
                  <div
                    class="combobox-child combobox-content"
                    @click="HandlerClickCombobox"
                    check="false" ref="CloumnValue"
                  >
                    <div
                      class="combobox-content-select combobox-child combobox-content-select-content-none"
                      ref="vocativeId"
                    >
                      - Không chọn -
                    </div>
                    <div
                      class="
                        combobox-content-icon
                        button-icon-up-black
                        icon-font-16
                        combobox-child
                      "
                    ></div>
                  </div>

                  <div class="combobox-child combobox-data" ref="vocative">
                    <!-- loading -->
                    <div class="content-background-icon-loading">
                      <div class="background-icon-loading"></div>
                    </div>

                   <!-- tìm kiếm -->
                   <div class="combobox-data-search combobox-data-child-content-text" >
                        <label class="label-input combobox-data-search-label combobox-data-child-content-text">
                          <input
                            type="text"
                            class="input input-icon combobox-data-child-content-text"
                            placeholder="Tìm kiếm"
                            v-on:keyup.enter="SearchVocative"
                            v-model="searchVocative"
                          />
                          <span class="background-icon-search-input combobox-data-child-content-text"
                          @click="SearchVocative"></span>
                        </label>
                      </div>
                    <div class="combobox-data-child">
                      <div
                          class="combobox-data-child-content"
                        
                          @click="HandlerClickComboboxData"
                          value="null"
                        >
                          <div class="combobox-data-child-content-text">
                            - Không chọn -
                          </div>
                          <div
                            class="background-icon-checked icon-font-16"
                          
                          ></div>
                        </div>
                      <div
                        class="combobox-data-child-content"
                        v-for="v in Vocative"
                        :key="v.vocativeId"
                        @click="HandlerClickComboboxData"
                        :value="v.vocativeId"
                      >
                        <div class="combobox-data-child-content-text">
                          {{ TitleCase(v.vocativeName) }}
                        </div>
                        <div class="background-icon-checked icon-font-16"></div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
            <!-- End Xưng hô -->

            <!-- Start Họ và tên -->
            <div class="form-container-content-child-item" v-else-if="(ShowField == 'FullName')">
               
                <div class="form-container-content-child-item-input">
                   <div class="border-input-content" :class="{'input-error':(errors.get('FullName'))}">
                    <input type="text" class="input-content"  v-model="FullName" @click="checkNullFullName = true;" />
                    <div class="input-icon-content">
                      <span class="icon-font-16 background-icon-close" @click="FullName= null"></span>
                    </div>
                  </div>
                  <span class="span-error" v-if="(errors.get('FullName'))">{{errors.get('FullName')}}</span>
                </div>
              </div>
            <!-- End họ và tên -->

            <!-- Start Chức danh -->
              <div class="form-container-content-child-item" v-else-if="(ShowField == 'PositionId')">
              <div class="form-container-content-child-item-input">
                <div class="combobox" id="position">
                  <div
                    class="combobox-child combobox-content"
                    @click="HandlerClickCombobox"
                    check="false"
                  >
                    <div
                      class="combobox-content-select combobox-child combobox-content-select-content-none"
                      ref="positionId"
                    >
                      - Không chọn -
                    </div>
                    <div
                      class="
                        combobox-content-icon
                        button-icon-up-black
                        icon-font-16
                        combobox-child
                      "
                    ></div>
                  </div>

                  <div class="combobox-child combobox-data" ref="position">
                    <!-- loading -->
                    <div class="content-background-icon-loading">
                      <div class="background-icon-loading"></div>
                    </div>

                    <div class="combobox-data-search combobox-data-child-content-text">
                        <label class="label-input combobox-data-search-label combobox-data-child-content-text">
                          <input
                            type="text"
                            class="input input-icon combobox-data-child-content-text"
                            placeholder="Tìm kiếm"
                            v-on:keyup.enter="SearchpPosition"
                            v-model="searchpPosition"
                          />
                          <span class="background-icon-search-input combobox-data-child-content-text"
                          @click="SearchpPosition"></span>
                        </label>
                      </div>
                    <div class="combobox-data-child">
                      <div
                          class="combobox-data-child-content"
                        
                          @click="HandlerClickComboboxData"
                          value="null"
                        >
                          <div class="combobox-data-child-content-text">
                            - Không chọn -
                          </div>
                          <div
                            class="background-icon-checked icon-font-16"
                          
                          ></div>
                        </div>
                      <div
                        class="combobox-data-child-content"
                        v-for="v in Position"
                        :key="v.positionId"
                        @click="HandlerClickComboboxData"
                        :value="v.positionId"
                      >
                        <div class="combobox-data-child-content-text">
                          {{ TitleCase(v.positionName) }}
                        </div>
                        <div class="background-icon-checked icon-font-16"></div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
            <!-- End chức danh -->

            <!-- Start FaceBook -->
              <div class="form-container-content-child-item" v-else-if="(ShowField == 'Facebook')">
               
                <div class="form-container-content-child-item-input">
                   <div class="border-input-content" :class="{'input-error':(errors.get('Facebook'))}">
                    <input type="text" class="input-content"  v-model="Facebook"/>
                    <div class="input-icon-content">
                      <span class="icon-font-16 background-icon-close" @click="Facebook= null"></span>
                    </div>
                  </div>
                </div>
              </div>
            <!-- End FaceBook -->

            <!-- Start ĐT cơ quan -->
              <div class="form-container-content-child-item" v-else-if="(ShowField == 'CompanyPhoneNumber')">
               
                <div class="form-container-content-child-item-input">
                   <div class="border-input-content" :class="{'input-error':(errors.get('CompanyPhoneNumber'))}">
                    <input type="text" class="input-content"  v-model="CompanyPhoneNumber"/>
                    <div class="input-icon-content">
                      <span class="icon-font-16 background-icon-close" @click="CompanyPhoneNumber= null"></span>
                    </div>
                  </div>
                </div>
              </div>
            <!-- End ĐT cơ quan -->

            <!-- Start  Email Cơ quan -->
            <div class="form-container-content-child-item" v-else-if="(ShowField == 'CompanyEmail')">
               
                <div class="form-container-content-child-item-input">
                   <div class="border-input-content" :class="{'input-error':(errors.get('CompanyEmail'))}">
                    <input type="text" class="input-content"  v-model="CompanyEmail"/>
                    <div class="input-icon-content">
                      <span class="icon-font-16 background-icon-close" @click="CompanyEmail= null"></span>
                    </div>
                  </div>
                </div>
              </div>
            <!-- End Email cơ quan -->

            <!-- Start Doanh thu -->
            <div class="form-container-content-child-item" v-else-if="(ShowField == 'TurnoverId')">
              <div class="form-container-content-child-item-input">
                <div class="combobox" id="turnover">
                  <div
                    class="combobox-child combobox-content"
                    @click="HandlerClickCombobox"
                    check="false"
                  >
                    <div
                      class="combobox-content-select combobox-child combobox-content-select-content-none"
                      ref="turnoverId"
                    >
                      - Không chọn -
                    </div>
                    <div
                      class="
                        combobox-content-icon
                        button-icon-up-black
                        icon-font-16
                        combobox-child
                      "
                    ></div>
                  </div>

                  <div class="combobox-child combobox-data" ref="turnover">
                    <!-- loading -->
                    <div class="content-background-icon-loading">
                      <div class="background-icon-loading"></div>
                    </div>

                  <!-- tìm kiếm -->
                  <div class="combobox-data-search combobox-data-child-content-text">
                        <label class="label-input combobox-data-search-label combobox-data-child-content-text">
                          <input
                            type="text"
                            class="input input-icon combobox-data-child-content-text"
                            placeholder="Tìm kiếm"
                            v-on:keyup.enter="SearchTurnover"
                            v-model="searchTurnover"
                          />
                          <span class="background-icon-search-input combobox-data-child-content-text"
                          @click="SearchTurnover"></span>
                        </label>
                      </div>
                    <div class="combobox-data-child">
                      <div
                          class="combobox-data-child-content"
                        
                          @click="HandlerClickComboboxData"
                          value="null"
                        >
                          <div class="combobox-data-child-content-text">
                            - Không chọn -
                          </div>
                          <div
                            class="background-icon-checked icon-font-16"
                          
                          ></div>
                        </div>
                      <div
                        class="combobox-data-child-content"
                        v-for="v in Turnover"
                        :key="v.turnoverId"
                        @click="HandlerClickComboboxData"
                        :value="v.turnoverId"
                      >
                        <div class="combobox-data-child-content-text">
                          {{ TitleCase(v.turnoverName) }}
                        </div>
                        <div class="background-icon-checked icon-font-16"></div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
            <!-- End Doanh thu -->

            <!-- Start Giới tính -->
              <div class="form-container-content-child-item" v-else-if="(ShowField == 'Gender')">
              <div class="form-container-content-child-item-input">
                <div class="combobox" id="gender">
                  <div
                    class="combobox-child combobox-content"
                    @click="HandlerClickCombobox"
                    check="false"
                  >
                    <div
                      class="combobox-content-select combobox-child combobox-content-select-content-none"
                      ref="genderId"
                    >
                      - Không chọn -  
                    </div>
                    <div
                      class="
                        combobox-content-icon
                        button-icon-up-black
                        icon-font-16
                        combobox-child
                      "
                    ></div>
                  </div>
                  <div class="combobox-child combobox-data" ref="gender">
                    <div class="combobox-data-child">
                      <div
                        class="combobox-data-child-content"
                        @click="HandlerClickComboboxData"
                        value="null"
                      >
                        <div class="combobox-data-child-content-text">
                          - Không chọn -
                        </div>
                        <div class="background-icon-checked icon-font-16"></div>
                      </div>

                      <div
                        class="combobox-data-child-content"
                        v-for="v in gender"
                        :key="v.Code"
                        @click="HandlerClickComboboxData"
                        :value="v.Code"
                      >
                        <div class="combobox-data-child-content-text">
                          {{ TitleCase(v.Name) }}
                        </div>
                        <div
                          class="background-icon-checked icon-font-16"></div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
            <!-- End giới tính -->

              <!-- Start hiển thị chưa chọn -->
            <div class="form-container-content-child-item" v-else>
              <div class="form-container-content-child-item-input">
                <div class="border-input-content disabled-input">
                  <input type="text" disabled />
                </div>
                <div class="input-icon-content">
                  <!-- <span class="icon-font-16 background-icon-close" @click="customerInfo.FirstName = null"></span> -->
                </div>
              </div>
            </div>
            <!-- End hiển thị chưa chọn -->

          </div>
          <!-- End Value Combobox -->
        </div>

        <!-- Start active -->
        <div class="toolbar-update-mul-container-bottom">
          <button
            type="button"
            class="button-background-primary"
            :class="{ disabled: (checkUpdate == false || errors.size >0)?true:false }"
            @click="ClickUpdateMul"
          >
            Cập nhật
          </button>
          <button
          @click="ShowFormUpdateMul = false,ShowField = null, checkNullFullName=false"
            type="button"
            class="button-background-white"
          >
            Hủy bỏ
          </button>
        </div>
        <!-- End Active -->
      </div>
    </div>
    <!-- End xử lý update nhiều -->
  </div>
</template>

<script>

  // nhung tooltip
import ToolTip from "./ToolTip"

// check null
import { IsEmpty } from "../../js/FormatData";

// nhúng service xử lý Customer
import { CustomerService } from "../Services/CustomerService";

// in hoa dữ liệu
import { TitleCase } from "../../js/HandlerString";

// nhúng service xử lý loại doanh thu
import { TurnoverService } from "../Services/TurnoverService";

// nhúng service xử lý phòng ban
import { PositionsService } from "../Services/PositionsService";

// hàm xử lý hiển thị loading
import { UnLoading } from "../../js/Loading";

// nhúng status code
import { StatusCode } from "../Models/StatusCode";

// nhúng Toastmessage
import { ToastMessage } from "../Models/ToastMessage";


// nhúng service xử lý xưng hô
import { VocativeService } from "../Services/VocativeService";

// nhúng giới tính
import { GenderModel } from "../Models/GenderModel";

// mã lỗi
import { ErrorsValidation } from "../../js/Validation";

import {
  ClickShowHideComboboxData,
  SelectValueComboboxData,
} from "../../js/HandlerCombobox";

// ClickShowHideComboboxMulData,

export default {
  name: "ToolbarComponent",
  components: {
    ToolTip
   },
  props: {
    checkShowFormData: Boolean,
    listCustomerId: Array,
    ActiveMessage: Boolean,
    
  },
  data() {
    return {
      checkRemoveId: false,
      ActiveMessageCurrent: false,
      ToastMessageCustomer: ToastMessage,
      fielsUpdate: new Map(),
      Vocative: "",
      FullName: "",
      Position: "",
      Facebook: "",
      CompanyPhoneNumber: "",
      CompanyEmail: "",
      Turnover: "",
      Gender: "", 
      checkUpdate: false,
      ShowField: "",
      errors: new Map(),
      gender: GenderModel,
      customerGender:"",
      ShowFormUpdateMul: false,
      ColumnValue: null,
      ColumnName: null,
      DataUpdate: {
        columnName: null,
        columnValue: null,
        listId: []
      },
      searchVocative:"",
      searchpPosition:"",
      searchTurnover: "",
      checkNullFullName:false
    };
  },
  created() {
    this.fielsUpdate.set("VocativeId", "Xưng hô");
    this.fielsUpdate.set("FullName", "Họ và tên");
    this.fielsUpdate.set("PositionId", "Chức danh");
    this.fielsUpdate.set("Facebook", "Facebook");
    this.fielsUpdate.set("CompanyPhoneNumber", "ĐT cơ quan");
    this.fielsUpdate.set("CompanyEmail", "Email cơ quan");
    this.fielsUpdate.set("TurnoverId", "Doanh thu");
    this.fielsUpdate.set("Gender", "Giới tính");
  },
  watch: {
    /**
     * Author: Phạm Văn Đạt
     * function: theo dõi họ và tên
     */
    FullName(){
      if(this.FullName == "") this.FullName = null;

      if(this.FullName == null && this.checkNullFullName == true){
        // thêm mã lỗi vào: full name không được bỏ trống
        this.errors.set("FullName", ErrorsValidation.FullNameRequired)
        this.checkUpdate=false;  
      } else{
        if(this.errors.get("FullName")) this.errors.delete("FullName")
          this.checkUpdate = true;
      } 
    },
    Facebook(){
      if(this.Facebook == "") this.Facebook = null;
      if(this.Facebook == null){
        // thêm mã lỗi vào
        this.checkUpdate=false;  
      } else{
        this.checkUpdate = true;
      } 
    },
    CompanyPhoneNumber(){
      if(this.CompanyPhoneNumber == "") this.CompanyPhoneNumber = null;
      if(this.CompanyPhoneNumber == null){
        // thêm mã lỗi vào
        this.checkUpdate=false;  
      } else{
        this.checkUpdate = true;
      } 
    },
    CompanyEmail(){
      if(this.CompanyEmail == "") this.CompanyEmail = null;
      if(this.CompanyEmail == null || this.CompanyEmail == ""){
        // thêm mã lỗi vào
        this.checkUpdate=false;  
      } else{
        this.checkUpdate = true;
      } 
    },

    // theo dõi thông tin xưng hô
    Vocative() {
      console.log(this.$refs.vocative);
      UnLoading(this.$refs.vocative);
    },

    // theo dõi thông tin chức danh
    Position() {
      console.log(this.$refs.position);
      UnLoading(this.$refs.position);
    },
    
    // theo dõi thông tin doanh thu
    Turnover() {
      console.log(this.$refs.position);
      UnLoading(this.$refs.turnover);
    },
    ActiveMessage() {
      this.ActiveMessageCurrent = this.ActiveMessage;
    },
    ActiveMessageCurrent() {
      if (this.ActiveMessageCurrent == true) {
        // xóa dữ liệu
        let _CustomerService = new CustomerService();
        _CustomerService.Delete(this.listCustomerId).then((res) => {
          if (res.data.statusCode == StatusCode.DeleteSuccess) {
            console.log(res);
            this.ToastMessageCustomer.Type = "success";
            this.ToastMessageCustomer.Message = res.data.message;

            // load lại dữ liệu trong form
            this.$emit("checkLoadCustomerData", true);
          } else {
            this.ToastMessageCustomer.Type = "error";
            this.ToastMessageCustomer.Message = res.data.message;
          }
        });

        // gửi hiển thị thông báo
        this.$emit("toastMessageInfo", this.ToastMessageCustomer);
        this.$emit("showToastMessageInfo", true);

        this.$emit("ActiveMessage", !this.ActiveMessage);
      }
      console.log(this.listCustomerId);
    },
  },
  methods: {

     /**
     * Author: Phạm Văn Đạt
     * function: xóa các id đã chọn
     */
     ClickremoveListCustomerId(){
      this.$emit("removeListCustomerId",!this.checkRemoveId);
      this.checkRemoveId = !this.checkRemoveId;
      console.log("click remove")
    },

     /**
     * Author: Phạm Văn Đạt
     * function: kiểm tra giá trị null
     */
    IsEmpty,

    /**
     * Author: Phạm Văn Đạt
     * function: check load data
     */
    loadData(){
      // load lại dữ liệu trong form
      this.$emit("checkLoadCustomerData",true);
    },

    /**
     * Author: Phạm Văn Đạt
     * function: hiển thị thông báo chưa xử lý
     */
    ShowNotFound(){
      this.ToastMessageCustomer.Type = "info";
      this.ToastMessageCustomer.Message = "Chúng tôi sẽ sớm ra mắt";
      this.$emit("toastMessageInfo", this.ToastMessageCustomer);
      this.$emit("showToastMessageInfo", true);
    },

     /**
     * Author: Phạm Văn Đạt
     * function: xử lý tìm kiếm doanh thu
     */
    async SearchTurnover(){
      let _TurnoverService = new TurnoverService();
        await _TurnoverService.getByName(this.searchTurnover).then((res) => {
          console.log(res)
          if(res.statusCode == StatusCode.GetSuccess){
            this.Turnover = res.data;
          }
        });
    },

    /**
     * Author: Phạm Văn Đạt
     * function: xử lý tìm kiếm Chức danh
     */
    async SearchpPosition(){
      let _PositionService = new PositionsService();
        await _PositionService.getByName(this.searchpPosition).then((res) => {
          console.log(res)
          if(res.statusCode == StatusCode.GetSuccess){
            this.Position = res.data;
          }
        });
    },

    /**
     * Author: Phạm Văn Đạt
     * function: xử lý tìm kiếm xưng hô
     */
      async SearchVocative(){
      let _VocativeService = new VocativeService();
        await _VocativeService.getByName(this.searchVocative).then((res) => {
          if(res.statusCode == StatusCode.GetSuccess){
            this.Vocative = res.data;
          }
         
        });
    },

    /**
     * Author: Phạm Văn Đạt
     * function: xuất file excel
     */
    async ClickExportExcel(event){ 
      this.ShowOptions(event);
      // // test export excel
      this.$emit("loadFullScreen",true);

      let data = (this.listCustomerId.Length ==0)?[]:this.listCustomerId;
      console.log(data);
      let _CustomerService = new CustomerService();
      await  _CustomerService.ExportExcel(data);
      this.$emit("loadFullScreen",false);
    },

    /**
     * Author: Phạm Văn Đạt
     * function: Cập nhật danh sách
     */
    ClickUpdateMul(){
      if(this.checkUpdate == true || this.errors.size ==0  && this.ColumnName !=null){

        // hiển thị form xác nhận xóa, nếu đồng ý thì mới xóa

        if(this.FullName != null){
          this.ColumnValue =  this.FullName;
        } 
        if(this.Facebook != null){
          this.ColumnValue =  this.Facebook;
        }
        if(this.CompanyPhoneNumber != null){
          this.ColumnValue =  this.CompanyPhoneNumber;
        }
        if(this.CompanyEmail != null){
           this.ColumnValue =  this.CompanyEmail;
        }   

        if(this.$refs.vocativeId != undefined){
          let value =  this.$refs.vocativeId.getAttribute("value");
        
          if(value){
            if(value  == "null")
              value = null;
            this.ColumnValue =  value;
          }

        }
        if(this.$refs.positionId != undefined){
           let value =  this.$refs.positionId.getAttribute("value");
           if(value){
            if(value  == "null")
              value = null;
            this.ColumnValue =  value;
          }
        }
        if(this.$refs.turnoverId != undefined){
           let value =  this.$refs.turnoverId.getAttribute("value");
           if(value){
            if(value  == "null")
              value = null;
            this.ColumnValue =  value;
          }
        }

        if(this.$refs.genderId  != null){
          let value =  this.$refs.genderId.getAttribute("value");
          if(value){
            if(value  == "null")
              value = null;
            this.ColumnValue =  value;
          }
        }
        

        this.DataUpdate.columnName = this.ColumnName;
        this.DataUpdate.columnValue = this.ColumnValue;
        this.DataUpdate.listId = this.listCustomerId;
        // lấy được dữ liệu ->  update
         // xóa dữ liệu
        let _CustomerService = new CustomerService();
        _CustomerService.UpdateMul(this.DataUpdate).then((res) => {
          if (res.data.statusCode == StatusCode.UpdateSuccess) {
            console.log(res);
             // ẩn form
            this.ShowFormUpdateMul = false;
            
            this.ToastMessageCustomer.Type = "success";
            this.ToastMessageCustomer.Message = res.data.message;

            // load lại dữ liệu trong form
            this.$emit("checkLoadCustomerData", true);
           
          } else {
            this.ToastMessageCustomer.Type = "error";
            this.ToastMessageCustomer.Message = res.data.message;
          }

          
              this.$emit("toastMessageInfo", this.ToastMessageCustomer);
              this.$emit("showToastMessageInfo", true);
        });

        this.ShowField = null
        this.checkNullFullName = false;
      }
   
    },

    /**
     * Author: Phạm Văn Đạt
     * function:  lấy giới tính
     */
    SelectGenderName: function (value) {
      for (let i = 0; i < this.gender.length; i++) {
        if (value == this.gender[i].Code) return this.gender[i].Name;
      }
      return "- Không chọn -";
    },
    TitleCase,
    /**
     * Author: Phạm Văn Đạt
     * function:  xử lý lấy dữ liệu vocative
     * created time: 11:28 17/08/2022
     */
    async HandlerSelectVocative() {
      if (!this.Vocative) {
        let _VocativeService = new VocativeService();
        await _VocativeService.getAll().then((res) => {
          console.log(res);
          this.Vocative = res;
        });
        UnLoading(this.$refs.vocative)
      }else
        UnLoading(this.$refs.vocative)
    },

     /**
      * Author: Phạm Văn Đạt
     * function:  xử lý lấy dữ liệu position
     */
    async HandlerSelectPosition() {
      if (!this.Position) {
        let _PositionsService = new PositionsService();
        await _PositionsService.getAll().then((res) => {
          this.Position = res;
        });
        UnLoading(this.$refs.position)
      }else UnLoading(this.$refs.position)
    },

     /**
      * Author: Phạm Văn Đạt
     * function:  xử lý lấy dữ liệu doanh thu
     */
    async HandlerSelectTurnover() {
      if (!this.Turnover) {
        let _TurnoverService = new TurnoverService();
        await _TurnoverService.getAll().then((res) => {
          if (res) this.Turnover = res;
        });
        UnLoading(this.$refs.turnover)
      }else UnLoading(this.$refs.turnover)
    },

    /**
     * Author: Phạm Văn Đạt
     * function: click hiển thị form
     */
    ClickShowForm: function () {
      try {
        this.$emit("ShowFormData", !this.checkShowFormData);
      } catch (error) {
        console.log(error);
      }
    },

    /**
     * Author: Phạm Văn Đạt
     * function: Hiển thị form chọn xuất khẩu, xóa
     */
    ShowOptions: function (event) {
      try {
        let el = event.target;
        console.log(el);
        if (el) {
          let item = el.getElementsByClassName("toolbar-left-child-options")[0];
          while (!item) {
            el = el.parentNode;
            item = el.getElementsByClassName("toolbar-left-child-options")[0];
          }

          if (item.style.display == "" || item.style.display == "none") {
            item.style.display = "flex";
          } else {
            item.style.display = "none";
          }
        }
      } catch (error) {
        console.log(error);
      }
    },

     /**
     * Author: Phạm Văn Đạt
     * function: xử lý xóa
     */
    ClickDeleteMul(event) {
      try {
        this.ShowOptions(event)
        this.$emit("checkShowPopUp", true);
        this.$emit(
          "PopUpTitle",
          "Bạn có chắc chắn muốn xóa Tiềm năng này không?"
        );
      } catch (error) {
        console.log(error);
      }
    },

     /**
     * Author: Phạm Văn Đạt
     * function: xử lý click combobox
     */
    HandlerClickCombobox: function (event) {
      try {
        console.log(event)
        // Nếu click vào combobox xưng hô: nếu chưa có dữ liệu thì loading, nếu có dữ liệu rồi thì không loading
        if (
          event.target.parentNode.getAttribute("id") == "vocative" ||
          event.target.parentNode.parentNode.getAttribute("id") == "vocative"
        ) {
          /// lấy thông tin xưng hô nếu chưa có dữ liệu
          this.HandlerSelectVocative();
        }

        // Nếu click vào combobox chức danh: nếu chưa có dữ liệu thì loading, nếu có dữ liệu rồi thì không loading
        if (
          event.target.parentNode.getAttribute("id") == "position" ||
          event.target.parentNode.parentNode.getAttribute("id") == "position"
        ) {
          /// lấy thông tin phòng ban nếu chưa có dữ liệu
          this.HandlerSelectPosition();
        }

        // Nếu click vào combobox doanh thu: nếu chưa có dữ liệu thì loading, nếu có dữ liệu rồi thì không loading
        if (
          event.target.parentNode.getAttribute("id") == "turnover" ||
          event.target.parentNode.parentNode.getAttribute("id") == "turnover"
        ) {
          /// lấy thông tin doanh thu nếu chưa có dữ liệu
          this.HandlerSelectTurnover();
        }

        // hiển thị combobox data
        ClickShowHideComboboxData(event);
      } catch (error) {
        console.log(error);
      }
    },

    /***
     * Author: Phạm Văn Đạt
     * function:  xử lý kích combobox multiple
     */
    HandlerClickComboboxData: function (event) {
      try {
        
        // chưa cho phép cập nhật
        this.checkUpdate = false;
        this.errors.clear();

        // xoa hết dữ liệu hiện có
        this.FullName=null;
        this.Facebook = null;
        this.CompanyPhoneNumber = null;
        this.CompanyEmail = null;

        // kiểm tra xem click vào trường nào
        let El = event.target;
        if (El) {
          

          while(!El.getAttribute("value"))
            El = El.parentNode;

          let ElValue = (El.getAttribute("value"))?El.getAttribute("value"):undefined;
          
          if (El.getAttribute("value")){

            if(this.fielsUpdate.get(ElValue))
              this.ShowField = ElValue;
            else{
              this.checkUpdate = true;
              console.log("cho phep update")
            } 
          }

          if(this.fielsUpdate.get(ElValue)!= undefined)
            this.ColumnName = ElValue;
        }

        SelectValueComboboxData(event);
      } catch (error) {
        console.log(error);
      }
    },

  },
};
</script>

<style>
</style>

