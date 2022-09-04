using Common;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebInfrastructure;
using static Common.ContantsError;
using static Common.ContantsSuccess;

namespace WebDomain
{
    public class CustomerService : ICustomerService
    {

        private readonly IDapperRepository _dapper;
        public CustomerService(IDapperRepository dapper)
        {
            _dapper = dapper;
        }

        public async Task<ReponsitoryModel> PagingCustomer(string keyword = null, int currentPageNumber = 1, int pageSize = 10)
        {
            try
            {
                // lấy nhiều nhất là 100 bản ghi
                var maxPagesize = 100;
                pageSize = (pageSize < maxPagesize) ? pageSize : maxPagesize;

                var Offset = (currentPageNumber - 1) * pageSize;

                var strQuery = @"SELECT COUNT(*) FROM Customer WHERE CustomerId IN (SELECT Customer.CustomerId FROM customer LEFT JOIN vocative ON customer.VocativeId = vocative.VocativeId LEFT JOIN department ON customer.DepartmentId = department.DepartmentId LEFT JOIN positions ON customer.PositionId = positions.PositionId LEFT JOIN source ON customer.SourceId = source.SourceId LEFT JOIN organizationtype ON customer.OrganizationTypeId = organizationtype.OrganizationTypeId LEFT JOIN turnover ON customer.TurnoverId = turnover.TurnoverId WHERE customer.IsDelete = false);";

                if (keyword != null) {
                    strQuery += @"SELECT customer.gender,customer.CustomerId,customer.LastName, customer.FirstName, customer.PotentialCode, customer.FullName, customer.CustomerPhoneNumber, customer.CompanyPhoneNumber, customer.CustomerEmail,customer.IsActiveEmail, customer.IsActivePhoneNumber, customer.CompanyEmail, customer.TaxCode, customer.Zalo, customer.Organization, customer.Address, customer.VocativeId, customer.DepartmentId, customer.PositionId, customer.SourceId, customer.OrganizationTypeId, customer.TurnoverId, customer.IsDelete, vocative.VocativeName, department.DepartmentName, positions.PositionName, source.SourceName, organizationtype.OrganizationTypeName, turnover.TurnoverName,customer.Country,customer.District,customer.Wards,customer.HomeNumber FROM customer LEFT JOIN vocative ON customer.VocativeId = vocative.VocativeId LEFT JOIN department ON customer.DepartmentId = department.DepartmentId LEFT JOIN positions ON customer.PositionId = positions.PositionId LEFT JOIN source ON customer.SourceId = source.SourceId LEFT JOIN organizationtype ON customer.OrganizationTypeId = organizationtype.OrganizationTypeId LEFT JOIN turnover ON customer.TurnoverId = turnover.TurnoverId WHERE customer.IsDelete = false and (FullName LIKE @keyword OR CustomerPhoneNumber LIKE @keyword OR PotentialCode LIKE @keyword) ORDER BY customer.UpdatedAt DESC LIMIT @Offset,@PageSize";
                }
                else
                {
                    strQuery += @"SELECT customer.gender,customer.CustomerId,customer.LastName, customer.FirstName, customer.PotentialCode,customer.BirthDay, customer.FullName, customer.CustomerPhoneNumber, customer.CompanyPhoneNumber, customer.CustomerEmail,customer.IsActiveEmail, customer.IsActivePhoneNumber, customer.CompanyEmail, customer.TaxCode, customer.Zalo, customer.Organization, customer.Address, customer.VocativeId, customer.DepartmentId, customer.PositionId, customer.SourceId, customer.OrganizationTypeId, customer.TurnoverId, customer.IsDelete, vocative.VocativeName, department.DepartmentName, positions.PositionName, source.SourceName, organizationtype.OrganizationTypeName, turnover.TurnoverName,customer.Country,customer.District,customer.Wards,customer.HomeNumber FROM customer LEFT JOIN vocative ON customer.VocativeId = vocative.VocativeId LEFT JOIN department ON customer.DepartmentId = department.DepartmentId LEFT JOIN positions ON customer.PositionId = positions.PositionId LEFT JOIN source ON customer.SourceId = source.SourceId LEFT JOIN organizationtype ON customer.OrganizationTypeId = organizationtype.OrganizationTypeId LEFT JOIN turnover ON customer.TurnoverId = turnover.TurnoverId WHERE customer.IsDelete = false ORDER BY customer.UpdatedAt DESC LIMIT @Offset,@PageSize";
                }
                //var parameters = new DynamicParameters();

                //parameters.Add("Offset", Offset);
                //parameters.Add("PageSize", pageSize);
                var parameterWhere = new Dictionary<string, object>()
                {
                    ["keyword"] = $"%{keyword}%",
                    ["Offset"] = Offset,
                    ["PageSize"] = pageSize
                };
              

                PagingModel<CustomerModel> result = await _dapper.PagingT<CustomerModel>(strQuery, parameterWhere);
                if (result.Data == null)
                    return new ReponsitoryModel { Data = null, Message = MessageError.NotValue, StatusCode = CodeError.NotValue };

                // lấy được data, totalcount

                var pagingData = new PagingDataModel<CustomerModel>(result.TotalCount, result.Data, currentPageNumber, pageSize);
                return new ReponsitoryModel { Data = pagingData, Message = MessageSuccess.GetSuccess, StatusCode = CodeSuccess.Status200 };

            }
            catch (Exception ex)
            {
                return new ReponsitoryModel { Data = ex.Message, Message = MessageError.ProcessError, StatusCode = CodeError.ProcessError };
            }
        }


