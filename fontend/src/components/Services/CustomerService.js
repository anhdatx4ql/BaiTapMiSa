import axios from 'axios'

// Author: Phạm Văn Đạt
// function: Service xử lý thao tác khách hàng
//  created time: 12:06 15/08/2022
export class CustomerService{

    url= "https://localhost:44355/api/Customers/";


  //  check trùng các cột
  async CheckExists(Data){
    try{

      return await axios.post(this.url+"CheckExists",Data).then((res) => {
        return res;
     })
     .catch((e) => {
       console.log(e);
     });         

 }catch(error){
  console.log(error);
 }
 }

    // lấy tất cả thông tin của khách hàng
    async GetAll(){
       try{

            return await axios.get(this.url)
            .then((res) => {
                return res.data.data;
            })
            .catch((e) => {
              console.log(e);
            });         

       }catch(error){
        console.log(error);
       }
    }

     // Lấy mã code mới +1
     async GetCodeMax(){
      try{

           return await axios.get(this.url+"GetCode")
           .then((res) => {
               return res.data.data;
           })
           .catch((e) => {
             console.log(e);
           });         

      }catch(error){
       console.log(error);
      }
   }


    // tạo mới thông tin của khách hàng
    async Create(Data){
      try{

           return await axios.post(this.url,Data).then((res) => {
             return res;
          })
          .catch((e) => {
            console.log(e);
          });         

      }catch(error){
       console.log(error);
      }
   }

   
    // cập nhật thông tin của khách hàng
    async Update(customerId,Data){
      try{

           return await axios.put(this.url+customerId,Data).then((res) => {
             return res;
          })
          .catch((e) => {
            console.log(e);
          });         

      }catch(error){
       console.log(error);
      }
   }
    
    // Tìm kiếm khách hàng
    async FindByName(name){
        try{
 
             return await axios.get(this.url+name).then((res) => {
               return res.data.data;
            })
            .catch((e) => {
              console.log(e);
            });         
 
        }catch(error){
         console.log(error);
        }
     }


     // xoa ban ghi
     async Delete(Data){
      try{

           return await axios.post(this.url+"DeleteMul",Data).then((res) => {
             return res;
          })
          .catch((e) => {
            console.log(e);
          });         

      }catch(error){
       console.log(error);
      }
   }

     // cập nhật nhiều
     async UpdateMul(Data){
      try{

           return await axios.post(this.url+"UpdateMul",Data).then((res) => {
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



