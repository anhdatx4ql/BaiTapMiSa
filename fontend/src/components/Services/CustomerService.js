import axios from 'axios'

// Author: Phạm Văn Đạt
// function: Service xử lý thao tác khách hàng
//  created time: 12:06 15/08/2022
export class CustomerService{

    // api 
    url= "https://localhost:44355/api/Customers/";

    // lấy tất cả thông tin của khách hàng
    GetAll(){
       try{

            return axios.get(this.url);         

       }catch(error){
        console.log(error);
       }
    }

    
    // lấy tất cả thông tin của khách hàng
    FindByName(name){
        try{
 
             return axios.get(this.url+name);         
 
        }catch(error){
         console.log(error);
        }
     }
}



