<template>
  <div class="form-container">
    <form @submit.prevent>
      <div class="form-content">
        <div class="form-container-title">
          <div class="form-container-title-left">
            <div class="filter-title-text" style="font-size: 20px">
              Thêm tiềm năng
            </div>
          </div>
          <div class="form-container-title-right">
            <button type="button" class="button button-background-primary save" @click="OnSubmit">Lưu</button>
            <button type="button" class="button button-background-white created" @click="OnSubmit">Lưu và thêm</button>
            <button type="button" class="button button-background-white" @click="HandlerCloseForm">
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

                        <!-- Tìm kiếm -->
                        <div class="combobox-data-search combobox-data-child-content-text">
                        <label class="label-input combobox-data-search-label combobox-data-child-content-text">
                          <input
                            type="text"
                            class="input input-icon arduino combobox-data-child-content-text"
                            placeholder="Tìm kiếm"
                            v-on:keyup.enter="SearchDepartment"
                            v-model="searchDepartment"
                          />
                          <span class="background-icon-search-input combobox-data-child-content-text"
                          @click="SearchDepartment"></span>
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

                      <!-- Tìm kiếm -->
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
                  <ToolTip :type="'top'" :text="'Điện thoại di động'"></ToolTip>
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
                  <ToolTip :type="'top'" :text="'Điện thoại cơ quan'"></ToolTip>
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

                      <div class="combobox-data-search combobox-data-child-content-text">
                        <label class="label-input combobox-data-search-label combobox-data-child-content-text">
                          <input
                            type="text"
                            class="input input-icon combobox-data-child-content-text"
                            placeholder="Tìm kiếm"
                            v-on:keyup.enter="SearchSource"
                            v-model="searchSource"
                          />
                          <span class="background-icon-search-input combobox-data-child-content-text"
                          @click="SearchSource"></span>
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
                          class="combobox-content-select-content combobox-content-select-content-none"
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
                  <el-config-provider :locale="locale"> 
                  <el-date-picker v-model="customerInfo.CreatedTimeBankAccount" type="date" format="DD/MM/YYYY"></el-date-picker>
                </el-config-provider>
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

                      <!-- tìm kiếm -->
                      <div class="combobox-data-search combobox-data-child-content-text">
                        <label class="label-input combobox-data-search-label combobox-data-child-content-text">
                          <input
                            type="text"
                            class="input input-icon combobox-data-child-content-text"
                            placeholder="Tìm kiếm"
                            v-on:keyup.enter="SearchOrganizationType"
                            v-model="searchOrganizationType"
                          />
                          <span class="background-icon-search-input combobox-data-child-content-text"
                          @click="SearchOrganizationType"></span>
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
                          class="combobox-content-select-content combobox-content-select-content-none"
                          v-if="fieldMap.size == 0"
                        >
                          <div>- Không chọn -</div>
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
                          class="combobox-content-select-content combobox-content-select-content-none"
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

                  <div class="combobox" id="country">
                    <div
                      class="combobox-child combobox-content"
                      @click="handlerClickCombobox"
                      check="false"
                    >
                      <div
                        class="combobox-content-select combobox-child"
                        ref="countryId"
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

                    <div class="combobox-child combobox-data" ref="country">
                     
                      <div class="combobox-data-child">
                        <div
                          class="combobox-data-child-content country"
                          @click="handlerClickComboboxData"
                         
                        >
                          <div class="combobox-data-child-content-text"
                          :class="{
                            selected:
                            customerInfo.Country == null
                                ? true
                                : false,
                          }">
                            - Không chọn -
                          </div>
                          <div
                            class="background-icon-checked icon-font-16"
                            :style="
                              customerInfo.Country == null
                                ? 'display:inline-block'
                                : 'display:none'
                            "
                          ></div>
                        </div>
                        <div
                          class="combobox-data-child-content country"
                          @click="handlerClickComboboxData"
                          value="Việt Nam"
                        >
                          <div class="combobox-data-child-content-text">
                            Việt Nam
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
              <!-- End Quốc Gia -->

              <!--Start Tỉnh/Thành phố-->
              <div class="form-container-content-child-item">
                <div class="form-container-content-child-item-label">
                  Tỉnh/Thành phố
                </div>
                <div class="form-container-content-child-item-input">
                  <div class="combobox" id="province">
                    <div
                      class="combobox-child combobox-content"
                      @click="handlerClickCombobox"
                      check="false"
                    >
                      <div
                        class="combobox-content-select combobox-child"
                        ref="provinceId"
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

                    <div class="combobox-child combobox-data" ref="province">

                      <div class="combobox-data-child">
                        <div
                          class="combobox-data-child-content province"
                          @click="handlerClickComboboxData"
                          :class="{
                            selected:
                              customerInfo.Province == null
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
                              customerInfo.province == null
                                ? 'display:inline-block'
                                : 'display:none'
                            "
                          ></div>
                        </div>
                        <div
                          class="combobox-data-child-content province"
                          v-for="v in province"
                          :key="v.code"
                          @click="handlerClickComboboxData"
                          :value="v.code"
                        >
                          <div class="combobox-data-child-content-text">
                            {{ titleCase(v.name) }}
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
              <!-- END Tỉnh/Thành phố -->

              <!-- Start Quận/Huyện -->
              <div class="form-container-content-child-item">
                <div class="form-container-content-child-item-label">
                  Quận/Huyện
                </div>
                <div class="form-container-content-child-item-input">
                  <div class="combobox" id="districts" ref="districts">
                    <div
                      class="combobox-child combobox-content"
                      @click="handlerClickCombobox"
                      check="false"
                    >
                      <div
                        class="combobox-content-select combobox-child"
                        ref="districtId"
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

                    <div class="combobox-child combobox-data" ref="district">

                      <div class="combobox-data-child">
                        <div
                          class="combobox-data-child-content district"
                          @click="handlerClickComboboxData"
                          :class="{
                            selected:
                              customerInfo.District == null
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
                              customerInfo.District == null
                                ? 'display:inline-block'
                                : 'display:none'
                            "
                          ></div>
                        </div>
                        <div
                          class="combobox-data-child-content district"
                          v-for="v in districts"
                          :key="v.code"
                          @click="handlerClickComboboxData"
                          :value="v.code"
                        >
                          <div class="combobox-data-child-content-text">
                            {{ titleCase(v.name) }}
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
              <!-- End Quận/Huyện -->

              <!-- Start Phường/Xã -->
              <div class="form-container-content-child-item">
                <div class="form-container-content-child-item-label">
                  Phường/Xã
                </div>
                <div class="form-container-content-child-item-input">
                  <div class="combobox" id="wards" ref="wards">
                    <div
                      class="combobox-child combobox-content"
                      @click="handlerClickCombobox"
                      check="false"
                    >
                      <div
                        class="combobox-content-select combobox-child"
                        ref="wardId"
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

                    <div class="combobox-child combobox-data" ref="ward">

                      <div class="combobox-data-child">
                        <div
                          class="combobox-data-child-content"
                          @click="handlerClickComboboxData"
                          :class="{
                            selected:
                              customerInfo.Wards == null
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
                              customerInfo.Wards == null
                                ? 'display:inline-block'
                                : 'display:none'
                            "
                          ></div>
                        </div>
                        <div
                          class="combobox-data-child-content wards"
                          v-for="v in wards"
                          :key="v.code"
                          @click="handlerClickComboboxData"
                          :value="v.code"
                        >
                          <div class="combobox-data-child-content-text">
                            {{ titleCase(v.name) }}
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
                  <textarea class="textarea" v-model="customerInfo.Address"></textarea>
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
                      <span class="icon-font-16 background-icon-close" @click="customerInfo.PotentialCode = null"></span>
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
  import { ElConfigProvider ,ElDatePicker }  from '../../../node_modules/element-plus';
  import '../../../node_modules/element-plus/dist/index.css'
  import vi from '../../../node_modules/element-plus/es/locale/lang/vi'

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


