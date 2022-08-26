<template>
  <div class="form-container">
    <form @submit.prevent="OnSubmit">
      <div class="form-content">
        <div class="form-container-title">
          <div class="form-container-title-left">
            <div class="filter-title-text" style="font-size: 20px">
              Thêm tiềm năng
            </div>
          </div>
          <div class="form-container-title-right">
            <button class="button">Lưu</button>
            <button class="button">Lưu và thêm</button>
            <button class="button" type="button" @click="HandlerCloseForm">
              Hủy bỏ
            </button>
          </div>
        </div>

        <div class="form-container-content">
          <!-- ảnh tiềm năng -->
          <div class="form-container-content-child">
            <div class="form-container-content-child-title font-latin-bold">
              Ảnh tiềm năng
            </div>
            <div
              class="
                form-container-content-child-item
                form-container-content-child-avatar
              "
            >
              <label class="label-file" for="file">
                <span class="background-icon-avatar-push"></span>
              </label>
              <input type="file" class="input-file" id="file" />
            </div>
          </div>

          <!-- thông tin chung -->
          <div class="form-container-content-child">
            <div class="form-container-content-child-title font-latin-bold">
              Thông tin chung
            </div>

            <div class="form-container-content-child-body">
              <!-- Start Xưng hô -->
              <div class="form-container-content-child-item">
                <div class="form-container-content-child-item-label">
                  Xưng hô
                </div>
                <div class="form-container-content-child-item-input">
                  <div class="combobox" id="vocative">
                    <div
                      class="combobox-child combobox-content"
                      @click="handlerClickCombobox"
                      check="false"
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
                          @click="handlerClickComboboxData"
                          :class="{
                            selected:
                              customerInfo.VocativeId == undefined
                                ? true
                                : false,
                          }"
                        >
                          <div class="combobox-data-child-content-text">
                            - Không chọn -
                          </div>
                          <div
                            class="background-icon-checked icon-font-16"
                            :style="
                              customerInfo.VocativeId == undefined
                                ? 'display:inline-block'
                                : 'display:none'
                            "
                          ></div>
                        </div>
                        <div
                          class="combobox-data-child-content"
                          v-for="v in vocative"
                          :key="v.vocativeId"
                          @click="handlerClickComboboxData"
                          :value="v.vocativeId"
                        >
                          <div class="combobox-data-child-content-text">
                            {{ titleCase(v.vocativeName) }}
                          </div>
                          <div
                            class="background-icon-checked icon-font-16"
                          ></div>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
              <!-- End Xưng hô -->

              <!-- Start họ và đệm -->
              <div class="form-container-content-child-item">
                <div class="form-container-content-child-item-label">
                  Họ và đệm
                </div>
                <div class="form-container-content-child-item-input">
                  <div class="border-input-content">
                    <input type="text" class="input-content" v-model="customerInfo.LastName"/>
                    <div class="input-icon-content">
                      <span class="icon-font-16 background-icon-close" @click="customerInfo.LastName = null"></span>
                    </div>
                  </div>
                </div>
              </div>
              <!-- End Họ và đệm -->

              <!-- Start Tên -->
              <div class="form-container-content-child-item">
                <div class="form-container-content-child-item-label">
                  Tên <span class="not-required" style="color: red">*</span>
                </div>
                <div class="form-container-content-child-item-input">
                   <div class="border-input-content" :class="{'input-error':(errors.get('FirstName'))}">
                    <input type="text" class="input-content"  v-model="customerInfo.FirstName"/>
                    <div class="input-icon-content">
                      <span class="icon-font-16 background-icon-close" @click="customerInfo.FirstName = null"></span>
                    </div>
                  </div>
                  <span class="span-error" v-if="(errors.get('FirstName'))">{{errors.get('FirstName')}}</span>
                </div>
              </div>
              <!-- End Tên -->

              <!-- Start Họ và tên  -->
              <div class="form-container-content-child-item">
                <div class="form-container-content-child-item-label">
                  Họ và tên
                </div>
                <div class="form-container-content-child-item-input">
                   <div class="border-input-content disabled-input">
                    <input
                    type="text"
                    class="input-content disabled-input" v-model="customerInfo.FullName"
                    disabled
                  />
                </div>
                    <div class="input-icon-content">
                      <!-- <span class="icon-font-16 background-icon-close" @click="customerInfo.FirstName = null"></span> -->
                    </div>
                  </div>
                 
              </div>
              <!-- End họ và tên -->

              <!-- Start Phòng ban -->
              <div class="form-container-content-child-item">
                <div class="form-container-content-child-item-label">
                  Phòng ban
                </div>
                <div class="form-container-content-child-item-input">
                  <div class="combobox" id="department">
                    <div
                      class="combobox-child combobox-content"
                      @click="handlerClickCombobox"
                      check="false"
                    >
                      <div
                        class="combobox-content-select combobox-child"
                        ref="departmentId"
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

                    <div class="combobox-child combobox-data" ref="department">
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
                          @click="handlerClickComboboxData"
                          :class="{
                            selected:
                              customerInfo.DepartmentId == undefined
                                ? true
                                : false,
                          }"
                        >
                          <div class="combobox-data-child-content-text">
                            - Không chọn -
                          </div>
                          <div
                            class="background-icon-checked icon-font-16"
                            :style="
                              customerInfo.DepartmentId == undefined
                                ? 'display:inline-block'
                                : 'display:none'
                            "
                          ></div>
                        </div>
                        <div
                          class="combobox-data-child-content"
                          v-for="v in department"
                          :key="v.departmentId"
                          @click="handlerClickComboboxData"
                          :value="v.departmentId"
                        >
                          <div class="combobox-data-child-content-text">
                            {{ titleCase(v.departmentName) }}
                          </div>
                          <div
                            class="background-icon-checked icon-font-16"
                          ></div>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
              <!-- End phòng ban -->

              <!--Start Chức danh -->
              <div class="form-container-content-child-item">
                <div class="form-container-content-child-item-label">
                  Chức danh
                </div>
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
                          @click="handlerClickComboboxData"
                          :class="{
                            selected:
                              customerInfo.PositionId == undefined
                                ? true
                                : false,
                          }"
                        >
                          <div class="combobox-data-child-content-text">
                            - Không chọn -
                          </div>
                          <div
                            class="background-icon-checked icon-font-16"
                            :style="
                              customerInfo.PositionId == undefined
                                ? 'display:inline-block'
                                : 'display:none'
                            "
                          ></div>
                        </div>
                        <div
                          class="combobox-data-child-content"
                          v-for="v in position"
                          :key="v.positionId"
                          @click="handlerClickComboboxData"
                          :value="v.positionId"
                        >
                          <div class="combobox-data-child-content-text">
                            {{ titleCase(v.positionName) }}
                          </div>
                          <div
                            class="background-icon-checked icon-font-16"
                          ></div>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
              <!-- END chức danh -->

              <!-- Start Đt di động -->
              <div class="form-container-content-child-item">
                <div class="form-container-content-child-item-label">
                  ĐT di động
                </div>
                <div class="form-container-content-child-item-input">
                   <div class="border-input-content" :class="{'input-error':(errors.get('CustomerPhoneNumber'))}">
                    <input type="text" class="input-content" v-model="customerInfo.CustomerPhoneNumber"/>

                    <div class="input-icon-content">
                      <span class="icon-font-16 background-icon-close" @click="customerInfo.CustomerPhoneNumber = null"></span>
                    </div>
                  </div>
                   <span class="span-error" v-if="(errors.get('CustomerPhoneNumber'))">{{errors.get('CustomerPhoneNumber')}}</span>
                </div>
              </div>
              <!-- End ĐT di động -->

              <!-- Start Đt cơ quan -->
              <div class="form-container-content-child-item">
                <div class="form-container-content-child-item-label">
                  ĐT cơ quan
                </div>
                <div class="form-container-content-child-item-input">
                   <div class="border-input-content">
                  <input type="text" class="input-content" v-model="customerInfo.CompanyPhoneNumber"/>
                    
                    <div class="input-icon-content">
                      <span class="icon-font-16 background-icon-close" @click="customerInfo.CompanyPhoneNumber = null"></span>
                    </div>
                  </div>
                </div>
              </div>
              <!-- End ĐT cơ quan-->

              <!-- Start Nguồn gốc -->
              <div class="form-container-content-child-item">
                <div class="form-container-content-child-item-label">
                  Nguồn gốc
                </div>
                <div class="form-container-content-child-item-input">
                  <div class="combobox" id="source">
                    <div
                      class="combobox-child combobox-content"
                      @click="handlerClickCombobox"
                      check="false"
                    >
                      <div
                        class="combobox-content-select combobox-child"
                        ref="sourceId"
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

                    <div class="combobox-child combobox-data" ref="source">
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
                          @click="handlerClickComboboxData"
                          :class="{
                            selected:
                              customerInfo.SourceId == undefined ? true : false,
                          }"
                        >
                          <div class="combobox-data-child-content-text">
                            - Không chọn -
                          </div>
                          <div
                            class="background-icon-checked icon-font-16"
                            :style="
                              customerInfo.SourceId == undefined
                                ? 'display:inline-block'
                                : 'display:none'
                            "
                          ></div>
                        </div>
                        <div
                          class="combobox-data-child-content"
                          v-for="v in source"
                          :key="v.sourceId"
                          @click="handlerClickComboboxData"
                          :value="v.sourceId"
                        >
                          <div class="combobox-data-child-content-text">
                            {{ titleCase(v.sourceName) }}
                          </div>
                          <div
                            class="background-icon-checked icon-font-16"
                          ></div>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
              <!-- End Nguồn gốc -->

              <!-- Start Loại tiềm năng -->
              <div class="form-container-content-child-item">
                <div class="form-container-content-child-item-label">
                  Loại tiềm năng
                </div>
                <div class="form-container-content-child-item-input">
                  <div class="combobox combobox-mul" id="potentialType">
                    <div
                      class="combobox-child combobox-content"
                      @click="handlerClickComboboxMul"
                      check="false"
                    >
                      <div class="combobox-content-select combobox-mul-child">
                        <div
                          class="combobox-content-select-content"
                          v-if="potentialTypeMap.size == 0"
                        >
                          <div class="">- Không chọn -</div>
                          <!-- <div class="combobox-content-select-content-icon background-icon-close icon-font-16"></div> -->
                        </div>

                        <div
                          class="combobox-content-select-content"
                          v-else
                          v-for="v in potentialTypeMap"
                          :key="v[0]"
                        >
                          <div
                            class="combobox-content-select-content-text"
                            :value="v[0]"
                          >
                            {{ titleCase(v[1]) }}
                          </div>
                          <div
                            class="
                              combobox-content-select-content-icon
                              background-icon-close
                              icon-font-16
                            "
                            @click="handlerClickComboboxDataClose"
                          ></div>
                        </div>
                      </div>
                    </div>

                    <div
                      class="combobox-child combobox-data"
                      ref="potentialType"
                    >
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
                          :class="{ selected: potentialTypeMap.size == 0 }"
                          class="combobox-data-child-content"
                          @click="
                            potentialTypeMap.size == 0
                              ? handlerClickComboboxMulData
                              : ''
                          "
                          value=""
                          :style="
                            potentialTypeMap.size != 0
                              ? 'cursor: no-drop !important;background-color: #F8F8F8 !important;'
                              : ''
                          "
                        >
                          <div class="combobox-data-child-content-text">
                            - Không chọn -
                          </div>
                          <div
                            class="background-icon-checked icon-font-16"
                            :style="
                              potentialTypeMap.size == 0
                                ? 'display:inline-block;'
                                : 'display:none'
                            "
                          ></div>
                        </div>
                        <div
                          class="combobox-data-child-content"
                          v-for="v in potentialType"
                          :key="v.potentialTypeId"
                          :value="v.potentialTypeId"
                          @click="handlerClickComboboxMulData"
                        >
                          <div class="combobox-data-child-content-text">
                            {{ titleCase(v.potentialTypeName) }}
                          </div>
                          <div
                            class="background-icon-checked icon-font-16"
                          ></div>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
              <!-- End Loại tiềm năng -->

              <!-- Start Zalo -->
              <div class="form-container-content-child-item">
                <div class="form-container-content-child-item-label">Zalo</div>
                <div class="form-container-content-child-item-input">
                   <div class="border-input-content">
                  <input type="text" class="input-content" v-model="customerInfo.Zalo"/>

                    <div class="input-icon-content">
                      <span class="icon-font-16 background-icon-close" @click="customerInfo.Zalo = null"></span>
                    </div>
                  </div>
                </div>
              </div>
              <!-- End Zalo -->

              <!-- Start Email cá nhân -->
              <div class="form-container-content-child-item">
                <div class="form-container-content-child-item-label">
                  Email cá nhân
                </div>
                <div class="form-container-content-child-item-input">
                   <div class="border-input-content" :class="{'input-error':(errors.get('CustomerEmail'))}">
                  <input type="text" class="input-content" v-model="customerInfo.CustomerEmail"/>

                    <div class="input-icon-content">
                      <span class="icon-font-16 background-icon-close" @click="customerInfo.CustomerEmail = null"></span>
                    </div>
                  </div>
                  <span class="span-error" v-if="(errors.get('CustomerEmail'))">{{errors.get('CustomerEmail')}}</span>
                </div>
              </div>
              <!-- EndEmail cá nhân -->

              <!-- Start cơ quan-->
              <div class="form-container-content-child-item">
                <div class="form-container-content-child-item-label">
                  Email cơ quan
                </div>
                <div class="form-container-content-child-item-input">
                   <div class="border-input-content">
                  <input type="text" class="input-content" v-model="customerInfo.CompanyEmail"/>

                    <div class="input-icon-content">
                      <span class="icon-font-16 background-icon-close" @click="customerInfo.CompanyEmail = null"></span>
                    </div>
                  </div>
                </div>
              </div>
              <!-- EndEmail cơ quan-->

              <!-- Start tổ chức -->
              <div class="form-container-content-child-item">
                <div class="form-container-content-child-item-label">
                  Tổ chức
                </div>
                <div class="form-container-content-child-item-input">
                  <div class="border-input-content">
                  <input type="text" class="input-content" v-model="customerInfo.Organization"/>

                    <div class="input-icon-content">
                      <span class="icon-font-16 background-icon-close" @click="customerInfo.Organization = null"></span>
                    </div>
                  </div>
                </div>
              </div>
              <!-- End Tổ chức-->

              <!-- Start Mã số thuế-->
               <div class="form-container-content-child-item">
                <div class="form-container-content-child-item-label">
                  Mã số thuế
                </div>
                <div class="form-container-content-child-item-input">
                   <div class="border-input-content" :class="{'input-error':(errors.get('TaxCode'))}">
                    <input type="text" class="input-content"  v-model="customerInfo.TaxCode"/>
                    <div class="input-icon-content">
                      <span class="icon-font-16 background-icon-close" @click="customerInfo.TaxCode = null"></span>
                    </div>
                  </div>
                  <span class="span-error" v-if="(errors.get('TaxCode'))">{{errors.get('TaxCode')}}</span>
                </div>
              </div>
              <!-- End Mã số thuế -->
            </div>
          </div>

          <!-- thông tin tổ chức -->
          <div class="form-container-content-child">
            <div class="form-container-content-child-title font-latin-bold">
              Thông tin tổ chức
            </div>

            <!-- Start Tài khoản ngân hàng-->
            <div class="form-container-content-child-body">
              <div class="form-container-content-child-item">
                <div class="form-container-content-child-item-label">
                  Tài khoản ngân hàng
                </div>
                <div class="form-container-content-child-item-input">
                   <div class="border-input-content" :class="{'input-error':(errors.get('BankAccount'))}">
                    <input type="text" class="input-content"  v-model="customerInfo.BankAccount"/>
                    <div class="input-icon-content">
                      <span class="icon-font-16 background-icon-close" @click="customerInfo.BankAccount = null"></span>
                    </div>
                  </div>
                  <span class="span-error" v-if="(errors.get('BankAccount'))">{{errors.get('BankAccount')}}</span>
                </div>
              </div>
              <!-- End Tài khoản ngân hàng -->

              <!-- Start Mở tại ngân hàng -->
              <div class="form-container-content-child-item">
                <div class="form-container-content-child-item-label">
                  Mở tại ngân hàng
                </div>
                <div class="form-container-content-child-item-input">
                    <div class="border-input-content">
                  <input type="text" class="input-content" v-model="customerInfo.BankName" />

                    <div class="input-icon-content">
                      <span class="icon-font-16 background-icon-close" @click="customerInfo.BankName = null"></span>
                    </div>
                  </div>
                </div>
              </div>
              <!-- End Mở tại ngân hàng-->

              <!-- Start Ngày thành lập -->
              <div class="form-container-content-child-item">
                <div class="form-container-content-child-item-label">
                  Ngày thành lập
                </div>
                <div class="form-container-content-child-item-input">
                  
                  <input type="date" class="border-input-content" v-model="customerInfo.CreatedTimeBankAccount"/>
                </div>
              </div>
              <!-- End Ngày thành lập -->

              <!-- Start Loại hình  -->
              <div class="form-container-content-child-item">
                <div class="form-container-content-child-item-label">
                  Loại hình
                </div>
                <div class="form-container-content-child-item-input">
                  <div class="combobox" id="organizationType">
                    <div
                      class="combobox-child combobox-content"
                      @click="handlerClickCombobox"
                      check="false"
                    >
                      <div
                        class="combobox-content-select combobox-child"
                        ref="organizationTypeId"
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

                    <div
                      class="combobox-child combobox-data"
                      ref="organizationType"
                    >
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
                          @click="handlerClickComboboxData"
                          :class="{
                            selected:
                              customerInfo.OrganizationTypeId == undefined
                                ? true
                                : false,
                          }"
                        >
                          <div class="combobox-data-child-content-text">
                            - Không chọn -
                          </div>
                          <div
                            class="background-icon-checked icon-font-16"
                            :style="
                              customerInfo.OrganizationTypeId == undefined
                                ? 'display:inline-block'
                                : 'display:none'
                            "
                          ></div>
                        </div>
                        <div
                          class="combobox-data-child-content"
                          v-for="v in organizationType"
                          :key="v.organizationTypeId"
                          @click="handlerClickComboboxData"
                          :value="v.organizationTypeId"
                        >
                          <div class="combobox-data-child-content-text">
                            {{ titleCase(v.organizationTypeName) }}
                          </div>
                          <div
                            class="background-icon-checked icon-font-16"
                          ></div>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
              <!-- End Loại hình -->

              <!-- Start Lĩnh vực -->
              <div class="form-container-content-child-item">
                <div class="form-container-content-child-item-label">
                  Lĩnh vực
                </div>
                <div class="form-container-content-child-item-input">
                  <div class="combobox combobox-mul" id="field">
                    <div
                      class="combobox-child combobox-content"
                      @click="handlerClickComboboxMul"
                      check="false"
                    >
                      <div class="combobox-content-select combobox-mul-child">
                        <div
                          class="combobox-content-select-content"
                          v-if="fieldMap.size == 0"
                        >
                          <div class="">- Không chọn -</div>
                          <!-- <div class="combobox-content-select-content-icon background-icon-close icon-font-16"></div> -->
                        </div>

                        <div
                          class="combobox-content-select-content"
                          v-else
                          v-for="v in fieldMap"
                          :key="v[0]"
                        >
                          <div
                            class="combobox-content-select-content-text"
                            :value="v[0]"
                          >
                            {{ titleCase(v[1]) }}
                          </div>
                          <div
                            class="
                              combobox-content-select-content-icon
                              background-icon-close
                              icon-font-16
                            "
                            @click="handlerClickComboboxDataClose"
                          ></div>
                        </div>
                      </div>
                    </div>

                    <div class="combobox-child combobox-data" ref="field">
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
                          :class="{ selected: fieldMap.size == 0 }"
                          class="combobox-data-child-content"
                          @click="
                            fieldMap.size == 0
                              ? handlerClickComboboxMulData
                              : ''
                          "
                          value=""
                          :style="
                            fieldMap.size != 0
                              ? 'cursor: no-drop !important;background-color: #F8F8F8 !important;'
                              : ''
                          "
                        >
                          <div class="combobox-data-child-content-text">
                            - Không chọn -
                          </div>
                          <div
                            class="background-icon-checked icon-font-16"
                            :style="
                              fieldMap.size == 0
                                ? 'display:inline-block;'
                                : 'display:none'
                            "
                          ></div>
                        </div>
                        <div
                          class="combobox-data-child-content"
                          v-for="v in field"
                          :key="v.fieldId"
                          :value="v.fieldId"
                          @click="handlerClickComboboxMulData"
                        >
                          <div class="combobox-data-child-content-text">
                            {{ titleCase(v.fieldName) }}
                          </div>
                          <div
                            class="background-icon-checked icon-font-16"
                          ></div>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
              <!-- End Lĩnh vực -->

              <!--Start Ngành nghề -->
              <div class="form-container-content-child-item">
                <div class="form-container-content-child-item-label">
                  Ngành nghề
                </div>
                <div class="form-container-content-child-item-input">
                  <div class="combobox combobox-mul" id="career">
                    <div
                      class="combobox-child combobox-content"
                      @click="handlerClickComboboxMul"
                      check="false"
                    >
                      <div class="combobox-content-select combobox-mul-child">
                        <div
                          class="combobox-content-select-content"
                          v-if="careerMap.size == 0"
                        >
                          <div class="">- Không chọn -</div>
                          <!-- <div class="combobox-content-select-content-icon background-icon-close icon-font-16"></div> -->
                        </div>

                        <div
                          class="combobox-content-select-content"
                          v-else
                          v-for="v in careerMap"
                          :key="v[0]"
                        >
                          <div
                            class="combobox-content-select-content-text"
                            :value="v[0]"
                          >
                            {{ titleCase(v[1]) }}
                          </div>
                          <div
                            class="
                              combobox-content-select-content-icon
                              background-icon-close
                              icon-font-16
                            "
                            @click="handlerClickComboboxDataClose"
                          ></div>
                        </div>
                      </div>
                    </div>

                    <div class="combobox-child combobox-data" ref="career">
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
                          :class="{ 'selected': careerMap.size == 0 }"
                          class="combobox-data-child-content"
                          @click="
                            careerMap.size == 0
                              ? handlerClickComboboxMulData
                              : ''
                          "
                          value=""
                          :style="
                            careerMap.size != 0
                              ? 'cursor: no-drop !important;background-color: #F8F8F8 !important;'
                              : ''
                          "
                        >
                          <div class="combobox-data-child-content-text">
                            - Không chọn -
                          </div>
                          <div
                            class="background-icon-checked icon-font-16"
                            :style="
                              careerMap.size == 0
                                ? 'display:inline-block;'
                                : 'display:none'
                            "
                          ></div>
                        </div>
                        <div
                          class="combobox-data-child-content"
                          v-for="v in career"
                          :key="v.careerId"
                          :value="v.careerId"
                          @click="handlerClickComboboxMulData"
                        >
                          <div class="combobox-data-child-content-text">
                            {{ titleCase(v.careerName) }}
                          </div>
                          <div
                            class="background-icon-checked icon-font-16"
                          ></div>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
              <!-- END Ngành nghề -->

              <!-- Start Doanh thu-->
              <div class="form-container-content-child-item">
                <div class="form-container-content-child-item-label">
                  Doanh thu
                </div>
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
                          @click="handlerClickComboboxData"
                          :class="{
                            selected:
                              customerInfo.TurnoverId == undefined
                                ? true
                                : false,
                          }"
                        >
                          <div class="combobox-data-child-content-text">
                            - Không chọn -
                          </div>
                          <div
                            class="background-icon-checked icon-font-16"
                            :style="
                              customerInfo.TurnoverId == undefined
                                ? 'display:inline-block'
                                : 'display:none'
                            "
                          ></div>
                        </div>
                        <div
                          class="combobox-data-child-content"
                          v-for="v in turnover"
                          :key="v.turnover"
                          @click="handlerClickComboboxData"
                          :value="v.turnoverId"
                        >
                          <div class="combobox-data-child-content-text">
                            {{ titleCase(v.turnoverName) }}
                          </div>
                          <div
                            class="background-icon-checked icon-font-16"
                          ></div>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
              <!-- End Doanh thu -->
            </div>
          </div>

          <!-- end thông tin tổ chức -->

          <!-- start Thông tin địa chỉ -->
          <div class="form-container-content-child">
            <div class="form-container-content-child-title font-latin-bold">
              Thông tin địa chỉ
            </div>

            <div class="form-container-content-child-body">
              <!-- Start Quốc Gia -->
              <div class="form-container-content-child-item">
                <div class="form-container-content-child-item-label">
                  Quốc gia
                </div>
                <div class="form-container-content-child-item-input">
                  <div class="combobox">
                    <div
                      class="combobox-child combobox-content"
                      @click="handlerClickCombobox"
                      check="false"
                    >
                      <div class="combobox-content-select combobox-child">
                        - Không chọn -
                      </div>
                      <div
                        class="
                          combobox-content-icon
                          button-icon-up-black
                          combobox-child
                          icon-font-16
                        "
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
                          class="combobox-data-child-content"
                          @click="handlerClickComboboxData"
                          value="- Không chọn -"
                        >
                          - Không chọn -
                        </div>
                        <div
                          class="combobox-data-child-content"
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
              </div>
              <!-- End Quốc Gia -->

              <!--Start Tỉnh/Thành phố-->
              <div class="form-container-content-child-item">
                <div class="form-container-content-child-item-label">
                  Tỉnh/Thành phố
                </div>
                <div class="form-container-content-child-item-input">
                  <div class="combobox">
                    <div
                      class="combobox-child combobox-content"
                      @click="handlerClickCombobox"
                      check="false"
                    >
                      <div class="combobox-content-select combobox-child">
                        - Không chọn -
                      </div>
                      <div
                        class="
                          combobox-content-icon
                          button-icon-up-black
                          combobox-child
                          icon-font-16
                        "
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
                          class="combobox-data-child-content"
                          @click="handlerClickComboboxData"
                          value="- Không chọn -"
                        >
                          - Không chọn -
                        </div>
                        <div
                          class="combobox-data-child-content"
                          @click="handlerClickComboboxData"
                          value="Giám đốc"
                        >
                          Giám đốc
                        </div>
                        <div
                          class="combobox-data-child-content"
                          @click="handlerClickComboboxData"
                          value="Trưởng nhóm"
                        >
                          Trưởng nhóm
                        </div>
                        <div
                          class="combobox-data-child-content"
                          @click="handlerClickComboboxData"
                          value="Nhân viên"
                        >
                          Nhân viên
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
              <!-- END Tỉnh/Thành phố -->

              <!-- Start Quận/Huyện -->
              <div class="form-container-content-child-item">
                <div class="form-container-content-child-item-label">
                  Quận/Huyện
                </div>
                <div class="form-container-content-child-item-input">
                  <div class="combobox">
                    <div
                      class="combobox-child combobox-content"
                      @click="handlerClickCombobox"
                      check="false"
                    >
                      <div class="combobox-content-select combobox-child">
                        - Không chọn -
                      </div>
                      <div
                        class="
                          combobox-content-icon
                          button-icon-up-black
                          combobox-child
                          icon-font-16
                        "
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
                          class="combobox-data-child-content"
                          @click="handlerClickComboboxData"
                          value="- Không chọn -"
                        >
                          - Không chọn -
                        </div>
                        <div
                          class="combobox-data-child-content"
                          @click="handlerClickComboboxData"
                          value="Giám đốc"
                        >
                          Giám đốc
                        </div>
                        <div
                          class="combobox-data-child-content"
                          @click="handlerClickComboboxData"
                          value="Trưởng nhóm"
                        >
                          Trưởng nhóm
                        </div>
                        <div
                          class="combobox-data-child-content"
                          @click="handlerClickComboboxData"
                          value="Nhân viên"
                        >
                          Nhân viên
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
              <!-- End Quận/Huyện -->

              <!-- Start Phường/Xã -->
              <div class="form-container-content-child-item">
                <div class="form-container-content-child-item-label">
                  Phường/Xã
                </div>
                <div class="form-container-content-child-item-input">
                  <div class="combobox">
                    <div
                      class="combobox-child combobox-content"
                      @click="handlerClickCombobox"
                      check="false"
                    >
                      <div class="combobox-content-select combobox-child">
                        - Không chọn -
                      </div>
                      <div
                        class="
                          combobox-content-icon
                          button-icon-up-black
                          combobox-child
                          icon-font-16
                        "
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
                          class="combobox-data-child-content"
                          @click="handlerClickComboboxData"
                          value="- Không chọn -"
                        >
                          - Không chọn -
                        </div>
                        <div
                          class="combobox-data-child-content"
                          @click="handlerClickComboboxData"
                          value="Giám đốc"
                        >
                          Giám đốc
                        </div>
                        <div
                          class="combobox-data-child-content"
                          @click="handlerClickComboboxData"
                          value="Trưởng nhóm"
                        >
                          Trưởng nhóm
                        </div>
                        <div
                          class="combobox-data-child-content"
                          @click="handlerClickComboboxData"
                          value="Nhân viên"
                        >
                          Nhân viên
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
              <!-- End Phường/Xã -->

              <!-- Start Số nhà, Đường phố -->
              <div class="form-container-content-child-item">
                <div class="form-container-content-child-item-label">
                  Số nhà, Đường phố
                </div>
                <div class="form-container-content-child-item-input">
                  <div class="border-input-content">
                  <input type="text" class="input-content" v-model="customerInfo.HomeNumber" />

                    <div class="input-icon-content">
                      <span class="icon-font-16 background-icon-close" @click="customerInfo.HomeNumber = null"></span>
                    </div>
                  </div>
                </div>
              </div>
              <!-- End Số nhà, Đường phố-->

              <!-- Start Mã vùng -->
              <div class="form-container-content-child-item">
                <div class="form-container-content-child-item-label">
                  Mã vùng
                </div>
                <div class="form-container-content-child-item-input">

                   <div class="border-input-content">
                  <input type="text" class="input-content" v-model="customerInfo.RegionCode" />

                    <div class="input-icon-content">
                      <span class="icon-font-16 background-icon-close" @click="customerInfo.RegionCode = null"></span>
                    </div>
                  </div>
                </div>
              </div>
              <!-- Mã vùng -->

              <!-- Start Địa chỉ -->
              <div class="form-container-content-child-item">
                <div class="form-container-content-child-item-label">
                  Địa chỉ
                </div>
                <div class="form-container-content-child-item-input">
                  <textarea class="textarea"></textarea>
                </div>
              </div>
              <!-- End địa chỉ -->
            </div>
          </div>
          <!-- end thông tin địa chỉ -->

          <!-- Start thông tin mô tả -->
          <div class="form-container-content-child">
            <div class="form-container-content-child-title font-latin-bold">
              Thông tin mô tả
            </div>

            <div class="form-container-content-child-body">
              <!-- Start thông tin mô tả -->
              <div
                class="
                  form-container-content-child-item form-container-description
                "
              >
                <div class="form-container-content-child-item-label">Mô tả</div>
                <div class="form-container-content-child-item-input">
                  <textarea class="textarea textarea-description"></textarea>
                </div>
              </div>
              <!-- End địa chỉ -->
            </div>
          </div>
          <!-- End thông tin mô tả -->

          <!-- Start thông tin hệ thống -->
          <div class="form-container-content-child">
            <div class="form-container-content-child-title font-latin-bold">
              Thông tin hệ thống
            </div>

            <div class="form-container-content-child-body">

              <!-- Start Mã tiềm năng -->
               <div class="form-container-content-child-item">
                <div class="form-container-content-child-item-label">
                  Mã tiềm năng
                </div>
                <div class="form-container-content-child-item-input">
                   <div class="border-input-content" :class="{'input-error':(errors.get('PotentialCode'))}">
                    <input type="text" class="input-content"  v-model="customerInfo.PotentialCode"/>
                    <div class="input-icon-content">
                      <span class="icon-font-16 background-icon-close" @click="customerInfo.FirstName = null"></span>
                    </div>
                  </div>
                  <span class="span-error" v-if="(errors.get('PotentialCode'))">{{errors.get('PotentialCode')}}</span>
                </div>
              </div>
              
              <!-- End Mã tiềm năng -->
            </div>
          </div>
          <!-- End thông tin hệ thống -->
        </div>
      </div>
    </form>
  </div>
