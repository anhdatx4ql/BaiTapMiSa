import axios from 'axios'

// Author: Phạm Văn Đạt
// function: Service xử lý thao tác xưng hô
//  created time: 12:06 15/08/2022
export class VocativeService{

    url= "https://localhost:44355/api/Vocative/";


    // lấy danh sách xưng hô
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

    // lấy danh sách xưng hô theo tên
    async getByName(search){
        try{
            return axios.get(this.url+search).then((res) => {
                return res.data;
             })
             .catch((e) => {
               console.log(e);
             });         
        }catch(error){
            console.log(error);
        }
    }
}
