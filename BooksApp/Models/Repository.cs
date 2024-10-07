namespace BooksApp.Models{

    public class Repository{

        private static readonly List<Product> _products = new();
        private static readonly List<Category> _categories = new();

        static Repository(){
            _categories.Add(new Category{CategoryId = 1, Name = "Roman"});
            _categories.Add(new Category{CategoryId = 2, Name = "Bilim Kurgu"});

            _products.Add(new Product{ProductId = 1, Name = "Son Ayı", Pages = 150 ,IsActive = true, Image = "1.png",CategoryId = 1});
            _products.Add(new Product{ProductId = 2, Name = "Tarık Buğra'nın Roman Dünyası", Pages = 1500,IsActive = true, Image = "2.png",CategoryId = 1});
            _products.Add(new Product{ProductId = 3, Name = "Cadı", Pages = 15,IsActive = true, Image = "3.png",CategoryId = 2});
        }

        public static List<Product> Products{get{return _products;}}

        public static void CreateProduct(Product entity){
            _products.Add(entity);
        }
        public static List<Category> Categories{get{return _categories;}}
    }
}