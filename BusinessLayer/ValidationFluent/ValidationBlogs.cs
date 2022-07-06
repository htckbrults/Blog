namespace BusinessLayer.ValidationFluent
{
    public class ValidationBlogs:AbstractValidator<Blogs>
    {
        public ValidationBlogs()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Boş Bırakılamaz.");
            RuleFor(x => x.Name).MaximumLength(150).WithMessage("Maximum 150 Karakter");
            // RuleFor(x => x.Name).MinimumLength(5).MaximumLength(10);
            // RuleFor(x=> x.Name).CreditCard();
            // RuleFor(x => x.Name).EmailAddress();
            RuleFor(x => x.Explanation).NotNull().WithMessage("Boş Bırakılamaz.");
        }
    }
}
