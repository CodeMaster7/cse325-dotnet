using BlazingPizza;

namespace BlazingPizza.Services;

/// <summary>
/// Scoped service: one cart/dialog state per Blazor Server circuit (per browser tab).
/// </summary>
public class OrderState
{
    public bool ShowingConfigureDialog { get; private set; }
    public Pizza? ConfiguringPizza { get; private set; }
    public Order Order { get; private set; } = new Order();

    public void ShowConfigurePizzaDialog(PizzaSpecial special)
    {
        ConfiguringPizza = new Pizza()
        {
            Special = special,
            SpecialId = special.Id,
            Size = Pizza.DefaultSize,
            Toppings = new List<PizzaTopping>(),
        };

        ShowingConfigureDialog = true;
    }

    public void CancelConfigurePizzaDialog()
    {
        ConfiguringPizza = null;
        ShowingConfigureDialog = false;
    }

    public void ConfirmConfigurePizzaDialog()
    {
        if (ConfiguringPizza is not null)
        {
            Order.Pizzas.Add(ConfiguringPizza);
        }

        ConfiguringPizza = null;
        ShowingConfigureDialog = false;
    }

    public void RemoveConfiguredPizza(Pizza pizza)
    {
        Order.Pizzas.Remove(pizza);
    }

    public void ResetOrder()
    {
        Order = new Order();
    }
}