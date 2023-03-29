﻿using MediatR;
using Regnology.Data;

namespace Regnology.Business
{
    public class CreateManagementCommand: IRequest<long>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public int Salary { get; set; }
        public string EmployeeId { get; set; }
        public string CNP { get; set; }
        public string IdSeriesNumber { get; set; }
        public int DivisionId { get; set; }

    }

    public sealed class CreateStaffResponse
    {
        public long Id { get; set; }
    }
}