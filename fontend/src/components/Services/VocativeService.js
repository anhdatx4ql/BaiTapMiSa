import axios from 'axios'

// Author: Phạm Văn Đạt
// function: Service xử lý thao tác xưng hô
//  created time: 12:06 15/08/2022
export class VocativeService{

    url= "https://localhost:44355/api/Vocative/";


    // lấy danh sách xưng hô
    getAll(){
       try{
            return axios.get(this.url);         

       }catch(error){
        console.log(error);
       }
    }

    // lấy danh sách xưng hô theo tên
    getByName(search){
        try{
            return axios.get(this.url+search);         
        }catch(error){
            console.log(error);
        }
    }
}
