import axios from 'axios'

// Author: Phạm Văn Đạt
// function: Service xử lý thao tác phòng ban
//  created time: 11:00 16/08/2022
export class DepartmentService{

    url= "https://localhost:44355/api/Department";


    // lấy danh sách phòng ban
    getAll(){
       try{
            return axios.get(this.url);         

       }catch(error){
        console.log(error);
       }
    }

    // lấy danh sách phòng ban theo tên
    getByName(search){
        try{
            return axios.get(this.url+search);         
        }catch(error){
            console.log(error);
        }
    }
}
