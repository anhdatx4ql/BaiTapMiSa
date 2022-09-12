

// // xử lý ẩn các combobox khi kích vào chỗ bên ngoài
// export function HideCombobox(){
  
//   window.addEventListener("click", function(){

//     handlerClickHideFullComboboxData();
//   });
// }


// Hàm xử lý scroll thanh cuộn của table
// Author: Phạm Văn Đạt
// created: 0h24' 1/08/2022
export function handlerScroll() {
  try {
    if (document.getElementsByClassName("table-content")[0]) {
      document
        .getElementsByClassName("table-content")[0]
        .addEventListener("scroll", function (e) {
          let element = document.getElementsByClassName("table-header")[0];
          if (e.target.scrollLeft > 0) {
            let translateXValue = -e.target.scrollLeft + "px";
            element.style.transform = `translateX(${translateXValue})`;
          } else if (e.target.scrollLeft < 40) element.style.transform = "translateX(0)";
        });
    }
  } catch (error) {
    console.log(error);
  }
}

// // Hàm xử lý click combobox hiển thị data
// // Author: Phạm Văn Đạt
// // created: 10h24' 1/08/2022
export async function ClickShowHideComboboxData(e, _element = null) {
  try {

    if (_element == null) _element = e.target;

    if (e.target.getAttribute("check") == null) {
      _element = e.target.parentNode;
    }

    await HandlerShowHideComboboxData(_element);

  } catch (error) {
    console.log(error);
  }
}

// // Hàm xử lý click hiển thị data combobox lên ô hiển thị
// // Author: Phạm Văn Đạt
// // created: 11h24' 1/08/2022
export async function selectValueComboboxData(e) {
  try {

    let element = "";
    // kiểm tra xem click đúng chưa
    if(e.target.classList.contains("combobox-data-child-content")){
      element =  e.target;

    }
    else{
      element =  e.target.parentNode;
    }

    // chọn trường khác => đổi màu
    let handlerColorComboboxData = element.parentNode.getElementsByClassName("combobox-data-child-content");
    if(handlerColorComboboxData){
      for(let i=0;i<handlerColorComboboxData.length;i++){
      
        // kiểm tra xem element nào có class selected thì bỏ đi
        if(handlerColorComboboxData[i].classList.contains("selected")){
          
          if(handlerColorComboboxData[i].classList.contains("selected"))
            handlerColorComboboxData[i].classList.remove("selected");

          const el =  handlerColorComboboxData[i].getElementsByClassName("background-icon-checked")[0];

          if(el){
            el.style.display = "none";
          }
        }
      }
      // nhúng class selected vào element vừa click
      element.classList.add("selected");
      

      const elBackgroundChecked = element.getElementsByClassName("background-icon-checked")[0];
      if(elBackgroundChecked)
        elBackgroundChecked.style.display = "inline-block";
      
      let value = (element.getAttribute("value"))?element.getAttribute("value"):"";

      const elInnerHtml = element.getElementsByClassName("combobox-data-child-content-text")[0];

      if(elInnerHtml){
        let innerHTML = (elInnerHtml.innerHTML)?elInnerHtml.innerHTML:"";
        const containerElement = element.parentNode.parentNode.parentNode;
        let containerContent = containerElement.getElementsByClassName(
          "combobox-content-select"
        )[0];
        let comboboxContent =
          containerElement.getElementsByClassName("combobox-content")[0];
        containerContent.innerHTML = innerHTML;
        containerContent.removeAttribute("value");
        containerContent.setAttribute("value", value);
        await HandlerShowHideComboboxData(comboboxContent);
      }
      
    }
    
  } catch (error) {
    console.log(error);
  }
}

// // Hàm xử lý click combobox hiển thị data
// // Author: Phạm Văn Đạt
// // created: 10h24' 1/08/2022
export async function ClickShowHideComboboxMulData(e) {
  try {

      let element = e.target;

      if(element.getAttribute("check") == null){
        element = element.parentNode;
       
      }

      await HandlerShowHideComboboxData(element);

  } catch (error) {
    console.log(error);
  }
}

// // Hàm xử lý click hiển thị data combobox lên ô hiển thị combobox chứa nhiều
// // Author: Phạm Văn Đạt
// // created: 10h09' 05/08/2022
export async function selectValueComboboxMulData(e) {
  try {
    let value = e.target.getAttribute("value");
    const containerElement = e.target.parentNode.parentNode.parentNode;
    let containerContent = containerElement.getElementsByClassName("combobox-content-select")[0];

    containerContent.innerHTML = value;
    containerElement.setAttribute("value", value);
    
  } catch (error) {
    console.log(error);
  }
}

// function xử lý hiển thị combobox data
export async function HandlerShowHideComboboxData(element) {
  try {
    
    let check = element.getAttribute("check");
    if(check){
      let comboboxData = element.parentNode.getElementsByClassName("combobox-data")[0];
      if(comboboxData){
        let iconBox = element.getElementsByClassName("combobox-content-icon")[0];
        ShowFormData(comboboxData, check, iconBox, element);
        
      }
     
    }
   
  } catch (error) {
    console.log(error);
  }
}

