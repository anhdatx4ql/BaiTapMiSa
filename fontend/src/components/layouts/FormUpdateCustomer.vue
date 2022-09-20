<template>
  <div class="form-container" v-if="checkShowFormData">
    <form @submit.prevent>
      <div class="form-content">
        <div class="form-container-title">
          <div class="form-container-title-left">
            <div class="filter-title-text" style="font-size: 20px">
              Sửa tiềm năng
            </div>
          </div>
          <div class="form-container-title-right">
            <button
              type="button"
              class="button button-background-primary save"
              @click="OnSubmit"
              ref="save"
              tabindex="14"
            >
              Lưu
            </button>
            <button
              type="button"
              class="button button-background-white created"
              @click="OnSubmit"
              ref="saveAndAdd"
              tabindex="15"
            >
              Lưu và thêm
            </button>
            <button
              type="button"
              class="button button-background-white"
              @click="HandlerCloseForm"
              tabindex="16"
            >
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
                <!-- <div>
                  <img v-if="customerInfo.path!=null" src='http://localhost:8080/Resource/Uploads/2022_09_19_10_04_57-fileUpload.jpg' alt="Không tìm thấy ảnh" width="48" height="48">
                </div> -->
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
                        :class="{
                          'combobox-content-select-content-none': IsEmpty(
                            customerInfo.vocativeId
                          )
                            ? true
                            : false,
                        }"
                        :model="
                          customerInfo.vocativeId?customerInfo.vocativeId:''
                        "
                        :value="customerInfo.vocativeId"
                      >
                        {{
                          customerInfo.vocativeName
                            ? TitleCase(customerInfo.vocativeName)
                            : "- Không chọn -"
                        }}
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
                      <div
                        class="
                          combobox-data-search combobox-data-child-content-text
                        "
                      >
                        <label
                          class="
                            label-input
                            combobox-data-search-label
                            combobox-data-child-content-text
                          "
                        >
                          <input
                            type="text"
                            class="
                              input input-icon
                              combobox-data-child-content-text
                            "
                            placeholder="Tìm kiếm"
                            v-on:keyup.enter="SearchVocative"
                            v-model="searchVocative"
                          />
                          <span
                            class="
                              background-icon-search-input
                              combobox-data-child-content-text
                            "
                            @click="SearchVocative"
                          ></span>
                        </label>
                      </div>
                      <div class="combobox-data-child">
                        <div
                          class="combobox-data-child-content vocativeId"
                          :class="{
                            selected: IsEmpty(customerInfo.vocativeId),
                          }"
                          @click="HandlerClickComboboxData"
                        >
                          <div class="combobox-data-child-content-text">
                            - Không chọn -
                          </div>
                          <div
                            class="background-icon-checked icon-font-16"
                            :style="
                              IsEmpty(customerInfo.vocativeId)
                                ? 'display:inline-block'
                                : 'display:none'
                            "
                          ></div>
                        </div>
                        <div
                          class="combobox-data-child-content vocativeId"
                          v-for="v in vocative"
                          :key="v.vocative"
                          :class="{
                            selected:
                              v.vocativeId == customerInfo.vocativeId
                                ? true
                                : false,
                          }"
                          @click="HandlerClickComboboxData"
                          :value="v.vocativeId"
                        >
                          <div class="combobox-data-child-content-text">
                            {{ TitleCase(v.vocativeName) }}
                          </div>
                          <div
                            class="background-icon-checked icon-font-16"
                            :style="
                              v.vocativeId == customerInfo.vocativeId
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
              <!-- End Xưng hô -->

              <!-- Start họ và đệm -->
              <div class="form-container-content-child-item">
                <div class="form-container-content-child-item-label">
                  Họ và đệm
                </div>
                <div class="form-container-content-child-item-input">
                  <div class="form-container-content-child-item-input">
                    <div
                      class="border-input-content"
                      :class="{ 'input-error': errors.get('LastName') }"
                    >
                      <input
                        type="text"
                        class="input-content"
                        v-model="customerInfo.lastName"
                        tabindex="1"
                        ref="LastName" autofocus
                      />
                      <div class="input-icon-content">
                        <span
                          class="icon-font-16 background-icon-close"
                          @click="customerInfo.lastName = null"
                        ></span>
                      </div>
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
                  <div
                    class="border-input-content"
                    :class="{ 'input-error': errors.get('FirstName') }"
                  >
                    <input
                      type="text"
                      class="input-content"
                      v-model="customerInfo.firstName"
                      tabindex="2"
                    />
                    <div class="input-icon-content">
                      <span
                        class="icon-font-16 background-icon-close"
                        @click="customerInfo.firstName = null"
                      ></span>
                    </div>
                  </div>
                  <span class="span-error" v-if="errors.get('FirstName')">{{
                    errors.get("FirstName")
                  }}</span>
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
                      v-model="customerInfo.fullName"
                      type="text"
                      class="input-content disabled-input"
                      disabled
                    />
                  </div>
                  <div class="input-icon-content">
                    <!-- <span class="icon-font-16 background-icon-close" @click="CustomerInfo.FirstName = null"></span> -->
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
                        :class="{
                          'combobox-content-select-content-none': IsEmpty(
                            customerInfo.departmentId
                          )
                            ? true
                            : false,
                        }"
                        :model="
                          customerInfo.departmentId
                            ? customerInfo.departmentId
                            : ''
                        "
                        :value="customerInfo.departmentId"
                      >
                        {{
                          customerInfo.departmentName
                            ? TitleCase(customerInfo.departmentName)
                            : "- Không chọn -"
                        }}
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
                      <div
                        class="
                          combobox-data-search combobox-data-child-content-text
                        "
                      >
                        <label
                          class="
                            label-input
                            combobox-data-search-label
                            combobox-data-child-content-text
                          "
                        >
                          <input
                            type="text"
                            class="
                              input input-icon
                              arduino
                              combobox-data-child-content-text
                            "
                            placeholder="Tìm kiếm"
                            v-on:keyup.enter="SearchDepartment"
                            v-model="searchDepartment"
                          />
                          <span
                            class="
                              background-icon-search-input
                              combobox-data-child-content-text
                            "
                            @click="SearchDepartment"
                          ></span>
                        </label>
                      </div>
                      <div class="combobox-data-child">
                        <div
                          class="combobox-data-child-content departmentId"
                          :class="{
                            selected: IsEmpty(customerInfo.departmentId),
                          }"
                          @click="HandlerClickComboboxData"
                        >
                          <div class="combobox-data-child-content-text">
                            - Không chọn -
                          </div>
                          <div
                            class="background-icon-checked icon-font-16"
                            :style="
                              IsEmpty(customerInfo.departmentId)
                                ? 'display:inline-block'
                                : 'display:none'
                            "
                          ></div>
                        </div>
                        <div
                          class="combobox-data-child-content departmentId"
                          v-for="v in department"
                          :key="v.department"
                          :class="{
                            selected:
                              v.departmentId == customerInfo.departmentId
                                ? true
                                : false,
                          }"
                          @click="HandlerClickComboboxData"
                          :value="v.departmentId"
                        >
                          <div class="combobox-data-child-content-text">
                            {{ TitleCase(v.departmentName) }}
                          </div>
                          <div
                            class="background-icon-checked icon-font-16"
                            :style="
                              v.departmentId == customerInfo.departmentId
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
                        :class="{
                          'combobox-content-select-content-none': IsEmpty(
                            customerInfo.positionId
                          )
                            ? true
                            : false,
                        }"
                        :model="
                          customerInfo.positionId ? customerInfo.positionId : ''
                        "
                        :value="customerInfo.positionId"
                      >
                        {{
                          customerInfo.positionName
                            ? TitleCase(customerInfo.positionName)
                            : "- Không chọn -"
                        }}
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

                      <div
                        class="
                          combobox-data-search combobox-data-child-content-text
                        "
                      >
                        <label
                          class="
                            label-input
                            combobox-data-search-label
                            combobox-data-child-content-text
                          "
                        >
                          <input
                            type="text"
                            class="
                              input input-icon
                              combobox-data-child-content-text
                            "
                            placeholder="Tìm kiếm"
                            v-on:keyup.enter="SearchpPosition"
                            v-model="searchpPosition"
                          />
                          <span
                            class="
                              background-icon-search-input
                              combobox-data-child-content-text
                            "
                            @click="SearchpPosition"
                          ></span>
                        </label>
                      </div>
                      <div class="combobox-data-child">
                        <div
                          class="combobox-data-child-content positionId"
                          :class="{
                            selected: IsEmpty(customerInfo.positionId),
                          }"
                          @click="HandlerClickComboboxData"
                        >
                          <div class="combobox-data-child-content-text">
                            - Không chọn -
                          </div>
                          <div
                            class="background-icon-checked icon-font-16"
                            :style="
                              IsEmpty(customerInfo.positionId)
                                ? 'display:inline-block'
                                : 'display:none'
                            "
                          ></div>
                        </div>
                        <div
                          class="combobox-data-child-content positionId"
                          v-for="v in position"
                          :key="v.position"
                          :class="{
                            selected:
                              v.positionId == customerInfo.positionId
                                ? true
                                : false,
                          }"
                          @click="HandlerClickComboboxData"
                          :value="v.positionId"
                        >
                          <div class="combobox-data-child-content-text">
                            {{ TitleCase(v.positionName) }}
                          </div>
                          <div
                            class="background-icon-checked icon-font-16"
                            :style="
                              v.positionId == customerInfo.positionId
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
              <!-- END chức danh -->

              <!-- Start Đt di động -->
              <div class="form-container-content-child-item">
                <div class="form-container-content-child-item-label">
                  ĐT di động
                  <span class="background-icon-tool-tip tool-tip-container">
                    <ToolTip
                      :type="'top'"
                      :text="'Điện thoại di động'"
                    ></ToolTip>
                  </span>
                </div>
                <div class="form-container-content-child-item-input">
                  <div
                    class="border-input-content"
                    :class="{
                      'input-error': errors.get('CustomerPhoneNumber'),
                    }"
                  >
                    <input
                      type="text"
                      class="input-content"
                      v-model="customerInfo.customerPhoneNumber"
                      tabindex="3"
                    />

                    <div class="input-icon-content">
                      <span
                        class="icon-font-16 background-icon-close"
                        @click="customerInfo.customerPhoneNumber = null"
                      ></span>
                    </div>
                  </div>
                  <span
                    class="span-error"
                    v-if="errors.get('CustomerPhoneNumber')"
                    >{{ errors.get("CustomerPhoneNumber") }}</span
                  >
                </div>
              </div>

              <!-- End ĐT di động -->

              <!-- Start Đt cơ quan -->
              <div class="form-container-content-child-item">
                <div class="form-container-content-child-item-label">
                  ĐT cơ quan
                  <span class="background-icon-tool-tip tool-tip-container">
                    <ToolTip
                      :type="'top'"
                      :text="'Điện thoại di động'"
                    ></ToolTip>
                  </span>
                </div>
                <div class="form-container-content-child-item-input">
                  <div class="border-input-content">
                    <input
                      type="text"
                      class="input-content"
                      v-model="customerInfo.companyPhoneNumber"
                      tabindex="4"
                    />

                    <div class="input-icon-content">
                      <span
                        class="icon-font-16 background-icon-close"
                        @click="customerInfo.companyPhoneNumber = null"
                      ></span>
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
                        :class="{
                          'combobox-content-select-content-none': IsEmpty(
                            customerInfo.sourceId
                          )
                            ? true
                            : false,
                        }"
                        :model="
                          customerInfo.sourceId ? customerInfo.sourceId : null
                        "
                        :value="customerInfo.sourceId"
                      >
                        {{
                          customerInfo.sourceName
                            ? TitleCase(customerInfo.sourceName)
                            : "- Không chọn -"
                        }}
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

                      <!-- tìm kiếm -->
                      <div
                        class="
                          combobox-data-search combobox-data-child-content-text
                        "
                      >
                        <label
                          class="
                            label-input
                            combobox-data-search-label
                            combobox-data-child-content-text
                          "
                        >
                          <input
                            type="text"
                            class="
                              input input-icon
                              combobox-data-child-content-text
                            "
                            placeholder="Tìm kiếm"
                            v-on:keyup.enter="SearchSource"
                            v-model="searchSource"
                          />
                          <span
                            class="
                              background-icon-search-input
                              combobox-data-child-content-text
                            "
                            @click="SearchSource"
                          ></span>
                        </label>
                      </div>
                      <div class="combobox-data-child">
                        <div
                          class="combobox-data-child-content sourceId"
                          :class="{
                            selected: IsEmpty(customerInfo.sourceId),
                          }"
                          @click="HandlerClickComboboxData"
                        >
                          <div class="combobox-data-child-content-text">
                            - Không chọn -
                          </div>
                          <div
                            class="background-icon-checked icon-font-16"
                            :style="
                              IsEmpty(customerInfo.sourceId)
                                ? 'display:inline-block'
                                : 'display:none'
                            "
                          ></div>
                        </div>
                        <div
                          class="combobox-data-child-content sourceId"
                          v-for="v in source"
                          :key="v.source"
                          :class="{
                            selected:
                              v.sourceId == customerInfo.sourceId
                                ? true
                                : false,
                          }"
                          @click="HandlerClickComboboxData"
                          :value="v.sourceId"
                        >
                          <div class="combobox-data-child-content-text">
                            {{ TitleCase(v.sourceName) }}
                          </div>
                          <div
                            class="background-icon-checked icon-font-16"
                            :style="
                              v.sourceId == customerInfo.sourceId
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
                      @click="HandlerClickComboboxMul"
                      check="false"
                    >
                      <div class="combobox-content-select combobox-mul-child">
                        <div
                          class="
                            combobox-content-select-content
                            combobox-content-select-content-none
                          "
                          v-if="customerPotentialTypeMap.size == 0"
                        >
                          <div class="">- Không chọn -</div>
                          <!-- <div class="combobox-content-select-content-icon background-icon-close icon-font-16"></div> -->
                        </div>

                        <div
                          class="combobox-content-select-content"
                          v-else
                          v-for="v in customerPotentialTypeMap"
                          :key="v[0]"
                        >
                          <div
                            class="combobox-content-select-content-text"
                            :value="v[0]"
                          >
                            {{ TitleCase(v[1]) }}
                          </div>
                          <div
                            class="
                              combobox-content-select-content-icon
                              background-icon-close
                              icon-font-16
                            "
                            @click="HandlerClickComboboxDataClose"
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
                          class="combobox-data-child-content"
                          @click="HandlerClickComboboxMulData"
                          value=""
                          :class="{
                            selected: customerPotentialTypeMap.size == 0,
                          }"
                        >
                          <div class="combobox-data-child-content-text">
                            - Không chọn -
                          </div>
                          <div
                            class="background-icon-checked icon-font-16"
                            :style="
                              customerPotentialTypeMap.size == 0
                                ? 'display:inline-block'
                                : 'display:none'
                            "
                          ></div>
                        </div>
                        <div
                          class="combobox-data-child-content"
                          v-for="v in potentialType"
                          :key="v.potentialTypeId"
                          :value="v.potentialTypeId"
                          :class="{
                            selected: CheckSelectComboboxDataMul(
                              v.potentialTypeId
                            ),
                          }"
                          @click="HandlerClickComboboxMulData"
                        >
                          <div class="combobox-data-child-content-text">
                            {{ TitleCase(v.potentialTypeName) }}
                          </div>
                          <div
                            class="background-icon-checked icon-font-16"
                            :style="
                              CheckSelectComboboxDataMul(v.potentialTypeId)
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
              <!-- End Loại tiềm năng -->

              <!-- Start không gọi điện -->
              <div class="form-container-content-child-item">
                <div class="form-container-content-child-item-label">
                  Không gọi điện
                </div>
                <div class="form-container-content-child-item-input">
                  <input
                    type="checkbox"
                    id="isActivePhoneNumber"
                    v-model="customerInfo.isActivePhoneNumber"
                    tabindex="5"
                  />
                  <label
                    for="isActivePhoneNumber"
                    class="background-icon-checked-table"
                  ></label>
                </div>
              </div>
              <!-- End không gọi điện -->

              <!-- Start không gửi email -->
              <div class="form-container-content-child-item">
                <div class="form-container-content-child-item-label">
                  Không gửi Email
                </div>
                <div class="form-container-content-child-item-input">
                  <input
                    type="checkbox"
                    id="isActiveEmail"
                    v-model="customerInfo.isActiveEmail"
                    tabindex="6"
                  />
                  <label
                    for="isActiveEmail"
                    class="background-icon-checked-table"
                  ></label>
                </div>
              </div>
              <!-- End không gửi email -->

              <!-- Start Zalo -->
              <div class="form-container-content-child-item">
                <div class="form-container-content-child-item-label">Zalo</div>
                <div class="form-container-content-child-item-input">
                  <div class="border-input-content">
                    <input
                      type="text"
                      class="input-content"
                      v-model="customerInfo.zalo"
                      tabindex="7"
                    />

                    <div class="input-icon-content">
                      <span
                        class="icon-font-16 background-icon-close"
                        @click="customerInfo.zalo = null"
                      ></span>
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
                  <div
                    class="border-input-content"
                    :class="{ 'input-error': errors.get('CustomerEmail') }"
                  >
                    <input
                      type="text"
                      class="input-content"
                      v-model="customerInfo.customerEmail"
                      tabindex="8"
                    />

                    <div class="input-icon-content">
                      <span
                        class="icon-font-16 background-icon-close"
                        @click="customerInfo.customerEmail = null"
                      ></span>
                    </div>
                  </div>
                  <span class="span-error" v-if="errors.get('CustomerEmail')">{{
                    errors.get("CustomerEmail")
                  }}</span>
                </div>
              </div>

              <!-- EndEmail cá nhân -->

              <!-- Start cơ quan-->
              <div class="form-container-content-child-item">
                <div class="form-container-content-child-item-label">
                  Email cơ quan
                </div>
                <div class="form-container-content-child-item-input">
                  <div
                    class="border-input-content"
                    :class="{ 'input-error': errors.get('CompanyEmail') }"
                  >
                    <input
                      type="text"
                      class="input-content"
                      v-model="customerInfo.companyEmail"
                      tabindex="9"
                    />

                    <div class="input-icon-content">
                      <span
                        class="icon-font-16 background-icon-close"
                        @click="customerInfo.companyEmail = null"
                      ></span>
                    </div>
                  </div>
                  <span class="span-error" v-if="errors.get('CompanyEmail')">{{
                    errors.get("CompanyEmail")
                  }}</span>
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
                    <input
                      type="text"
                      class="input-content"
                      v-model="customerInfo.organization"
                      tabindex="10"
                    />

                    <div class="input-icon-content">
                      <span
                        class="icon-font-16 background-icon-close"
                        @click="customerInfo.organization = null"
                      ></span>
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
                  <div
                    class="border-input-content"
                    :class="{ 'input-error': errors.get('TaxCode') }"
                  >
                    <input
                      type="text"
                      class="input-content"
                      v-model="customerInfo.taxCode"
                      tabindex="11"
                    />
                    <div class="input-icon-content">
                      <span
                        class="icon-font-16 background-icon-close"
                        @click="customerInfo.taxCode = null"
                      ></span>
                    </div>
                  </div>
                  <span class="span-error" v-if="errors.get('TaxCode')">{{
                    errors.get("TaxCode")
                  }}</span>
                </div>
              </div>
              <!-- End Mã số thuế -->
            </div>
          </div>

          <!-- thông tin tổ chức -->
          <div class="form-container-content-child">
            <div class="form-container-content-child-title font-latin-bold">
              Thông tin cá nhân
            </div>
            <div class="form-container-content-child-body">
              <!-- Start giới tính -->
              <div class="form-container-content-child-item">
                <div class="form-container-content-child-item-label">
                  Giới tính
                </div>
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
                        :class="{
                          'combobox-content-select-content-none': IsEmpty(
                            customerInfo.gender
                          )
                            ? true
                            : false,
                        }"
                        :value="
                          customerInfo.gender != null
                            ? customerInfo.gender
                            : null
                        "
                      >
                        {{
                          customerInfo.gender != null
                            ? selectGenderName(customerInfo.gender)
                            : "- Không chọn -"
                        }}
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
                          class="combobox-data-child-content genderId"
                          :class="{
                            selected: IsEmpty(customerInfo.gender),
                          }"
                          @click="HandlerClickComboboxData"
                        >
                          <div class="combobox-data-child-content-text">
                            - Không chọn -
                          </div>
                          <div
                            class="background-icon-checked icon-font-16"
                            :style="
                              IsEmpty(customerInfo.gender)
                                ? 'display:inline-block'
                                : 'display:none'
                            "
                          ></div>
                        </div>
                        <div
                          class="combobox-data-child-content genderId"
                          v-for="v in gender"
                          :key="v.Code"
                          :class="{
                            selected:
                              v.Code == customerInfo.gender ? true : false,
                          }"
                          @click="HandlerClickComboboxData"
                          :value="v.Code"
                        >
                          <div class="combobox-data-child-content-text">
                            {{ TitleCase(v.Name) }}
                          </div>
                          <div
                            class="background-icon-checked icon-font-16"
                            :style="
                              v.Code == customerInfo.gender
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

              <!-- Start Ngày sinh -->
              <div class="form-container-content-child-item">
                <div class="form-container-content-child-item-label">
                  Ngày sinh
                </div>
                <div class="form-container-content-child-item-input">
                  <!-- <Datepicker class="border-input-content" type="date">
                </Datepicker> -->
                  <el-config-provider :locale="locale">
                    <el-date-picker
                      tabindex="12"
                      v-model="customerInfo.birthDay"
                      :value="customerInfo.birthDay"
                      type="date"
                      format="DD/MM/YYYY"
                      placeholder="DD/MM/YYYY"
                      :style="
                        errors.get('DateTimeError')
                          ? 'border:1px solid red !important'
                          : ''
                      "
                    ></el-date-picker>
                  </el-config-provider>
                  <span class="span-error" v-if="errors.get('DateTimeError')">{{
                    errors.get("DateTimeError")
                  }}</span>
                </div>
              </div>
              <!-- End Ngày sinh-->

              <!-- Start Facebook -->
              <div class="form-container-content-child-item">
                <div class="form-container-content-child-item-label">
                  Facebook
                </div>
                <div class="form-container-content-child-item-input">
                  <div class="border-input-content">
                    <input
                      type="text"
                      class="input-content"
                      v-model="customerInfo.facebook"
                      tabindex="13"
                    />

                    <div class="input-icon-content">
                      <span
                        class="icon-font-16 background-icon-close"
                        @click="customerInfo.facebook = null"
                      ></span>
                    </div>
                  </div>
                </div>
              </div>
              <!-- End Facebook -->
            </div>
          </div>
        </div>

        <!-- end thông tin cá nhân -->
      </div>
    </form>
  </div>
