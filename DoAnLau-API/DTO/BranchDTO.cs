﻿using DoAnLau_API.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DoAnLau_API.Interface
{
    public class BranchDTO
    {
        
        public string branch_Id { get; set; }
        
        public string branchName { get; set; }
        
        public string addressDetail { get; set; }
       
        public int ward { get; set; }
        
        public int district { get; set; }
       
        public int city { get; set; }

        public string? wardName { get; set; }

        public string? districtName { get; set; }

        public string? cityName { get; set; }

        public string phone { get; set; }
       
        public string email { get; set; }
        
        public string openingTime { get; set; }

        public bool state { get; set; }
    }
}
