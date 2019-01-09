using Microsoft.EntityFrameworkCore;

namespace OwnedEntities
{
    [Owned]
    public class Location
    {
        public string Country { get; set; }
        public string City { get; set; }
    }
}
