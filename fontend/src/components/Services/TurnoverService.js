import axios from 'axios'

// Author: Phạm Văn Đạt
// function: Service xử lý thao tác doanh thu
//  created time: 11:00 16/08/2022
export class SourceService{

    url= "https://localhost:44355/api/Turnover/";


    // lấy danh sách doanh thu
    getAll(){
       try{
            return axios.get(this.url);         

       }catch(error){
        console.log(error);
       }
    }

    // lấy danh sách doanh thu theo tên
    getByName(search){
        try{
            return axios.get(this.url+search);         
        }catch(error){
            console.log(error);
        }
    }
}