</template>

<script>
// các hàm xử lý click combobox
import {
  ClickShowHideComboboxData,
  selectValueComboboxData,
  ClickShowHideComboboxMulData,
} from "../../js/test";


// nhúng status code
import { StatusCode } from "../Models/StatusCode";

// nhúng T code
import { ToastMessage } from "../Models/ToastMessage";

// hàm xử lý combobox chọn nhiều
import { handlerClickCloseIconComboboxMul,hanlderClickComboboxMulData } from "../../js/comboboxDataMultiple";

// nhúng service xử lý Customer
import { CustomerService } from "../Services/CustomerService";

// hàm xử lý hiển thị loading
import { UnLoading } from "../../js/Loading";
// import { ErrorsValidation } from "../../js/validation";

import { titleCase } from "../../js/handlerString";

// nhúng service xử lý xưng hô
import { VocativeService } from "../Services/VocativeService";

// nhúng service xử lý phòng ban
import { DepartmentService } from "../Services/DepartmentService";

// nhúng service xử lý phòng ban
import { PositionsService } from "../Services/PositionsService";

// nhúng service xử lý Nguồn gốc
import { SourceService } from "../Services/SourceService";

// nhúng service xử lý loại tiềm năng
import { PotentialTypeService } from "../Services/PotentialTypeService";

