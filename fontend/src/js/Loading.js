// xử lý hiển thị loading khhi đang tải dữ liệu
export async function Loading(element){

    let DivLoadingChild= element.getElementsByClassName("content-background-icon-loading")[0];
    if(DivLoadingChild)
        DivLoadingChild.style.display =  "flex"
}

// xử lý ẩn loading khi đã tải dữ liệu xong
export async function UnLoading(element){

    // lấy thẻ cha chứa loading

    let DivLoadingChild= element.getElementsByClassName("content-background-icon-loading")[0];
    console.log("unloading")
    if(DivLoadingChild)
        DivLoadingChild.style.display =  "none"

    // DivParent.removeChild(DivLoadingChild);
}