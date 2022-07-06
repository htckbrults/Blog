namespace BusinessLayer.ValidationFluent
{
    public class ValidaitonComment : AbstractValidator<Comments>
    {
        public ValidaitonComment()
        {
            RuleFor(x => x.Commenter).MinimumLength(2).WithMessage("Minimum 2 Karakter");
            RuleFor(x => x.Commenter).MaximumLength(100).WithMessage("Maximum 100 Karakter");
            RuleFor(x => x.Email).MinimumLength(2).WithMessage("Minimum 2 Karakter");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Doğru Email Adresi Girilmedi.");
        }
    }
}