// nhúng service xử lý loại doanh thu
import { TurnoverService } from "../Services/TurnoverService";

// nhúng service xử lý loại ngành nghề
import { CareerService } from "../Services/CareerService";

// nhúng service xử lý loại lĩnh vực
import { FieldService } from "../Services/FieldService";


// nhúng service xử lý loại tiềm năng
import { CustomerPotentialTypeService } from "../Services/CustomerPotentialTypeService";


// // nhúng service xử lý ngành nghề
import { CustomerCareerService } from "../Services/CustomerCareerService";



// // nhúng service xử lý loại lĩnh vực khách hàng
import { CustomerFieldService } from "../Services/CustomerFieldService";

// nhúng service xử lý loại loại hình
import { OrganizationTypeSrervice } from "../Services/OrganizationTypeSrervice";

// các hàm xử lý click combobox
import { IsEmpty } from "../../js/formatData";

// các hàm xử lý click combobox
import { handlerValidateCustomer,handlerValidateTCustomer } from "../../js/handlerValidateCustomer";

// nhúng model view customer xử lý thêm customer
import { CreateCustomerModel } from "../Models/CustomerModel/CreateCustomerModel";


// nhúng model view customer xử lý thêm customer
import { CustomerPotentialTypeModel } from "../Models/CustomerPotentialTypeModel/CustomerPotentialTypeModel";

