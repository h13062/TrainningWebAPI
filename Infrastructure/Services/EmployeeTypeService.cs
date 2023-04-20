using ApplicationCore.Contract.Repositories;
using ApplicationCore.Contract.Services;
using ApplicationCore.Models;
using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class EmployeeTypeService : IEmployeeTypeService
    {
        IEmployeeTypeRepository employeeTypeRepository;
        public EmployeeTypeService(IEmployeeTypeRepository _employeeTypes)
        {
            employeeTypeRepository = _employeeTypes;
        }
        public async Task<int> AddEmployeeTypeAsync(EmployeeTypeRequestModel model)
        {
            var existingEmployeeType = await employeeTypeRepository.GetEmployeeTypeByTypeName(model.TypeName);
            if (existingEmployeeType != null)
            {
                throw new Exception("Employee Type already exists");
            }
            EmployeeType EmployeeType = new EmployeeType();
            if (model != null)
            {
                EmployeeType.TypeName = model.TypeName.ToLower();
            }
            //returns number of rows affected, typically 1
            return await employeeTypeRepository.InsertAsync(EmployeeType);
        }

        public async Task<int> DeleteEmployeeTypeAsync(int id)
        {
            //returns number of rows affected, typically 1
            return await employeeTypeRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<EmployeeTypeResponseModel>> GetAllEmployeeTypes()
        {
            var collection = await employeeTypeRepository.GetAllAsync();
            if (collection != null)
            {
                List<EmployeeTypeResponseModel> result = new List<EmployeeTypeResponseModel>();
                foreach (var item in collection)
                {
                    EmployeeTypeResponseModel model = new EmployeeTypeResponseModel();
                    model.Id = item.Id;
                    model.TypeName = item.TypeName;
                    model.TypeName = item.TypeName;
                    result.Add(model);
                }
                return result;
            }
            return null;
        }

        public async Task<EmployeeTypeResponseModel> GetEmployeeTypeByIdAsync(int id)
        {
            var collection = await employeeTypeRepository.GetByIdAsync(id);
            if (collection != null)
            {

                EmployeeTypeResponseModel model = new EmployeeTypeResponseModel();
                model.Id = collection.Id;
                model.TypeName = collection.TypeName;
                model.TypeName = collection.TypeName;
                return model;
            }
            return null;
        }

        public async Task<int> UpdateEmployeeTypeAsync(EmployeeTypeRequestModel model)
        {
            var existingEmployeeType = await employeeTypeRepository.GetEmployeeTypeByTypeName(model.TypeName);
            if (existingEmployeeType == null)
            {
                throw new Exception("EmployeeType does not exist");
            }
            EmployeeType employeeType = new EmployeeType();
            if (model != null)
            {
                employeeType.TypeName = model.TypeName.ToLower();
                return await employeeTypeRepository.UpdateAsync(employeeType);
            }
            else
            {
                //unsuccessful update
                return -1;
            }

        }
    }
}
