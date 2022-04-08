using EmployeeAssiginment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAssiginment.Service
{
    public interface IIdentityService
    {
        Task SignUpAsync(UserModel user);

        Task SignInAsync(UserModel user);
    }
}