export default {
  name: "FormDataComponent",
  components: {},
  created() {
    console.log("khởi tạo form thêm");
    this.HandlerSelectCodeMax();
  },
  props: {
    checkShowFormData: Boolean,
  },
  data() {
    return {
      vocative: "",
      department: "",
      position: "",
      source: "",
      potentialType: "",
      turnover: "",
      career: "",
      field: "",
      organizationType: "",
      customerInfo: CreateCustomerModel,
      potentialTypeMap: new Map(),
      fieldMap: new Map(),
      careerMap: new Map(),
      errors: new Map(),
      customerPotentialType: CustomerPotentialTypeModel,
      ToastMessageCustomer: ToastMessage
    };
  },
  watch: {
    // theo dõi tên
     "customerInfo.FirstName":{
      handler(){
        if(this.errors.get("FirstName"))
          this.errors.delete("FirstName")
        
        let Firstname =  (this.customerInfo.FirstName!=null)?this.customerInfo.FirstName:"";
        let LastName =  (this.customerInfo.LastName!=null)?this.customerInfo.LastName+" ":"";

        this.customerInfo.FullName = LastName+Firstname;
        console.log(this.customerInfo.FullName)

      }

     },
     // theo dõi họ đệm
      "customerInfo.LastName":{
      handler(){
        if(this.errors.get("FirstName"))
          this.errors.delete("FirstName")

        let Firstname =  (this.customerInfo.FirstName!=null)?this.customerInfo.FirstName:"";
        let LastName =  (this.customerInfo.LastName!=null)?this.customerInfo.LastName+" ":"";

        this.customerInfo.FullName = LastName+Firstname;

      }

     },
     // theo dõi ĐT cá nhân
      "customerInfo.CustomerPhoneNumber":{
      handler(){
        if(this.errors.get("CustomerPhoneNumber"))
          this.errors.delete("CustomerPhoneNumber")

          if(this.customerInfo.CustomerPhoneNumber == "")
          this.customerInfo.CustomerPhoneNumber  =  null; 
      }

     },
     // theo dõi email cá nhân
      "customerInfo.CustomerEmail":{
      handler(){
        if(this.errors.get("CustomerEmail"))
          this.errors.delete("CustomerEmail")

        if(this.customerInfo.CustomerEmail == "")
          this.customerInfo.CustomerEmail  =  null;
      }

     },
     // theo dõi mã số thuế
      "customerInfo.TaxCode":{
      handler(){
        if(this.errors.get("TaxCode"))
          this.errors.delete("TaxCode")

          if(this.customerInfo.TaxCode == "")
          this.customerInfo.TaxCode  =  null; 

      }

     },
     // theo dõi tài khoản ngân hàng
      "customerInfo.BankAccount":{
        handler(){
          if(this.errors.get("BankAccount"))
            this.errors.delete("BankAccount")

          if(this.customerInfo.BankAccount == "")
            this.customerInfo.BankAccount  =  null;
        }

     },
     // theo dõi mã tiềm năng
      "customerInfo.PotentialCode":{
      handler(){
        if(this.errors.get("PotentialCode"))
          this.errors.delete("PotentialCode")

        if(this.customerInfo.PotentialCode == "")
          this.customerInfo.PotentialCode  =  null;
      }

     },
   
    // theo dõi thông tin xưng hô
    vocative() {
      console.log(this.$refs.vocative);
      UnLoading(this.$refs.vocative);
    },

    // theo dõi thông tin phòng ban
    department() {
      console.log(this.$refs.department);
      UnLoading(this.$refs.department);
    },

    // theo dõi thông tin chức danh
    position() {
      console.log(this.$refs.position);
      UnLoading(this.$refs.position);
    },

    //  theo dõi thông tin nguồn gốc
    source() {
      console.log(this.$refs.source);
      UnLoading(this.$refs.source);
    },

    //  theo dõi thông tin loại chức danh
    potentialType() {
      UnLoading(this.$refs.potentialType);
    },

    // theo dõi thông tin doanh thu
    turnover() {
      UnLoading(this.$refs.turnover);
    },

    //  theo dõi thông tin ngành nghề
    career() {
      UnLoading(this.$refs.career);
    },

    // theo dõi thông tin lĩnh vực
    field() {
      UnLoading(this.$refs.field);
    },

    // theo dõi loại hình
    organizationType() {
      console.log(this.$refs.organizationType);
      UnLoading(this.$refs.organizationType);
    },
  },
  methods: {
    // lấy mã mới nhất
    HandlerSelectCodeMax(){
      let _CustomerService= new CustomerService();
      _CustomerService.GetCodeMax().then((res)=>{
        if(res) this.customerInfo.PotentialCode = res;
      })
             
    },

    /**
     * Author: Phạm Văn Đạt
     * function:  check null dữ liệu
     * created time: 16:43 19/08/2022
     */
    IsEmpty,

    /**
     * Author: Phạm Văn Đạt
     * function:  in hoa chữ cái đầu mỗi từ
     * created time: 16:43 19/08/2022
     */
    titleCase,

    /**
     * Author: Phạm Văn Đạt
     * function:  xử lý xóa loại tiềm năng
     * created time: 16:43 19/08/2022
     */
    handlerClickComboboxDataClose: function (event) {
      let nodeId = event.target.parentNode;
          while (nodeId.getAttribute("id") == null) {
            nodeId = nodeId.parentNode;
          }
        let valueId = nodeId.getAttribute("id");

        if(valueId == "potentialType")
          this.potentialTypeMap = handlerClickCloseIconComboboxMul(event,this.potentialTypeMap);
        
        if(valueId == "field")
          this.fieldMap  =  handlerClickCloseIconComboboxMul(event,this.fieldMap);

        if(valueId == "career")
          this.careerMap  =  handlerClickCloseIconComboboxMul(event,this.careerMap);
      
    },

    /**
     * Author: Phạm Văn Đạt
     * function:  xử lý đóng form data
     * created time: 11:28 17/08/2022
     */
    HandlerCloseForm() {
      try {
        this.$emit("CloseFormData", false);
      } catch (error) {
        console.log(error);
      }
    },

    /**
     * Author: Phạm Văn Đạt
     * function:  xử lý lấy dữ liệu vocative
     * created time: 11:28 17/08/2022
     */
    HandlerSelectVocative() {
      if (!this.vocative) {
        let _VocativeService = new VocativeService();
        _VocativeService.getAll().then((res) => {
          this.vocative = res;
        });
      }
    },

    /**
     * Author: Phạm Văn Đạt
     * function:  xử lý lấy dữ liệu vocative
     * created time: 15:28 17/08/2022
     */
    HandlerSelectDepartment() {
      if (!this.department) {
        let _DepartmentService = new DepartmentService();
        _DepartmentService.getAll().then((res) => {
          this.department = res;
        });
      }
    },

    /**
     * Author: Phạm Văn Đạt
     * function:  xử lý lấy dữ liệu vocative
     * created time: 15:28 17/08/2022
     */
    HandlerSelectPosition() {
      if (!this.position) {
        let _PositionsService = new PositionsService();
        _PositionsService.getAll().then((res) => {
          this.position = res;
        });
      }
    },

    /**
     * Author: Phạm Văn Đạt
     * function:  xử lý lấy dữ liệu source: nguồn gốc
     * created time: 15:28 17/08/2022
     */
    HandlerSelectSource() {
      if (!this.source) {
        let _SourceService = new SourceService();
        _SourceService.getAll().then((res) => {
          if (res) this.source = res;
        });
      }
    },

    /**
     * Author: Phạm Văn Đạt
     * function:  xử lý lấy dữ liệu potential
     * created time: 15:28 17/08/2022
     */
    HandlerSelectPotentialType() {
      if (!this.potentialType) {
        let _PotentialTypeService = new PotentialTypeService();
        _PotentialTypeService.getAll().then((res) => {
          if (res) this.potentialType = res;
        });
      }
    },

    /**
     * Author: Phạm Văn Đạt
     * function:  xử lý lấy dữ liệu doanh thu
     * created time: 15:28 17/08/2022
     */
    HandlerSelectTurnover() {
      if (!this.turnover) {
        let _TurnoverService = new TurnoverService();
        _TurnoverService.getAll().then((res) => {
          if (res) this.turnover = res;
        });
      }
    },

    /**
     * Author: Phạm Văn Đạt
     * function:  xử lý lấy dữ liệu ngành nghề
     * created time: 00:41 28 18/08/2022
     */
    async HandlerSelectCareer() {
      if (!this.career) {
        let _CareerService = new CareerService();
        await _CareerService.GetAll().then((res) => {
          if (res) this.career = res;
          console.log(res)
        });
      }
    },

    /**
     * Author: Phạm Văn Đạt
     * function:  xử lý lấy dữ liệu ngành nghề
     * created time: 00:41 28 18/08/2022
     */
    async HandlerSelectField() {
      if (!this.field) {
        let _FieldService = new FieldService();
        await _FieldService.GetAll().then((res) => {
          if (res) this.field = res;
        });
      }
    },

    /**
     * Author: Phạm Văn Đạt
     * function:  xử lý lấy dữ liệu loại hình
     * created time: 10:40 28 18/08/2022
     */
    async HandlerSelectOrganizationType() {
      if (!this.organizationType) {
        let _OrganizationTypeSrervice = new OrganizationTypeSrervice();
        await _OrganizationTypeSrervice.GetAll().then((res) => {
          if (res) console.log("lĩnh vực: " + this.field);
          this.organizationType = res;
        });
      }
    },

    /**
     * Author: Phạm Văn Đạt
     * function:  xử lý đóng form data
     * created time: 11:28 17/08/2022
     */
    handlerClickCombobox: function (event) {
      try {
        // Nếu click vào combobox xưng hô: nếu chưa có dữ liệu thì loading, nếu có dữ liệu rồi thì không loading
        if (
          event.target.parentNode.getAttribute("id") == "vocative" ||
          event.target.parentNode.parentNode.getAttribute("id") == "vocative"
        ) {
          /// lấy thông tin xưng hô nếu chưa có dữ liệu
          this.HandlerSelectVocative();
        }

        // Nếu click vào combobox phòng ban: nếu chưa có dữ liệu thì loading, nếu có dữ liệu rồi thì không loading
        if (
          event.target.parentNode.getAttribute("id") == "department" ||
          event.target.parentNode.parentNode.getAttribute("id") == "department"
        ) {
          /// lấy thông tin phòng ban nếu chưa có dữ liệu
          this.HandlerSelectDepartment();
        }

        // Nếu click vào combobox chức danh: nếu chưa có dữ liệu thì loading, nếu có dữ liệu rồi thì không loading
        if (
          event.target.parentNode.getAttribute("id") == "position" ||
          event.target.parentNode.parentNode.getAttribute("id") == "position"
        ) {
          /// lấy thông tin phòng ban nếu chưa có dữ liệu
          this.HandlerSelectPosition();
        }

        // Nếu click vào combobox nguồn gốc: nếu chưa có dữ liệu thì loading, nếu có dữ liệu rồi thì không loading
        if (
          event.target.parentNode.getAttribute("id") == "source" ||
          event.target.parentNode.parentNode.getAttribute("id") == "source"
        ) {
          /// lấy thông tin nguồn gốc nếu chưa có dữ liệu
          this.HandlerSelectSource();
        }

        // Nếu click vào combobox doanh thu: nếu chưa có dữ liệu thì loading, nếu có dữ liệu rồi thì không loading
        if (
          event.target.parentNode.getAttribute("id") == "turnover" ||
          event.target.parentNode.parentNode.getAttribute("id") == "turnover"
        ) {
          /// lấy thông tin doanh thu nếu chưa có dữ liệu
          this.HandlerSelectTurnover();
        }

        // Nếu click vào combobox loại hình: nếu chưa có dữ liệu thì loading, nếu có dữ liệu rồi thì không loading
        if (
          event.target.parentNode.getAttribute("id") == "organizationType" ||
          event.target.parentNode.parentNode.getAttribute("id") ==
            "organizationType"
        ) {
          /// lấy thông tin loại hình nếu chưa có dữ liệu
          this.HandlerSelectOrganizationType();
        }

        // hiển thị combobox data
        ClickShowHideComboboxData(event);
      } catch (error) {
        console.log(error);
      }
    },

    /***
     *  Author: Phạm Văn Đạt
     * function:  xử lý kích combobox multiple
     * created time: 11:28 17/08/2022
     */
    handlerClickComboboxData: function (event) {
      try {
        selectValueComboboxData(event);
      } catch (error) {
        console.log(error);
      }
    },
    handlerClickComboboxMul(event) {
      try {
        if (
          !event.target.classList.contains(
            "combobox-content-select-content-icon"
          )
        ) {
          let nodeId = event.target.parentNode;
          console.log(nodeId);
          while (nodeId.getAttribute("id") == null) {
            nodeId = nodeId.parentNode;
          }

          const valueId = nodeId.getAttribute("id");

          if (valueId) {
            // Nếu click vào combobox  multiple loại tiềm năng: nếu chưa có dữ liệu thì loading, nếu có dữ liệu rồi thì không loading
            if (valueId == "potentialType") {
              /// lấy thông tin loại tiềm năng  nếu chưa có dữ liệu
              this.HandlerSelectPotentialType();
            }

            // Nếu click vào combobox ngành nghề ngành nghề: nếu chưa có dữ liệu thì loading, nếu có dữ liệu rồi thì không loading
            if (valueId == "career") {

              /// lấy thông tin ngành nghề nếu chưa có dữ liệu
              this.HandlerSelectCareer();
            }

            // Nếu click vào combobox ngành nghề doanh thu: nếu chưa có dữ liệu thì loading, nếu có dữ liệu rồi thì không loading
            if (valueId == "field") {
              /// lấy thông tin ngành nghề nếu chưa có dữ liệu
              this.HandlerSelectField();
            }

            // xử lý hiển thị form data
            ClickShowHideComboboxMulData(event);
          }
        }
      } catch (error) {
        console.log(error);
      }
    },

    // Xử lý click chọn dữ liệu trong combobox data
    handlerClickComboboxMulData(event) {
      try {
         let nodeId = event.target.parentNode;
          console.log(nodeId);
          while (nodeId.getAttribute("id") == null) {
            nodeId = nodeId.parentNode;
          }
        let valueId = nodeId.getAttribute("id");

        if(valueId == "potentialType")
          this.potentialTypeMap  =  hanlderClickComboboxMulData(event,this.potentialTypeMap);
        
        if(valueId == "field")
          this.fieldMap  =  hanlderClickComboboxMulData(event,this.fieldMap);

        if(valueId == "career")
          this.careerMap  =  hanlderClickComboboxMulData(event,this.careerMap);

      } catch (error) {
        console.log(error);
      }
    },
    async OnSubmit() {
      try{
      const [customerInfo,errors]= await handlerValidateCustomer(this.$refs,this.customerInfo,this.errors);
      this.customerInfo = customerInfo;
      this.errors = errors;

      // nếu khong có xưng hô thì xóa đi
      if(this.customerInfo.VocativeId == ""){
          delete  this.customerInfo.VocativeId;
      }

      // nếu khong có Phòng ban thì xóa đi
      if(this.customerInfo.DepartmentId == ""){
          delete  this.customerInfo.DepartmentId;
      }

       // nếu khong có chức danh thì xóa đi
      if(this.customerInfo.PositionId == ""){
          delete  this.customerInfo.PositionId;
      }

       // nếu khong có Nguồn gốc thì xóa đi
      if(this.customerInfo.SourceId == ""){
          delete  this.customerInfo.SourceId;
      }

       // nếu khong có loaij hinhf thì xóa đi
      if(this.customerInfo.OrganizationTypeId == ""){
          delete  this.customerInfo.OrganizationTypeId;
      }

      
       // nếu khong có doanh thu thì xóa đi
      if(this.customerInfo.TurnoverId == ""){
          delete  this.customerInfo.TurnoverId;
      }

      console.log(this.customerInfo)
      if(this.errors.size ==0){
          let _CustomerService= new CustomerService();
        _CustomerService.Create(this.customerInfo).then((res)=>{
          console.log(res)
          if(res.data.statusCode == StatusCode.CreateSuccess){
            console.log(res.data.message)
            // lấy ra Customer id
              const customerId = res.data.data.customerId
              // hiển thị thông báo Tạo mới thành công
              console.log(customerId)
              console.log(handlerValidateTCustomer(this.potentialTypeMap,"customer"))
              if(customerId){
                

                console.log("potentialTypeMap: "+this.potentialTypeMap)
                // tạo mới dữ liệu bảng loại tiềm năng
                if(this.potentialTypeMap.size != 0){

                  // lấy thông tin data lưu thành mảng
                  let potentialTypeMapArr = handlerValidateTCustomer(this.potentialTypeMap,customerId);


                  // thao tác thêm mới loại tiềm năng
                  let _CustomerPotentialTypeService= new CustomerPotentialTypeService();
                  _CustomerPotentialTypeService.Create(potentialTypeMapArr).then(res=>{
                    if(res.data.statusCode == StatusCode.CreateSuccess){
                      console.log(res)
                    }
                  })

                  // lấy thông tin ngành nghề lưu thành mảng
                  let careerMapArr = handlerValidateTCustomer(this.careerMap,customerId);
                  
                  // thao tác thêm mới ngành nghề
                  let _CustomerCareerService = new CustomerCareerService();
                  _CustomerCareerService.Create(careerMapArr).then(res=>{
                    if(res.data.statusCode == StatusCode.CreateSuccess){
                      console.log(res)
                    }
                  })

                  // lấy thông tin ngành nghề lưu thành mảng
                  let fieldMapArr = handlerValidateTCustomer(this.fieldMap,customerId);

                  
                  // thao tác thêm mới Lĩnh vực
                  let _CustomerFieldService= new CustomerFieldService();
                  _CustomerFieldService.Create(fieldMapArr).then(res=>{
                    if(res.data.statusCode == StatusCode.CreateSuccess){
                      console.log(res)
                    }
                  })
 
                }

                // nếu check = false thì không được thêm, xóa customer đi

                // nếu chck = true thì được thêm và xử lý hiển thị notifi
               
              }
                  console.log(this.ToastMessageCustomer)      

                 // chuyển trang về trang chính bằng cách ẩn form hiển tại
                  this.$emit("CloseFormData", false);
                  this.ToastMessageCustomer.Type = "success";
                  this.ToastMessageCustomer.Message = res.data.message;
                       
                       
              // load lại dữ liệu trong form
              this.$emit("checkLoadCustomerData",true);
          }else{
            // hiển thị thông báo thêm thất bại
            console.log("thêm thất bại")
            this.ToastMessageCustomer.Type = "error";
            this.ToastMessageCustomer.Message = res.data.message;
          }
          // gửi thống báo cho toast message
          console.log(this.ToastMessageCustomer)
          this.$emit("toastMessageInfo", this.ToastMessageCustomer);
          this.$emit("showToastMessageInfo", true);
        })
       }

     }catch(error){
        console.log(error)
      }
    
      
    },
  },
  mounted() {
    // alert('huy');
  },
};
</script>
<style>
</style>