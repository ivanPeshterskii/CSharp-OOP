using ModifyProductPrice.Models.Interfaces;
using ModifyProductPrice.Models.Enumerables;

public class ProductCommand : ICommand
{
    private Product _product;
    private PriceAction _action;
    private int _amount;

    public ProductCommand(Product product, PriceAction action, int amount)
    {
        _product = product;
        _action = action;
        _amount = amount;
    }

    public void Execute()
    {
        if (_action == PriceAction.Increase)
            _product.IncreasePrice(_amount);
        else
            _product.DecreasePrice(_amount);
    }
}