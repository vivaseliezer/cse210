using System;
using System.Collections.Generic;
using System.Text;

public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double CalculateTotalCost()
    {
        double productTotalCost = 0;
        foreach (Product product in _products)
        {
            productTotalCost += product.CalculateTotalCost();
        }

        double shippingCost = _customer.IsInUSA() ? 5.00 : 35.00;
        return productTotalCost + shippingCost;
    }

    public string GetPackingLabel()
    {
        StringBuilder label = new StringBuilder();
        label.AppendLine("Packing Label:");
        foreach (Product product in _products)
        {
            label.AppendLine($"- ID: {product.GetProductId()} | Name: {product.GetName()} (Qty: {product.GetQuantity()})");
        }
        return label.ToString().TrimEnd();
    }

    public string GetShippingLabel()
    {
        StringBuilder label = new StringBuilder();
        label.AppendLine("Shipping Label:");
        label.AppendLine(_customer.GetName());
        label.AppendLine(_customer.GetAddress().GetFullAddress());
        return label.ToString().TrimEnd();
    }
}
