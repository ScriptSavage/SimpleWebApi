namespace Application.DTO;

public class CreateNewOrderDTO
{
    public int ClientId { get; set; }
    public int WarehouseID { get; set; }

    public List<ProductsList> ProductsLists { get; set; }
}

public class ProductsList
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}
