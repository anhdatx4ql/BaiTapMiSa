<template>
  <div class="form-container" v-if="checkShowFormData">
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
                  <div class="combobox">
                    <div
                      class="combobox-child combobox-content" id="vocative"
                      @click="handlerClickCombobox"
                      check="false"
                    >
                      <div class="combobox-content-select">- Không chọn -</div>
                      <div
                        class="
                          combobox-content-icon
                          button-icon-up-black
                          icon-font-16
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
                          value=""
                        >
                          - Không chọn -
                        </div>
                        <div
                          class="combobox-data-child-content"
                          v-for="v in vocative"
                          :key="v.vocativeId"
                          @click="handlerClickComboboxData"
                          :value="v.vocativeId"
                        >
                          {{ titleCase(v.vocativeName) }}
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
                  <input type="text" class="input-content" />
                </div>
              </div>
              <!-- End Họ và đệm -->

              <!-- Start Tên -->
              <div class="form-container-content-child-item">
                <div class="form-container-content-child-item-label">
                  Tên <span class="not-required">*</span>
                </div>
                <div class="form-container-content-child-item-input">
                  <input type="text" class="input-content" />
                  <span class="span-error">Tên không được để trống</span>
                </div>
              </div>
              <!-- End Tên -->

              <!-- Start Họ và tên  -->
              <div class="form-container-content-child-item">
                <div class="form-container-content-child-item-label">
                  Họ và tên
                </div>
                <div class="form-container-content-child-item-input">
                  <input
                    type="text"
                    class="input-content disabled-input"
                    disabled
                  />
                </div>
              </div>
              <!-- End họ và tên -->

              <!-- Start Phòng ban -->
             <div class="form-container-content-child-item">
                <div class="form-container-content-child-item-label">
                  Phòng ban
                </div>
                <div class="form-container-content-child-item-input">
                  <div class="combobox">
                    <div
                      class="combobox-child combobox-content" id="department"
                      @click="handlerClickCombobox"
                      check="false"
                    >
                      <div class="combobox-content-select">- Không chọn -</div>
                      <div
                        class="
                          combobox-content-icon
                          button-icon-up-black
                          icon-font-16
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
                          value=""
                        >
                          - Không chọn -
                        </div>
                        <div
                          class="combobox-data-child-content"
                          v-for="v in department"
                          :key="v.departmentId"
                          @click="handlerClickComboboxData"
                          :value="v.departmentId"
                        >
                          {{ titleCase(v.departmentName) }}
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
                  <div class="combobox">
                    <div
                      class="combobox-child combobox-content" id="position"
                      @click="handlerClickCombobox"
                      check="false"
                    >
                      <div class="combobox-content-select">- Không chọn -</div>
                      <div
                        class="
                          combobox-content-icon
                          button-icon-up-black
                          icon-font-16
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
                          value=""
                        >
                          - Không chọn -
                        </div>
                        <div
                          class="combobox-data-child-content"
                          v-for="v in position"
                          :key="v.positionId"
                          @click="handlerClickComboboxData"
                          :value="v.positionId"
                        >
                          {{ titleCase(v.positionName) }}
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
                  <input type="text" class="input-content" />
                </div>
              </div>
              <!-- End ĐT di động -->

              <!-- Start Đt cơ quan -->
              <div class="form-container-content-child-item">
                <div class="form-container-content-child-item-label">
                  ĐT di động
                </div>
                <div class="form-container-content-child-item-input">
                  <input type="text" class="input-content" />
                </div>
              </div>
              <!-- End ĐT cơ quan-->

              <!-- Start Nguồn gốc -->
               <div class="form-container-content-child-item">
                <div class="form-container-content-child-item-label">
                  Nguồn gốc
                </div>
                <div class="form-container-content-child-item-input">
                  <div class="combobox">
                    <div
                      class="combobox-child combobox-content" id="source"
                      @click="handlerClickCombobox"
                      check="false"
                    >
                      <div class="combobox-content-select">- Không chọn -</div>
                      <div
                        class="
                          combobox-content-icon
                          button-icon-up-black
                          icon-font-16
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
                          value=""
                        >
                          - Không chọn -
                        </div>
                        <div
                          class="combobox-data-child-content"
                          v-for="v in source"
                          :key="v.sourceId"
                          @click="handlerClickComboboxData"
                          :value="v.sourceId"
                        >
                          {{ titleCase(v.sourceName) }}
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
                  <div class="combobox combobox-mul">
                    <div
                      class="combobox-child combobox-content" id="potentialType"
                      @click="handlerClickComboboxMul"
                      check="false"
                    >
                      <div class="combobox-content-select">- Không chọn -</div>
                    </div>

                    <div class="combobox-child combobox-data" ref="potentialType">
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
                          @click="selectValueComboboxMulData"
                          value="- Không chọn -"
                        >
                          - Không chọn -
                        </div>
                        <div
                          class="combobox-data-child-content"
                           v-for="v in potentialType"
                          :key="v.potentialTypeId"
                          :value="v.potentialTypeId"
                          @click="selectValueComboboxMulData"
                        >
                          {{titleCase(v.potentialTypeName)}}
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
                  <input type="text" class="input-content" />
                </div>
              </div>
              <!-- End Zalo -->

              <!-- Start Email cá nhân -->
              <div class="form-container-content-child-item">
                <div class="form-container-content-child-item-label">
                  Email cá nhân
                </div>
                <div class="form-container-content-child-item-input">
                  <input type="text" class="input-content" />
                </div>
              </div>
              <!-- EndEmail cá nhân -->

              <!-- Start cơ quan-->
              <div class="form-container-content-child-item">
                <div class="form-container-content-child-item-label">
                  Email cơ quan
                </div>
                <div class="form-container-content-child-item-input">
                  <input type="text" class="input-content" />
                </div>
              </div>
              <!-- EndEmail cơ quan-->

              <!-- Start tổ chức -->
              <div class="form-container-content-child-item">
                <div class="form-container-content-child-item-label">
                  Tổ chức
                </div>
                <div class="form-container-content-child-item-input">
                  <input type="text" class="input-content" />
                </div>
              </div>
              <!-- End Tổ chức-->

              <!-- Start Mã số thuế-->
              <div class="form-container-content-child-item">
                <div class="form-container-content-child-item-label">
                  Mã số thuế
                </div>
                <div class="form-container-content-child-item-input">
                  <input type="text" class="input-content" />
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
                  <input type="text" class="input-content input-error" />
                  <span class="span-error">Tên không được để trống</span>
                </div>
              </div>
              <!-- End Tài khoản ngân hàng -->

              <!-- Start Mở tại ngân hàng -->
              <div class="form-container-content-child-item">
                <div class="form-container-content-child-item-label">
                  Mở tại ngân hàng
                </div>
                <div class="form-container-content-child-item-input">
                  <input type="text" class="input-content" />
                </div>
              </div>
              <!-- End Mở tại ngân hàng-->

              <!-- Start Ngày thành lập -->
              <div class="form-container-content-child-item">
                <div class="form-container-content-child-item-label">
                  Ngày thành lập
                </div>
                <div class="form-container-content-child-item-input">
                  <input type="date" class="input-content" />
                </div>
              </div>
              <!-- End Ngày thành lập -->

              <!-- Start Loại hình  -->
              <div class="form-container-content-child-item">
                <div class="form-container-content-child-item-label">
                  Loại hình
                </div>
                <div class="form-container-content-child-item-input">
                  <input
                    type="text"
                    class="input-content disabled-input"
                    disabled
                  />
                </div>
              </div>
              <!-- End Loại hình -->

              <!-- Start Lĩnh vực -->
              <div class="form-container-content-child-item">
                <div class="form-container-content-child-item-label">
                  Lĩnh vực
                </div>
                <div class="form-container-content-child-item-input">
                  <div class="combobox">
                    <div
                      class="combobox-child combobox-content"
                      @click="handlerClickCombobox"
                      check="false"
                    >
                      <div class="combobox-content-select">- Không chọn -</div>
                      <div
                        class="
                          combobox-content-icon
                          button-icon-up-black
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
              <!-- End Lĩnh vực -->

              <!--Start Ngành nghề -->
              <div class="form-container-content-child-item">
                <div class="form-container-content-child-item-label">
                  Ngành nghề
                </div>
                <div class="form-container-content-child-item-input">
                  <div class="combobox">
                    <div
                      class="combobox-child combobox-content"
                      @click="handlerClickCombobox"
                      check="false"
                    >
                      <div class="combobox-content-select">- Không chọn -</div>
                      <div
                        class="
                          combobox-content-icon
                          button-icon-up-black
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
              <!-- END Ngành nghề -->

              <!-- Start Doanh thu-->
             <div class="form-container-content-child-item">
                <div class="form-container-content-child-item-label">
                  Doanh thu
                </div>
                <div class="form-container-content-child-item-input">
                  <div class="combobox">
                    <div
                      class="combobox-child combobox-content" id="turnover"
                      @click="handlerClickCombobox"
                      check="false"
                    >
                      <div class="combobox-content-select">- Không chọn -</div>
                      <div
                        class="
                          combobox-content-icon
                          button-icon-up-black
                          icon-font-16
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
                          value=""
                        >
                          - Không chọn -
                        </div>
                        <div
                          class="combobox-data-child-content"
                          v-for="v in turnover"
                          :key="v.turnoverId"
                          @click="handlerClickComboboxData"
                          :value="v.turnoverId"
                        >
                          {{ titleCase(v.turnoverName) }}
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
                      <div class="combobox-content-select">- Không chọn -</div>
                      <div
                        class="
                          combobox-content-icon
                          button-icon-up-black
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
                      <div class="combobox-content-select">- Không chọn -</div>
                      <div
                        class="
                          combobox-content-icon
                          button-icon-up-black
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
                      <div class="combobox-content-select">- Không chọn -</div>
                      <div
                        class="
                          combobox-content-icon
                          button-icon-up-black
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
                      <div class="combobox-content-select">- Không chọn -</div>
                      <div
                        class="
                          combobox-content-icon
                          button-icon-up-black
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
                  <input type="text" class="input-content" />
                </div>
              </div>
              <!-- End Số nhà, Đường phố-->

              <!-- Start Mã vùng -->
              <div class="form-container-content-child-item">
                <div class="form-container-content-child-item-label">
                  Mã vùng
                </div>
                <div class="form-container-content-child-item-input">
                  <input type="text" class="input-content" />
                </div>
              </div>
              <!-- Mã vùng -->

              <!-- Start Địa chỉ -->
              <div class="form-container-content-child-item">
                <div class="form-container-content-child-item-label">
                  Mã vùng
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
              <!-- Start dùng chung-->
              <div
                class="
                  form-container-content-child-item form-container-description
                "
              >
                <div class="form-container-content-child-item-label">
                  Dùng chung
                </div>
                <div class="form-container-content-child-item-input">
                  <input type="checkbox" />
                </div>
              </div>
              <!-- End dùng chung -->

              <!-- Start Mã tiềm năng -->
              <div class="form-container-content-child-item">
                <div class="form-container-content-child-item-label">
                  Mã tiềm năng
                </div>
                <div class="form-container-content-child-item-input">
                  <input type="text" class="input-content" />
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
import { PotentialTypeService  } from "../Services/PotentialTypeService";

