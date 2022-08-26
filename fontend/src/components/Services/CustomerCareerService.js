import axios from 'axios'

// Author: Phạm Văn Đạt
// function: Service xử lý thao tác chức danh
//  created time: 11:00 16/08/2022
export class CustomerCareerService{

    url= "https://localhost:44355/api/CustomerCareer/";


    // tạo mới loại tiềm năng
    async Create(Data){
        try{
  
             return await axios.post(this.url,Data).then((res) => {
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