        /// <summary>
        /// Tạo mới khách hàng
        /// Author: Phạm văn Đạt
        /// 20;34 10/08/2022
        ///  10:10 12/08/2022 : chưa xử lý loại tiềm năng, lĩnh vực, ngành nghề
        /// </summary>
        public async Task<ReponsitoryModel> CreateCustomer(CreateCustomerModel model)
        {
            try {

                // id tự động tạo nếu 
                    model.CustomerId = Guid.NewGuid();

                // kiểm tra mã tiềm năng
                var ExistsPotentialCode = await _dapper.FindCloumnTAsync<Customer>("Customer", "PotentialCode", model.PotentialCode);
                if (ExistsPotentialCode ==true)
                    return new ReponsitoryModel { Data = null, Message = MessageError.DuplicateCode, StatusCode = CodeError.DuplicateCode };

                // kiểm tra tên có tồn tại không
                if (model.FirstName == null)
                    return new ReponsitoryModel { Data = null, Message = "Tên " + MessageError.NotExists, StatusCode = CodeError.NotExists };

             
                // Kiểm tra số điện thoại cá nhân có tồn tại hay không rồi mới check trùng
                if(model.CustomerPhoneNumber != null)
                {
                    // check trùng số điện thoại cá nhân
                    var ExistsCustomerPhoneNumber = await _dapper.FindCloumnTAsync<Customer>("Customer", "CustomerPhoneNumber", model.CustomerPhoneNumber);
                    if (ExistsCustomerPhoneNumber == true)
                        return new ReponsitoryModel { Data = null, Message = MessageError.DuplicatePhone, StatusCode = CodeError.DuplicatePhone };
                }

                // kiểm tra email có tồn tại hay không
                if (model.CustomerEmail!= null)
                {
                    // check trùng  email
                    var ExistsCustomerEmail = await _dapper.FindCloumnTAsync<Customer>("Customer", "CustomerEmail", model.CustomerEmail);
                    if (ExistsCustomerEmail == true)
                        return new ReponsitoryModel { Data = null, Message = MessageError.DuplicateEmail, StatusCode = CodeError.DuplicateEmail };
                }

                // kiểm tra mã số thuế có tồn tại hay không
                if(model.TaxCode != null)
                {
                    // check trùng mã số thuế
                    var ExistsTaxCode = await _dapper.FindCloumnTAsync<Customer>("Customer", "TaxCode", model.TaxCode);
                    if (ExistsTaxCode == true)
                        return new ReponsitoryModel { Data = null, Message = MessageError.DuplicateTaxCode, StatusCode = CodeError.DuplicateTaxCode };
                }

                // kiểm tra tài khoản ngân hàng có tồn tại hay không
                if (model.BankAccount != null)
                {
                    // check trùng tài khoản ngân hàng
                    var ExistsBankAccount = await _dapper.FindCloumnTAsync<Customer>("Customer", "BankAccount", model.BankAccount);
                    if (ExistsBankAccount == true)
                        return new ReponsitoryModel { Data = null, Message = MessageError.DuplicateBankAccount, StatusCode = CodeError.DuplicateBankAccount };
                }

                model.updatedAt = DateTime.Now;
                model.CreatedAt = DateTime.Now;
                if(model.IsDelete == false)
                    model.IsDelete = false;
                else model.IsDelete = false;

                string sql = @"INSERT INTO customer (LastName, FirstName, FullName, PotentialCode, CustomerPhoneNumber, CompanyPhoneNumber, CustomerEmail, CompanyEmail, TaxCode, Zalo, Organization, CustomerDescription, Address, Country, Province, District, HomeNumber, RegionCode, BankAccount, BankName, VocativeId, DepartmentId, PositionId, SourceId, OrganizationTypeId, TurnoverId, CreatedAt, UpdatedAt, IsDelete, UpdatedBy, CreatedBy, CreatedTimeBankAccount, CustomerId,Wards)  VALUES (@LastName, @FirstName, @FullName, @PotentialCode, @CustomerPhoneNumber, @CompanyPhoneNumber, @CustomerEmail, @CompanyEmail, @TaxCode, @Zalo, @Organization, @CustomerDescription, @Address, @Country, @Province, @District, @HomeNumber, @RegionCode, @BankAccount, @BankName, @VocativeId, @DepartmentId, @PositionId, @SourceId, @OrganizationTypeId, @TurnoverId, @CreatedAt, @UpdatedAt, @IsDelete, @UpdatedBy, @CreatedBy, @CreatedTimeBankAccount,@CustomerId,@Wards)";

                var result = await _dapper.CreateTAsync<CreateCustomerModel>(sql, model);

                return new ReponsitoryModel { Data = model, Message = MessageSuccess.CreatedSuccess, StatusCode = CodeSuccess.Status201 };

            }
            catch(Exception ex)
            
            {
                return new ReponsitoryModel { Data = ex, Message = MessageError.ProcessError, StatusCode = CodeError.ProcessError };
            }
        }


