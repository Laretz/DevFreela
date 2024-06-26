using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreela.Application.ViewModels
{
    public class UserViewModels(string fullName, string email)
    {
        public string FullName { get; private set; } = fullName;
        public string Email { get; private set; } = email;
    }
}