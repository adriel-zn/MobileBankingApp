﻿namespace BankingApp.Shared.Models
{
    public class Beneficiary
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public string Bank { get; set; } = string.Empty;
        public string BankCode { get; set; } = string.Empty;
        public string BranchName { get; set; } = string.Empty;
        public string BranchCode { get; set; } = string.Empty;
    }
}
