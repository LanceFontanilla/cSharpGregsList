

namespace server.Models;

public class House
{
    public int Id { get; set; }
    public int SqFt { get; set; }
    public int Bedrooms { get; set; }  
    public double Bathrooms { get; set; }
    public string ImgUrl { get; set; }
    public string Description { get; set; }
    public int? Price { get; set; }
    public DateTime createdAt { get; set; }
    public DateTime updatedAt { get; set; }
    // NOTE once we have our DB created we wont use constructors.
}