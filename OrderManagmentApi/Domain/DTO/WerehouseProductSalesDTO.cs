namespace Domain.DTO;

public class WerehouseProductSalesDTO
{
    public string WarehouseName { get; set; }
    public List<ProductSalesDTO> ProductSales{ get; set; }
}

public class ProductSalesDTO
{
    public string ProductName { get; set; }
    public int Quantity { get; set; }
}