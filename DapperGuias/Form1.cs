using AccesoDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DapperDemo
{
    public partial class Form1 : Form
    {
        //Instancia de la clase CustomerRepository
        ProductoRepository productoRep = new ProductoRepository();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnObtenerTodos_Click(object sender, EventArgs e)
        {
            var productos = productoRep.ObtenerTodo();
            dgvCustomers.DataSource = productos;
        }

     

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            var nuevoCliente = CrearProducto();
            var insertado = productoRep.AddProductos(nuevoCliente);
            MessageBox.Show($"{insertado} REGISTRO INSERTADOS");

        }

        private Productos CrearProducto()
        {
            var nuevo = new Productos
            {
                
                Nombre = txtNombre.Text,
                Precio = decimal.Parse(txtPrecio.Text),
                Stock = int.Parse(txtStock.Text),
                Descripcion = txtDescripcion.Text,
                Marca   = txtMarca.Text,
                Proveedor = txtProveedor.Text
            };
            return nuevo;

        }

    }
}
