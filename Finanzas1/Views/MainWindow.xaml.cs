using Finanzas1.Data;
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
using Finanzas1.Models;
using Finanzas1.Services;
using Finanzas1.ViewModels;


namespace Finanzas1;


public partial class MainWindow : Window
{
  
    public MainWindow()
    {
        InitializeComponent();

        this.DataContext = new MainViewModels();
    }

private void BtnIngresoClick(object sender, RoutedEventArgs e)
    {
        var vm = (MainViewModels)this.DataContext;
        vm.AddMovement(MovementType.Income);
    }
    private void BtnGastoClick(object sender, RoutedEventArgs e)
    {
        var vm = (MainViewModels)this.DataContext;
        vm.AddMovement(MovementType.Expense);
    }


}