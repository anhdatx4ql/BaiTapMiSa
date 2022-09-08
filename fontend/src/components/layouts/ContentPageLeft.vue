<template>
  <div class="content-chlid content-sider-bar-left">
    <div class="content-sider-bar-left-top">
      <div class="combobox filter-save combobox-filter-top">
        <div
          class="combobox-child combobox-content"
          @click="handlerClickCombobox"
          check="false"
        >
          <div class="combobox-content-select combobox-child">
            BỘ LỌC ĐÃ LƯU
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

      <div class="filter-content" ref="filterContent">
        <div class="filter-content-child">
          <div class="filter-content-child-checkbox">
            <div class="filter-content-child-checkbox-input">
              <input
                type="checkbox"
                id="cardInput"
                class="trCheckboxFilter"
                value="card"
              />
              <label
                for="cardInput"
                class="background-icon-checked-table"
              ></label>
            </div>
            <div class="filter-content-child-checkbox-text">Thẻ</div>
          </div>
          <!-- <div class="filter-content-child-box">
             content thẻ
          </div> -->
        </div>

        <!-- Xưng hô -->
        <div class="filter-content-child">
          <div class="filter-content-child-checkbox">
            <div class="filter-content-child-checkbox-input">
              <input
                type="checkbox"
                id="vocativeInput"
                class="trCheckboxFilter"
                value="vocative"
              />
              <label
                for="vocativeInput"
                class="background-icon-checked-table"
                @click="
                  listField.Vocative.checkShow = !listField.Vocative.checkShow
                "
              ></label>
            </div>
            <div class="filter-content-child-checkbox-text">Xưng hô</div>
          </div>
          <div
            class="filter-content-child-box"
            v-if="listField.Vocative.checkShow"
          >
            <div
              class="combobox filter-save filter-content-child-box-combobox"
              id="vocative"
            >
              <div
                class="combobox-child combobox-content border-color-c"
                @click="handlerClickCombobox"
                check="false"
              >
                <div class="combobox-content-select combobox-child" ref="vocativeType">Là</div>
                <div
                  class="
                    combobox-content-icon
                    button-icon-up-black
                    combobox-child
                    icon-font-16
                  "
                ></div>
              </div>

              <div
                class="combobox-child combobox-data filter-content-child-data"
                ref="vocative"
              >
                <!-- loading -->
                <div class="content-background-icon-loading">
                  <div class="background-icon-loading"></div>
                </div>
                <div
                  class="
                    combobox-data-search
                    filter-content-child-data-child
                    combobox-data-child-content-text
                  "
                >
                  <label class="label-input combobox-data-search-label">
                    <input
                      type="text"
                      class="input input-icon combobox-data-child-content-text"
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
                <div
                  class="combobox-data-child filter-content-child-data-child"
                >
                  <div
                    class="combobox-data-child-content"
                    v-for="v in vocative"
                    :key="v.vocativeId"
                    @click="handlerClickComboboxData"
                    :value="v.vocativeId"
                    :class="{
                      selected:
                        VocativeMap.get(v.vocativeId) != undefined
                          ? true
                          : false,
                    }"
                    id="filedVocative"
                  >
                    <div class="combobox-data-child-content-text-filter">
                      {{ titleCase(v.vocativeName) }}
                    </div>
                    <div
                      class="background-icon-checked icon-font-16"
                      :style="
                        VocativeMap.get(v.vocativeId) != undefined
                          ? 'display:inline-block'
                          : 'none'
                      "
                    ></div>
                  </div>
                </div>
              </div>
            </div>

            <div class="filter-content-child-box-textarea">
              <div
                class="filter-content-child-box-textarea-content border-color-c"
              >
                <div
                  class="combobox-content-select-content vocativeValue"
                  v-for="v in VocativeMap"
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
                      valueVocativeMap
                    "
                    :value="v[0]"
                    @click="handlerClickComboboxDataClose"
                  ></div>
                </div>
              </div>
            </div>
          </div>
        </div>

        <!-- <!- Họ và tên -> -->
        <div class="filter-content-child">
          <div class="filter-content-child-checkbox">
            <div class="filter-content-child-checkbox-input">
              <input
                type="checkbox"
                id="fullNameInput"
                class="trCheckboxFilter"
                value="fullName"
              />
              <label
                for="fullNameInput"
                class="background-icon-checked-table"
                @click="
                  listField.FullName.checkShow = !listField.FullName.checkShow
                "
              ></label>
            </div>
            <div class="filter-content-child-checkbox-text">Họ và tên</div>
          </div>
          <div
            class="filter-content-child-box"
            v-if="listField.FullName.checkShow"
          >
            <!-- <!- content thẻ -> -->
            <div class="combobox filter-save filter-content-child-box-combobox">
              <div
                class="combobox-child combobox-content border-color-c"
                @click="handlerClickCombobox"
                check="false"
              >
                <div class="combobox-content-select combobox-child"
                 ref="valueColumnFullName" value="Exactly">Là</div>
                <div
                  class="
                    combobox-content-icon
                    button-icon-up-black
                    combobox-child
                    icon-font-16
                  "
                ></div>
              </div>

              <div
                class="combobox-child combobox-data filter-content-child-data"
              >
                <div
                  class="combobox-data-child filter-content-child-data-child"
                >
                  <div
                    class="combobox-data-child-content selected"
                    @click="handlerClickComboboxData"
                    value="Exactly"
                  >
                  <div class="combobox-data-child-content-text">
                      Là
                    </div>
                    <div
                      class="background-icon-checked icon-font-16" style="display:inline-block">
                     </div>
                  </div>
                  <div
                    class="combobox-data-child-content"
                    @click="handlerClickComboboxData"
                    value="Contain"
                  >
                  <div class="combobox-data-child-content-text">
                      Chứa
                    </div>
                    <div
                      class="background-icon-checked icon-font-16">
                     </div>
                  </div>
                </div>
              </div>
            </div>

            <div class="filter-content-child-box-text">
              <div class="border-input-content">
                <input type="text" class="input-content" v-model="listField.FullName.value" />
                <div class="input-icon-content">
                  <span class="icon-font-16 background-icon-close"></span>
                </div>
              </div>
            </div>
          </div>
        </div>

        <!-- <!- Chức danh -> -->
        <div class="filter-content-child">
          <div class="filter-content-child-checkbox">
            <div class="filter-content-child-checkbox-input">
              <input
                type="checkbox"
                id="positionInput"
                class="trCheckboxFilter"
                value="position"
              />
              <label
                for="positionInput"
                class="background-icon-checked-table"
                @click="
                  listField.Position.checkShow = !listField.Position.checkShow
                "
              ></label>
            </div>
            <div class="filter-content-child-checkbox-text">Chức danh</div>
          </div>
          <div
            class="filter-content-child-box"
            v-if="listField.Position.checkShow"
          >
            <div
              class="combobox filter-save filter-content-child-box-combobox"
              id="position"
            >
              <div
                class="combobox-child combobox-content border-color-c"
                @click="handlerClickCombobox"
                check="false"
              >
                <div class="combobox-content-select combobox-child">Là</div>
                <div
                  class="
                    combobox-content-icon
                    button-icon-up-black
                    combobox-child
                    icon-font-16
                  "
                ></div>
              </div>

              <div
                class="combobox-child combobox-data filter-content-child-data"
                ref="position"
              >
                <!-- loading -->
                <div class="content-background-icon-loading">
                  <div class="background-icon-loading"></div>
                </div>
                <div
                  class="
                    combobox-data-search
                    filter-content-child-data-child
                    combobox-data-child-content-text
                  "
                >
                  <label class="label-input combobox-data-search-label">
                    <input
                      type="text"
                      class="input input-icon combobox-data-child-content-text"
                      placeholder="Tìm kiếm"
                      v-on:keyup.enter="SearchPosition"
                      v-model="searchPosition"
                    />
                    <span
                      class="
                        background-icon-search-input
                        combobox-data-child-content-text
                      "
                      @click="SearchPosition"
                    ></span>
                  </label>
                </div>
                <div
                  class="combobox-data-child filter-content-child-data-child"
                >
                  <div
                    class="combobox-data-child-content"
                    v-for="v in position"
                    :key="v.positionId"
                    @click="handlerClickComboboxData"
                    :value="v.positionId"
                    :class="{
                      selected:
                        PositionMap.get(v.positionId) != undefined
                          ? true
                          : false,
                    }"
                    id="filedPosition"
                  >
                    <div class="combobox-data-child-content-text-filter">
                      {{ titleCase(v.positionName) }}
                    </div>
                    <div
                      class="background-icon-checked icon-font-16"
                      :style="
                        PositionMap.get(v.positionId) != undefined
                          ? 'display:inline-block'
                          : 'none'
                      "
                    ></div>
                  </div>
                </div>
              </div>
            </div>

            <div class="filter-content-child-box-textarea">
              <div
                class="filter-content-child-box-textarea-content border-color-c"
              >
                <div
                  class="combobox-content-select-content positionValue"
                  v-for="v in PositionMap"
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
                      valuePositionMap
                    "
                    :value="v[0]"
                    @click="handlerClickComboboxDataClose"
                  ></div>
                </div>
              </div>
            </div>
          </div>
        </div>

        <!-- <!- điện thoại di động -> -->
        <div class="filter-content-child">
          <div class="filter-content-child-checkbox">
            <div class="filter-content-child-checkbox-input">
              <input
                type="checkbox"
                id="customerPhoneNumberInput"
                class="trCheckboxFilter"
                value="customerPhoneNumber"
              />
              <label
                for="customerPhoneNumberInput"
                class="background-icon-checked-table"
                @click="
                  listField.CustomerPhoneNumber.checkShow =
                    !listField.CustomerPhoneNumber.checkShow
                "
              ></label>
            </div>
            <div class="filter-content-child-checkbox-text">ĐT di động</div>
          </div>
          <div
            class="filter-content-child-box"
            v-if="listField.CustomerPhoneNumber.checkShow"
          >
           <!-- <!- content thẻ -> -->
           <div class="combobox filter-save filter-content-child-box-combobox">
              <div
                class="combobox-child combobox-content border-color-c"
                @click="handlerClickCombobox"
                check="false"
              >
                <div class="combobox-content-select combobox-child"
                 ref="valueColumnCustomerPhoneNumber" value="Empty">Trống</div>
                <div
                  class="
                    combobox-content-icon
                    button-icon-up-black
                    combobox-child
                    icon-font-16
                  "
                ></div>
              </div>

              <div
                class="combobox-child combobox-data filter-content-child-data"
              >
                <div
                  class="combobox-data-child filter-content-child-data-child"
                >
                  <div
                    class="combobox-data-child-content selected"
                    @click="handlerClickComboboxData"
                    value="Empty"
                  >
                  <div class="combobox-data-child-content-text">
                      Trống
                    </div>
                    <div
                      class="background-icon-checked icon-font-16" style="display:inline-block">
                     </div>
                  </div>
                  <div
                    class="combobox-data-child-content"
                    @click="handlerClickComboboxData"
                    value="NotEmpty"
                  >
                  <div class="combobox-data-child-content-text">
                      Không trống
                    </div>
                    <div
                      class="background-icon-checked icon-font-16">
                     </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>

        <!-- <!- điện thoại cơ quan -> -->
        <div class="filter-content-child">
          <div class="filter-content-child-checkbox">
            <div class="filter-content-child-checkbox-input">
              <input
                type="checkbox"
                id="companyPhoneNumberInput"
                class="trCheckboxFilter"
                value="companyPhoneNumber"
              />
              <label
                for="companyPhoneNumberInput"
                class="background-icon-checked-table"
                @click="
                  listField.CompanyPhoneNumber.checkShow =
                    !listField.CompanyPhoneNumber.checkShow
                "
              ></label>
            </div>
            <div class="filter-content-child-checkbox-text">ĐT cơ quan</div>
          </div>
          <div
            class="filter-content-child-box"
            v-if="listField.CompanyPhoneNumber.checkShow"
          >
            <!-- <!- content thẻ -> -->
            <div class="combobox filter-save filter-content-child-box-combobox">
              <div
                class="combobox-child combobox-content border-color-c"
                @click="handlerClickCombobox"
                check="false"
              >
                <div class="combobox-content-select combobox-child"
                 ref="valueColumnCompanyPhoneNumber" value="Empty">Trống</div>
                <div
                  class="
                    combobox-content-icon
                    button-icon-up-black
                    combobox-child
                    icon-font-16
                  "
                ></div>
              </div>

              <div
                class="combobox-child combobox-data filter-content-child-data"
              >
                <div
                  class="combobox-data-child filter-content-child-data-child"
                >
                  <div
                    class="combobox-data-child-content selected"
                    @click="handlerClickComboboxData"
                    value="Empty"
                  >
                  <div class="combobox-data-child-content-text">
                      Trống
                    </div>
                    <div
                      class="background-icon-checked icon-font-16" style="display:inline-block">
                     </div>
                  </div>
                  <div
                    class="combobox-data-child-content"
                    @click="handlerClickComboboxData"
                    value="NotEmpty"
                  >
                  <div class="combobox-data-child-content-text">
                      Không trống
                    </div>
                    <div
                      class="background-icon-checked icon-font-16">
                     </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>

        <!-- <!- email cơ quan -> -->
        <div class="filter-content-child">
          <div class="filter-content-child-checkbox">
            <div class="filter-content-child-checkbox-input">
              <input
                type="checkbox"
                id="companyEmailInput"
                class="trCheckboxFilter"
                value="companyEmail"
              />
              <label
                for="companyEmailInput"
                class="background-icon-checked-table"
                @click="
                  listField.CompanyEmail.checkShow =
                    !listField.CompanyEmail.checkShow
                "
              ></label>
            </div>
            <div class="filter-content-child-checkbox-text">Email cơ quan</div>
          </div>
          <div
            class="filter-content-child-box"
            v-if="listField.CompanyEmail.checkShow"
          >
            <!-- <!- content thẻ -> -->
            <div class="combobox filter-save filter-content-child-box-combobox">
              <div
                class="combobox-child combobox-content border-color-c"
                @click="handlerClickCombobox"
                check="false"
              >
                <div class="combobox-content-select combobox-child"
                 ref="valueColumnCompanyEmail" value="Exactly">Là</div>
                <div
                  class="
                    combobox-content-icon
                    button-icon-up-black
                    combobox-child
                    icon-font-16
                  "
                ></div>
              </div>

              <div
                class="combobox-child combobox-data filter-content-child-data"
              >
                <div
                  class="combobox-data-child filter-content-child-data-child"
                >
                  <div
                    class="combobox-data-child-content selected"
                    @click="handlerClickComboboxData"
                    value="Exactly"
                  >
                  <div class="combobox-data-child-content-text">
                      Là
                    </div>
                    <div
                      class="background-icon-checked icon-font-16" style="display:inline-block">
                     </div>
                  </div>
                  <div
                    class="combobox-data-child-content"
                    @click="handlerClickComboboxData"
                    value="Contain"
                  >
                  <div class="combobox-data-child-content-text">
                      Chứa
                    </div>
                    <div
                      class="background-icon-checked icon-font-16">
                     </div>
                  </div>
                </div>
              </div>
            </div>

            <div class="filter-content-child-box-text">
              <div class="border-input-content">
                <input type="text" class="input-content" v-model="listField.CompanyEmail.value" />
                <div class="input-icon-content">
                  <span class="icon-font-16 background-icon-close"></span>
                </div>
              </div>
            </div>
          </div>
        </div>

        <!-- <!- email cá nhân -> -->
        <div class="filter-content-child">
          <div class="filter-content-child-checkbox">
            <div class="filter-content-child-checkbox-input">
              <input
                type="checkbox"
                id="customerEmailInput"
                class="trCheckboxFilter"
                value="customerEmail"
              />
              <label
                for="customerEmailInput"
                class="background-icon-checked-table"
                @click="
                  listField.CustomerEmail.checkShow =
                    !listField.CustomerEmail.checkShow
                "
              ></label>
            </div>
            <div class="filter-content-child-checkbox-text">Email cá nhân</div>
          </div>
          <div
            class="filter-content-child-box"
            v-if="listField.CustomerEmail.checkShow"
          >
            <!-- <!- content thẻ -> -->
            <div class="combobox filter-save filter-content-child-box-combobox">
              <div
                class="combobox-child combobox-content border-color-c"
                @click="handlerClickCombobox"
                check="false"
              >
                <div class="combobox-content-select combobox-child"
                 ref="valueColumnCustomerEmail" value="Exactly">Là</div>
                <div
                  class="
                    combobox-content-icon
                    button-icon-up-black
                    combobox-child
                    icon-font-16
                  "
                ></div>
              </div>

              <div
                class="combobox-child combobox-data filter-content-child-data"
              >
                <div
                  class="combobox-data-child filter-content-child-data-child"
                >
                  <div
                    class="combobox-data-child-content selected"
                    @click="handlerClickComboboxData"
                    value="Exactly"
                  >
                  <div class="combobox-data-child-content-text">
                      Là
                    </div>
                    <div
                      class="background-icon-checked icon-font-16" style="display:inline-block">
                     </div>
                  </div>
                  <div
                    class="combobox-data-child-content"
                    @click="handlerClickComboboxData"
                    value="Contain"
                  >
                  <div class="combobox-data-child-content-text">
                      Chứa
                    </div>
                    <div
                      class="background-icon-checked icon-font-16">
                     </div>
                  </div>
                </div>
              </div>
            </div>

            <div class="filter-content-child-box-text">
              <div class="border-input-content">
                <input type="text" class="input-content" v-model="listField.CustomerEmail.value" />
                <div class="input-icon-content">
                  <span class="icon-font-16 background-icon-close"></span>
                </div>
              </div>
            </div>
          </div>
        </div>

        <!-- <!- tổ chức -> -->
        <div class="filter-content-child">
          <div class="filter-content-child-checkbox">
            <div class="filter-content-child-checkbox-input">
              <input
                type="checkbox"
                id="organizationInput"
                class="trCheckboxFilter"
                value="organization"
              />
              <label
                for="organizationInput"
                class="background-icon-checked-table"
                @click="
                  listField.Organization.checkShow =
                    !listField.Organization.checkShow
                "
              ></label>
            </div>
            <div class="filter-content-child-checkbox-text">Tổ chức</div>
          </div>
          <div
            class="filter-content-child-box"
            v-if="listField.Organization.checkShow"
          >
            <!-- <!- content thẻ -> -->
            <div class="combobox filter-save filter-content-child-box-combobox">
              <div
                class="combobox-child combobox-content border-color-c"
                @click="handlerClickCombobox"
                check="false"
              >
                <div class="combobox-content-select combobox-child"
                 ref="valueColumnOrganization" value="Exactly">Là</div>
                <div
                  class="
                    combobox-content-icon
                    button-icon-up-black
                    combobox-child
                    icon-font-16
                  "
                ></div>
              </div>

              <div
                class="combobox-child combobox-data filter-content-child-data"
              >
                <div
                  class="combobox-data-child filter-content-child-data-child"
                >
                  <div
                    class="combobox-data-child-content selected"
                    @click="handlerClickComboboxData"
                    value="Exactly"
                  >
                  <div class="combobox-data-child-content-text">
                      Là
                    </div>
                    <div
                      class="background-icon-checked icon-font-16" style="display:inline-block">
                     </div>
                  </div>
                  <div
                    class="combobox-data-child-content"
                    @click="handlerClickComboboxData"
                    value="Contain"
                  >
                  <div class="combobox-data-child-content-text">
                      Chứa
                    </div>
                    <div
                      class="background-icon-checked icon-font-16">
                     </div>
                  </div>
                </div>
              </div>
            </div>

            <div class="filter-content-child-box-text">
              <div class="border-input-content">
                <input type="text" class="input-content" v-model="listField.Organization.value" />
                <div class="input-icon-content">
                  <span class="icon-font-16 background-icon-close"></span>
                </div>
              </div>
            </div>
          </div>
        </div>

        <!-- <!- Địa chỉ -> -->
        <div class="filter-content-child">
          <div class="filter-content-child-checkbox">
            <div class="filter-content-child-checkbox-input">
              <input
                type="checkbox"
                id="addressInput"
                class="trCheckboxFilter"
                value="address"
              />
              <label
                for="addressInput"
                class="background-icon-checked-table"
                @click="
                  listField.Address.checkShow = !listField.Address.checkShow
                "
              ></label>
            </div>
            <div class="filter-content-child-checkbox-text">Địa chỉ</div>
          </div>
          <div
            class="filter-content-child-box"
            v-if="listField.Address.checkShow"
          >
            <!-- <!- content thẻ -> -->
            <div class="combobox filter-save filter-content-child-box-combobox">
              <div
                class="combobox-child combobox-content border-color-c"
                @click="handlerClickCombobox"
                check="false"
              >
                <div class="combobox-content-select combobox-child"
                 ref="valueColumnAddress" value="Exactly">Là</div>
                <div
                  class="
                    combobox-content-icon
                    button-icon-up-black
                    combobox-child
                    icon-font-16
                  "
                ></div>
              </div>

              <div
                class="combobox-child combobox-data filter-content-child-data"
              >
                <div
                  class="combobox-data-child filter-content-child-data-child"
                >
                  <div
                    class="combobox-data-child-content selected"
                    @click="handlerClickComboboxData"
                    value="Exactly"
                  >
                  <div class="combobox-data-child-content-text">
                      Là
                    </div>
                    <div
                      class="background-icon-checked icon-font-16" style="display:inline-block">
                     </div>
                  </div>
                  <div
                    class="combobox-data-child-content"
                    @click="handlerClickComboboxData"
                    value="Contain"
                  >
                  <div class="combobox-data-child-content-text">
                      Chứa
                    </div>
                    <div
                      class="background-icon-checked icon-font-16">
                     </div>
                  </div>
                </div>
              </div>
            </div>

            <div class="filter-content-child-box-text">
              <div class="border-input-content">
                <input type="text" class="input-content" v-model="listField.Address.value" />
                <div class="input-icon-content">
                  <span class="icon-font-16 background-icon-close"></span>
                </div>
              </div>
            </div>
          </div>
        </div>
        <!-- Nguồn gốc-->
        <div class="filter-content-child">
          <div class="filter-content-child-checkbox">
            <div class="filter-content-child-checkbox-input">
              <input
                type="checkbox"
                id="sourceInput"
                class="trCheckboxFilter"
                value="source"
              />
              <label
                for="sourceInput"
                class="background-icon-checked-table"
                @click="
                  listField.Source.checkShow = !listField.Source.checkShow
                "
              ></label>
            </div>
            <div class="filter-content-child-checkbox-text">Nguồn gốc</div>
          </div>
          <div
            class="filter-content-child-box"
            v-if="listField.Source.checkShow"
          >
            <div
              class="combobox filter-save filter-content-child-box-combobox"
              id="source"
            >
              <div
                class="combobox-child combobox-content border-color-c"
                @click="handlerClickCombobox"
                check="false"
              >
                <div class="combobox-content-select combobox-child">Là</div>
                <div
                  class="
                    combobox-content-icon
                    button-icon-up-black
                    combobox-child
                    icon-font-16
                  "
                ></div>
              </div>

              <div
                class="combobox-child combobox-data filter-content-child-data"
                ref="source"
              >
                <!-- loading -->
                <div class="content-background-icon-loading">
                  <div class="background-icon-loading"></div>
                </div>
                <div
                  class="
                    combobox-data-search
                    filter-content-child-data-child
                    combobox-data-child-content-text
                  "
                >
                  <label class="label-input combobox-data-search-label">
                    <input
                      type="text"
                      class="input input-icon combobox-data-child-content-text"
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
                <div
                  class="combobox-data-child filter-content-child-data-child"
                >
                  <div
                    class="combobox-data-child-content"
                    v-for="v in source"
                    :key="v.sourceId"
                    @click="handlerClickComboboxData"
                    :value="v.sourceId"
                    :class="{
                      selected:
                        SourceMap.get(v.sourceId) != undefined
                          ? true
                          : false,
                    }"
                    id="filedSource"
                  >
                    <div class="combobox-data-child-content-text-filter">
                      {{ titleCase(v.sourceName) }}
                    </div>
                    <div
                      class="background-icon-checked icon-font-16"
                      :style="
                        SourceMap.get(v.sourceId) != undefined
                          ? 'display:inline-block'
                          : 'none'
                      "
                    ></div>
                  </div>
                </div>
              </div>
            </div>

            <div class="filter-content-child-box-textarea">
              <div
                class="filter-content-child-box-textarea-content border-color-c"
              >
                <div
                  class="combobox-content-select-content sourceValue"
                  v-for="v in SourceMap"
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
                      valueSourceMap
                    "
                    :value="v[0]"
                    @click="handlerClickComboboxDataClose"
                  ></div>
                </div>
              </div>
            </div>
          </div>
        </div>

        <!-- Start mã số thuế -->
        <div class="filter-content-child">
          <div class="filter-content-child-checkbox">
            <div class="filter-content-child-checkbox-input">
              <input
                type="checkbox"
                id="taxCodeInput"
                class="trCheckboxFilter"
                value="taxCode"
              />
              <label
                for="taxCodeInput"
                class="background-icon-checked-table"
                @click="
                  listField.TaxCode.checkShow = !listField.TaxCode.checkShow
                "
              ></label>
            </div>
            <div class="filter-content-child-checkbox-text">Mã số thuế</div>
          </div>
          <div
            class="filter-content-child-box"
            v-if="listField.TaxCode.checkShow"
          >
            <!-- <!- content thẻ -> -->
            <div class="combobox filter-save filter-content-child-box-combobox">
              <div
                class="combobox-child combobox-content border-color-c"
                @click="handlerClickCombobox"
                check="false"
              >
                <div class="combobox-content-select combobox-child"
                 ref="valueColumnTaxCode" value="Exactly">Là</div>
                <div
                  class="
                    combobox-content-icon
                    button-icon-up-black
                    combobox-child
                    icon-font-16
                  "
                ></div>
              </div>

              <div
                class="combobox-child combobox-data filter-content-child-data"
              >
                <div
                  class="combobox-data-child filter-content-child-data-child"
                >
                  <div
                    class="combobox-data-child-content selected"
                    @click="handlerClickComboboxData"
                    value="Exactly"
                  >
                  <div class="combobox-data-child-content-text">
                      Là
                    </div>
                    <div
                      class="background-icon-checked icon-font-16" style="display:inline-block">
                     </div>
                  </div>
                  <div
                    class="combobox-data-child-content"
                    @click="handlerClickComboboxData"
                    value="Contain"
                  >
                  <div class="combobox-data-child-content-text">
                      Chứa
                    </div>
                    <div
                      class="background-icon-checked icon-font-16">
                     </div>
                  </div>
                </div>
              </div>
            </div>

            <div class="filter-content-child-box-text">
              <div class="border-input-content">
                <input type="text" class="input-content" v-model="listField.TaxCode.value" />
                <div class="input-icon-content">
                  <span class="icon-font-16 background-icon-close"></span>
                </div>
              </div>
            </div>
          </div>
        </div>
        <!-- End mã số thuế -->

        <!-- doanh thu -->
        <div class="filter-content-child">
          <div class="filter-content-child-checkbox">
            <div class="filter-content-child-checkbox-input">
              <input
                type="checkbox"
                id="turnoverInput"
                class="trCheckboxFilter"
                value="turnover"
              />
              <label
                for="turnoverInput"
                class="background-icon-checked-table"
                @click="
                  listField.Turnover.checkShow = !listField.Turnover.checkShow
                "
              ></label>
            </div>
            <div class="filter-content-child-checkbox-text">Doanh thu</div>
          </div>
          <div
            class="filter-content-child-box"
            v-if="listField.Turnover.checkShow"
          >
            <div
              class="combobox filter-save filter-content-child-box-combobox"
              id="turnover"
            >
              <div
                class="combobox-child combobox-content border-color-c"
                @click="handlerClickCombobox"
                check="false"
              >
                <div class="combobox-content-select combobox-child">Là</div>
                <div
                  class="
                    combobox-content-icon
                    button-icon-up-black
                    combobox-child
                    icon-font-16
                  "
                ></div>
              </div>

              <div
                class="combobox-child combobox-data filter-content-child-data"
                ref="turnover"
              >
                <!-- loading -->
                <div class="content-background-icon-loading">
                  <div class="background-icon-loading"></div>
                </div>
                <div
                  class="
                    combobox-data-search
                    filter-content-child-data-child
                    combobox-data-child-content-text
                  "
                >
                  <label class="label-input combobox-data-search-label">
                    <input
                      type="text"
                      class="input input-icon combobox-data-child-content-text"
                      placeholder="Tìm kiếm"
                      v-on:keyup.enter="SearchTurnover"
                      v-model="searchTurnover"
                    />
                    <span
                      class="
                        background-icon-search-input
                        combobox-data-child-content-text
                      "
                      @click="SearchTurnover"
                    ></span>
                  </label>
                </div>
                <div
                  class="combobox-data-child filter-content-child-data-child"
                >
                  <div
                    class="combobox-data-child-content"
                    v-for="v in turnover"
                    :key="v.turnoverId"
                    @click="handlerClickComboboxData"
                    :value="v.turnoverId"
                    :class="{
                      selected:
                      TurnoverMap.get(v.turnoverId) != undefined
                          ? true
                          : false,
                    }"
                    id="filedTurnover"
                  >
                    <div class="combobox-data-child-content-text-filter">
                      {{ titleCase(v.turnoverName) }}
                    </div>
                    <div
                      class="background-icon-checked icon-font-16"
                      :style="
                        TurnoverMap.get(v.turnoverId) != undefined
                          ? 'display:inline-block'
                          : 'none'
                      "
                    ></div>
                  </div>
                </div>
              </div>
            </div>

            <div class="filter-content-child-box-textarea">
              <div
                class="filter-content-child-box-textarea-content border-color-c"
              >
                <div
                  class="combobox-content-select-content turnoverValue"
                  v-for="v in TurnoverMap"
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
                      valueTurnoverMap
                    "
                    :value="v[0]"
                    @click="handlerClickComboboxDataClose"
                  ></div>
                </div>
              </div>
            </div>
          </div>
        </div>


        <!-- Facebook -->
        <div class="filter-content-child">
          <div class="filter-content-child-checkbox">
            <div class="filter-content-child-checkbox-input">
              <input
                type="checkbox"
                id="facebookInput"
                class="trCheckboxFilter"
                value="facebook"
              />
              <label
                for="facebookInput"
                class="background-icon-checked-table"
                @click="
                  listField.Facebook.checkShow = !listField.Facebook.checkShow
                "
              ></label>
            </div>
            <div class="filter-content-child-checkbox-text">Facebook</div>
          </div>
          <div
            class="filter-content-child-box"
            v-if="listField.Facebook.checkShow"
          >
            <!-- <!- content thẻ -> -->
            <div class="combobox filter-save filter-content-child-box-combobox">
              <div
                class="combobox-child combobox-content border-color-c"
                @click="handlerClickCombobox"
                check="false"
              >
                <div class="combobox-content-select combobox-child"
                 ref="valueColumnFacebook" value="Exactly">Là</div>
                <div
                  class="
                    combobox-content-icon
                    button-icon-up-black
                    combobox-child
                    icon-font-16
                  "
                ></div>
              </div>

              <div
                class="combobox-child combobox-data filter-content-child-data"
              >
                <div
                  class="combobox-data-child filter-content-child-data-child"
                >
                  <div
                    class="combobox-data-child-content selected"
                    @click="handlerClickComboboxData"
                    value="Exactly"
                  >
                  <div class="combobox-data-child-content-text">
                      Là
                    </div>
                    <div
                      class="background-icon-checked icon-font-16" style="display:inline-block">
                     </div>
                  </div>
                  <div
                    class="combobox-data-child-content"
                    @click="handlerClickComboboxData"
                    value="Contain"
                  >
                  <div class="combobox-data-child-content-text">
                      Chứa
                    </div>
                    <div
                      class="background-icon-checked icon-font-16">
                     </div>
                  </div>
                </div>
              </div>
            </div>

            <div class="filter-content-child-box-text">
              <div class="border-input-content">
                <input type="text" class="input-content" v-model="listField.Facebook.value" />
                <div class="input-icon-content">
                  <span class="icon-font-16 background-icon-close"></span>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
      <div class="filter-bottom" v-if="FieldArr.length != 0 ? true : false">
        <button type="button" class="button button-background-primary"
        @click="handlerFilter">
          Áp dụng
        </button>
        <button type="button" class="button button-background-white"
        @click="hanlderClickCancelSelect">
          Bỏ chọn
        </button>
      </div>
    </div>
  </div>
