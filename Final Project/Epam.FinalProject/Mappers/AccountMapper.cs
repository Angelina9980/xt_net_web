using Entities;
using System;

namespace Mappers
{
    public static class AccountMapper
    {
        public static AccountEntity ToEntity(this AccountEntity account)
        {
            DateTime dateTimeNow = DateTime.Today;
            int age = dateTimeNow.Year - account.DateOfBirth.Year;
            if (account.DateOfBirth > dateTimeNow.AddYears(-age))
            {
                age--;
            }

            return new AccountEntity
            {
                Name = account.Name,
                Email = account.Email,
                Password = account.Password,
                Role = account.Role,
                Balance = account.Balance,
                CardInformation = account.CardInformation,
                Number = account.Number,
                DateOfBirth = account.DateOfBirth,
                Age = age
            };
        }
    }
}
