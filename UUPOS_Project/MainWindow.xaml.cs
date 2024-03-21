using System.Numerics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UUPOS_Project.Class_s;

namespace UUPOS_Project
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            categories_ListView.Items.Add("Category");
            categories_ListView.Items.Add("Category");
            categories_ListView.Items.Add("Category");

            Product[] products = new Product[]
            {
                new Product("Pepsi", 1, "10.0"),
                new Product("Pepsi Special Edition", 90, "15.0"),
            };

            foreach (Product product in products)
            {
                BuyingList.Items.Add(product);
            }
            UpdateBuyingList();
        }

        private void categories_additem_Button_Click(object sender, RoutedEventArgs e)
        {
            categories_ListView.Items.Add("Category");
        }

        private int categories_editingIndex = -1;

        private void categories_edititem_button_Click(object sender, RoutedEventArgs e)
        {
            if (categories_ListView.SelectedItem != null)
            {
                categories_editingIndex = categories_ListView.SelectedIndex;

                categories_editnamepopup_Button.Text = categories_ListView.Items[categories_editingIndex].ToString();

                categories_editnamepopup_Popup.IsOpen = true;
            }
        }

        private void categories_additem_Popup_Button_Click(object sender, RoutedEventArgs e)
        {
            if (categories_editnamepopup_Button.Text == "") return;
            if (categories_editingIndex != -1)
            {
                categories_ListView.Items[categories_editingIndex] = categories_editnamepopup_Button.Text;
                categories_editingIndex = -1;
            }
            categories_editnamepopup_Popup.IsOpen = false;

        }


        #region Popup_Drag
        private bool isDragging = false;
        private Point lastMousePosition;

        private void Popup_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isDragging = true;
            lastMousePosition = e.GetPosition(categories_editnamepopup_Popup);
            categories_editnamepopup_Popup.CaptureMouse();
        }

        private void Popup_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point currentMousePosition = e.GetPosition(categories_editnamepopup_Popup);
                double deltaX = currentMousePosition.X - lastMousePosition.X;
                double deltaY = currentMousePosition.Y - lastMousePosition.Y;

                categories_editnamepopup_Popup.HorizontalOffset += deltaX;
                categories_editnamepopup_Popup.VerticalOffset += deltaY;

                lastMousePosition = currentMousePosition;
            }
        }

        private void Popup_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isDragging = false;
            categories_editnamepopup_Popup.ReleaseMouseCapture();
        }

        #endregion

        private void UpdateBuyingList()
        {
            double total = 0.0;

            foreach (var item in BuyingList.Items)
            {
                if (item is Product product)
                {
                    total += Convert.ToDouble(product.Price);
                }
            }
            buyinglistTotal.Text = "$" + total.ToString() + "  ";
        }

        private int buyinglist_editingIndex = -1;
        private void buyinglist_increaseamount_Button_Click(object sender, RoutedEventArgs e)
        {
            if (BuyingList.SelectedItem != null)
            {
                if (BuyingList.SelectedItem is Product selectedProduct)
                {
                    if (selectedProduct.Quantity < 99) selectedProduct.Quantity++;
                    else selectedProduct.Quantity = 99;
                    BuyingList.Items.Refresh();
                }
            }
        }

        private void buyinglist_decreaseamount_Button_Click(object sender, RoutedEventArgs e)
        {
            if (BuyingList.SelectedItem != null)
            {
                if (BuyingList.SelectedItem is Product selectedProduct)
                {
                    if(selectedProduct.Quantity > 0) selectedProduct.Quantity--;
                    else selectedProduct.Quantity = 0;
                    BuyingList.Items.Refresh();
                }
            }
        }
    }

}
