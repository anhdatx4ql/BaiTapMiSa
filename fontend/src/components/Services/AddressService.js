import axios from 'axios'

// Author: Phạm Văn Đạt
// function: Service xử lý thao tác ngành nghề
//  created time: 12:06 15/08/2022
export class AddressService{


     // lấy danh sách tỉnh/ thành phố
     async GetAllProvince(){
        try{
             return await axios.get("https://provinces.open-api.vn/api/").then((res) => {
                 return res;
              })
              .catch((e) => {
                console.log(e);
              });         
 
        }catch(error){
         console.log(error);
        }
     }

   //   
   // lấy danh sách quận/huyện
   async GetAllDistricts(code){
      try{
           return await axios.get("https://provinces.open-api.vn/api/p/"+code+"?depth=2 ").then((res) => {
               return res;
            })
            .catch((e) => {
              console.log(e);
            });         

      }catch(error){
       console.log(error);
      }
   }


     // lấy danh sách quận/huyện
     async GetAllWards(code){
      try{
           return await axios.get("https://provinces.open-api.vn/api/d/"+code+"?depth=2 ").then((res) => {
               return res;
            })
            .catch((e) => {
              console.log(e);
            });         

      }catch(error){
       console.log(error);
      }
   }
}



