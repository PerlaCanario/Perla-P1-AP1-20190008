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

namespace PerlaD_P1_AP1_20190008.UI.Registros
{
    /// <summary>
    /// Lógica de interacción para rAportes.xaml
    /// </summary>
    public partial class rAportes : Window
    {
        private Aportes aportes;
        public rAportes()
        {
            InitializeComponent();
            aportes = new Aportes();
            this.DataContext = aportes;
        }
        private void Limpiar()
        {
            this.aportes = new Aportes();
            this.DataContext = aportes;
        }
        public void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
        private bool Validar()
        {
            bool esValido = true;
            if (AportesBLL.Existe(PersonaTextBox.Text))
            {
                esValido = false;
                MessageBox.Show("Ha ocurrido un error, no puede repetir el nombre", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
; if (PersonaTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Ha ocurrido un error, debe insertar un nombre", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (PersonaTextBox.Text.Any(char.IsDigit))
            {
                esValido = false;
                MessageBox.Show("Ha ocurrido un error, no hay ciudades con numeros", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            return esValido;
        }
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var ciudad = AportesBLL.Buscar(Convert.ToInt32(AportesIdTextBox.Text));
            if (ciudad != null)
                this.aportes = ciudad;
            else
            {
                this.aportes = new Aportes();
                MessageBox.Show("No se ha encontrado", "Error",
                   MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            this.DataContext = this.aportes;
        }
        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {

            if (!Validar())
                return;
            var paso = AportesBLL.Guardar(this.aportes);
            if (paso)
            {
                Limpiar();
                MessageBox.Show("Transaccion exitosa", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Transaccion fallida", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (AportesBLL.Eliminar(Convert.ToInt32(AportesIdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Registro eliminado", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No fue posible eliminar", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);

        }
    }
}