        /// <summary>
        /// Tạo mới khách hàng
        /// Author: Phạm văn Đạt
        /// 10:10 12/08/2022
        /// xóa nhiều: chưa xong: 10:10 12/08/2022
        /// </summary>
        public async Task<ReponsitoryModel> DeleteCustomer(List<Guid> ListString)
        {
            try
            {
               
                // kiểm tra xem id truyền vào có giá trị hay không
                if (ListString.Count == 0)
                    return new ReponsitoryModel { Data = null, Message = MessageError.NotValue, StatusCode = CodeError.NotValue };

                string SqlUpdate = @"UPDATE customer SET IsDelete=true,UpdatedAt = @UpdatedAt WHERE CustomerId IN @ListString";
                var parameters = new DynamicParameters();
                parameters.Add("@ListString", ListString);
                parameters.Add("UpdatedAt", DateTime.Now);

                var ResultUpdate = await _dapper.UpdateTAsync<Customer>(SqlUpdate, parameters);

                if (ResultUpdate == 0)
                    return new ReponsitoryModel { Data = ResultUpdate, StatusCode = CodeError.DeletedFail, Message = MessageError.DeletedFail };
                return new ReponsitoryModel { Data = ResultUpdate, Message = MessageSuccess.DeletedSuccess, StatusCode = CodeSuccess.Status200 };


            }
            catch (Exception ex)
            {
                return new ReponsitoryModel { Data = ex.Message, Message = MessageError.ProcessError, StatusCode = CodeError.ProcessError };
            }
        }

