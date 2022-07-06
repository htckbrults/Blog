namespace BusinessLayer.ValidationFluent
{
    public class ValidationUsers:AbstractValidator<Users>
    {
        public ValidationUsers()
        {
            RuleFor(x => x.NameSurname).NotEmpty().WithMessage("Boş Bırakılamaz.");
            RuleFor(x => x.NameSurname).MaximumLength(100).WithMessage("Maximum 100 Karakter");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Boş Bırakılamaz.");
            RuleFor(x => x.Password).MaximumLength(30).WithMessage("Maximum 30 Karakter");

            RuleFor(x => x.Summary).NotEmpty().WithMessage("Boş Bırakılamaz.");
            RuleFor(x => x.Summary).MaximumLength(150).WithMessage("Maximum 150 Karakter");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Boş Bırakılamaz.");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Doğru Email Adresi Giriniz.");

            RuleFor(x => x.Explanation).NotEmpty().WithMessage("Boş Bırakılamaz.");
        }
    }
}
