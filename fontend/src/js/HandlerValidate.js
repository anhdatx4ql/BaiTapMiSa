import {FormatDate} from "./FormatData";

import { CheckEmail } from "./HandlerString";

import {ErrorsValidation} from "./Validation";

// nhúng service xử lý Customer
import { CustomerService } from "../components/Services/CustomerService";

// nhúng service xử lý Customer
import { CheckExistsColumn } from "../components/Models/CustomerModel/CheckExistsColumn";


// nhúng service xử lý Customer
import { StatusCode } from "../components/Models/StatusCode";



/***
 * Author: Phạm Văn Đạt
 * Function: hàm xử lý create customer
 */
export async function HandlerValidateCustomer(refs,customerInfo,errors){
  try{
    console.log("validation")
    let vocativeId = refs.vocativeId.getAttribute("value");
    let departmentId= refs.departmentId.getAttribute("value");
    let sourceId = refs.sourceId.getAttribute("value");
    let positionId = refs.positionId.getAttribute("value");
    let turnoverId = refs.turnoverId.getAttribute("value");
    let organizationTypeId = refs.organizationTypeId.getAttribute("value");


    (vocativeId == null)?delete customerInfo.VocativeId:customerInfo.VocativeId = vocativeId;
    (departmentId == null)?delete customerInfo.DepartmentId:customerInfo.DepartmentId = departmentId;
    (sourceId == null)?delete customerInfo.SourceId:customerInfo.SourceId = sourceId;
    (positionId == null)?delete customerInfo.PositionId:customerInfo.PositionId = positionId;
    (turnoverId == null)?delete customerInfo.TurnoverId:customerInfo.TurnoverId = turnoverId;
    (organizationTypeId == null)?delete customerInfo.OrganizationTypeId:customerInfo.OrganizationTypeId = organizationTypeId;
    

    // nếu số điện thoại, email, bank account, mã số thuế rỗng thì bỏ, không thêm

    //  xóa kí tẹ khoảng trắng
    const checkFirstName = TrimString(customerInfo.FirstName);

    // tên không được bỏ trông
    if( customerInfo.FirstName == null || customerInfo.FirstName == "" || checkFirstName==true){
      console.log("chạy vào đây")
      errors.set("FirstName",ErrorsValidation.FirstNameRequired)
    }


    // xóa kí tự khoảng trắng
    const checkPotentialCode = TrimString(customerInfo.PotentialCode);
 // mã tiềm năng không được bỏ trông
  if(customerInfo.PotentialCode == null || customerInfo.PotentialCode == "" || checkPotentialCode==true){
    errors.set("PotentialCode",ErrorsValidation.CustomerIdRequired)
  }else customerInfo.PotentialCode = customerInfo.PotentialCode.trim();

    //  kiểm tra trùng số điện thoại nếu có
    if(customerInfo.CustomerPhoneNumber != null || customerInfo.CustomerPhoneNumber != ""){
      let checkPhone = CheckExistsColumn;
      checkPhone.tableName = "Customer";
      checkPhone.columnName = "CustomerPhoneNumber";
      checkPhone.value = customerInfo.CustomerPhoneNumber;
      let result = await CheckExists(checkPhone)
      if(result == true)
      errors.set("CustomerPhoneNumber",ErrorsValidation.PhoneDuplicate)
    
    }

    //kiểm tra trùng email nếu có
    if(customerInfo.CustomerEmail){
      console.log(customerInfo.CustomerEmail)

      if(CheckEmail(customerInfo.CustomerEmail) == null){
        if(!errors.get("CustomerEmail"))
          errors.set("CustomerEmail",ErrorsValidation.EmailType);
      }else{
        if(errors.get("CustomerEmail"))
          errors.delete("CustomerEmail")

          let CheckEmail = CheckExistsColumn;
          CheckEmail.tableName = "Customer";
          CheckEmail.columnName = "CustomerEmail";
          CheckEmail.value = customerInfo.CustomerEmail;
          let result = await CheckExists(CheckEmail)
          if(result == true)
          errors.set("CustomerEmail",ErrorsValidation.EmailDuplicate)
      }

     
    }

    // kiểm tra trùng bank account nếu có
    if(customerInfo.BankAccount != null || customerInfo.BankAccount != ""){
      let checkBankAccount = CheckExistsColumn;
      checkBankAccount.tableName = "Customer";
      checkBankAccount.columnName = "BankAccount";
      checkBankAccount.value = customerInfo.BankAccount;
      let result  = await CheckExists(checkBankAccount)
      if(result == true)
      errors.set("BankAccount",ErrorsValidation.BankAccountDuplicate)
    }

    // kiểm tra trùng mã số thuế nếu có
    if(customerInfo.TaxCode != null || customerInfo.TaxCode != ""){
      let checkTaxCode = CheckExistsColumn;
      checkTaxCode.tableName = "Customer";
      checkTaxCode.columnName = "TaxCode";
      checkTaxCode.value = customerInfo.TaxCode;
      let result = await CheckExists(checkTaxCode);
      if(result == true)
      errors.set("TaxCode",ErrorsValidation.TaxCodeDuplicate)
    }
    
    if(customerInfo.CompanyEmail){
      if(CheckEmail(customerInfo.CompanyEmail) == null){
        if(!errors.get("CompanyEmail"))
          errors.set("CompanyEmail",ErrorsValidation.EmailType);
      }else{
        if(errors.get("CompanyEmail"))
          errors.delete("CompanyEmail")
      }
    }
    

    // kiểm tra trùng mã tiềm năng nếu có
    if(customerInfo.PotentialCode != null || customerInfo.PotentialCode != ""){
      let checkPotentialCode = CheckExistsColumn;
      checkPotentialCode.tableName = "Customer";
      checkPotentialCode.columnName = "PotentialCode";
      checkPotentialCode.value = customerInfo.PotentialCode;
      let result = await CheckExists(checkPotentialCode);
      if(result == true)
      errors.set("PotentialCode",ErrorsValidation.CustomerIdDuplicate)
    }

    // nếu không tồn tại thời gian tạo tài khoản, bỏ
    if(FormatDate(customerInfo.CreatedTimeBankAccount) == 'Invalid date'){
      delete customerInfo.CreatedTimeBankAccount
    }

    console.log(errors)
    console.log(customerInfo)

    return [customerInfo,errors];

  } catch (error) {
    console.log(error);
  }
 
}

/**
 * Author: Phạm Văn Đạt
 * Xử lý vlaidate dữ liệu bảng nhiều nhiều
 */
export function HandlerValidateTCustomer(_MapValue,_customerId){
  let Arr = [];
  let customerId = _customerId;
  if(_MapValue.size >0){
    for(let item of _MapValue){
      let potentialTypeId = item[0];
      Arr.push({customerId,potentialTypeId})
    }
  }else{
    let potentialTypeId = null;
    Arr.push({customerId,potentialTypeId})
  }
 
  return Arr;
}

/**
 * Author: Phạm Văn Đạt
 * Xử lý check trùng
 */

export async function CheckExists(model){
  let check = false;
  let _CustomerService = new CustomerService();
  await _CustomerService.CheckExists(model).then(res=>{
    if(res.data.statusCode == StatusCode.GetSuccess){
      if(res.data.data == true){
        // trường này đã bị trùng

        check= true;

      }
    }
  })

  return check;

}


/**
 * Author: Phạm Văn Đạt
 * function: Xóa khoảng trắng chuỗi
 */
function TrimString(string){
  if(string != null){
    if(string.length > 0)
    string = string.trim();

    if(string.length == 0)
      return true;
 
  }
  return false;
}