        /// <summary>
        /// Hàm lấy thông tin customers
        /// Author: Phạm Văn Đạt
        /// DateTime:  6;29 10/08/2022
        /// Xong
        /// </summary>
        /// <returns></returns>
        public async Task<ReponsitoryModel> GetAllCustomer()
        {
            try { 

                 string sql = @"SELECT customer.gender,customer.CustomerId,customer.LastName, customer.FirstName, customer.PotentialCode, customer.FullName, customer.CustomerPhoneNumber, customer.CompanyPhoneNumber, customer.CustomerEmail,customer.IsActiveEmail, customer.IsActivePhoneNumber, customer.CompanyEmail, customer.TaxCode, customer.Zalo, customer.Organization, customer.Address, customer.VocativeId, customer.DepartmentId, customer.PositionId, customer.SourceId, customer.OrganizationTypeId, customer.TurnoverId, customer.IsDelete, vocative.VocativeName, department.DepartmentName, positions.PositionName, source.SourceName, organizationtype.OrganizationTypeName, turnover.TurnoverName,customer.Country,customer.District,customer.Wards,customer.HomeNumber FROM customer LEFT JOIN vocative ON customer.VocativeId = vocative.VocativeId LEFT JOIN department ON customer.DepartmentId = department.DepartmentId LEFT JOIN positions ON customer.PositionId = positions.PositionId LEFT JOIN source ON customer.SourceId = source.SourceId LEFT JOIN organizationtype ON customer.OrganizationTypeId = organizationtype.OrganizationTypeId LEFT JOIN turnover ON customer.TurnoverId = turnover.TurnoverId WHERE customer.IsDelete = false ORDER BY customer.UpdatedAt DESC LIMIT 50";

                var result = await _dapper.GetAllAsync<CustomerModel>(sql);
                if (result == null)
                    return new ReponsitoryModel { Data = null, Message = MessageError.NotValue, StatusCode = CodeError.NotValue };
                return new ReponsitoryModel { Data = result, Message = MessageSuccess.GetSuccess, StatusCode = CodeSuccess.Status200 };
            }
            catch(Exception ex)
            {
                return new ReponsitoryModel { Data = ex, Message = MessageError.ProcessError, StatusCode = CodeError.ProcessError };
            }
            
        }


        /// <summary>
        /// Tìm kiếm khách hàng theo họ và tên
        /// Author: Phạm văn Đạt
        /// 20;34 10/08/2022
        /// đang có lỗi @FullName query có lỗi
        /// </summary>
        public async Task<ReponsitoryModel> GetCustomerByFullName(string _search)
        {
            try {
                var sql = @"SELECT customer.gender,customer.CustomerId,customer.LastName, customer.FirstName, customer.PotentialCode, customer.FullName, customer.CustomerPhoneNumber, customer.CompanyPhoneNumber, customer.CustomerEmail,customer.IsActiveEmail, customer.IsActivePhoneNumber, customer.CompanyEmail, customer.TaxCode, customer.Zalo, customer.Organization, customer.Address, customer.VocativeId, customer.DepartmentId, customer.PositionId, customer.SourceId, customer.OrganizationTypeId, customer.TurnoverId, customer.IsDelete, vocative.VocativeName, department.DepartmentName, positions.PositionName, source.SourceName, organizationtype.OrganizationTypeName, turnover.TurnoverName,customer.Country,customer.District,customer.Wards,customer.HomeNumber FROM customer LEFT JOIN vocative ON customer.VocativeId = vocative.VocativeId LEFT JOIN department ON customer.DepartmentId = department.DepartmentId LEFT JOIN positions ON customer.PositionId = positions.PositionId LEFT JOIN source ON customer.SourceId = source.SourceId LEFT JOIN organizationtype ON customer.OrganizationTypeId = organizationtype.OrganizationTypeId LEFT JOIN turnover ON customer.TurnoverId = turnover.TurnoverId WHERE FullName like @search and customer.IsDelete = false LIMIT 50";
                var parameters = new Dictionary<string, object>()
                {
                    ["search"] = $"%{_search}%"
                };
                var result = await _dapper.FindTAsync<CustomerModel>(sql, parameters);
                if (result.Count == 0)
                    return new ReponsitoryModel { Data = null, Message = MessageError.NotValue, StatusCode = CodeError.NotValue };
                return new ReponsitoryModel { Data = result, Message = MessageSuccess.GetSuccess, StatusCode = CodeSuccess.Status200 };

            }
            catch (Exception ex)
            {
                return new ReponsitoryModel { Data = ex, Message = MessageSuccess.GetSuccess, StatusCode = CodeSuccess.Status200 };
            }
        }

