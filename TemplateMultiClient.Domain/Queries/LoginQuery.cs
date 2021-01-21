using System;
using System.Linq.Expressions;
using TemplateMultiClient.Domain.Entities;
using TemplateMultiClient.Domain.ValueObjects;

namespace TemplateMultiClient.Domain.Queries
{
    public static class LoginQuery
    {
        public static Expression<Func<User, bool>> GetByEmailAndPassword(string email, Password password)
        {
            return x => x.Email == email && x.Password.Value == password.Value;
        } 
    }
}