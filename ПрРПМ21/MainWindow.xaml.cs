using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ПрРПМ21
{

    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }

    public partial class MainWindow : Window
    {

        private ObservableCollection<Product> products;

        public MainWindow()
        {
            InitializeComponent();

            products = new ObservableCollection<Product>
            {
                new Product { Name = "Процессор Intel Core i5", Price = 20000, Quantity = 10 },
                new Product { Name = "Видеокарта RTX 3060", Price = 35000, Quantity = 5 },
                new Product { Name = "Оперативная память 16GB", Price = 5000, Quantity = 20 }
            };

            ProductsGrid.ItemsSource = products;
        }
        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            products.Add(new Product { Name = "Новый товар", Price = 0, Quantity = 0 });
        }

        //ПУПУПУ
        private void DeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            Product selectedProduct = ProductsGrid.SelectedItem as Product;

            if (selectedProduct != null)
            {
                products.Remove(selectedProduct); 
            }
            else
            {
                MessageBox.Show("Выберите товар для удаления!", "Внимание");
            }
        }
        private void BuyProduct_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Product selectedProduct = btn.DataContext as Product;

            if (selectedProduct != null)
            {

                if (selectedProduct.Quantity > 0)
                {
                    selectedProduct.Quantity--;

                    ProductsGrid.ItemsSource = null;
                    ProductsGrid.ItemsSource = products;
                }
                else
                {
                    MessageBox.Show("Столько нету зайдите позже", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}