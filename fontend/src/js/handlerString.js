
/**
 * Author: Phạm Văn Đạt
 * function: In hoa chữ cái đầu
 */
export function titleCase(string) {
    //1. Tách các từ, cụm từ trong chuỗi ban đầu
    let sentence = string.toLowerCase().split(" ");
    //2. Tạo vòng lặp và viết hoa chữ cái đầu tiên của các từ, cụm từ trên
   if(sentence.length>0){
      for(var i = 0; i< sentence.length; i++){

         sentence[i] = sentence[i].charAt(0).toUpperCase() + sentence[i].slice(1);
      }
      //3. Nối các từ, cụm từ đã xử lý ở trên và trả về kết quả
      return sentence.join(" ");
   }
    return string;
}


/**
 * Author: Phạm Văn Đạt
 * function: Kiểm tra định dạng email
 */
export function checkEmail(value){
   let myRe = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,5}$/;
   return myRe.exec(value);
}