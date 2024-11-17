using System;

namespace Core.Dtos;

public class ProductDto
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required decimal Price { get; set; }
    public required string ImgUrl { get; set; }
    public required string Type { get; set; }
    public required string Brand { get; set; }
    public required int QuantityInStock { get; set; }
}
