import {formatDate} from "./formatData";

import {ErrorsValidation} from "./validation";

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
export async function handlerValidateCustomer(refs,customerInfo,errors){
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

    // validate Tên, số điện thoại,  email
    if(customerInfo.FirstName == null || customerInfo.FirstName == ""){
      errors.set("FirstName",ErrorsValidation.FirstNameRequired)
    }

    //  kiểm tra trùng số điện thoại nếu có
    if(customerInfo.CustomerPhoneNumber != null || customerInfo.CustomerPhoneNumber != ""){
      let checkPhone = CheckExistsColumn;
      checkPhone.tableName = "Customer";
      checkPhone.columnName = "CustomerPhoneNumber";
      checkPhone.value = customerInfo.CustomerPhoneNumber;
      let result = await checkExists(checkPhone)
      if(result == true)
      errors.set("CustomerPhoneNumber",ErrorsValidation.PhoneDuplicate)
    
    }

    //kiểm tra trùng email nếu có
    if(customerInfo.CustomerEmail != null || customerInfo.CustomerEmail != ""){
      let checkEmail = CheckExistsColumn;
      checkEmail.tableName = "Customer";
      checkEmail.columnName = "CustomerEmail";
      checkEmail.value = customerInfo.CustomerEmail;
      let result = await checkExists(checkEmail)
      if(result == true)
      errors.set("CustomerEmail",ErrorsValidation.EmailDuplicate)
    }

    // kiểm tra trùng bank account nếu có
    if(customerInfo.BankAccount != null || customerInfo.BankAccount != ""){
      let checkBankAccount = CheckExistsColumn;
      checkBankAccount.tableName = "Customer";
      checkBankAccount.columnName = "BankAccount";
      checkBankAccount.value = customerInfo.BankAccount;
      let result  = await checkExists(checkBankAccount)
      if(result == true)
      errors.set("BankAccount",ErrorsValidation.BankAccountDuplicate)
    }

    // kiểm tra trùng mã số thuế nếu có
    if(customerInfo.TaxCode != null || customerInfo.TaxCode != ""){
      let checkTaxCode = CheckExistsColumn;
      checkTaxCode.tableName = "Customer";
      checkTaxCode.columnName = "TaxCode";
      checkTaxCode.value = customerInfo.TaxCode;
      let result = await checkExists(checkTaxCode);
      if(result == true)
      errors.set("TaxCode",ErrorsValidation.TaxCodeDuplicate)
    }



    // kiểm tra trùng mã số thuế nếu có
    if(customerInfo.PotentialCode != null || customerInfo.PotentialCode != ""){
      let checkPotentialCode = CheckExistsColumn;
      checkPotentialCode.tableName = "Customer";
      checkPotentialCode.columnName = "PotentialCode";
      checkPotentialCode.value = customerInfo.PotentialCode;
      let result = await checkExists(checkPotentialCode);
      if(result == true)
      errors.set("PotentialCode",ErrorsValidation.CustomerIdDuplicate)
    }

    // nếu không tồn tại thời gian tạo tài khoản, bỏ
    if(formatDate(customerInfo.CreatedTimeBankAccount) == 'Invalid date'){
      delete customerInfo.CreatedTimeBankAccount
    }

    console.log(errors)
    console.log(customerInfo)

    return [customerInfo,errors];

}

/**
 * Xử lý vlaidate dữ liệu bảng nhiều nhiều
 */
export function handlerValidateTCustomer(_MapValue,_customerId){
  let Arr = [];
  for(let item of _MapValue){
    let customerId = _customerId
    let potentialTypeId = item[0];
    Arr.push({customerId,potentialTypeId})
  }
  return Arr;
}

/**
 * Xử lý check trùng
 */

export async function checkExists(model){
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