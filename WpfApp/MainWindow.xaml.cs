using BusinessObjects;
using Repositories;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ICategoryRepository iCategoryRepository;
        private readonly IProductRepository iProductRepository;
        public MainWindow()
        {
            InitializeComponent();
            iCategoryRepository = new CategoryRepository();
            iProductRepository = new ProductRepository();
            LoadCategoryList();
            LoadProductList();
        }

        public void LoadCategoryList()
        {
            try
            {
                var CateList = iCategoryRepository.GetCategories();
                cbxCategory.ItemsSource = CateList;
                cbxCategory.DisplayMemberPath = "CategoryName";
                cbxCategory.SelectedValuePath = "CategoryId";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on loading list of categories");
            }
        }

        public void LoadProductList()
        {
            try
            {
                var ProductList = iProductRepository.GetProducts();
                dgData.ItemsSource = ProductList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on loading list of products");
            }
            finally
            {
                ResetInput();
            }
        }


        public void ResetInput()
        {
            txtProductId.Text = "";
            txtProductName.Text = "";
            txtPrice.Text = "";
            txtUnits.Text = "";
            cbxCategory.SelectedValue = 0;
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product product = new Product();
                product.ProductName = txtProductName.Text;
                product.UnitPrice = Decimal.Parse(txtPrice.Text);
                product.UnitsInStock = short.Parse(txtUnits.Text);
                product.CategoryId = Int32.Parse(cbxCategory.SelectedValue.ToString());
                iProductRepository.AddNewProduct(product);
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error occurs when creating new products");
            } finally
            {
                LoadProductList();
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtProductId.Text.Length > 0)
                {
                    Product product = new Product();
                    product.ProductName = txtProductName.Text;
                    product.UnitPrice = Decimal.Parse(txtPrice.Text);
                    product.UnitsInStock = short.Parse(txtUnits.Text);
                    product.CategoryId = Int32.Parse(cbxCategory.SelectedValue.ToString());
                    product.CategoryId = Int32.Parse(cbxCategory.SelectedValue.ToString());
                    iProductRepository.UpdateProduct(product);
                } else
                {
                    MessageBox.Show("You must select a product");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error occurs when updating products");
            }
            finally
            {
                LoadProductList();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtProductId.Text.Length > 0)
                {
                    Product product = new Product();
                    product.ProductName = txtProductName.Text;
                    product.UnitPrice = Decimal.Parse(txtPrice.Text);
                    product.UnitsInStock = short.Parse(txtUnits.Text);
                    product.CategoryId = Int32.Parse(cbxCategory.SelectedValue.ToString());
                    product.CategoryId = Int32.Parse(cbxCategory.SelectedValue.ToString());
                    iProductRepository.DeleteProduct(product);
                } else
                {
                    MessageBox.Show("You must select a product");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error occurs when deleting products");
            }
            finally
            {
                LoadProductList();
            }
        }

        private void DataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid;
            DataGridRow row =
                (DataGridRow)dataGrid.ItemContainerGenerator
                .ContainerFromIndex(dataGrid.SelectedIndex);
            DataGridCell RowColumn =
                dataGrid.Columns[0].GetCellContent(row).Parent as DataGridCell;
            string id = ((TextBlock)RowColumn.Content).Text;
            Product product = iProductRepository.GetProductById(Int32.Parse(id));
            txtProductId.Text = product.ProductId.ToString();
            txtProductName.Text = product.ProductName;
            txtPrice.Text = product.UnitPrice.ToString();
            txtUnits.Text = product.UnitsInStock.ToString();
            cbxCategory.SelectedValue = product.CategoryId;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}