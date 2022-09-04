import axios from 'axios'

// Author: Phạm Văn Đạt
// function: Service xử lý thao tác chức danh
//  created time: 11:00 16/08/2022
export class PositionsService{

    url= "https://localhost:44355/api/Positions/";


    // lấy danh sách chức danh
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

    // lấy danh sách chức danh theo tên
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