</template>

<script>
import {
  ClickShowHideComboboxData,
  selectValueComboboxData,
} from "../../js/test";

// xử lý in hoa
import { titleCase } from "../../js/handlerString";

// nhúng status code
import { StatusCode } from "../Models/StatusCode";

// nhúng status code
import { PagingFilterEnum } from "../Models/PagingFilterEnum";

// nhúng service xử lý xưng hô
import { VocativeService } from "../Services/VocativeService";

// nhúng service xử lý loại doanh thu
import { TurnoverService } from "../Services/TurnoverService";

// nhúng service xử lý phòng ban
import { PositionsService } from "../Services/PositionsService";

// nhúng service xử lý Nguồn gốc
import { SourceService } from "../Services/SourceService";

// hàm xử lý hiển thị loading
import { UnLoading } from "../../js/Loading";

export default {
  name: "ContentPageLeft",
  data() {
    return {
      searchVocative: "",
      vocative: "",
      position: "",
      searchPosition: "",
      turnover: "",
      searchTurnover: "",
      source: "",
      searchSource: "",
      //  xưng hô
      VocativeMap: new Map(),
      // chuc danh
      PositionMap: new Map(),
      // nguon goc
      SourceMap: new Map(),
      // doanh thu
      TurnoverMap: new Map(),
      listField: {
        // xưng hô
        Vocative: {
          checkShow: false,
          value: [],
          type: "Exactly",
        },
        // họ và tên
        FullName: {
          checkShow: false,
          value: "",
          type: "Exactly",
        },
        // số đt cá nhân

        CustomerPhoneNumber: {
          checkShow: false,
          value: "",
          type: "Exactly",
        },
        // sđt công ty
        CompanyPhoneNumber: {
          checkShow: false,
          value: "",
          type: "Exactly",
        },
        //  email công ty
        CompanyEmail: {
          checkShow: false,
          value: "",
          type: "Exactly",
        },
        // email cas nhan
        CustomerEmail: {
          checkShow: false,
          value: "",
          type: "Exactly",
        },
        // tổ chức
        Organization: {
          checkShow: false,
          value: "",
          type: "Exactly",
        },
        // địa chỉ
        Address: {
          checkShow: false,
          value: "",
          type: "Exactly",
        },
        // chức danh
        Position: {
          checkShow: false,
          value: [],
          type: "Exactly",
        },
        // Doanh thu
        Turnover: {
          checkShow: false,
          value: [],
          type: "Exactly",
        },
        //nguồn gốc
        Source: {
          checkShow: false,
          value: [],
          type: "Exactly",
        },
        // mã số thuế
        TaxCode: {
          checkShow: false,
          value: "",
          type: "Exactly",
        },
        // facebook
        Facebook: {
          checkShow: false,
          value: "",
          type: "Exactly",
        },
      },
      FieldArr: [],
      PagingFilterExactlyModelChild:{
        Type:PagingFilterEnum.Exactly,
        Data: []
      },
      PagingFilterContainModelChild:{
        Type:PagingFilterEnum.Contain,
        Data: []
      },
      PagingFilterNotEmptyModelChild:{
        Type:PagingFilterEnum.NotEmpty,
        Data: []
      },   
      PagingFilterEmptyModelChild:{
        Type:PagingFilterEnum.Empty,
        Data: []
      },
      PagingDataModel:{
        cloumnName: "",
        value: []
      }
    };
  },
  props: {},
  watch: {
    "listField.Vocative.checkShow"(value) {
      this.handlerButtonFilter(value, "Vocative");
      if(value == false){
        this.VocativeMap.clear();
      }
    },
    "listField.FullName.checkShow"(value) {
      this.handlerButtonFilter(value, "FullName");
      if(value == false){
        this.listField.FullName.value=null;
      }
    },
    "listField.CustomerPhoneNumber.checkShow"(value) {
      this.handlerButtonFilter(value, "CustomerPhoneNumber");
    },
    "listField.CompanyPhoneNumber.checkShow"(value) {
      this.handlerButtonFilter(value, "CompanyPhoneNumber");
    },
    "listField.CompanyEmail.checkShow"(value) {
      this.handlerButtonFilter(value, "CompanyEmail");
      if(value == false){
        this.listField.CompanyEmail.value=null;
      }
    },
    "listField.CustomerEmail.checkShow"(value) {
      this.handlerButtonFilter(value, "CustomerEmail");
      if(value == false){
        this.listField.CustomerEmail.value=null;
      }
    },
    "listField.Organization.checkShow"(value) {
      this.handlerButtonFilter(value, "Organization");
      if(value == false){
        this.listField.Organization.value=null;
      }
    },
    "listField.Address.checkShow"(value) {
      this.handlerButtonFilter(value, "Address");
      if(value == false){
        this.listField.Address.value=null;
      }
    },
    "listField.Position.checkShow"(value) {
      this.handlerButtonFilter(value, "Position");
      if(value == false){
        this.PositionMap.clear();
      }
    },
    "listField.Turnover.checkShow"(value) {
      this.handlerButtonFilter(value, "Turnover");
      if(value == false){
        this.TurnoverMap.clear();
      }
    },
    "listField.Source.checkShow"(value) {
      this.handlerButtonFilter(value, "Source");
      if(value == false){
        this.SourceMap.clear();
      }
    },
    "listField.TaxCode.checkShow"(value) {
      this.handlerButtonFilter(value, "TaxCode");
      if(value == false){
        this.listField.TaxCode.value=null;
      }
    },
    "listField.Facebook.checkShow"(value) {
      this.handlerButtonFilter(value, "Facebook");
      if(value == false){
        this.listField.Facebook.value=null;
      }
    },
  },
  created() {},
  methods: {
    async ResetPagingDataModel(){
       // trả về giá trị ban đầu
      this.PagingDataModel={
        cloumnName: "",
        value: []
      } 
    },
    // XỬ lý lọc
    async handlerFilter(){
      // lấy dữ liệu xưng hô
      if(this.VocativeMap.size> 0){
        for(let item of this.VocativeMap){
          this.listField.Vocative.value.push(item[0]);
        }
      }

      // lấy dữ liệu chức danh
      if(this.PositionMap.size> 0){
        for(let item of this.PositionMap){
          this.listField.Position.value.push(item[0]);
        }
      }

      // lấy dữ liệu nguồn gốc
      if(this.SourceMap.size> 0){
        for(let item of this.SourceMap){
          this.listField.Source.value.push(item[0]);
        }
      }

      // lấy dữ liệu Doanh thu
      if(this.TurnoverMap.size> 0){
        for(let item of this.TurnoverMap){
          this.listField.Turnover.value.push(item[0]);
        }
      }


      if(this.$refs.valueColumnFullName!= null){
          if(this.$refs.valueColumnFullName.getAttribute("value"))
              this.listField.FullName.type = this.$refs.valueColumnFullName.getAttribute("value");
      }

      // lấy kiểu của các trường input
      if(this.$refs.valueColumnCustomerPhoneNumber!= null){
          if(this.$refs.valueColumnCustomerPhoneNumber.getAttribute("value"))
              this.listField.CustomerPhoneNumber.type = this.$refs.valueColumnCustomerPhoneNumber.getAttribute("value");
      }
   
      if(this.$refs.valueColumnCompanyPhoneNumber != null)    
        if(this.$refs.valueColumnCompanyPhoneNumber.getAttribute("value"))      
          this.listField.CompanyPhoneNumber.type = this.$refs.valueColumnCompanyPhoneNumber.getAttribute("value");
     
      if(this.$refs.valueColumnCompanyEmail!= null){
          if(this.$refs.valueColumnCompanyEmail.getAttribute("value"))
              this.listField.CompanyEmail.type = this.$refs.valueColumnCompanyEmail.getAttribute("value");
      }

      
      if(this.$refs.valueColumnCustomerEmail != null)
        if(this.$refs.valueColumnCustomerEmail.getAttribute("value"))           
          this.listField.CustomerEmail.type = this.$refs.valueColumnCustomerEmail.getAttribute("value");
      
      if(this.$refs.valueColumnOrganization != null)
        if(this.$refs.valueColumnOrganization.getAttribute("value"))           
          this.listField.Organization.type = this.$refs.valueColumnOrganization.getAttribute("value");
      
      if(this.$refs.valueColumnAddress != null)
        if(this.$refs.valueColumnAddress.getAttribute("value"))           
          this.listField.Address.type = this.$refs.valueColumnAddress.getAttribute("value");
      
      if(this.$refs.valueColumnTaxCode != null)
        if(this.$refs.valueColumnTaxCode.getAttribute("value"))           
          this.listField.TaxCode.type = this.$refs.valueColumnTaxCode.getAttribute("value");
      
      if(this.$refs.valueColumnFacebook != null)
        if(this.$refs.valueColumnFacebook.getAttribute("value"))           
          this.listField.Facebook.type = this.$refs.valueColumnFacebook.getAttribute("value");

      // laays ra list column, list value

      console.log(this.listField);

      // Start thêm vào object "là"| cloumn, value
      this.PagingFilterExactlyModelChild.Data = [];
      this.PagingFilterContainModelChild.Data = [];
      this.PagingFilterNotEmptyModelChild.Data = [];
      this.PagingFilterEmptyModelChild.Data = [];
      // Xưng hô
      if(this.VocativeMap.size > 0 && this.listField.Vocative.checkShow == true){
        this.PagingDataModel.cloumnName = "customer.VocativeId";
        for(let item of this.VocativeMap){
          this.PagingDataModel.value.push(item[0]);
        }
        this.PagingFilterExactlyModelChild.Data.push(this.PagingDataModel);
        await this.ResetPagingDataModel();
      }

       // chức danh
       if(this.PositionMap.size > 0 && this.listField.Position.checkShow == true){
        this.PagingDataModel.cloumnName = "customer.PositionId";
        for(let item of this.PositionMap){
          this.PagingDataModel.value.push(item[0]);
        }
        this.PagingFilterExactlyModelChild.Data.push(this.PagingDataModel);
        await this.ResetPagingDataModel();
      }

       // nguồn gốc
       if(this.SourceMap.size > 0 && this.listField.Source.checkShow == true){
        this.PagingDataModel.cloumnName = "customer.SourceId";
        for(let item of this.SourceMap){
          this.PagingDataModel.value.push(item[0]);
        }
        this.PagingFilterExactlyModelChild.Data.push(this.PagingDataModel);
        await this.ResetPagingDataModel();
      }

      // Doanh thu
      if(this.TurnoverMap.size > 0 && this.listField.Turnover.checkShow == true){
        this.PagingDataModel.cloumnName = "customer.TurnoverId";
        for(let item of this.TurnoverMap){
          this.PagingDataModel.value.push(item[0]);
        }
        this.PagingFilterExactlyModelChild.Data.push(this.PagingDataModel);
        await this.ResetPagingDataModel();
      }

      // End thêm vào object "là"| cloumn, value

      // kiểm tra fulname
      if(this.listField.FullName.checkShow == true){
        this.PagingDataModel.cloumnName = "customer.FullName";
        if(this.listField.FullName.value != ""){
          this.PagingDataModel.value.push(this.listField.FullName.value);
          if(this.listField.FullName.type == "Exactly"){
            this.PagingFilterExactlyModelChild.Data.push(this.PagingDataModel);
          }else{
            // chứa
            this.PagingFilterContainModelChild.Data.push(this.PagingDataModel);
          }
        }
        
        await this.ResetPagingDataModel();
      }

      // kiểm tra Email cơ quan
      if(this.listField.CompanyEmail.checkShow == true){
        this.PagingDataModel.cloumnName = "customer.CompanyEmail";
        if(this.listField.CompanyEmail.value != ""){
          this.PagingDataModel.value.push(this.listField.CompanyEmail.value);
          // là
          if(this.listField.CompanyEmail.type == "Exactly"){
            this.PagingFilterExactlyModelChild.Data.push(this.PagingDataModel);
          }else{
            // chứa
            this.PagingFilterContainModelChild.Data.push(this.PagingDataModel);
          }
        }
      
        await this.ResetPagingDataModel();
      }

       // kiểm tra Email cá nhân
       if(this.listField.CustomerEmail.checkShow == true){
        this.PagingDataModel.cloumnName = "customer.CustomerEmail";
        if(this.listField.CustomerEmail.value != null){
          this.PagingDataModel.value.push(this.listField.CustomerEmail.value)
          // là
          if(this.listField.CustomerEmail.type == "Exactly"){
            this.PagingFilterExactlyModelChild.Data.push(this.PagingDataModel);
          }else{
            // chứa
            this.PagingFilterContainModelChild.Data.push(this.PagingDataModel);
          }
        }
        
        await this.ResetPagingDataModel();
      }

       // kiểm tra Tổ chức
       if(this.listField.Organization.checkShow == true){
        this.PagingDataModel.cloumnName = "customer.Organization";
        if(this.listField.Organization.value != null){
          this.PagingDataModel.value.push(this.listField.Organization.value)
          // là
          if(this.listField.Organization.type == "Exactly"){
            this.PagingFilterExactlyModelChild.Data.push(this.PagingDataModel);
          }else{
            // chứa
            this.PagingFilterContainModelChild.Data.push(this.PagingDataModel);
          }
        }
        
        await this.ResetPagingDataModel();
      }

       // kiểm tra Địa chỉ
       if(this.listField.Address.checkShow == true){
        this.PagingDataModel.cloumnName = "customer.Address";
        if(this.listField.Address.value != ""){
          this.PagingDataModel.value.push(this.listField.Address.value)
          // là
          if(this.listField.Address.type == "Exactly"){
            this.PagingFilterExactlyModelChild.Data.push(this.PagingDataModel);
          }else{
            // chứa
            this.PagingFilterContainModelChild.Data.push(this.PagingDataModel);
          }
        }
        
        await this.ResetPagingDataModel();
      }

       // kiểm tra Mã số thuế
       if(this.listField.TaxCode.checkShow == true){
        this.PagingDataModel.cloumnName = "customer.TaxCode";
        if(this.listField.TaxCode.value != ""){
          this.PagingDataModel.value.push(this.listField.TaxCode.value)
          // là
          if(this.listField.TaxCode.type == "Exactly"){
            this.PagingFilterExactlyModelChild.Data.push(this.PagingDataModel);
          }else{
            // chứa
            this.PagingFilterContainModelChild.Data.push(this.PagingDataModel);
          }
        }
        
        await this.ResetPagingDataModel();
      }

       // kiểm tra Mã số thuế
       if(this.listField.Facebook.checkShow == true){
        this.PagingDataModel.cloumnName = "customer.Facebook";
        if(this.listField.Facebook.value != null){
          this.PagingDataModel.value.push(this.listField.Facebook.value)
          // là
          if(this.listField.Facebook.type == "Exactly"){
            this.PagingFilterExactlyModelChild.Data.push(this.PagingDataModel);
          }else{
            // chứa
            this.PagingFilterContainModelChild.Data.push(this.PagingDataModel);
          }
        }
       
        await this.ResetPagingDataModel();
      }

       // kiểm tra Điện thoại cá nhân
       if(this.listField.CustomerPhoneNumber.checkShow == true){
        this.PagingDataModel.cloumnName = "customer.CustomerPhoneNumber";
        this.PagingDataModel.value.push(this.listField.CustomerPhoneNumber.value)
        // null
        console.log(this.listField.CustomerPhoneNumber.type)
        if(this.listField.CustomerPhoneNumber.type == "Empty"){
          this.PagingFilterEmptyModelChild.Data.push(this.PagingDataModel);
        }else{
          // không trống
          this.PagingFilterNotEmptyModelChild.Data.push(this.PagingDataModel);
        }
        await this.ResetPagingDataModel();
      }

       // kiểm tra Điện thoại công ty
       if(this.listField.CompanyPhoneNumber.checkShow == true){
        this.PagingDataModel.cloumnName = "customer.CompanyPhoneNumber";
        this.PagingDataModel.value.push(this.listField.CompanyPhoneNumber.value)
        // null
        console.log(this.listField.CompanyPhoneNumber.type)
        if(this.listField.CompanyPhoneNumber.type == "Empty"){
          this.PagingFilterEmptyModelChild.Data.push(this.PagingDataModel);
        }else{
          // không trống
          this.PagingFilterNotEmptyModelChild.Data.push(this.PagingDataModel);
        }
        await this.ResetPagingDataModel();
      }


      console.log(this.PagingFilterExactlyModelChild)
      console.log(this.PagingFilterContainModelChild)
      console.log(this.PagingFilterNotEmptyModelChild)
      console.log(this.PagingFilterEmptyModelChild)

      let ArrayObjectData = [];
      if(this.PagingFilterExactlyModelChild.Data.length > 0){
        ArrayObjectData.push(this.PagingFilterExactlyModelChild);
      }
      if(this.PagingFilterContainModelChild.Data.length > 0){
        ArrayObjectData.push(this.PagingFilterContainModelChild);
      }
      if(this.PagingFilterNotEmptyModelChild.Data.length > 0){
        ArrayObjectData.push(this.PagingFilterNotEmptyModelChild);
      }
      if(this.PagingFilterEmptyModelChild.Data.length > 0){
        ArrayObjectData.push(this.PagingFilterEmptyModelChild);
      }

      console.log(ArrayObjectData);
      this.$emit("ArrayObjectData",ArrayObjectData);
    },

    // xử lý bỏ chọn
    hanlderClickCancelSelect(){
      this.FieldArr.splice(0,this.FieldArr.length);
      this.listField = {
        // xưng hô
        Vocative: {
          checkShow: false,
          value: null,
          type: "",
        },
        // họ và tên
        FullName: {
          checkShow: false,
          value: null,
          type: "",
        },
        // số đt cá nhân
        CustomerPhoneNumber: {
          checkShow: false,
          value: null,
          type: "",
        },
        // sđt công ty
        CompanyPhoneNumber: {
          checkShow: false,
          value: null,
          type: "",
        },
        //  email công ty
        CompanyEmail: {
          checkShow: false,
          value: null,
          type: "",
        },
        // email cas nhan
        CustomerEmail: {
          checkShow: false,
          value: null,
          type: "",
        },
        // tổ chức
        Organization: {
          checkShow: false,
          value: null,
          type: "",
        },
        // địa chỉ
        Address: {
          checkShow: false,
          value: null,
          type: "",
        },
        // chức danh
        Position: {
          checkShow: false,
          value: null,
          type: "",
        },
        // Doanh thu
        Turnover: {
          checkShow: false,
          value: null,
          type: "",
        },
        //nguồn gốc
        Source: {
          checkShow: false,
          value: null,
          type: "",
        },
        // mã số thuế
        TaxCode: {
          checkShow: false,
          value: null,
          type: "",
        },
        // facebook
        Facebook: {
          checkShow: false,
          value: null,
          type: "",
        },
      }

      let Els =  document.getElementsByClassName("trCheckboxFilter");
      if(Els.length >0){
        for(let i=0;i<Els.length;i++){
          if(Els[i]){
            if(Els[i].checked == true)
            Els[i].checked = false;
          }
        }
      }

      //  gửi dữ liệu mảng rỗng đi
      this.$emit("ArrayObjectData",[]);

    },

    // xử lý close value
    handlerClickComboboxDataClose(event){
      let El = event.target;

      console.log(El)

      // // xưng hô
      if(El.classList.contains("valueVocativeMap")){
          let value =  El.getAttribute("value");
          if(value){
            if(this.VocativeMap.get(value))
              this.VocativeMap.delete(value)
            console.log(this.VocativeMap)
          }
      }
      
      // // chức danh
      if(El.classList.contains("valuePositionMap")){
          let value =  El.getAttribute("value");
          if(value){
            if(this.PositionMap.get(value))
              this.PositionMap.delete(value)
            console.log(this.PositionMap)
          }
      }

      //  // Nguồn gốc
      if(El.classList.contains("valueSourceMap")){
          let value =  El.getAttribute("value");
          if(value){
            if(this.SourceMap.get(value))
              this.SourceMap.delete(value)
            console.log(this.SourceMap)
          }
      }

      //  // Doanh thu
      if(El.classList.contains("valueTurnoverMap")){
          let value =  El.getAttribute("value");
          if(value){
            if(this.TurnoverMap.get(value))
              this.TurnoverMap.delete(value)
            console.log(this.TurnoverMap)
          }
      }

    },

    // xử lý in hoa
    titleCase,

    //  xử lý nút lọc
    handlerButtonFilter(value, column) {
      if (value == true) {
        this.FieldArr.push(column);
      } else {
        let item = this.FieldArr.filter((item) => item != column);
        this.FieldArr = item;
      }

      if (this.FieldArr.length != 0) {
        this.$refs.filterContent.style.height =
          "calc(100vh - 84px -  64px - 32px - 32px - 56px)";
      } else {
        this.$refs.filterContent.style.height =
          "calc(100vh - 84px -  64px - 32px - 32px)";
      }
    },

    // xử lý tìm kiếm xưng hô
    async SearchVocative() {
      let _VocativeService = new VocativeService();
      await _VocativeService.getByName(this.searchVocative).then((res) => {
        if (res.statusCode == StatusCode.GetSuccess) {
          this.vocative = res.data;
        }
      });
    },

    // xử lý tìm kiếm Chức danh
    async SearchPosition() {
      let _PositionService = new PositionsService();
      await _PositionService.getByName(this.searchPosition).then((res) => {
        console.log(res);
        if (res.statusCode == StatusCode.GetSuccess) {
          this.position = res.data;
        }
      });
    },

    // xử lý tìm kiếm nguồn gốc
    async SearchSource() {
      let _SearchSource = new SourceService();
      await _SearchSource.getByName(this.searchSource).then((res) => {
        console.log(res);
        if (res.statusCode == StatusCode.GetSuccess) {
          this.source = res.data;
        }
      });
    },

    // xử lý tìm kiếm doanh thu
    async SearchTurnover() {
      let _TurnoverService = new TurnoverService();
      await _TurnoverService.getByName(this.searchTurnover).then((res) => {
        console.log(res);
        if (res.statusCode == StatusCode.GetSuccess) {
          this.turnover = res.data;
        }
      });
    },

    /**
     * function:  xử lý lấy dữ liệu vocative
     */
    async HandlerSelectVocative() {
      if (!this.vocative) {
        let _VocativeService = new VocativeService();
        await _VocativeService.getAll().then((res) => {
          if (res) this.vocative = res;
        });
        UnLoading(this.$refs.vocative);
      } else UnLoading(this.$refs.vocative);
    },

    /**
     * function:  xử lý lấy dữ liệu chuc danh
     */
    async HandlerSelectPosition() {
      if (!this.position) {
        let _PositionsService = new PositionsService();
        await _PositionsService.getAll().then((res) => {
          if (res) this.position = res;
        });
        UnLoading(this.$refs.position);
      } else UnLoading(this.$refs.position);
    },

    /**
     * function:  xử lý lấy dữ liệu source: nguồn gốc
     */
    async HandlerSelectSource() {
      if (!this.source) {
        let _SourceService = new SourceService();
        await _SourceService.getAll().then((res) => {
          if (res) this.source = res;
        });
        UnLoading(this.$refs.source);
      } else UnLoading(this.$refs.source);
    },

    /**
     * Author: Phạm Văn Đạt
     * function:  xử lý lấy dữ liệu doanh thu
     * created time: 15:28 17/08/2022
     */
    async HandlerSelectTurnover() {
      if (!this.turnover) {
        let _TurnoverService = new TurnoverService();
        await _TurnoverService.getAll().then((res) => {
          console.log(res);
          if (res) this.turnover = res;
        });
        UnLoading(this.$refs.turnover);
      } else UnLoading(this.$refs.turnover);
    },

    // xử lý click combobox hiển thị - ẩn
    handlerClickCombobox: function (event) {
      let El = event.target.parentNode;
      // xử lý lấy dữ liêuj

      // Xwng hoo
      if (
        El.getAttribute("id") == "vocative" ||
        El.parentNode.getAttribute("id") == "vocative"
      ) {
        console.log("lay du lieu");
        /// lấy thông tin xưng hô nếu chưa có dữ liệu
        this.HandlerSelectVocative();
      }

      // Chuc danh
      if (
        El.getAttribute("id") == "position" ||
        El.parentNode.getAttribute("id") == "position"
      ) {
        console.log("lay du lieu");
        /// lấy thông tin chuc danh nếu chưa có dữ liệu
        this.HandlerSelectPosition();
      }

      // nguon goc
      if (
        El.getAttribute("id") == "source" ||
        El.parentNode.getAttribute("id") == "source"
      ) {
        console.log("lay du lieu");
        /// lấy thông tin nguon goc nếu chưa có dữ liệu
        this.HandlerSelectSource();
      }
      // doanh thu
      if (
        El.getAttribute("id") == "turnover" ||
        El.parentNode.getAttribute("id") == "turnover"
      ) {
        console.log("lay du lieu");
        /// lấy thông tin doanh thu nếu chưa có dữ liệu
        this.HandlerSelectTurnover();
      }

      ClickShowHideComboboxData(event);
    },
    // xử lý click lấy thông tin tronc combobox
    handlerClickComboboxData: function (event) {
     
      let El = event.target;
      if (El.getAttribute("id") == null) El = El.parentNode;

      // lấy id
      let IdElment = El.getAttribute("id");

      // lấy value
      let ValueElement =
        El.getAttribute("value") != null ? El.getAttribute("value") : null;

      // lấy nội dung
      let ElContent = El.getElementsByClassName("combobox-data-child-content-text-filter")[0];
      let InnerHtmlElement = null;
      if (ElContent)
        InnerHtmlElement = ElContent.innerHTML != null ? ElContent.innerHTML : null;
      else{
        selectValueComboboxData(event);
      }

        // Xưng hô
      if (ValueElement != null && InnerHtmlElement != null) {
        if (IdElment == "filedVocative") {
          if (!this.VocativeMap.get(ValueElement))
            this.VocativeMap.set(ValueElement, InnerHtmlElement);
          else {
            this.VocativeMap.delete(ValueElement, InnerHtmlElement);
          }
        }
      }

        // Chức danh
        if (ValueElement != null && InnerHtmlElement != null) {
        if (IdElment == "filedPosition") {
          if (!this.PositionMap.get(ValueElement))
            this.PositionMap.set(ValueElement, InnerHtmlElement);
          else {
            this.PositionMap.delete(ValueElement, InnerHtmlElement);
          }
          console.log(this.PositionMap);
        }
      }

      // Nguồn gốc
      if (ValueElement != null && InnerHtmlElement != null) {
        if (IdElment == "filedSource") {
          if (!this.SourceMap.get(ValueElement))
            this.SourceMap.set(ValueElement, InnerHtmlElement);
          else {
            this.SourceMap.delete(ValueElement, InnerHtmlElement);
          }
          console.log(this.SourceMap);
        }
      }

       // Doanh thu
       if (ValueElement != null && InnerHtmlElement != null) {
        if (IdElment == "filedTurnover") {
          if (!this.TurnoverMap.get(ValueElement))
            this.TurnoverMap.set(ValueElement, InnerHtmlElement);
          else {
            this.TurnoverMap.delete(ValueElement, InnerHtmlElement);
          }
          console.log(this.TurnoverMap);
        }
      }


    },
  },
};
</script>

<style>
</style>