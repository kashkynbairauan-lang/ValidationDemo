using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ValidationDemo.Models
{
    // Өздік жұмыс үшін IValidatableObject интерфейсін қостық
    public class RegisterViewModel : IValidatableObject
    {
        [Required(ErrorMessage = "Аты-жөніңізді енгізу міндетті!")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Атыңыз 2-ден 50 таңбаға дейін болуы керек.")]
        [Display(Name = "Аты-жөні")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email енгізу міндетті!")]
        [EmailAddress(ErrorMessage = "Дұрыс email формат енгізіңіз (мысалы: test@mail.com)")]
        [Display(Name = "Электронды пошта")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Құпиясөзді енгізіңіз!")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Құпиясөз кемінде 6 таңбадан тұруы керек.")]
        [DataType(DataType.Password)]
        [Display(Name = "Құпиясөз")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Құпиясөзді растау міндетті!")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Құпиясөздер сәйкес келмейді!")]
        [Display(Name = "Құпиясөзді растау")]
        public string ConfirmPassword { get; set; } = string.Empty;

        [Range(18, 100, ErrorMessage = "Жасыңыз 18-ден 100-ге дейін болуы керек.")]
        [Display(Name = "Жасы")]
        public int Age { get; set; }

        // Бұл өздік жұмысқа арналған кастомды валидация (Қосымша баға үшін)
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (FullName != null && FullName.ToLower().StartsWith("admin"))
            {
                yield return new ValidationResult(
                    "Аты-жөні 'Admin' деп басталмауы керек!",
                    new[] { nameof(FullName) }
                );
            }
        }
    }
}