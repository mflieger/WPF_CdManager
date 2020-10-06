using System;
using System.Collections.Generic;
using System.Linq;
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
using CdManager.Model;
using System.Collections.ObjectModel;

namespace CdManager.Wpf
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    private List<Cd> _cds;

    public MainWindow()
    {
      InitializeComponent();
      Loaded += new RoutedEventHandler(MainWindow_Loaded);

    }

    void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
      Repository rep = Repository.GetInstance();
      _cds = rep.GetAllCds();
      lbxCds.ItemsSource = _cds;

      btNew.Click += BtNew_Click;
    }

    /// <summary>
    /// Button Neu gedrückt
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void BtNew_Click(object sender, RoutedEventArgs e)
    {
      AddCdWindow addCdWindow = new AddCdWindow();
      addCdWindow.ShowDialog();
      //Nachdem der "Neuanlegen Dialog" geschlossen wurde
      //Liste der Cds aktualisieren:
      _cds = Repository.GetInstance().GetAllCds();
      //Bei normaler Collection muss zusätzlich ItemSource neu gesetzt werden
      //um Aktualisierung auszulösen (Alternative: ObservableCollection):
      lbxCds.ItemsSource = _cds;
    }

  }
}
