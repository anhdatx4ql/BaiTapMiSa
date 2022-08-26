import axios from 'axios'

// Author: Phạm Văn Đạt
// function: Service xử lý thao tác phòng ban
//  created time: 11:00 16/08/2022
export class DepartmentService{

    url= "https://localhost:44355/api/Department";


    // lấy danh sách phòng ban
    async getAll(){
       try{
            return axios.get(this.url).then((res) => {
                return res.data.data;
             })
             .catch((e) => {
               console.log(e);
             });         

       }catch(error){
        console.log(error);
       }
    }

    // lấy danh sách phòng ban theo tên
    async getByName(search){
        try{
            return axios.get(this.url+search).then((res) => {
                return res.data.data;
             })
             .catch((e) => {
               console.log(e);
             });         
        }catch(error){
            console.log(error);
        }
    }
}
