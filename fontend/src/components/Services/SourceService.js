import axios from 'axios'

// Author: Phạm Văn Đạt
// function: Service xử lý thao tác nguồn gốc
//  created time: 11:00 16/08/2022
export class SourceService{

    url= "https://localhost:44355/api/Source/";


    // lấy danh sách nguồn gốc
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

    // lấy danh sách nguồn gốc theo tên
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
