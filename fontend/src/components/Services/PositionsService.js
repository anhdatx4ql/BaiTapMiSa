import axios from 'axios'

// Author: Phạm Văn Đạt
// function: Service xử lý thao tác chức danh
//  created time: 11:00 16/08/2022
export class PositionsService{

    url= "https://localhost:44355/api/Positions/";


    // lấy danh sách chức danh
    getAll(){
       try{
            return axios.get(this.url);         

       }catch(error){
        console.log(error);
       }
    }

    // lấy danh sách chức danh theo tên
    getByName(search){
        try{
            return axios.get(this.url+search);         
        }catch(error){
            console.log(error);
        }
    }
}
