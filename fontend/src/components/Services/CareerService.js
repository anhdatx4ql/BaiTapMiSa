import axios from 'axios'

// Author: Phạm Văn Đạt
// function: Service xử lý thao tác ngành nghề
//  created time: 12:06 15/08/2022
export class CareerService{

    url= "https://localhost:44355/api/Carrer/";

    // lấy danh sách ngành nghề
    async GetAll(){
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

    
    // lấy danh sách xưng hô theo tên
    async GetByName(search){
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



