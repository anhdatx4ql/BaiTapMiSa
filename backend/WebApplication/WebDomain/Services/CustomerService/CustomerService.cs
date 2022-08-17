using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebInfrastructure;
using static WebDomain.ContantsError;
using static WebDomain.ContantsSuccess;

namespace WebDomain
{
    public class CustomerService : ICustomerService
    {

        private readonly IDapperRepository _dapper;
        public CustomerService(IDapperRepository dapper)
        {
            _dapper = dapper;
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
                if (model.CustomerId == Guid.Empty)
                    model.CustomerId = Guid.NewGuid();

                // kiểm tra mã tiềm năng
                var ExistsPotentialCode = await _dapper.FindCloumnTAsync<Customer>("Customer", "PotentialCode", model.PotentialCode);
                if (ExistsPotentialCode != null)
                    return new ReponsitoryModel { Data = null, Message = MessageError.DuplicateCode, StatusCode = CodeError.DuplicateCode };

                // kiểm tra tên có tồn tại không
                if (model.FirstName == null)
                    return new ReponsitoryModel { Data = null, Message = "Tên " + MessageError.NotExists, StatusCode = CodeError.NotExists };

             
                // Kiểm tra số điện thoại cá nhân có tồn tại hay không rồi mới check trùng
                if(model.CustomerPhoneNumber != null)
                {
                    // check trùng số điện thoại cá nhân
                    var ExistsCustomerPhoneNumber = await _dapper.FindCloumnTAsync<Customer>("Customer", "CustomerPhoneNumber", model.CustomerPhoneNumber);
                    if (ExistsCustomerPhoneNumber != null)
                        return new ReponsitoryModel { Data = null, Message = MessageError.DuplicatePhone, StatusCode = CodeError.DuplicatePhone };
                }

                // kiểm tra email có tồn tại hay không
                if (model.CustomerEmail!= null)
                {
                    // check trùng  email
                    var ExistsCustomerEmail = await _dapper.FindCloumnTAsync<Customer>("Customer", "CustomerEmail", model.CustomerEmail);
                    if (ExistsCustomerEmail != null)
                        return new ReponsitoryModel { Data = null, Message = MessageError.DuplicateEmail, StatusCode = CodeError.DuplicateEmail };
                }

                // kiểm tra mã số thuế có tồn tại hay không
                if(model.TaxCode != null)
                {
                    // check trùng mã số thuế
                    var ExistsTaxCode = await _dapper.FindCloumnTAsync<Customer>("Customer", "TaxCode", model.TaxCode);
                    if (ExistsTaxCode != null)
                        return new ReponsitoryModel { Data = null, Message = MessageError.DuplicateTaxCode, StatusCode = CodeError.DuplicateTaxCode };
                }

                // kiểm tra tài khoản ngân hàng có tồn tại hay không
                if (model.BankAccount != null)
                {
                    // check trùng tài khoản ngân hàng
                    var ExistsBankAccount = await _dapper.FindCloumnTAsync<Customer>("Customer", "BankAccount", model.BankAccount);
                    if (ExistsBankAccount != null)
                        return new ReponsitoryModel { Data = null, Message = MessageError.DuplicateBankAccount, StatusCode = CodeError.DuplicateBankAccount };
                }

                model.updatedAt = DateTime.Now;
                model.CreatedAt = DateTime.Now;
                if(model.IsDelete == false)
                    model.IsDelete = false;
                else model.IsDelete = false;

                string sql = @"INSERT INTO customer (LastName, FirstName, FullName, PotentialCode, CustomerPhoneNumber, CompanyPhoneNumber, CustomerEmail, CompanyEmail, TaxCode, Zalo, Organization, CustomerDescription, Address, Country, Province, District, HomeNumber, RegionCode, BankAccount, BankName, VocativeId, DepartmentId, PositionId, SourceId, OrganizationTypeId, TurnoverId, CreatedAt, UpdatedAt, IsDelete, UpdatedBy, CreatedBy, CreatedTimeBankAccount, CustomerId,Wards)  VALUES (@LastName, @FirstName, @FullName, @PotentialCode, @CustomerPhoneNumber, @CompanyPhoneNumber, @CustomerEmail, @CompanyEmail, @TaxCode, @Zalo, @Organization, @CustomerDescription, @Address, @Country, @Province, @District, @HomeNumber, @RegionCode, @BankAccount, @BankName, @VocativeId, @DepartmentId, @PositionId, @SourceId, @OrganizationTypeId, @TurnoverId, @CreatedAt, @UpdatedAt, @IsDelete, @UpdatedBy, @CreatedBy, @CreatedTimeBankAccount,@CustomerId,@Wards)";

                var result = await _dapper.CreateTAsync<CreateCustomerModel>(sql, model);

                return new ReponsitoryModel { Data = result, Message = MessageSuccess.CreatedSuccess, StatusCode = CodeSuccess.CreatedSuccess };

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
        public async Task<ReponsitoryModel> DeleteCustomer(string[] ids)
        {
            try
            {
                // kiểm tra xem id truyền vào có giá trị hay không
                if(ids == null)
                    return new ReponsitoryModel { Data = null, Message = MessageError.NotValue, StatusCode = CodeError.NotValue };

                string SqlUpdate = @"UPDATE customer SET IsDelete=true,UpdatedAt = " + DateTime.Now + " WHERE CustomerId IN (";
                int dem = 0;
                foreach (string id in ids)
                {
                    
                    // lấy thông tin khách hàng
                    var sql = @"Select * FROM Customer WHERE CustomerId = @CustomerId";
                    var dynamicParameterId = new DynamicParameters();
                    dynamicParameterId.Add(id);
                    Customer customer = await _dapper.GetByIdAsync<Customer>(sql, dynamicParameterId);
                    // kiểm tra xem khách hàng có tồn tại hay không
                    if (customer == null)
                    {
                        dem++;
                        return new ReponsitoryModel { Data = null, Message = MessageError.NotFound, StatusCode = CodeError.NotFound };

                    }

                    if (dem ==1)
                    {
                        customer.UpdatedAt = DateTime.Now;
                        // update customer
                        SqlUpdate += "'@CustomerId" + dem + "'";
                    }
                    if (dem >1)
                    {
                        customer.UpdatedAt = DateTime.Now;
                        // update customer
                        SqlUpdate += ",'@CustomerId" + dem + "'";
                    }
                    
                }

                // đã lấy ra được câu truy vấn, giờ truyền biến vào để thực thi
                int DemParams = 0;
                var dynamicParameters = new DynamicParameters();
                foreach(string id in ids)
                {
                    dem++;
                    dynamicParameters.Add("CustomerId" + DemParams, id);
                }
               

                var ResultUpdate = await _dapper.UpdateTAsync<Customer>(SqlUpdate, dynamicParameters);

                if (ResultUpdate == 0)
                    return new ReponsitoryModel { Data = ResultUpdate, StatusCode = CodeError.DeletedFail, Message = MessageError.DeletedFail };
                return new ReponsitoryModel { Data = ResultUpdate, Message = MessageSuccess.DeletedSuccess, StatusCode = CodeSuccess.DeletedSuccess };


            }
            catch (Exception ex)
            {
                return new ReponsitoryModel { Data = ex, Message = MessageError.ProcessError, StatusCode = CodeError.ProcessError };
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
            try
            {
                string sql = @"SELECT customer.CustomerId, customer.PotentialCode, customer.FullName, customer.CustomerPhoneNumber, customer.CompanyPhoneNumber, customer.CustomerEmail, customer.CompanyEmail, customer.TaxCode, customer.Zalo, customer.Organization, customer.Address, customer.VocativeId, customer.DepartmentId, customer.PositionId, customer.SourceId, customer.OrganizationTypeId, customer.TurnoverId, customer.IsDelete, vocative.VocativeName, department.DepartmentName, positions.PositionName, source.SourceName, organizationtype.OrganizationTypeName, turnover.TurnoverName FROM customer LEFT JOIN vocative ON customer.VocativeId = vocative.VocativeId LEFT JOIN department ON customer.DepartmentId = department.DepartmentId LEFT JOIN positions ON customer.PositionId = positions.PositionId LEFT JOIN source ON customer.SourceId = source.SourceId LEFT JOIN organizationtype ON customer.OrganizationTypeId = organizationtype.OrganizationTypeId LEFT JOIN turnover ON customer.TurnoverId = turnover.TurnoverId WHERE customer.IsDelete = false ORDER BY customer.UpdatedAt DESC LIMIT 50";

                var result = await _dapper.GetAllAsync<CustomerModel>(sql);
                if (result == null)
                    return new ReponsitoryModel { Data = null, Message = MessageError.NotValue, StatusCode = CodeError.NotValue };
                return new ReponsitoryModel { Data = result, Message = MessageSuccess.GetSuccess, StatusCode = CodeSuccess.GetSuccess };
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
                var sql = @"SELECT customer.CustomerId, customer.PotentialCode, customer.FullName, customer.CustomerPhoneNumber, customer.CompanyPhoneNumber, customer.CustomerEmail, customer.CompanyEmail, customer.TaxCode, customer.Zalo, customer.Organization, customer.Address, customer.VocativeId, customer.DepartmentId, customer.PositionId, customer.SourceId, customer.OrganizationTypeId, customer.TurnoverId, customer.IsDelete, vocative.VocativeName, department.DepartmentName, positions.PositionName, source.SourceName, organizationtype.OrganizationTypeName, turnover.TurnoverName FROM customer LEFT JOIN vocative ON customer.VocativeId = vocative.VocativeId LEFT JOIN department ON customer.DepartmentId = department.DepartmentId LEFT JOIN positions ON customer.PositionId = positions.PositionId LEFT JOIN source ON customer.SourceId = source.SourceId LEFT JOIN organizationtype ON customer.OrganizationTypeId = organizationtype.OrganizationTypeId LEFT JOIN turnover ON customer.TurnoverId = turnover.TurnoverId WHERE FullName like @search and customer.IsDelete = false LIMIT 10";
                var parameters = new Dictionary<string, object>()
                {
                    ["search"] = $"%{_search}%"
                };
                var result = await _dapper.FindTAsync<CustomerModel>(sql, parameters);
                if (result.Count == 0)
                    return new ReponsitoryModel { Data = null, Message = MessageError.NotValue, StatusCode = CodeError.NotValue };
                return new ReponsitoryModel { Data = result, Message = MessageSuccess.GetSuccess, StatusCode = CodeSuccess.GetSuccess };

            }
            catch (Exception ex)
            {
                return new ReponsitoryModel { Data = ex, Message = MessageSuccess.GetSuccess, StatusCode = CodeSuccess.GetSuccess };
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

                var sql = @"Select * FROM Customer WHERE CustomerId = @CustomerId";
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("CustomerId", _id);

                Customer customer = await _dapper.GetByIdAsync<Customer>(sql, dynamicParameters);
                // lấy thông tin customerId
                //var customer = await _dapper.GetByIdAsync<Customer>(sql);
                if(customer == null)
                    return new ReponsitoryModel { Data = null, Message = MessageError.NotFound, StatusCode = CodeError.NotFound };

                // không cho null
                if(model.FirstName == null )
                    return new ReponsitoryModel { Data = null, Message = "Tên "+MessageError.NotExists, StatusCode = CodeError.NotExists };

                // check trùng mã số thuế
                if (model.TaxCode != null)
                {
                    var ExistsUserPhone = await _dapper.FindCloumnTAsync<Customer>("Customer", "TaxCode", model.TaxCode);
                    if (ExistsUserPhone != null)
                        return new ReponsitoryModel { Data = null, StatusCode =CodeError.DuplicateTaxCode, Message = MessageError.DuplicateTaxCode };
                    customer.CustomerPhoneNumber = model.CustomerPhoneNumber;
                }
                
                // check trùng số điện thoại
                if (model.CustomerPhoneNumber != null)
                {
                    var ExistsUserPhone = await _dapper.FindCloumnTAsync<Customer>("Customer", "CustomerPhoneNumber", model.CustomerPhoneNumber);
                    if (ExistsUserPhone != null)
                        return new ReponsitoryModel { Data = null, StatusCode =CodeError.DuplicatePhone, Message = MessageError.DuplicatePhone };
                    customer.CustomerPhoneNumber = model.CustomerPhoneNumber;
                }

                // check trùng email
                if (model.CustomerEmail != null)
                {
                    var ExistsUserPhone = await _dapper.FindCloumnTAsync<Customer>("Customer", "CustomerEmail", model.CustomerEmail);
                    if (ExistsUserPhone != null)
                        return new ReponsitoryModel { Data = null, StatusCode =CodeError.DuplicateEmail, Message = MessageError.DuplicateEmail };
                    customer.CustomerPhoneNumber = model.CustomerPhoneNumber;
                }

                if (model.VocativeId != null)
                    customer.VocativeId = model.VocativeId;

                if (model.LastName != null)
                    customer.LastName = model.LastName;

                if (model.FirstName != null)
                    customer.FirstName = model.FirstName;

                if (model.FullName != null)
                    customer.FullName = model.FullName;

                if (model.DepartmentId != null)
                    customer.DepartmentId = model.DepartmentId;

                if (model.PositionId != null)
                    customer.PositionId = model.PositionId;

                if (model.CustomerPhoneNumber != null)
                    customer.CustomerPhoneNumber = model.CustomerPhoneNumber;

                if (model.CompanyPhoneNumber != null)
                    customer.CompanyPhoneNumber = model.CompanyPhoneNumber;

                if (model.IsActivePhoneNumber == true)
                    customer.IsActivePhoneNumber = true;
                else customer.IsActivePhoneNumber = false;

                if (model.IsActiveEmail == true)
                    customer.IsActiveEmail = true;
                else customer.IsActiveEmail = false;

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

                if (model.BirthDay!= DateTime.MinValue)
                {
                    customer.BirthDay = model.BirthDay;
                }
                    

                if (model.Gender>=0 && model.Gender<=2)
                    customer.Gender = model.Gender;

                if (model.Facebook != null)
                    customer.Facebook = model.Facebook;

                if (model.Country != null)
                    customer.Country = model.Country;

                if (model.Province != null)
                    customer.Province = model.Province;

                if (model.District != null)
                    customer.District = model.District;

                if (model.Wards != null)
                    customer.Wards = model.Wards;

                if (model.HomeNumber != null)
                    customer.HomeNumber = model.HomeNumber;

                if (model.RegionCode != null)
                    customer.RegionCode = model.RegionCode;

                if (model.Address != null)
                    customer.Address = model.Address;

                customer.UpdatedAt = DateTime.Now;
                // update customer
                var SqlUpdate = @"UPDATE customer SET VocativeId = @VocativeId, LastName = @LastName, FirstName = @FirstName, FullName = @FullName, DepartmentId = @DepartmentId, PositionId = @PositionId, CustomerPhoneNumber = @CustomerPhoneNumber, CompanyPhoneNumber = @CompanyPhoneNumber, IsActivePhoneNumber = @IsActivePhoneNumber, IsActiveEmail = @IsActiveEmail, CustomerEmail = @CustomerEmail, CompanyEmail = @CompanyEmail, Zalo = @Zalo, Organization = @Organization, TaxCode = @TaxCode, BirthDay = @BirthDay, Gender = @Gender, Facebook = @Facebook, Country = @Country, Province = @Province, District = @District, HomeNumber = @HomeNumber, RegionCode = @RegionCode, Address = @Address WHERE CustomerId = @CustomerId";
                var dynamicParametersUpdate = new DynamicParameters();
                dynamicParametersUpdate.Add("VocativeId", customer.VocativeId);
                dynamicParametersUpdate.Add("LastName", customer.LastName);
                dynamicParametersUpdate.Add("FirstName", customer.FirstName);
                dynamicParametersUpdate.Add("FullName", customer.FullName);
                dynamicParametersUpdate.Add("DepartmentId", customer.DepartmentId);
                dynamicParametersUpdate.Add("PositionId", customer.PositionId);
                dynamicParametersUpdate.Add("CustomerPhoneNumber", customer.CustomerPhoneNumber);
                dynamicParametersUpdate.Add("CompanyPhoneNumber", customer.CompanyPhoneNumber);
                dynamicParametersUpdate.Add("IsActivePhoneNumber", customer.IsActiveEmail);
                dynamicParametersUpdate.Add("IsActiveEmail", customer.IsActiveEmail);
                dynamicParametersUpdate.Add("CustomerEmail", customer.CustomerEmail);
                dynamicParametersUpdate.Add("CompanyEmail", customer.CompanyEmail);
                dynamicParametersUpdate.Add("Zalo", customer.Zalo);
                dynamicParametersUpdate.Add("Organization", customer.Organization);
                dynamicParametersUpdate.Add("TaxCode", customer.TaxCode);
                dynamicParametersUpdate.Add("BirthDay", customer.BirthDay);
                dynamicParametersUpdate.Add("Gender", customer.Gender);
                dynamicParametersUpdate.Add("Facebook", customer.Facebook);
                dynamicParametersUpdate.Add("Country", customer.Country);
                dynamicParametersUpdate.Add("Province", customer.Province);
                dynamicParametersUpdate.Add("District", customer.District);
                dynamicParametersUpdate.Add("HomeNumber", customer.HomeNumber);
                dynamicParametersUpdate.Add("RegionCode", customer.RegionCode);
                dynamicParametersUpdate.Add("Address", customer.Address);
                dynamicParametersUpdate.Add("CustomerId", _id);
                var ResultUpdate = await _dapper.UpdateTAsync<Customer>(SqlUpdate, dynamicParametersUpdate);
                if (ResultUpdate == 0)
                     return new ReponsitoryModel { Data = customer, StatusCode = CodeError.UpdateFailed, Message = MessageError.UpdatedFail };
                return new ReponsitoryModel { Data = customer, Message = MessageSuccess.UpdatedSuccess, StatusCode = CodeSuccess.UpdatedSuccess };

                // update loai tiem nang

            }
            catch(Exception ex)
            {
                return new ReponsitoryModel { Data = ex, Message = MessageError.UpdatedFail, StatusCode = CodeError.UpdateFailed };
            }
        }

    }
}
