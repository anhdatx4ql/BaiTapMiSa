import axios from 'axios'

// Author: Phạm Văn Đạt
// function: Service xử lý thao tác ngành nghề
//  created time: 12:06 15/08/2022
export class CarrerService{

    url= "https://localhost:44355/api/Carrer/";

    // lấy danh sách ngành nghề
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



