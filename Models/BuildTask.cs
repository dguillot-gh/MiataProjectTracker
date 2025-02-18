﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MiataProjectTracker.ValidationAttributes;

namespace MiataProjectTracker.Models
{
    public class BuildTasks
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Status is required")]
        [StatusValidation]
        public string Status { get; set; } = "Not Started";

        
        public bool PartsNeeded { get; set; } = false; 
        public bool PartsAcquired { get; set; } = false;   
    }
}