</template>

<script>
// nhúng status code
import { StatusCode } from "../Models/StatusCode";

// nhúng model view customer xử lý sửa
import { UpdateCustomerModel } from "../Models/CustomerModel/UpdateCustomerModel";

// nhúng giới tính
import { GenderModel } from "../Models/GenderModel";

// nhúng status code
import { CheckExistsColumn } from "../Models/CustomerModel/CheckExistsColumn";

// nhúng service xử lý Customer
import { CustomerService } from "../Services/CustomerService";

// nhúng Toastmessage
import { ToastMessage } from "../Models/ToastMessage";

// các hàm xử lý click combobox
import {
  ClickShowHideComboboxData,
  SelectValueComboboxData,
  ClickShowHideComboboxMulData,
} from "../../js/HandlerCombobox";

// các hàm xử lý click combobox
import { IsEmpty, FormatDate } from "../../js/FormatData";

// các hàm xử lý click combobox
import { HandlerValidateTCustomer } from "../../js/HandlerValidate";

// hàm xử lý hiển thị loading
import { UnLoading } from "../../js/Loading";

// hàm xử lý lấy lỗi validate
import { ErrorsValidation } from "../../js/Validation";

// hàm xử lý hiển thị loading
import {
  HandlerClickCloseIconComboboxMul,
  HanlderClickComboboxMulData,
} from "../../js/ComboboxDataMultiple";

