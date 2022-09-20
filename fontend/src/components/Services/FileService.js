import axios from 'axios'

// Author: Phạm Văn Đạt
// function: Service xử lý thao tác lĩnh vực
//  created time: 11:00 16/08/2022
export class FileService{

    url= "https://localhost:44355/api/Files";

    constructor(){
        
    }

    // lấy danh sách Lĩnh vực
    async Create(customerId,Data){
       try{
         return axios.post(this.url+"?customerId="+customerId,Data).then((res) => {
                 return res;
              })
              .catch((e) => {
                console.log(e);
              });     

       }catch(error){
        console.log(error);
       }
    }

}
