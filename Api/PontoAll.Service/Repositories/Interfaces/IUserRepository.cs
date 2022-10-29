﻿using PontoAll.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoAll.Service.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task RegisterAdminForCompany(ApplicationUser admin, string password);
    }
}
