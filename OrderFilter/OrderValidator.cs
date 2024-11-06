using FluentValidation;

namespace OrderFilter
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(o => o.Weight).GreaterThan(0).WithMessage("Вес заказа должен весить больше 0.");
            RuleFor(o => o.District).NotEmpty().WithMessage("Район заказа не может быть пустым.");
            RuleFor(o => o.DeliveryTime).NotEmpty().WithMessage("Время доставки не может быть пустым.");
        }
    }
}
