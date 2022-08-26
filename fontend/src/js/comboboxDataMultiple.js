

/**
 * Author: Phạm Văn Đạt
 * function: xử lý kích nút xóa trên những dữ liệu đã chọn trong combobox
 * Created time: 18:38 20/08/2022
 */
export function handlerClickCloseIconComboboxMul(event, customerPotentialTypeMap){
    const el = event.target.parentNode.getElementsByClassName("combobox-content-select-content-text")[0];
      if(el){
        const elValue = el.getAttribute("value");
        const elHTML = el.innerHTML;
        console.log(elHTML);
        if(elValue){
          customerPotentialTypeMap.delete(elValue)
          let comboboxData = event.target.parentNode.parentNode.parentNode.parentNode.getElementsByClassName("combobox-data")[0];

          let comboboxDataChild =  comboboxData.getElementsByClassName("combobox-data-child")[0];

          let comboboxDataContents =  comboboxDataChild.getElementsByClassName("combobox-data-child-content");
          for(let item of comboboxDataContents){
            let elHTMLCheck  = item.getElementsByClassName("combobox-data-child-content-text")[0];

            
            if(elHTML == elHTMLCheck.innerHTML){
              console.log(elHTMLCheck)
              let parentElHTMLCheck = elHTMLCheck.parentNode;
              // bỏ selected của thẻ cha
              if(parentElHTMLCheck.classList.contains("selected")){
                parentElHTMLCheck.classList.remove("selected")
              }

              // chuyển trạng thái của icon về none
              let eIconCheck = parentElHTMLCheck.getElementsByClassName("background-icon-checked")[0];

              if(eIconCheck)
                eIconCheck.style.display="none";

            }
          }

        }

          return customerPotentialTypeMap;
      }
}

export function hanlderClickComboboxMulData(event,customerPotentialTypeMap){
  let elComboboxData = event.target;
  if(!elComboboxData.classList.contains("combobox-data-child-content"))
    elComboboxData =  event.target.parentNode;

  console.log(elComboboxData.classList.contains("combobox-data"))

  const valueEl = elComboboxData.getAttribute("value");

  let textEl  = elComboboxData.getElementsByClassName("combobox-data-child-content-text")[0].innerHTML;

  if(elComboboxData.classList.contains("combobox-data")){
    
    let checkClassListShow = elComboboxData.classList.contains("div-inline-block");
    if( checkClassListShow == false){
       elComboboxData.classList.add("div-inline-block")
    }

  }


  if(elComboboxData.classList.contains("selected")){
    // đây là id bảng customerpotential, cần   lấy ra giá trị để so sánh
    if(valueEl){
      customerPotentialTypeMap.delete(valueEl)

      // nếu ccó selected thì xóa đi
      if(elComboboxData.classList.contains("selected") == true){
        console.log('chay')
        elComboboxData.classList.remove("selected");
      }
      let showIcon = elComboboxData.getElementsByClassName("background-icon-checked")[0];

      if(showIcon)
        showIcon.style.display = "none";
    }
   console.log('xu ly xoa')
  }else{
    elComboboxData.classList.add("selected");
    let showIcon = elComboboxData.getElementsByClassName("background-icon-checked")[0];
    if(showIcon)
      showIcon.style.display = "inline-block";

    if(textEl && valueEl)
      customerPotentialTypeMap.set(valueEl,textEl)

    console.log('xu ly them')
  }
  // lấy ra giá trị id
  // let value = event.target.getAttribute("value");
  //  console.log(this.customerPotentialTypeMap.has(CheckSelectComboboxDataMul))

  // so sánh mới map, nếu trùng thì bỏ đi, nếu không trùng thì add vào

  return customerPotentialTypeMap;
}