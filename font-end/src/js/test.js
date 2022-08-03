

// // Hàm xử lý scroll thanh cuộn của table
// // Author: Phạm Văn Đạt
// // created: 0h24' 1/08/2022 
export function handlerScroll(){
    console.log('a')
    if(document.getElementsByClassName('table-content')[0]){
        document.getElementsByClassName('table-content')[0].addEventListener("scroll",function(e){
        let element = document.getElementsByClassName('table-header')[0];
        if(e.target.scrollLeft > 0){
            console.log(e.target.scrollLeft)
            let translateXValue = -e.target.scrollLeft  + "px";
            console.log(translateXValue)
            element.style.transform = `translateX(${translateXValue})`;
            console.log(`translate(${translateXValue})`)
        }else if(e.target.scrollLeft < 40)
            element.style.transform = "translateX(0)";
      
    });
    }
} 

// // Hàm xử lý click combobox hiển thị data
// // Author: Phạm Văn Đạt
// // created: 10h24' 1/08/2022 
export async function ClickShowHideComboboxData(e, _element = null){
    try{
        if(e){
             console.log( e.target)
            _element = e.target;

            if(e.target.getAttribute("check") == null){
                _element = e.target.parentNode
            }

            await HandlerShowHideComboboxData(_element);
        }
       
    }
    catch(error){
        console.log(error);
    }
    
}

// // Hàm xử lý click hiển thị data combobox lên ô hiển thị
// // Author: Phạm Văn Đạt
// // created: 11h24' 1/08/2022 
export async function selectValueComboboxData(e){
    console.log(e);
    let value = e.target.getAttribute("value");
    const containerElement = e.target.parentNode.parentNode.parentNode;
    let containerContent = containerElement.getElementsByClassName('combobox-content__select')[0];
    let comboboxContent = containerElement.getElementsByClassName('combobox-content')[0];
    containerContent.innerHTML = value;
    containerElement.setAttribute("value",value);
    await HandlerShowHideComboboxData(comboboxContent)
    console.log(e.target.parentNode.parentNode.parentNode);
}



export async function HandlerShowHideComboboxData(element){
    let check =  element.getAttribute("check");
    let comboboxData = element.parentNode.getElementsByClassName("combobox-data")[0];
    let iconBox = element.getElementsByClassName("combobox-content__icon")[0];
    if(comboboxData){
        if(check == "false"){
        // hiển thị box
        comboboxData.style.display = "inline-block";

        // thay đổi icon
        iconBox.classList.remove("button-icon__up-black");
        iconBox.classList.add("button-icon__down-black");
        // chuyển trạng thái check
        element.setAttribute("check", "true")
            
        }else{
            // ẩn box
            comboboxData.style.display = "none";

            // thay doi icon
            iconBox.classList.remove("button-icon__down-black");
            iconBox.classList.add("button-icon__up-black");

            // chuyển trạng thái check
            element.setAttribute("check","false");
        }
    }
}