// xử lý hiển thị text
import { TitleCase, CheckEmail } from "../../js/HandlerString";

// xử lý check trùng
import { CheckExists } from "../../js/HandlerValidate";

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

// nhúng service xử lý loại tiềm năng khách hàng
import { CustomerPotentialTypeService } from "../Services/CustomerPotentialTypeService";

// nhung tooltip
import ToolTip from "./ToolTip";

import {
  ElConfigProvider,
  ElDatePicker,
} from "../../../node_modules/element-plus";
import "../../../node_modules/element-plus/dist/index.css";
import vi from "../../../node_modules/element-plus/es/locale/lang/vi";
// import Datepicker from '../../../node_modules/vue3-datepicker';
export default {
  name: "FormDataComponent",
  components: {
    ToolTip,
    ElDatePicker,
    ElConfigProvider,
  },
  setup() {
    return {
      locale: vi,
    };
  },

  props: {
    checkShowFormData: Boolean,
    CustomerInfo: {},
  },
  data() {
    return {
      date: new Date("YYYY-MM-dd"),
      vocative: "",
      department: "",
      position: "",
      potentialType: "",
      career: "",
      source: "",
      customerPotentialType: "",
      customerPotentialTypeMap: new Map(),
      potentialTypeMap: new Map(),
      errors: new Map(),
      customerInfo: "",
      ToastMessageCustomer: ToastMessage,
      checkValidatePhone: false,
      checkValidateEmail: false,
      checkValidateCompanyEmail: false,
      checkValidateTaxCode: false,
      CustomerPhone: "",
      CustomerEmail: "",
      TaxCode: "",
      gender: GenderModel,
      customerUpdate: UpdateCustomerModel,
      searchVocative: "",
      searchDepartment: "",
      searchSource: "",
      searchpPosition: "",
      ErrorsValidation: ErrorsValidation,

    };
  },
  created() {},
  watch: {

   
  
    // theo dõi ngày sinh
    "customerInfo.birthDay": {
      handler(val) {
        let today = new Date();
        if (val > today) {
          console.log(this.errors.get("DateTimeError"));
          this.errors.set("DateTimeError", this.ErrorsValidation.DateTimeError);
        } else {
          if (this.errors.get("DateTimeError"))
            this.errors.delete("DateTimeError");
        }
        console.log(val)
      },
    },

    // theo dõi thông tin khách hàng
    customerInfo() {
      // lấy thông tin bảng loại tiềm năng
      console.log(this.customerInfo.path);
      if(this.customerInfo.path)
        window.open(this.customerInfo.path, null);
      this.HandlerCustomerPotentialType(this.customerInfo.customerId);
    },

    // theo dõi tên
    "customerInfo.firstName": {
      handler() {
        if (this.errors.get("FirstName")) this.errors.delete("FirstName");

        if(IsEmpty(this.customerInfo.firstName)){
          if(this.errors.get("FirstName") == undefined){
            this.errors.set("FirstName",this.ErrorsValidation.FirstNameRequired)
          }
        }

        let Firstname =
          this.customerInfo.firstName != null
            ? this.customerInfo.firstName
            : "";
        let LastName =
          this.customerInfo.lastName != null
            ? this.customerInfo.lastName + " "
            : "";

        if(this.customerInfo.firstName != null)
          this.customerInfo.firstName = TitleCase(this.customerInfo.firstName);

        this.customerInfo.fullName = LastName + Firstname;

        // in hoa chữ cái đầu
      },
    },

    // theo dõi họ và đệm
    "customerInfo.lastName": {
      handler() {
        if (this.errors.get("FirstName")) this.errors.delete("FirstName");

        let Firstname =
          this.customerInfo.firstName != null
            ? this.customerInfo.firstName
            : "";
        let LastName =
          this.customerInfo.lastName != null
            ? this.customerInfo.lastName + " "
            : "";

        if(this.customerInfo.lastName != null)
          this.customerInfo.lastName = TitleCase(this.customerInfo.lastName);

        this.customerInfo.fullName = LastName + Firstname;
      },
    },

    // theo doi customer phonenumber
    "customerInfo.customerPhoneNumber": {
      handler(newValue,oldValue) {
        if (this.errors.get("CustomerPhoneNumber"))
          this.errors.delete("CustomerPhoneNumber");

        console.log('newValue: ',newValue)  
        console.log('oldValue: ',oldValue)  

        if (IsEmpty(oldValue) == false && newValue != oldValue && this.CustomerPhone!=this.customerInfo.customerPhoneNumber) {
          this.checkValidatePhone = true;
        } else this.checkValidatePhone = false;

        console.log(this.checkValidatePhone)
      },
    },

    //  theo doi email
    "customerInfo.customerEmail": {
      handler(newValue, oldValue) {
        if (this.errors.get("CustomerEmail"))
          this.errors.delete("CustomerEmail");

          if (IsEmpty(oldValue) == false && newValue != oldValue && this.CustomerEmail!=newValue) {
          this.checkValidateEmail = true;
        } else this.checkValidateEmail = false;

      },
    },

    //  theo doi email công ty
    "customerInfo.companyEmail": {
      handler() {
        if (this.errors.get("CompanyEmail")) this.errors.delete("CompanyEmail");

        if (this.customerInfo.companyEmail != this.companyEmail) {
          this.checkValidateCompanyEmail = true;
        } else this.checkValidateCompanyEmail = false;
      },
    },

    //  theo doi ma so thue
    "customerInfo.taxCode": {
      handler(newValue, oldValue) {
        if (this.errors.get("TaxCode")) this.errors.delete("TaxCode");

        if (IsEmpty(oldValue) == false && newValue != oldValue && this.TaxCode!=newValue) {
          this.checkValidateTaxCode = true;
        } else this.checkValidateTaxCode = false;

      },
    },
    // theo dõi biển  loại tiềm năng đã chọn
    customerPotentialTypeMap() {
      console.log(this.customerPotentialTypeMap);
    },
    // theo dõi thông tin khách hàng
    CustomerInfo() {
      console.log(this.CustomerInfo)
      this.customerInfo = this.CustomerInfo;
      this.CustomerPhone = this.customerInfo.customerPhoneNumber;
      this.CustomerEmail = this.customerInfo.customerEmail;
      this.TaxCode = this.customerInfo.taxCode;
    },

    // lấy loại tiềm năng đã được chọn
    customerPotentialType() {
      if (this.customerPotentialType) {
        for (let i = 0; i < this.customerPotentialType.length; i++) {
          const me = this.customerPotentialType[i];
          this.customerPotentialTypeMap.set(
            me.potentialTypeId,
            me.potentialTypeName
          );
        }
      }
    },
  },
  methods: {

    /**
     * Author: Phạm Văn Đạt
     * Function: remove dataa
     */
    RemoveData() {
      this.customerInfo.LastName = "";
      this.customerInfo.FirstName = "";
      this.customerInfo.CustomerPhoneNumber = "";
      this.customerInfo.CompanyPhoneNumber = "";
      this.customerInfo.Zalo = "";
      this.customerInfo.CustomerEmail = "";
      this.customerInfo.CompanyEmail = "";
      this.customerInfo.Organization = "";
      this.customerInfo.TaxCode = "";
      this.customerInfo.Facebook = "";
    },

    /**
     * Author: Phạm Văn Đạt
     * Function:xử lý tìm kiếm Chức danh
     */
    async SearchpPosition() {
      let _PositionService = new PositionsService();
      await _PositionService.getByName(this.searchpPosition).then((res) => {
        console.log(res);
        if (res.statusCode == StatusCode.GetSuccess) {
          this.position = res.data;
        }
      });
    },

     /**
     * Author: Phạm Văn Đạt
     * Function: xử lý tìm kiếm nguồn gốc
     */
    async SearchSource() {
      let _SearchSource = new SourceService();
      await _SearchSource.getByName(this.searchSource).then((res) => {
        console.log(res);
        if (res.statusCode == StatusCode.GetSuccess) {
          this.source = res.data;
        }
      });
    },

    /**
     * Author: Phạm Văn Đạt
     * Function: xử lý tìm kiếm phòng ban
     */
    async SearchDepartment() {
      let _SearchDepartment = new DepartmentService();
      await _SearchDepartment.getByName(this.searchDepartment).then((res) => {
        console.log(res);
        if (res.statusCode == StatusCode.GetSuccess) {
          this.department = res.data;
        }
      });
    },

     /**
     * Author: Phạm Văn Đạt
     * Function: xử lý tìm kiếm xưng hô
     */
    async SearchVocative() {
      let _VocativeService = new VocativeService();
      await _VocativeService.getByName(this.searchVocative).then((res) => {
        if (res.statusCode == StatusCode.GetSuccess) {
          this.vocative = res.data;
        }
      });
    },

     /**
     * Author: Phạm Văn Đạt
     * Function: format thời gian
     */
    FormatDate,

    /**
     * Author: Phạm Văn Đạt
     * Function: lấy giới tính
     */
    selectGenderName: function (value) {
      for (let i = 0; i < this.gender.length; i++) {
        if (value == this.gender[i].Code) return this.gender[i].Name;
      }
      return "- Không chọn -";
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
    TitleCase,

    /**
     * Xử lý chọn dữ liệu trong combobox multiple
     */
    CheckSelectComboboxDataMul: function (potentialTypeId) {
      for (const item of this.customerPotentialTypeMap) {
        if (potentialTypeId == item[0]) return true;
      }

      return false;
    },

    /**
     * Author: Phạm Văn Đạt
     * function:  xử lý xóa loại tiềm năng
     * created time: 16:43 19/08/2022
     */
    HandlerClickComboboxDataClose: function (event) {
      this.customerPotentialTypeMap = HandlerClickCloseIconComboboxMul(
        event,
        this.customerPotentialTypeMap
      );
      // this.customerPotentialTypeMap.delete(event.target.getAttribute("value"))
    },

    /**
     * Author: Phạm Văn Đạt
     * function:  xử lý đóng form data
     * created time: 11:28 17/08/2022
     */
    HandlerCloseForm() {
      try {
        // xóa dữ liệu cũ
        this.RemoveData();
        
        // không check validate mã số thuế
        this.checkValidateTaxCode = false;

        // không check validate email ơ quan
        this.checkValidateCompanyEmail = false;

        // không check validate email cá nhân
        this.checkValidateEmail = false;

        // không check validate ĐT cá nhân
        this.checkValidatePhone = false;
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
    async HandlerSelectVocative() {
      if (!this.vocative) {
        let _VocativeService = new VocativeService();
        await _VocativeService.getAll().then((res) => {
          this.vocative = res;
        });
        UnLoading(this.$refs.vocative);
      } else {
        UnLoading(this.$refs.vocative);
      }
    },

    /**
     * Author: Phạm Văn Đạt
     * function:  xử lý lấy dữ liệu loại tiềm năng
     * created time: 11:28 17/08/2022
     */
    HandlerCustomerPotentialType(customerId) {
      if (!this.customerPotentialType) {
        let _CustomerPotentialTypeService = new CustomerPotentialTypeService();
        _CustomerPotentialTypeService.getByNameId(customerId).then((res) => {
          this.customerPotentialType = res;
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
        UnLoading(this.$refs.department);
      } else UnLoading(this.$refs.department);
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
        UnLoading(this.$refs.position);
      } else UnLoading(this.$refs.position);
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
        UnLoading(this.$refs.source);
      } else UnLoading(this.$refs.source);
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
          if (res) {
            this.potentialType = res;
            // tạo map lưu lại giá trị để so sánh
          }
          UnLoading(this.$refs.potentialType);
        });
      } else UnLoading(this.$refs.potentialType);
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

        // hiển thị combobox data
        ClickShowHideComboboxData(event);
      } catch (error) {
        console.log(error);
      }
    },

    /***
     * Author: Phạm văn Đạt
     * Function: xử lý click data combobox
     */
    HandlerClickComboboxData: function (event) {
      try {
        let El = event.target;

        // lấy node cha cố định
        while(!El.classList.contains("combobox-data-child-content")){
          El = El.parentNode;
        }

        //lấy value El cha cố định
        
        let value = (El.getAttribute("value"))?El.getAttribute("value"):null;

        if(El.classList.contains("vocativeId")){
          console.log(El)
          console.log(value);
          this.customerInfo.vocativeId = value;
        }else if(El.classList.contains("departmentId")){
          this.customerInfo.departmentId = value;
        }else if(El.classList.contains("positionId")){
          this.customerInfo.positionId = value;
        }else if(El.classList.contains("sourceId")){
          this.customerInfo.sourceId = value;
        }else if(El.classList.contains("genderId")){
          this.customerInfo.gender = value;
        }

        SelectValueComboboxData(event);
      } catch (error) {
        console.log(error);
      }
    },
    
    /***
     * Author: Phạm văn Đạt
     * Function: xử lý click combobox chọn nhiều
     */
    HandlerClickComboboxMul(event) {
      try {
        if (
          event.target.classList.contains(
            "combobox-content-select-content-icon"
          ) == false
        ) {
          if (
            event.target.parentNode.getAttribute("id") == "potentialType" ||
            event.target.parentNode.parentNode.getAttribute("id") ==
              "potentialType"
          ) {
            /// lấy thông tin loại tiềm năng  nếu chưa có dữ liệu
            this.HandlerSelectPotentialType();
          }

          // Nếu click vào combobox  multiple loại tiềm năng: nếu chưa có dữ liệu thì loading, nếu có dữ liệu rồi thì không loading
          ClickShowHideComboboxMulData(event.target);
        }
      } catch (error) {
        console.log(error);
      }
    },

     /***
     * Author: Phạm văn Đạt
     * Function: Xử lý click chọn dữ liệu trong combobox data
     */
    HandlerClickComboboxMulData(event) {
      try {
        this.customerPotentialTypeMap = HanlderClickComboboxMulData(
          event,
          this.customerPotentialTypeMap
        );
      } catch (error) {
        console.log(error);
      }
    },

     /***
     * Author: Phạm văn Đạt
     * Function: Xử lý update
     */
    async OnSubmit(event) {
      try {
        // disabled nút lưu
        if (this.$refs.save) {
          this.$refs.save.setAttribute("disabled", "disabled");
        }

        // disabled nút lưu và thêm
        if (this.$refs.saveAndAdd) {
          this.$refs.saveAndAdd.setAttribute("disabled", "disabled");
        }

        // kiểm tra tên không được trống
        if (
          this.customerInfo.firstName == null ||
          this.customerInfo.firstName == ""
        ) {
          this.errors.set("FirstName", ErrorsValidation.FirstNameRequired);
        }

        // check trùng số điện thoại cá nhân
        if (this.checkValidatePhone == true) {
          let customerPhoneNumber = CheckExistsColumn;
          customerPhoneNumber.tableName = "Customer";
          customerPhoneNumber.columnName = "customerPhoneNumber";
          customerPhoneNumber.value = this.customerInfo.customerPhoneNumber;

          let result = await CheckExists(customerPhoneNumber);
          if (result == true)
            this.errors.set(
              "CustomerPhoneNumber",
              ErrorsValidation.PhoneDuplicate
            );
        }

        // validate email
        if (this.checkValidateEmail == true) {
          // kiểm tra có đúng định dạng
          if (CheckEmail(this.customerInfo.customerEmail) == null) {
            if (!this.errors.get("CustomerEmail"))
              this.errors.set("CustomerEmail", ErrorsValidation.EmailType);
          } else {
            // kiếm tra trùng
            let customerEmail = CheckExistsColumn;
            customerEmail.tableName = "Customer";
            customerEmail.columnName = "customerEmail";
            customerEmail.value = this.customerInfo.customerEmail;

            let result = await CheckExists(customerEmail);
            if (result == true)
              this.errors.set("CustomerEmail", ErrorsValidation.EmailDuplicate);
          }
        }

        if (this.checkValidateCompanyEmail == true) {
          // kiểm tra có đúng định dạng
          if (CheckEmail(this.customerInfo.companyEmail) == null) {
            if (!this.errors.get("CompanyEmail"))
              this.errors.set("CompanyEmail", ErrorsValidation.EmailType);
          }
        }

        // check trùng mã số thuế
        if (this.checkValidateTaxCode == true) {
          let taxCode = CheckExistsColumn;
          taxCode.tableName = "Customer";
          taxCode.columnName = "taxCode";
          taxCode.value = this.customerInfo.taxCode;

          let result = await CheckExists(taxCode);
          if (result == true)
            this.errors.set("TaxCode", ErrorsValidation.TaxCodeDuplicate);
        }

        let vocativeId = this.$refs.vocativeId.getAttribute("value");
        let departmentId = this.$refs.departmentId.getAttribute("value");
        let sourceId = this.$refs.sourceId.getAttribute("value");
        let positionId = this.$refs.positionId.getAttribute("value");
        let genderId = this.$refs.genderId.getAttribute("value");


        this.customerInfo.vocativeId = IsEmpty(vocativeId)? null: vocativeId;
        this.customerInfo.departmentId = IsEmpty(departmentId)? null: departmentId;
        this.customerInfo.sourceId = IsEmpty(sourceId) ? null : sourceId;
        this.customerInfo.positionId = IsEmpty(positionId) ? null : positionId;
        this.customerInfo.gender = IsEmpty(genderId) ? null : genderId;

        // tạo mới dữ liệu bảng loại tiềm năng

        if (this.errors.size == 0) {
          // Biến kiểm tra có được phép  chỉnh sửa thông tin khách hàng hay không
          // format lại data

          this.customerUpdate.VocativeId = this.customerInfo.vocativeId;
          
          this.customerUpdate.LastName = this.customerInfo.lastName;
          
          this.customerUpdate.FirstName = this.customerInfo.firstName;
           
          this.customerUpdate.FullName = this.customerInfo.fullName;
           
          this.customerUpdate.DepartmentId = this.customerInfo.departmentId;
          
          this.customerUpdate.PositionId = this.customerInfo.positionId;
           
          this.customerUpdate.CustomerPhoneNumber = this.customerInfo.customerPhoneNumber;
           
          this.customerUpdate.CompanyPhoneNumber = this.customerInfo.companyPhoneNumber;
          
          this.customerUpdate.SourceId = this.customerInfo.sourceId;
           
          this.customerUpdate.IsActivePhoneNumber = this.customerInfo.isActivePhoneNumber;
           
          this.customerUpdate.IsActiveEmail = this.customerInfo.isActiveEmail;
           
          this.customerUpdate.Zalo = this.customerInfo.zalo;
         
          this.customerUpdate.CustomerEmail = this.customerInfo.customerEmail;
        
          this.customerUpdate.CompanyEmail = this.customerInfo.companyEmail;
       
          this.customerUpdate.Organization = this.customerInfo.organization;
         
          this.customerUpdate.TaxCode = this.customerInfo.taxCode;
          
          this.customerUpdate.Gender = this.customerInfo.gender;
            
          this.customerUpdate.Facebook = this.customerInfo.facebook;

          this.customerUpdate.BirthDay = FormatDate(this.customerInfo.birthDay);

          if (this.customerUpdate.BirthDay == "Invalid date")
            delete this.customerUpdate.BirthDay;
          
          console.log("Ngày sinh: ",this.customerUpdate.BirthDay);

           // update bảng loai tiem nang
          let potentialTypeMapArr = HandlerValidateTCustomer(
            this.customerPotentialTypeMap,
            this.customerInfo.customerId
          );

          if (potentialTypeMapArr != []) {
            let _CustomerPotentialTypeService =
              new CustomerPotentialTypeService();
            await _CustomerPotentialTypeService
              .Create(potentialTypeMapArr)
              .then((res) => {
                if (
                  res.data.statusCode == StatusCode.DeleteSuccess ||
                  res.data.statusCode == StatusCode.CreateSuccess
                ) {
                  console.log(res);
                  console.log("vocativeId: ",this.customerUpdate.VocativeId)
                }
              });
          }

          // update khách hàng
          let _CustomerService = new CustomerService();
          await _CustomerService
            .Update(this.customerInfo.customerId, this.customerUpdate)
            .then((res) => {
              console.log(res);
              if (res) {
                if (res.data.statusCode == StatusCode.UpdateSuccess) {
                  console.log(this.customerUpdate.Facebook);
                  // chuyển trang về trang chính bằng cách ẩn form hiển tại
                  this.ToastMessageCustomer.Type = "success";
                  this.ToastMessageCustomer.Message = res.data.message;
                  this.$emit("toastMessageInfo", this.ToastMessageCustomer);
                  this.$emit("showToastMessageInfo", true);
                  if (event.target.classList.contains("created") != true) {
                    this.HandlerCloseForm();
                  }

                  // load lại dữ liệu trong form
                  this.$emit("checkLoadCustomerData", true);
                  console.log("load lai du lieu");
                } else {
                  console.log("failed");
                  this.ToastMessageCustomer.Type = "error";
                  this.ToastMessageCustomer.Message = res.data.message;
                  this.$emit("toastMessageInfo", this.ToastMessageCustomer);
                  this.$emit("showToastMessageInfo", true);
                }
              } else {
                this.ToastMessageCustomer.Type = "error";
                this.ToastMessageCustomer.Message = "Cập nhật thất bại!";
                this.$emit("toastMessageInfo", this.ToastMessageCustomer);
                this.$emit("showToastMessageInfo", true);
              }
            });

          // end them
        }

        if (this.$refs.save) {
          this.$refs.save.removeAttribute("disabled");
        }

        // disabled nút lưu và thêm
        if (this.$refs.saveAndAdd) {
          this.$refs.saveAndAdd.removeAttribute("disabled");
        }
      } catch (error) {
        console.log(error);
      }
    },
  },
  mounted() {
    // alert('huy');
    console.log(this.$refs);
    if (this.$refs.LastName) {
      this.$refs.LastName.focus();
    }
  },
};
</script>
<style>
input[type="checkbox"]:checked ~ label {
  background: url("../../assets/img/icon_collection.svg") no-repeat -177px -17px;
  height: 16px;
  width: 16px;
  cursor: pointer;
}
</style>