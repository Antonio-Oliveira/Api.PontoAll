﻿using PontoAll.Models.Companys;
using PontoAll.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoAll.Facade.Interfaces
{
    public interface ICompanyFacade
    {
        Task<Guid> RegisterCompany(CompanyInputModel companyInputModel);
    }
}
