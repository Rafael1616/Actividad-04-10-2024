using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public  class ProductoRepository
    {

        public List<Productos> ObtenerTodo()
        {
            using (var conexion = DataBase.GetSqlConnection())
            {
                string Query = @"SELECT [idProducto]
                                          ,[Nombre]
                                          ,[Precio]
                                          ,[Stock]
                                          ,[Descripcion]
                                          ,[Marca]
                                          ,[Proveedor]
                                      FROM [dbo].[Productos]";

                var cliente = conexion.Query<Productos>(Query).ToList();
                return cliente;
            }
        }

        public Productos ObtenerPorID(string id)
        {

            using (var conexion = DataBase.GetSqlConnection())
            {

                String selectPorID = "";
                selectPorID = selectPorID + "SELECT [CustomerID] " + "\n";
                selectPorID = selectPorID + "      ,[CompanyName] " + "\n";
                selectPorID = selectPorID + "      ,[ContactName] " + "\n";
                selectPorID = selectPorID + "      ,[ContactTitle] " + "\n";
                selectPorID = selectPorID + "      ,[Address] " + "\n";
                selectPorID = selectPorID + "      ,[City] " + "\n";
                selectPorID = selectPorID + "      ,[Region] " + "\n";
                selectPorID = selectPorID + "      ,[PostalCode] " + "\n";
                selectPorID = selectPorID + "      ,[Country] " + "\n";
                selectPorID = selectPorID + "      ,[Phone] " + "\n";
                selectPorID = selectPorID + "      ,[Fax] " + "\n";
                selectPorID = selectPorID + "  FROM [dbo].[Customers] " + "\n";
                selectPorID = selectPorID + "  WHERE CustomerID = @CustomerID";

                var Cliente = conexion.QueryFirstOrDefault<Productos>(selectPorID, new { CustomerID = id });
                return Cliente;
            }

        }

        public int AddProductos(Productos productos)
        {
            using (var conexion = DataBase.GetSqlConnection())
            {
                string Insertar = "";
                Insertar = Insertar + "INSERT INTO [dbo].[Productos]" + "\n";
                Insertar = Insertar + "           ([Nombre] " + "\n";
                Insertar = Insertar + "           ,[Precio] " + "\n";
                Insertar = Insertar + "           ,[Stock] " + "\n";
                Insertar = Insertar + "           ,[Descripcion] " + "\n";
                Insertar = Insertar + "           ,[Marca] " + "\n";
                Insertar = Insertar + "           ,[Proveedor]) " + "\n";
                Insertar = Insertar + "     VALUES " + "\n";
                Insertar = Insertar + "           (@Nombre " + "\n";
                Insertar = Insertar + "           ,@Precio " + "\n";
                Insertar = Insertar + "           ,@Stock " + "\n";
                Insertar = Insertar + "           ,@Descripcion " + "\n";
                Insertar = Insertar + "           ,@Marca " + "\n";
                Insertar = Insertar + "           ,@Proveedor)";
                var insertadas = conexion.Execute(Insertar, new
                {
                    Nombre = productos.Nombre,
                    Precio = productos.Precio,
                    Stock = productos.Stock,
                    Descripcion = productos.Descripcion,
                    Marca = productos.Marca,
                    Proveedor = productos.Proveedor,
                });
                return insertadas;
            }


        }

    }
}
