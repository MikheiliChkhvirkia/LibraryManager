using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Applicaiton.Common
{
    public class AllowedExtensionsAttribute : ValidationAttribute
    {
        private readonly string[] _extensions;

        public AllowedExtensionsAttribute(string[] extensions)
        {
            _extensions = extensions;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is IFormFile file)
            {
                var fileExtension = Path.GetExtension(file.FileName)?.ToLowerInvariant();
                if (fileExtension != null && _extensions.Contains(fileExtension))
                {
                    return ValidationResult.Success!;
                }
                else
                {
                    var allowedExtensions = string.Join(", ", _extensions);
                    throw new Exception($"File can only be {allowedExtensions} format");
                }
            }

            return ValidationResult.Success!;
        }
    }
}