        /// <summary>
        /// Lấy mã code mới
        /// </summary>
        /// <returns></returns>
        public async Task<ReponsitoryModel> GetCustomerCodeMax()
        {
            try
            {
                var SqlDbType = @"SELECT MAX(customer.PotentialCode) as PotentialCode FROM customer";

                var code = await _dapper.GetCodeMaxAsync<CustomerCodeModel>(SqlDbType);
                if (code == null)
                    return new ReponsitoryModel { Data = null, Message = MessageError.NotValue, StatusCode = CodeError.NotValue };

                string[] ArrCode = code.PotentialCode.Split('-');
                long number;
                var isSuccess = Int64.TryParse(ArrCode[1], out number);
                if(isSuccess == true)
                {
                    var codeNew = ArrCode[0] + "-" + (number + 1).ToString();
                    return new ReponsitoryModel { Data = codeNew, Message = MessageSuccess.GetSuccess, StatusCode = CodeSuccess.Status200 };
                }

                    return new ReponsitoryModel { Data = null, Message = MessageError.NotValue, StatusCode = CodeError.NotValue };

            }
            catch (Exception ex)
            {
                return new ReponsitoryModel { Data = ex, Message = MessageError.ProcessError, StatusCode = CodeError.ProcessError };
            }
        }



        /// <summary>
        /// Cập nhật thông tin khách hàng
        /// Author: Phạm văn Đạt
        /// 20;34 10/08/2022
        /// chưa xong // update loai tiem nang
        /// </summary>
        public async Task<ReponsitoryModel> UpdateCustomer(UpdateCustomerModel model,string _id)
        {
            try
            {
                if (_id == null)
                    return new ReponsitoryModel { Data = null, Message = "Id " + MessageError.NotExists, StatusCode = CodeError.NotExists };

                var sql = @"Select * FROM Customer WHERE CustomerId = @CustomerId LIMIT 1";
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("CustomerId", _id);

                Customer customer = await _dapper.GetByIdAsync<Customer>(sql, dynamicParameters);
                // lấy thông tin customerId
                //var customer = await _dapper.GetByIdAsync<Customer>(sql);
                if(customer == null)
                    return new ReponsitoryModel { Data = null, Message = MessageError.NotFound, StatusCode = CodeError.NotFound };

                // check trùng mã số thuế
                if (model.TaxCode !=null)
                {
                    if (customer.TaxCode != model.TaxCode)
                    {
                        var ExistsTaxCode = await _dapper.FindCloumnTAsync<Customer>("Customer", "TaxCode", model.TaxCode);
                        if (ExistsTaxCode == true)
                            return new ReponsitoryModel { Data = null, StatusCode = CodeError.DuplicateTaxCode, Message = MessageError.DuplicateTaxCode };
                        customer.TaxCode = model.TaxCode;
                    }
                }
             
                
                // check trùng số điện thoại
                if(model.CustomerPhoneNumber != null)
                {
                    if (customer.CustomerPhoneNumber != model.CustomerPhoneNumber)
                    {
                        var ExistsUserPhone = await _dapper.FindCloumnTAsync<Customer>("Customer", "CustomerPhoneNumber", model.CustomerPhoneNumber);
                        if (ExistsUserPhone == true)
                            return new ReponsitoryModel { Data = null, StatusCode = CodeError.DuplicatePhone, Message = MessageError.DuplicatePhone };
                        customer.CustomerPhoneNumber = model.CustomerPhoneNumber;
                    }
                }

                // check trùng email
                if (model.CustomerEmail != null)
                {
                    if (customer.CustomerEmail != model.CustomerEmail)
                    {
                        var ExistsCustomerEmail = await _dapper.FindCloumnTAsync<Customer>("Customer", "CustomerEmail", model.CustomerEmail);
                        if (ExistsCustomerEmail == true)
                            return new ReponsitoryModel { Data = null, StatusCode = CodeError.DuplicateEmail, Message = MessageError.DuplicateEmail };
                        customer.CustomerPhoneNumber = model.CustomerPhoneNumber;
                    }
                }
              
                customer.VocativeId = model.VocativeId;

                if (model.LastName != null)
                    customer.LastName = model.LastName;

                if (model.FirstName != null)
                    customer.FirstName = model.FirstName;

                if (model.FullName != null)
                    customer.FullName = model.FullName;

                customer.DepartmentId = model.DepartmentId;

                customer.PositionId = model.PositionId;

                if (model.CustomerPhoneNumber != null)
                    customer.CustomerPhoneNumber = model.CustomerPhoneNumber;

                if (model.CompanyPhoneNumber != null)
                    customer.CompanyPhoneNumber = model.CompanyPhoneNumber;

                if (model.IsActivePhoneNumber == true)
                    customer.IsActivePhoneNumber = true;
                if (model.IsActivePhoneNumber == false)
                    customer.IsActivePhoneNumber = false;

                if (model.IsActiveEmail == true)
                    customer.IsActiveEmail = true;

                if(model.IsActiveEmail == false)
                    customer.IsActiveEmail = false;

                if (model.CustomerEmail != null)
                    customer.CustomerEmail = model.CustomerEmail;

                if (model.Zalo != null)
                    customer.Zalo = model.Zalo;

                if (model.CompanyEmail != null)
                    customer.CompanyEmail = model.CompanyEmail;

                if (model.Organization != null)
                    customer.Organization = model.Organization;

                if (model.TaxCode != null)
                    customer.TaxCode = model.TaxCode;

                if (model.BirthDay!= null)
                {
                    customer.BirthDay = model.BirthDay;
                }
                    

                if (model.Gender  >= (int)GenderEnum.Male && model.Gender <= (int)GenderEnum.Other)
                    customer.Gender = model.Gender;
                else
                {
                    return new ReponsitoryModel { Data = null, StatusCode = CodeError.GenderExists, Message = MessageError.GenderExists };
                }
                

                if (model.Facebook != null)
                    customer.Facebook = model.Facebook;


                customer.UpdatedAt = DateTime.Now;
                // update customer
                var SqlUpdate = @"UPDATE customer SET VocativeId = @VocativeId, LastName = @LastName, FirstName = @FirstName, FullName = @FullName, DepartmentId = @DepartmentId, PositionId = @PositionId, CustomerPhoneNumber = @CustomerPhoneNumber, CompanyPhoneNumber = @CompanyPhoneNumber, IsActivePhoneNumber = @IsActivePhoneNumber, IsActiveEmail = @IsActiveEmail, CustomerEmail = @CustomerEmail, CompanyEmail = @CompanyEmail, Zalo = @Zalo, Organization = @Organization, TaxCode = @TaxCode, BirthDay = @BirthDay, Gender = @Gender, Facebook = @Facebook WHERE CustomerId = @CustomerId";
                var dynamicParametersUpdate = new DynamicParameters();
                dynamicParametersUpdate.Add("VocativeId", customer.VocativeId);
                dynamicParametersUpdate.Add("LastName", customer.LastName);
                dynamicParametersUpdate.Add("FirstName", customer.FirstName);
                dynamicParametersUpdate.Add("FullName", customer.FullName);
                dynamicParametersUpdate.Add("DepartmentId", customer.DepartmentId);
                dynamicParametersUpdate.Add("PositionId", customer.PositionId);
                dynamicParametersUpdate.Add("CustomerPhoneNumber", customer.CustomerPhoneNumber);
                dynamicParametersUpdate.Add("CompanyPhoneNumber", customer.CompanyPhoneNumber);
                dynamicParametersUpdate.Add("IsActivePhoneNumber", customer.IsActivePhoneNumber);
                dynamicParametersUpdate.Add("IsActiveEmail", customer.IsActiveEmail);
                dynamicParametersUpdate.Add("CustomerEmail", customer.CustomerEmail);
                dynamicParametersUpdate.Add("CompanyEmail", customer.CompanyEmail);
                dynamicParametersUpdate.Add("Zalo", customer.Zalo);
                dynamicParametersUpdate.Add("Organization", customer.Organization);
                dynamicParametersUpdate.Add("TaxCode", customer.TaxCode);
                dynamicParametersUpdate.Add("BirthDay", customer.BirthDay);
                dynamicParametersUpdate.Add("Gender", customer.Gender);
                dynamicParametersUpdate.Add("Facebook", customer.Facebook);
                dynamicParametersUpdate.Add("CustomerId", _id);
                var ResultUpdate = await _dapper.UpdateTAsync<Customer>(SqlUpdate, dynamicParametersUpdate);
                if (ResultUpdate == 0)
                     return new ReponsitoryModel { Data = customer, StatusCode = CodeError.UpdateFailed, Message = MessageError.UpdatedFail };
                return new ReponsitoryModel { Data = customer, Message = MessageSuccess.UpdatedSuccess, StatusCode = CodeSuccess.Status200 };

                // update loai tiem nang

            }
            catch(Exception ex)
            {
                return new ReponsitoryModel { Data = ex, Message = MessageError.UpdatedFail, StatusCode = CodeError.UpdateFailed };
            }
        }


