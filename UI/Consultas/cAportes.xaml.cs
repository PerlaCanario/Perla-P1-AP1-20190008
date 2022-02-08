using PerlaD_P1_AP1_20190008.BLL;
using PerlaD_P1_AP1_20190008.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PerlaD_P1_AP1_20190008.UI.Consultas
{
    /// <summary>
    /// Lógica de interacción para cAportes.xaml
    /// </summary>
    public partial class cAportes : Window
    {
        public cAportes()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Aportes>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComBox.SelectedIndex)
                {
                    case 0:
                        listado = AportesBLL.GetList(e => e.Persona.ToLower().Contains(CriterioTextBox.Text.ToLower()));
                        break;

                    case 1:
                        listado = AportesBLL.GetList(e => e.Descripcion.ToLower().Contains(CriterioTextBox.Text.ToLower()));
                        break;
                }
            }
            else
            {
                listado = AportesBLL.GetList(c => true);
            }
            if (DesdeDatePicker.SelectedDate != null)
                listado = AportesBLL.GetList(c => c.Fecha.Date >= DesdeDatePicker.SelectedDate);

            if (HastaDataPicker.SelectedDate != null)
                listado = AportesBLL.GetList(c => c.Fecha.Date <= HastaDataPicker.SelectedDate);

            AportesDataGrid.ItemsSource = null;
            AportesDataGrid.ItemsSource = listado;

            var Conteo = listado.Count();
            ConteoTextBox.Text = Conteo.ToString();

            var Total = listado.Sum(x => x.Monto);
            TotalTextBox.Text = Total.ToString();
        }

    }
}
