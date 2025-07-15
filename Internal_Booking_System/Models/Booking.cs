using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace InternalBookingSystem.Models
{
    // Custom validation attribute to ensure EndTime > StartTime
    public class DateGreaterThanAttribute : ValidationAttribute
    {
        private readonly string _comparisonProperty;

        public DateGreaterThanAttribute(string comparisonProperty)
        {
            _comparisonProperty = comparisonProperty;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var currentValue = (DateTime?)value;

            var property = validationContext.ObjectType.GetProperty(_comparisonProperty);
            if (property == null)
                throw new ArgumentException($"Property '{_comparisonProperty}' not found.");

            var comparisonValue = (DateTime?)property.GetValue(validationContext.ObjectInstance);

            if (currentValue != null && comparisonValue != null)
            {
                if (currentValue <= comparisonValue)
                {
                    return new ValidationResult(ErrorMessage ?? $"{validationContext.MemberName} must be later than {_comparisonProperty}.");
                }
            }

            return ValidationResult.Success;
        }
    }

    public class Booking
    {
        public int Id { get; set; }

        [Required]
        public int ResourceId { get; set; }

        [Required(ErrorMessage = "Start time is required")]
        public DateTime StartTime { get; set; }

        [Required(ErrorMessage = "End time is required")]
        [DateGreaterThan("StartTime", ErrorMessage = "End time must be after start time")]
        public DateTime EndTime { get; set; }

        [Required(ErrorMessage = "Booked by is required")]
        [StringLength(100, ErrorMessage = "Booked by cannot exceed 100 characters")]
        public string BookedBy { get; set; } = string.Empty;

        [Required(ErrorMessage = "Purpose is required")]
        [StringLength(200, ErrorMessage = "Purpose cannot exceed 200 characters")]
        public string Purpose { get; set; } = string.Empty;

        [ValidateNever]
        public Resource? Resource { get; set; }
    }
}