// Hiển thị combobox Data
function ShowFormData(comboboxData, check, iconBox = null, element) {
  try {

    let ElClasses = element.classList;
    let checkChangeBorder = false;
    if(ElClasses.contains('combobox-child') && ElClasses.contains('combobox-content')){
      checkChangeBorder = true;
    }


     // lấy class các form
    handlerClickHideFullComboboxData();
    if (check == "false") {
      // thay đổi border-color xanh
      if(checkChangeBorder == true){
        if(ElClasses.contains("border-input-forcus") == false)
          ElClasses.add("border-input-forcus");
      }

      // hiển thị box
      comboboxData.classList.add("div-inline-block");

      // thay đổi icon
      if (iconBox) {
        iconBox.classList.remove("button-icon-up-black");
        iconBox.classList.add("button-icon-down-black");
      }

      // chuyển trạng thái check
      element.setAttribute("check", "true");
    } else {
      //xóa border-color xanh
      if(checkChangeBorder == true){
        if(ElClasses.contains("border-input-forcus") == true)
          ElClasses.remove("border-input-forcus");
      }

      // ẩn box
      comboboxData.classList.remove("div-inline-block");
      // thay doi icon
      if (iconBox) {
        iconBox.classList.remove("button-icon-down-black");
        iconBox.classList.add("button-icon-up-black");
      }

      // chuyển trạng thái check
      element.setAttribute("check", "false");
    }
  } catch (error) {
    console.log(error);
  }
}

export function handlerClickHideFullComboboxData(){
  // lấy class các form
  const comboboxDataFull = document.getElementsByClassName("combobox-data");

  for(let i=0;i<comboboxDataFull.length; i++){
   if(comboboxDataFull[i].classList.contains("div-inline-block")){
    const El = comboboxDataFull[i].parentNode.getElementsByClassName("combobox-content")[0];
    // xử lý màu border
    if(El){
      let ElClasses = El.classList;
      let checkChangeBorder = false;
      if(ElClasses.contains('combobox-child') && ElClasses.contains('combobox-content')){
        checkChangeBorder = true;
      }
  
      if(checkChangeBorder == true){
        if(ElClasses.contains("border-input-forcus") == true)
          ElClasses.remove("border-input-forcus");
      }
    }
  
     // lấy ra ô input để chỉnh sửa
     let inputCombobox = comboboxDataFull[i].parentNode.getElementsByClassName("combobox-content")[0];

     // lấy ra icon để thay đổi
     let iconCombobox = comboboxDataFull[i].parentNode.getElementsByClassName("combobox-content-icon")[0];

     // thay đổi icon
     if(iconCombobox){

       if(iconCombobox.classList.contains("button-icon-down-black") == true){
         iconCombobox.classList.remove("button-icon-down-black");
         iconCombobox.classList.add("button-icon-up-black");
       }
     }
    

     inputCombobox.setAttribute("check", "false");
     comboboxDataFull[i].classList.remove("div-inline-block")
   }
 }
}

// xử lý click hiển thị, ẩn side bar left/right
export function handlerClickButtonArrow(left, right, event) {
  try {
    if (left == true && right == true) {
      document.getElementsByClassName("content")[0].style.gridTemplateColumns =
        "0 100% 0";
      document.getElementsByClassName(
        "content-sider-bar-left"
      )[0].style.display = "none";
      document.getElementsByClassName(
        "content-sider-bar-right"
      )[0].style.display = "none";
    }

    if (left == true && right == false) {
      document.getElementsByClassName("content")[0].style.gridTemplateColumns =
        "0 calc(100% - 320px) 320px";
      document.getElementsByClassName(
        "content-sider-bar-left"
      )[0].style.display = "none";
      document.getElementsByClassName(
        "content-sider-bar-right"
      )[0].style.display = "grid";
    }

    if (left == false && right == true) {
      document.getElementsByClassName("content")[0].style.gridTemplateColumns =
        "240px calc(100% - 240px) 0";
      document.getElementsByClassName(
        "content-sider-bar-left"
      )[0].style.display = "inline-block";
      document.getElementsByClassName(
        "content-sider-bar-right"
      )[0].style.display = "none";
    }

    if (left == false && right == false) {
      document.getElementsByClassName("content")[0].style.gridTemplateColumns =
        "240px calc(100% -  240px - 320px) 320px";
      document.getElementsByClassName(
        "content-sider-bar-left"
      )[0].style.display = "inline-block";
      document.getElementsByClassName(
        "content-sider-bar-right"
      )[0].style.display = "grid";
    }

    let _element = event.target;
    if (event.target.getElementsByClassName("icon-font-16")[0])
      _element = event.target.getElementsByClassName("icon-font-16")[0];

    // check thay đổi mũi tên:

    let classList = _element.classList;
    classList.remove("icon-font-16");
    if (classList.value == "background-icon-arrow-left") leftToRight(_element);
    else {
      rightToLeft(_element);
    }
  } catch (error) {
    console.log(error);
  }
}

// start hàm xử lý thay đổi mũi tên trong lúc click để ẩn/ hiển thị side bar
function rightToLeft(element) {
  try {
    element.classList.remove("background-icon-arrow-right");
    element.classList.add("background-icon-arrow-left", "icon-font-16");
  } catch (error) {
    console.log(error);
  }
}

function leftToRight(element) {
  try {
    element.classList.remove("background-icon-arrow-left");
    element.classList.add("background-icon-arrow-right", "icon-font-16");
  } catch (error) {
    console.log(error);
  }
}

// end hàm xử lý thay đổi mũi tên trong lúc click để ẩn/ hiển thị side bar


