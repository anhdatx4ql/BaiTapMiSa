import axios from 'axios'

// Author: Phạm Văn Đạt
// function: Service xử lý thao tác loại hình
//  created time: 11:00 16/08/2022
export class OrganizationTypeSrervice{

    url= "https://localhost:44355/api/OrganizationType/";


    // lấy danh sách loại hình
    getAll(){
       try{
            return axios.get(this.url);         

       }catch(error){
        console.log(error);
       }
    }

    // lấy danh sách loại hình theo tên
    getByName(search){
        try{
            return axios.get(this.url+search);         
        }catch(error){
            console.log(error);
        }
    }
}
