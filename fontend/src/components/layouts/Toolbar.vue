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
        <button class="button-toolbar-left">Sửa</button>
      </div>
      <div class="toolbar-left-child">
        <button class="button-icon-refesh">
          <span class="button-icon-icon icon-refesh"></span>
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
        <button class="button-toolbar-left" @click="clickRemoveListCustomerId">
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
          class="button button-dots button-background-white"
          @click="showOptions"
        >
          <span class="button-icon-icon button-icon-icon-dots"></span>
        </button>
        <div class="toolbar-left-child-options">
          <button class="button-toolbar-left toolbar-left-child-button">
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

    <!-- Start Xử lý update nhiều -->
    <div class="toolbar-update-mul" v-if="ShowFormUpdateMul">
      <div class="toolbar-update-mul-container">
        <div class="toolbar-update-mul-container-title">
          <div class="toolbar-update-mul-container-title-text">
            Cập nhật thông tin
          </div>
          <div class="toolbar-update-mul-container-title-icon">
            <button class="icon-font-16 background-icon-close" @click="ShowFormUpdateMul =  false"></button>
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
                    @click="handlerClickCombobox"
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
                        class="combobox-data-child-content"
                        v-for="v in fielsUpdate"
                        :key="v[0]"
                        @click="handlerClickComboboxData"
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
                    @click="handlerClickCombobox"
                    check="false" ref="CloumnValue"
                  >
                    <div
                      class="combobox-content-select combobox-child"
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
                        class="combobox-data-child-content"
                        v-for="v in Vocative"
                        :key="v.vocativeId"
                        @click="handlerClickComboboxData"
                        :value="v.vocativeId"
                      >
                        <div class="combobox-data-child-content-text">
                          {{ titleCase(v.vocativeName) }}
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
                    <input type="text" class="input-content"  v-model="FullName"/>
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
                    @click="handlerClickCombobox"
                    check="false"
                  >
                    <div
                      class="combobox-content-select combobox-child"
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
                        class="combobox-data-child-content"
                        v-for="v in Position"
                        :key="v.positionId"
                        @click="handlerClickComboboxData"
                        :value="v.positionId"
                      >
                        <div class="combobox-data-child-content-text">
                          {{ titleCase(v.positionName) }}
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
                    @click="handlerClickCombobox"
                    check="false"
                  >
                    <div
                      class="combobox-content-select combobox-child"
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
                        class="combobox-data-child-content"
                        v-for="v in Turnover"
                        :key="v.turnoverId"
                        @click="handlerClickComboboxData"
                        :value="v.turnoverId"
                      >
                        <div class="combobox-data-child-content-text">
                          {{ titleCase(v.turnoverName) }}
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
                    @click="handlerClickCombobox"
                    check="false"
                  >
                    <div
                      class="combobox-content-select combobox-child"
                      ref="genderId"
                      value="0"
                    >
                      {{ selectGenderName(customerGender) }}
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
                    <div class="combobox-data-child"></div>
                    <div class="combobox-data-child">
                      <div
                        class="combobox-data-child-content"
                        v-for="v in gender"
                        :key="v.Code"
                        :class="{'selected':(customerGender == v.Code)}"
                        @click="handlerClickComboboxData"
                        :value="v.Code"
                      >
                        <div class="combobox-data-child-content-text">
                          {{ titleCase(v.Name) }}
                        </div>
                        <div
                          class="background-icon-checked icon-font-16"
                          :style="
                            v.Code == customerGender
                              ? 'display:inline-block'
                              : 'display:none'
                          "
                        ></div>
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
          @click="ShowFormUpdateMul = false"
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
// nhúng service xử lý Customer
import { CustomerService } from "../Services/CustomerService";

// in hoa dữ liệu
import { titleCase } from "../../js/handlerString";

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
import { ErrorsValidation } from "../../js/validation";

import {
  ClickShowHideComboboxData,
  selectValueComboboxData,
} from "../../js/test";

// ClickShowHideComboboxMulData,

export default {
  name: "ToolbarComponent",
  props: {
    checkShowFormData: Boolean,
    listCustomerId: Array,
    ActiveMessage: Boolean,
  },
  data() {
    return {
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
      }
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

    FullName(){
      if(this.FullName == "") this.FullName = null;

      if(this.FullName == null){
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

    // theo dõi list xóa, update
    listCustomerId: {
      handler: function (val) {
        console.log(val);
      },
      deep: true,
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

    // Cập nhật danh sách
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
          if(value)
            this.ColumnValue =  value;
        }
        if(this.$refs.positionId != undefined){
           let value =  this.$refs.positionId.getAttribute("value");
          if(value)
            this.ColumnValue =  value;
        }
        if(this.$refs.turnoverId != undefined){
           let value =  this.$refs.turnoverId.getAttribute("value");
          if(value)
            this.ColumnValue =  value;
        }

        if(this.$refs.genderId  != null){
          let value =  this.$refs.genderId.getAttribute("value");
          if(value)
            this.ColumnValue =  value;
        }
        

        this.DataUpdate.columnName = this.ColumnName;
        this.DataUpdate.columnValue = this.ColumnValue;
        this.DataUpdate.listId = this.listCustomerId;
        console.log(this.DataUpdate)  
        console.log("Updateting")
        console.log(this.listCustomerId);

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
      }
   
    },

      // lấy giới tính
    selectGenderName: function (value) {
      for (let i = 0; i < this.gender.length; i++) {
        if (value == this.gender[i].Code) return this.gender[i].Name;
      }
      return "- Không chọn -";
    },
    titleCase,
    /**
     * Author: Phạm Văn Đạt
     * function:  xử lý lấy dữ liệu vocative
     * created time: 11:28 17/08/2022
     */
    HandlerSelectVocative() {
      if (!this.Vocative) {
        let _VocativeService = new VocativeService();
        _VocativeService.getAll().then((res) => {
          console.log(res);
          this.Vocative = res;
        });
      }
    },

     /**
     * function:  xử lý lấy dữ liệu position
     */
    HandlerSelectPosition() {
      if (!this.Position) {
        let _PositionsService = new PositionsService();
        _PositionsService.getAll().then((res) => {
          this.Position = res;
        });
      }
    },

     /**
     * function:  xử lý lấy dữ liệu doanh thu
     */
    HandlerSelectTurnover() {
      if (!this.Turnover) {
        let _TurnoverService = new TurnoverService();
        _TurnoverService.getAll().then((res) => {
          if (res) this.Turnover = res;
        });
      }
    },
    // click hiển thị form
    ClickShowForm: function () {
      try {
        this.$emit("ShowFormData", !this.checkShowFormData);
      } catch (error) {
        console.log(error);
      }
    },
    // Hiển thị form chọn xuất khẩu, xóa
    showOptions: function (event) {
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

    // xử lý bỏ chọn
    clickRemoveListCustomerId: function () {},

    // xuwr lys xoas
    ClickDeleteMul() {
      try {
        this.$emit("checkShowPopUp", true);
        this.$emit(
          "PopUpTitle",
          "Bạn có chắc chắn muốn xóa Tiềm năng này không?"
        );
      } catch (error) {
        console.log(error);
      }
    },
    // xử lý click combobox
    handlerClickCombobox: function (event) {
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
     * function:  xử lý kích combobox multiple
     */
    handlerClickComboboxData: function (event) {
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

          let ElValue = El.getAttribute("value");
          
          if (ElValue){
            console.log(El)

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

        selectValueComboboxData(event);
      } catch (error) {
        console.log(error);
      }
    },
  },
};
</script>

<style>
</style>

