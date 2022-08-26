import axios from 'axios'

// Author: Phạm Văn Đạt
// function: Service xử lý thao tác lĩnh vực
//  created time: 11:00 16/08/2022
export class FieldService{

    url= "https://localhost:44355/api/Field";
    field = "";

    constructor(){
        
    }

    // lấy danh sách Lĩnh vực
    async GetAll(){
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

    // lấy danh sách lĩnh vực theo tên
    async GetByName(search){
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
