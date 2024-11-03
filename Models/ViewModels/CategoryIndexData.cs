using Ghirean_Daria_Lab2.Models;

namespace Ghirean_Daria_Lab2.ViewModels
{
    public class CategoryIndexData
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}