// nhúng service xử lý phòng ban
import { AddressService } from "../Services/AddressService";

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

// nhung tooltip
import ToolTip from "./ToolTip"

export default {
  name: "FormDataComponent",
  components: {
    ToolTip,
    ElDatePicker,
    ElConfigProvider 
  },
  
  setup() {
    return {
      locale: vi,
    }
  },
  created() {
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
      country: "",
      province:"",
      districts:"",
      wards:"",
      organizationType: "",
      customerInfo: CreateCustomerModel,
      potentialTypeMap: new Map(),
      fieldMap: new Map(),
      careerMap: new Map(),
      errors: new Map(),
      customerPotentialType: CustomerPotentialTypeModel,
      ToastMessageCustomer: ToastMessage,
      searchVocative:"",
      searchDepartment:"",
      searchSource:"",
      searchpPosition:"",
      searchOrganizationType:"",
      searchTurnover: ""
    };
  },
  watch: {

    "customerInfo.Address":{
      handler(val){
       console.log(val)
      }
    },
    // quốc gia
    "customerInfo.Country":{
      handler(){
        if(this.customerInfo.Country== null){
          this.customerInfo.Province = null;
          this.customerInfo.District = null;
          this.customerInfo.Wards = null;
        }
        this.getAddressSum();
      }
    },
    // tỉnh/ thành phố
    "customerInfo.Province":{
      handler(){
        if(this.customerInfo.Province== null){
          this.customerInfo.District = null;
          this.customerInfo.Wards = null;
        }
        this.getAddressSum();
      }
    },

    // quận/ huyện
    "customerInfo.District":{
      handler(){
        if(this.customerInfo.District== null){
          this.customerInfo.Wards = null;
        }
        this.getAddressSum();
      }
    },
    // phường. xã
    "customerInfo.Wards":{
      handler(){
        this.getAddressSum();
      }
    },
     // phường. xã
     "customerInfo.HomeNumber":{
      handler(){
        this.getAddressSum();
      }
    },
    // theo dõi tên
     "customerInfo.FirstName":{
      handler(){
        if(this.errors.get("FirstName"))
          this.errors.delete("FirstName")
        
        let Firstname =  (this.customerInfo.FirstName!=null)?this.customerInfo.FirstName:"";
        let LastName =  (this.customerInfo.LastName!=null)?this.customerInfo.LastName+" ":"";

        this.customerInfo.FullName = LastName+Firstname;

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
          console.log(this.customerInfo.PotentialCode)
      }

     },
   
    // theo dõi thông tin xưng hô
    vocative() {
      UnLoading(this.$refs.vocative);
    },

    // theo dõi thông tin phòng ban
    department() {
      UnLoading(this.$refs.department);
    },

    // theo dõi thông tin chức danh
    position() {
      UnLoading(this.$refs.position);
    },

    //  theo dõi thông tin nguồn gốc
    source() {
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
      UnLoading(this.$refs.organizationType);
    },
  },
  methods: {
  

    //  xử lý khởi tạo lại dữ liệu
    ResetCustomerInfo(){
      this.customerInfo = new CreateCustomerModel();
    },
    
    // xử lý tìm kiếm doanh thu
    async SearchTurnover(){
      let _TurnoverService = new TurnoverService();
        await _TurnoverService.getByName(this.searchTurnover).then((res) => {
          console.log(res)
          if(res.statusCode == StatusCode.GetSuccess){
            this.turnover = res.data;
          }
        });
    },

     // xử lý tìm kiếm loại hình
     async SearchOrganizationType(){
      let _OrganizationTypeSrervice = new OrganizationTypeSrervice();
        await _OrganizationTypeSrervice.getByName(this.searchOrganizationType).then((res) => {
          console.log(res)
          if(res.statusCode == StatusCode.GetSuccess){
            this.organizationType = res.data;
          }
        });
    },

    // xử lý tìm kiếm Chức danh
    async SearchpPosition(){
      let _PositionService = new PositionsService();
        await _PositionService.getByName(this.searchpPosition).then((res) => {
          console.log(res)
          if(res.statusCode == StatusCode.GetSuccess){
            this.position = res.data;
          }
        });
    },

     // xử lý tìm kiếm nguồn gốc
    async SearchSource(){
      let _SearchSource = new SourceService();
        await _SearchSource.getByName(this.searchSource).then((res) => {
          console.log(res)
          if(res.statusCode == StatusCode.GetSuccess){
            this.source = res.data;
          }
        });
    },

     // xử lý tìm kiếm phòng ban
    async SearchDepartment(){
      let _SearchDepartment = new DepartmentService();
        await _SearchDepartment.getByName(this.searchDepartment).then((res) => {
          console.log(res)
          if(res.statusCode == StatusCode.GetSuccess){
            this.department = res.data;
          }
        });
    },

    // xử lý tìm kiếm xưng hô
    async SearchVocative(){
      let _VocativeService = new VocativeService();
        await _VocativeService.getByName(this.searchVocative).then((res) => {
          if(res.statusCode == StatusCode.GetSuccess){
            this.vocative = res.data;
          }
         
        });
    },
    // get Address
    getAddressSum(){
      let HomeNumber = (this.customerInfo.HomeNumber)?this.customerInfo.HomeNumber+", ":"";
      let Wards = (this.customerInfo.Wards)?this.customerInfo.Wards+", ":"";
      let District = (this.customerInfo.District)?this.customerInfo.District+", ":"";
      let Province = (this.customerInfo.Province)?this.customerInfo.Province+", ":"";
      let Country = (this.customerInfo.Country)?this.customerInfo.Country:"";
      this.customerInfo.Address = HomeNumber + Wards + District + Province +  Country;
    },

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
        this.removeData();
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
        let El = event.target;
       
        if(El.classList.contains("country") || El.parentNode.classList.contains("country")){
          // lấy địa chỉ api
          // this.customerInfo.Country = 
          if(!El.classList.contains("country")){
            El  = El.parentNode;
          }

          let ElValue = El.getAttribute("value");
          this.customerInfo.Country =  ElValue;

          if(ElValue == null){
            this.customerInfo.Province = null;
            this.province = null;
          }else{
            let _AddressService = new AddressService();
          _AddressService.GetAllProvince().then(res=>{
            if(res.status == StatusCode.GetSuccess){
              this.province = res.data;
            }
          })
          }
            //  xóa giá trị cũ
            let oldValue =  this.$refs.provinceId;
              oldValue.innerHTML = "- Không chọn -";
              oldValue.setAttribute("value",null);

                //  xóa giá trị cũ
            let oldValueDis =  this.$refs.districtId;
            this.districts=[];
            oldValueDis.innerHTML = "- Không chọn -";
            oldValueDis.setAttribute("value",null);

              //  xóa giá trị cũ
              let oldValueWard =  this.$refs.wardId;
              this.wards=[];
              oldValueWard.innerHTML = "- Không chọn -";
              oldValueWard.setAttribute("value",null);
          
        }


        if(El.classList.contains("province") || El.parentNode.classList.contains("province")){
          // lấy địa chỉ api
          // this.customerInfo.Country = 
          this.customerInfo.Province = null;
          if(El.classList.contains("province") == false){
           El= El.parentNode;
          }
            
          let ElValue = El.getAttribute("value");
          // this.customerInfo.Country =  ElValue;
          
          if(ElValue){
            
            let stringHtml = El.getElementsByClassName("combobox-data-child-content-text")[0];
            if(stringHtml)
              this.customerInfo.Province =  stringHtml.innerHTML;

            let _AddressService = new AddressService();
            _AddressService.GetAllDistricts(ElValue).then(res=>{
            if(res.status == StatusCode.GetSuccess ){
              this.districts = res.data.districts;
            
            }
  
          })
          }else{
            this.districts=[];
          }

            //  xóa giá trị cũ
            let oldValue =  this.$refs.districtId;
            oldValue.innerHTML = "- Không chọn -";
            oldValue.setAttribute("value",null);
        }

        // districts
        if(El.classList.contains("district") || El.parentNode.classList.contains("district")){
          this.customerInfo.District = null;
          this.wards=[];
          if(El.classList.contains("district") == false){
           El= El.parentNode;
          }
          let value = El.getAttribute("value");
          if(value){

          let stringHtml = El.getElementsByClassName("combobox-data-child-content-text")[0];
            if(stringHtml)
              this.customerInfo.District =  stringHtml.innerHTML;

              let _AddressService = new AddressService();
          _AddressService.GetAllWards(value).then(res=>{
            if(res.status == StatusCode.GetSuccess ){
              this.wards = res.data.wards;
            }
  
          })
  
          }
              //  xóa giá trị cũ
              let oldValue =  this.$refs.wardId;
              oldValue.innerHTML = "- Không chọn -";
              oldValue.setAttribute("value",null);
        }

         // wards
         if(El.classList.contains("wards") || El.parentNode.classList.contains("wards")){
          this.customerInfo.Wards = null;
          if(El.classList.contains("wards") == false){
           El= El.parentNode;
          }
          let value = El.getAttribute("value");
          if(value){

          let stringHtml = El.getElementsByClassName("combobox-data-child-content-text")[0];
            if(stringHtml)
              this.customerInfo.Wards =  stringHtml.innerHTML;

  
          }
              //  xóa giá trị cũ
              let oldValue =  this.$refs.wardId;
              oldValue.innerHTML = "- Không chọn -";
              oldValue.setAttribute("value",null);
        }

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
    async OnSubmit(e) {
      try{
      const [customerInfo,errors]= await handlerValidateCustomer(this.$refs,this.customerInfo,this.errors);
      this.customerInfo = customerInfo;
      this.errors = errors;
        console.log(this.errors)
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

      if(this.errors.size ==0){
          let _CustomerService= new CustomerService();
        _CustomerService.Create(this.customerInfo).then((res)=>{
          if(res.data.statusCode == StatusCode.CreateSuccess){
            // lấy ra Customer id
              const customerId = res.data.data.customerId
              if(customerId){
                
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

              // chuyển trang về trang chính bằng cách ẩn form hiển tại
              if(e.target.classList.contains("created") == true){
                this.HandlerSelectCodeMax();
              }else{
                this.$emit("CloseFormData", false);
              }
              this.ToastMessageCustomer.Type = "success";
              this.ToastMessageCustomer.Message = res.data.message;
    
              // load lại dữ liệu trong form
              this.$emit("checkLoadCustomerData",true);
          }else{
            // hiển thị thông báo thêm thất bại
            this.ToastMessageCustomer.Type = "error";
            this.ToastMessageCustomer.Message = res.data.message;
          }
          // gửi thống báo cho toast message
          this.$emit("toastMessageInfo", this.ToastMessageCustomer);
          this.$emit("showToastMessageInfo", true);

        })

        this.removeData();
       }



     }catch(error){
        console.log(error)
      }
    
      
    },

    removeData(){
      this.customerInfo.LastName = "";
      this.customerInfo.FirstName = "";
      this.customerInfo.CustomerPhoneNumber = "";
      this.customerInfo.CompanyPhoneNumber = "";
      this.customerInfo.Zalo = "";
      this.customerInfo.CustomerEmail = "";
      this.customerInfo.CompanyEmail = "";
      this.customerInfo.Organization = "";
      this.customerInfo.TaxCode = "";
      this.customerInfo.BankAccount = "";
      this.customerInfo.BankName = "";
      this.customerInfo.HomeNumber = "";
      this.customerInfo.RegionCode = "";
      this.customerInfo.Address = "";
    }
  },
  mounted() {
    // alert('huy');
  },
  unmounted(){
    
  }
};
</script>
<style>
</style>