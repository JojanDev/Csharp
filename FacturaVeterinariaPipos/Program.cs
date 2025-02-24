namespace FacturaVeterinariaPipos
{

    class Cliente
    {
        public string Nombre;
        public Cliente(string nombre)
        {
            Nombre = nombre;
        }
    }

    class Producto
    {
        public string Nombre;
        public Producto(string nombre)
        {
            Nombre = nombre;
        }
    }

    class Factura
    {
        public string Cliente;
        public List<Producto> listaProductosFactura;
        public Factura(string cliente)
        {
            listaProductosFactura = new List<Producto>();
            Cliente = cliente;
        }
    }
    internal class Program
    {
        List<Cliente> listaClientes;
        List<Producto> listaProductos;
        List<Factura> listaFacturas;

        public Program()
        {
            listaProductos = new List<Producto>()
            {
                new Producto("Correa"),
                new Producto("Shampoo"),
                new Producto("Cepillo")
            };

            listaClientes = new List<Cliente>();
            listaFacturas = new List<Factura>();
        }

        public void mostrarMenu()
        {
            Console.Write("MENU:\n" +
                          "\n1. Registrar un cliente.\n" +
                          "2. Mostrar clientes.\n" +
                          "3. Registrar un producto.\n" +
                          "4. Mostrar Productos.\n" +
                          "5. Facturar una compra.\n" +
                          "6  Mostrar facturas\n" +
                          "0. Salir.\n" +
                          "\nIngresa una opcion del menu: ");

            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                        
                    registrarCliente();
                    mostrarMenu();
                    break;
                case 2:
                    if (!listasVacias(listaClientes))
                    {
                        mostrarClientes(listaClientes.Count, listaClientes.Count);
                        mostrarMenu();
                    }else
                    {
                        Console.WriteLine("ERROR: No hay clientes registrados.");
                        mostrarMenu();
                    }
                    break;
                case 3:
                    registrarProducto();
                    mostrarMenu();
                    break;
                case 4:
                    if (!listasVacias(listaProductos))
                    {
                        mostrarProductos(listaProductos.Count, listaProductos.Count);
                        mostrarMenu();
                    }
                    else
                    {
                        Console.WriteLine("ERROR: No hay productos registrados.");
                        mostrarMenu();
                    }
                    break;
                case 5:
                    facturarCompra();
                    mostrarMenu();
                    break;
                case 6:
                    mostrarFacturas(listaFacturas.Count, listaFacturas.Count);
                    break;
                default:
                    break;
            }
        }

        public void registrarCliente()
        {
            Console.Write("Ingrese el nombre del cliente a registrar: ");
            listaClientes.Add(new Cliente(Console.ReadLine()));
        }

        public bool listasVacias<T>(List<T> lista)
        {
            return lista.Count < 1;
        }

        public void mostrarClientes(int decrementador, int total)
        {
            int indice = total - decrementador;
            if (decrementador > 0)
            {
                string clienteActual = listaClientes[indice].Nombre;
                Console.WriteLine($"{indice + 1}.  {clienteActual}");
                Thread.Sleep(300);
                mostrarClientes(decrementador - 1, total);
            }
        }

        public void registrarProducto()
        {
            Console.Write("Ingrese el nombre del producto a registrar: ");
            listaProductos.Add(new Producto(Console.ReadLine()));
        }

        public void mostrarProductos(int decrementador, int total)
        {
            int indice = total - decrementador;
            if (decrementador > 0)
            {
                Console.WriteLine($"{indice + 1}. {listaProductos[indice].Nombre}");
                Thread.Sleep(300);
                mostrarProductos(decrementador - 1, total);
            }
        }

        public void facturarCompra()
        {
            Console.WriteLine("------- FACTURAR UNA COMPRA -------\n" +
                              "\nLista de clientes:\n");
            mostrarClientes(listaClientes.Count,listaClientes.Count);
            Console.WriteLine("\nIngrese el indice del cliente: ");
            int cliente = int.Parse(Console.ReadLine());
            Factura factura = new Factura(listaClientes[cliente-1].Nombre);
            listaFacturas.Add(factura);
            agregarProductosFactura();
            Console.WriteLine("Procesando factura...");
            cargarBarra(100, 100);
            Console.WriteLine($"------- FACTURA #{listaFacturas.Count} -------\n" +
                              $"\nCliente: {listaFacturas[listaFacturas.Count - 1].Cliente}\n");
            int indiceFactura = listaFacturas.Count - 1;
            mostrarProductosFactura(listaFacturas[indiceFactura].listaProductosFactura.Count, listaFacturas[indiceFactura].listaProductosFactura.Count, listaFacturas.Count - 1);
        }

        public void mostrarProductosFactura(int decrementador, int total, int indiceFactura)
        {
            int indice = total - decrementador;
            if (decrementador > 0)
            {
                Console.WriteLine($"{indice + 1}. {listaFacturas[indiceFactura].listaProductosFactura[indice].Nombre}");
                Thread.Sleep(300);
                mostrarProductosFactura(decrementador - 1, total, indiceFactura);
            }
        }

        public void cargarBarra(int decremento, int total, string barra = "")
        {
            if (decremento > 0)
            {
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write((barra += "█") + $" {total - decremento}%");
                Thread.Sleep(50);
                cargarBarra(decremento - 1, total, barra);
            }
        }

        public void agregarProductosFactura()
        {
            mostrarProductos(listaProductos.Count,listaProductos.Count);
            Console.WriteLine("\nIngrese el indice del producto (0 para facturar): ");
            int producto = int.Parse(Console.ReadLine());
            if (producto != 0)
            {
               listaFacturas[listaFacturas.Count-1].listaProductosFactura.Add(listaProductos[producto - 1]);
                agregarProductosFactura();
            }
        }

        public void mostrarFacturas(int decremetador, int total)
        {
            int indice = total - decremetador;
            if (decremetador > 0)
            {
                Console.WriteLine($"--------- FACTURA #{indice + 1} ---------\n" +
                                   $"\nCliente: {listaFacturas[indice].Cliente}");
                int logitudLista = listaFacturas[indice].listaProductosFactura.Count;
                mostrarProductosFactura(logitudLista, logitudLista, indice);
                mostrarFacturas(decremetador - 1, total);
            }
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.mostrarMenu();
        }
    }
}