        /// <summary>
        /// Check trùng mã tiềm năng
        /// Author: Phạm văn Đạt
        /// 20;34 10/08/2022
        /// </summary>
        public async Task<ReponsitoryModel> CheckExistColumn(FormCheckExists model)
        {
            try
            {
                if (model.TableName == null || model.ColumnName == null || model.Value == null)
                    return new ReponsitoryModel { Data = null, StatusCode = CodeError.NotValue, Message = MessageError.NotValue };
                var result =  await _dapper.FindCloumnTAsync<Customer>(model.TableName, model.ColumnName, model.Value);
                return new ReponsitoryModel { Data = result, Message = MessageSuccess.GetSuccess, StatusCode = CodeSuccess.Status200 };
            }
            catch (Exception ex)
            {
                return new ReponsitoryModel { Data = ex, Message = MessageError.UpdatedFail, StatusCode = CodeError.UpdateFailed };
            }
        }

        /// <summary>
        /// Update nhiều
        /// Author: Phạm văn Đạt
        /// 16:55 24/08/2022
        /// </summary>
        public async Task<ReponsitoryModel> UpdateCustomerMul(UpdateCustomerMul model)
        {
            try
            {

                // kiểm tra xem id truyền vào có giá trị hay không
                if (model.ListId.Count == 0)
                    return new ReponsitoryModel { Data = null, Message = MessageError.NotValue, StatusCode = CodeError.NotValue };

                string SqlUpdate = $"UPDATE customer SET {model.ColumnName} = @ColumnValue, UpdatedAt = @UpdatedAt WHERE CustomerId IN @ListId";
                var parameters = new DynamicParameters();
                parameters.Add(name :"@ListId",value: model.ListId);
                //parameters.Add(name: "@ColumnName",value: model.ColumnName, dbType: DbType.String);
                parameters.Add(name: "@ColumnValue",value: model.ColumnValue, dbType: DbType.String);
                parameters.Add(name: "UpdatedAt",value: DateTime.Now);

                var ResultUpdate = await _dapper.UpdateTAsync<Customer>(SqlUpdate, parameters);

                if (ResultUpdate == 0)
                    return new ReponsitoryModel { Data = null, StatusCode = CodeError.DeletedFail, Message = MessageError.DeletedFail };
                return new ReponsitoryModel { Data = ResultUpdate, Message = MessageSuccess.UpdatedSuccess, StatusCode = CodeSuccess.Status200 };


            }
            catch (Exception ex)
            {
                return new ReponsitoryModel { Data = ex.Message, Message = MessageError.ProcessError, StatusCode = CodeError.ProcessError };
            }
        }

