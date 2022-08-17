import axios from 'axios'

// Author: Phạm Văn Đạt
// function: Service xử lý thao tác nguồn gốc
//  created time: 11:00 16/08/2022
export class SourceService{

    url= "https://localhost:44355/api/Source/";


    // lấy danh sách nguồn gốc
    getAll(){
       try{
            return axios.get(this.url);         

       }catch(error){
        console.log(error);
       }
    }

    // lấy danh sách nguồn gốc theo tên
    getByName(search){
        try{
            return axios.get(this.url+search);         
        }catch(error){
            console.log(error);
        }
    }
}
