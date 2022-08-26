import axios from 'axios'

// Author: Phạm Văn Đạt
// function: Service xử lý thao tác chức danh
//  created time: 11:00 16/08/2022
export class CustomerPotentialTypeService{

    url= "https://localhost:44355/api/CustomerPotentialType/";


    // lấy danh sách chức danh
    async getAll(){
       try{
            return await axios.get(this.url).then((res) => {
                return res.data.data;
             })
             .catch((e) => {
               console.log(e);
             });         

       }catch(error){
        console.log(error);
       }
    }

    // lấy danh sách chức danh theo tên
    async getByNameId(search){
        try{
            return await axios.get(this.url+search).then((res) => {
                return res.data.data;
             })
             .catch((e) => {
               console.log(e);
             });         
        }catch(error){
            console.log(error);
        }
    }

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