// nhúng service xử lý loại doanh thu
import { TurnoverService  } from "../Services/TurnoverService";

// nhúng service xử lý loại doanh thu
import { CarrerService  } from "../Services/CarrerService";


 

export default {
  name: "FormDataComponent",
  components: {},
  created() {},
  props: {
    checkShowFormData: Boolean,
    CustomerInfo: {},
  },
  data() {
    return {
      vocative: "",
      department:  "",
      position: "",
      source:"",
      potentialType:"",
      turnover:"",
      carrer:""
    };
  },
  watch: {

    // theo dõi thông tin khách hàng
    CustomerInfo() {
      console.log(this.CustomerInfo);
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
    source(){
      console.log(this.$refs.source);
      UnLoading(this.$refs.source);
    },
    
    //  theo dõi thông tin loại chức danh
     potentialType(){
      UnLoading(this.$refs.potentialType);
    },

    // theo dõi thông tin doanh thu
     turnover(){
      UnLoading(this.$refs.turnover);
    },

    //  theo dõi thông tin ngành nghề
    carrer(){
      console.log(this.$refs.carrer);
      UnLoading(this.$refs.carrer);
    }
    
  },
  methods: {

    titleCase,

    /**
     * Author: Phạm Văn Đạt
     * function:  xử lý đóng form data
     * created time: 11:28 17/08/2022
     */
    HandlerCloseForm() {
      try {
        this.$emit("CloseFormData", !this.checkShowFormData);
      } catch (error) {
        console.log(error);
      }
    },

    /**
     * Author: Phạm Văn Đạt
     * function:  xử lý lấy dữ liệu vocative
     * created time: 11:28 17/08/2022
     */
    HandlerSelectVocative(){
        if(!this.vocative){
            let _VocativeService = new VocativeService();
            _VocativeService
              .getAll()
              .then((res) => {
                if (res.data.data) this.vocative = res.data.data;
                console.log(this.vocative)
              })
              .catch((e) => {
                console.log(e);
              });
          }
    },

    /**
     * Author: Phạm Văn Đạt
     * function:  xử lý lấy dữ liệu vocative
     * created time: 15:28 17/08/2022
     */
    HandlerSelectDepartment(){
        if(!this.department){
            let _DepartmentService = new DepartmentService();
            _DepartmentService
              .getAll()
              .then((res) => {
                if (res.data.data) this.department = res.data.data;
              })
              .catch((e) => {
                console.log(e);
              });
          }
    },

    /**
     * Author: Phạm Văn Đạt
     * function:  xử lý lấy dữ liệu vocative
     * created time: 15:28 17/08/2022
     */
    HandlerSelectPosition(){
        if(!this.department){
            let _PositionsService = new PositionsService();
            _PositionsService
              .getAll()
              .then((res) => {
                if (res.data.data) this.position = res.data.data;
              })
              .catch((e) => {
                console.log(e);
              });
          }
    },
    
    /**
     * Author: Phạm Văn Đạt
     * function:  xử lý lấy dữ liệu source: nguồn gốc
     * created time: 15:28 17/08/2022
     */
    HandlerSelectSource(){
        if(!this.department){
            let _SourceService = new SourceService();
            _SourceService
              .getAll()
              .then((res) => {
                if (res.data.data) this.source = res.data.data;
              })
              .catch((e) => {
                console.log(e);
              });
          }
    },

    /**
     * Author: Phạm Văn Đạt
     * function:  xử lý lấy dữ liệu potential
     * created time: 15:28 17/08/2022
     */
    HandlerSelectPotentialType(){
        if(!this.potentialType){
            let _PotentialTypeService = new PotentialTypeService();
            _PotentialTypeService
              .getAll()
              .then((res) => {
                if (res.data.data) this.potentialType = res.data.data;
              })
              .catch((e) => {
                console.log(e);
              });
          }
    },

    /**
     * Author: Phạm Văn Đạt
     * function:  xử lý lấy dữ liệu doanh thu
     * created time: 15:28 17/08/2022
     */
    HandlerSelectTurnover(){
        if(!this.potentialType){
            let _TurnoverService = new TurnoverService();
            _TurnoverService
              .getAll()
              .then((res) => {
                if (res.data.data) this.turnover = res.data.data;
              })
              .catch((e) => {
                console.log(e);
              });
          }
    },

    /**
     * Author: Phạm Văn Đạt
     * function:  xử lý lấy dữ liệu ngành nghề
     * created time: 00:41 28 18/08/2022
     */
    HandlerSelectCarrer(){
        if(!this.potentialType){
            let _CarrerService = new CarrerService();
            _CarrerService
              .getAll()
              .then((res) => {
                if (res.data.data) this.carrer = res.data.data;
              })
              .catch((e) => {
                console.log(e);
              });
          }
    },
    
    
     /**
     * Author: Phạm Văn Đạt
     * function:  xử lý đóng form data
     * created time: 11:28 17/08/2022
     */
    handlerClickCombobox: async function (event) {
      try {

        // Nếu click vào combobox xưng hô: nếu chưa có dữ liệu thì loading, nếu có dữ liệu rồi thì không loading
        if(event.target.getAttribute("id") == "vocative"){
          /// lấy thông tin xưng hô nếu chưa có dữ liệu
          this.HandlerSelectVocative();
        }

         // Nếu click vào combobox phòng ban: nếu chưa có dữ liệu thì loading, nếu có dữ liệu rồi thì không loading
        if(event.target.getAttribute("id") == "department"){
          /// lấy thông tin phòng ban nếu chưa có dữ liệu
          this.HandlerSelectDepartment();
        }

         // Nếu click vào combobox chức danh: nếu chưa có dữ liệu thì loading, nếu có dữ liệu rồi thì không loading
        if(event.target.getAttribute("id") == "position"){
          /// lấy thông tin phòng ban nếu chưa có dữ liệu
          this.HandlerSelectPosition();
        }

        
         // Nếu click vào combobox nguồn gốc: nếu chưa có dữ liệu thì loading, nếu có dữ liệu rồi thì không loading
        if(event.target.getAttribute("id") == "source"){
          /// lấy thông tin nguồn gốc nếu chưa có dữ liệu
          this.HandlerSelectSource();
        }

         // Nếu click vào combobox doanh thu: nếu chưa có dữ liệu thì loading, nếu có dữ liệu rồi thì không loading
        if(event.target.getAttribute("id") == "turnover"){
          /// lấy thông tin nguồn gốc nếu chưa có dữ liệu
          this.HandlerSelectTurnover();
        }

         // Nếu click vào combobox doanh thu: nếu chưa có dữ liệu thì loading, nếu có dữ liệu rồi thì không loading
        if(event.target.getAttribute("id") == "carrer"){
          /// lấy thông tin nguồn gốc nếu chưa có dữ liệu
          this.HandlerSelectCarrer();
        }


        

        ClickShowHideComboboxData(event);
      } catch (error) {
        console.log(error);
      }
    },
    handlerClickComboboxData: function (event) {
      try {
        selectValueComboboxData(event);
      } catch (error) {
        console.log(error);
      }
    },
    handlerClickComboboxMul(event) {
      try {
          // Nếu click vào combobox  multiple loại tiềm năng: nếu chưa có dữ liệu thì loading, nếu có dữ liệu rồi thì không loading
        if(event.target.getAttribute("id") == "potentialType"){
          console.log("chay source")
          /// lấy thông tin loại tiềm năng  nếu chưa có dữ liệu
          this.HandlerSelectPotentialType();
        }

        // xử lý hiển thị form data
        ClickShowHideComboboxMulData(event);
      } catch (error) {
        console.log(error);
      }
    },
    OnSubmit() {
      this.validate();
      console.log(this.errors);
    },
  },
  mounted() {
    // alert('huy');
  },
};
</script>
<style>
</style>