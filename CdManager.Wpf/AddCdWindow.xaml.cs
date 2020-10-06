using CdManager.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CdManager.Wpf
{
  /// <summary>
  /// Interaction logic for AddCdWindow.xaml
  /// </summary>
  public partial class AddCdWindow : Window
  {
    private Cd _newCd;

    public AddCdWindow()
    {
      InitializeComponent();
      Loaded += new RoutedEventHandler(AddCdWindow_Loaded);
    }

    void AddCdWindow_Loaded(object sender, RoutedEventArgs e)
    {
      btSave.Click += BtSave_Click;
      btCancel.Click += BtCancel_Click;

      _newCd = new Cd
      {
        AlbumTitle = "< hier Titel eingeben >"
      };
      grdCdFields.DataContext = _newCd;
    }

    /// <summary>
    /// Button Cancel gedrückt
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void BtCancel_Click(object sender, RoutedEventArgs e)
    {
      Close();
    }

    /// <summary>
    /// Button Save gedrückt
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void BtSave_Click(object sender, RoutedEventArgs e)
    {
      //Neue Cd in Repository hinzufügen - ohne Fehlerprüfung
      Repository.GetInstance().AddCd(_newCd);
      Close();
    }
  }
}