        public async Task<byte[]> ExportExcel(List<Guid> ListCustomerId = null)
        {
            byte[] fileContents;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage Ep = new ExcelPackage();

            ExcelWorksheet workSheet = Ep.Workbook.Worksheets.Add("CustomerInfo");

            // Tạo title
            workSheet.Cells["A1"].Value = "Xưng hô";
            workSheet.Cells["B1"].Value = "Họ và tên";
            workSheet.Cells["C1"].Value = "Chức danh";
            workSheet.Cells["D1"].Value = "ĐT di động";
            workSheet.Cells["E1"].Value = "ĐT cơ quan";
            workSheet.Cells["F1"].Value = "Email cơ quan";
            workSheet.Cells["G1"].Value = "Email cá nhân";
            workSheet.Cells["H1"].Value = "Tổ chức";
            workSheet.Cells["I1"].Value = "Mã số thuế";
            workSheet.Cells["J1"].Value = "Doanh thu";
            workSheet.Cells["K1"].Value = "Địa chỉ";


            var listTitle = new List<string>()
            {
                "A1","B1","C1","D1","E1","F1","G1","H1","I1","J1","K1"
            };

            listTitle.ForEach((title) =>
            {

                //  in đậm
                workSheet.Cells[title].Style.Font.Bold = true;

                // căn giữa
                workSheet.Cells[title].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                // màu background
                //workSheet.Cells[title].Style.Fill.BackgroundColor.SetColor(Color.Green);

                //workSheet.Cells["title:D32"].Style.Fill.PatternType = ExcelFillStyle.Solid;

                // border
                workSheet.Cells[title].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[title].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[title].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[title].Style.Border.Left.Style = ExcelBorderStyle.Thin;

                //Màu border
                //workSheet.Cells["A1:K1"].Style.Border.Bottom.Color.SetColor(Color.Black);

            });

            System.Drawing.Color colFromHex = System.Drawing.ColorTranslator.FromHtml("#70AD47");
            workSheet.Cells["A1:K1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells["A1:K1"].Style.Fill.BackgroundColor.SetColor(colFromHex);

            var sqlQuery = @"SELECT vocative.VocativeName,customer.FullName,positions.PositionName,customer.CustomerPhoneNumber, customer.CompanyPhoneNumber, customer.CustomerEmail,  customer.CompanyEmail,customer.Organization,customer.TaxCode,turnover.TurnoverName,customer.Address FROM customer LEFT JOIN vocative ON customer.VocativeId = vocative.VocativeId LEFT JOIN department ON customer.DepartmentId = department.DepartmentId LEFT JOIN positions ON customer.PositionId = positions.PositionId LEFT JOIN source ON customer.SourceId = source.SourceId LEFT JOIN organizationtype ON customer.OrganizationTypeId = organizationtype.OrganizationTypeId LEFT JOIN turnover ON customer.TurnoverId = turnover.TurnoverId WHERE customer.IsDelete = false";
            // lláy thông tin khách hàng
            if (ListCustomerId.Count != 0 )
                sqlQuery += " and customer.CustomerId IN @ListCustomerId";
            var parameters = new DynamicParameters();
            parameters.Add("@ListCustomerId", ListCustomerId);
            var result = await _dapper.GetAllAsync<ExcelModel>(sqlQuery, parameters);
            
            if(result.Count > 0)
            {

                // lấy dữ liệu
                int row = 2;
                foreach (var item in result)
                {
                    workSheet.Cells[string.Format("A{0}", row)].Value = (item.VocativeName != null) ? item.VocativeName : "-";
                    workSheet.Cells[string.Format("B{0}", row)].Value = (item.FullName != null) ? item.FullName : "-";
                    workSheet.Cells[string.Format("C{0}", row)].Value = (item.PositionName != null) ? item.PositionName : "-";
                    workSheet.Cells[string.Format("D{0}", row)].Value = (item.CustomerPhoneNumber != null) ? item.CustomerPhoneNumber : "-";
                    workSheet.Cells[string.Format("E{0}", row)].Value = (item.CompanyPhoneNumber != null) ? item.CompanyPhoneNumber : "-";
                    workSheet.Cells[string.Format("F{0}", row)].Value = (item.CompanyEmail != null) ? item.CompanyEmail : "-";
                    workSheet.Cells[string.Format("G{0}", row)].Value = (item.CustomerEmail != null) ? item.CustomerEmail : "-";
                    workSheet.Cells[string.Format("H{0}", row)].Value = (item.Organization != null) ? item.Organization : "-";
                    workSheet.Cells[string.Format("I{0}", row)].Value = (item.TaxCode != null) ? item.TaxCode : "-";
                    workSheet.Cells[string.Format("j{0}", row)].Value = (item.TurnoverName != null) ? item.TurnoverName : "-";
                    workSheet.Cells[string.Format("K{0}", row)].Value = (item.Address != null) ? item.Address : "-";
                    row++;
                }

                // border cho dữ liệu
                for(var i=0;i<= result.Count; i++)
                {
                    for(var j=1; j<= listTitle.Count; j++)
                    {
                        workSheet.Cells[i + 1, j].Style.Font.Size = 13;
                        workSheet.Cells[i+1,j].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        workSheet.Cells[i+1,j].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        workSheet.Cells[i+1,j].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        workSheet.Cells[i+1,j].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    }
                }

                workSheet.Cells["A:K"].AutoFitColumns();

                fileContents = Ep.GetAsByteArray();

                return fileContents;
            }
            return null;

           

           
        }
    }
}
