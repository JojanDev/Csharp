namespace FacturaVeterinariaPipos
{

    class Mascota
    {
        public string Nombre;
        public Mascota(string nombre)
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
        public Factura()
        {

        }
    }
    internal class Program
    {
        List<Mascota> listaMascotas;
        List<Producto> listaProductos;
        List<Factura> facturas;

        public Program()
        {
            listaProductos = new List<Producto>()
            {
                new Producto("Correa"),
                new Producto("Shampoo"),
                new Producto("Cepillo")
            };

            listaMascotas = new List<Mascota>();
            facturas = new List<Factura>();
        }

        public void mostrarMenu()
        {

        }

        public void mostrarProductos(int cantidad)
        {
            int total = listaProductos.Count;
            int posicion = total - cantidad + 1;
            if (cantidad > 0)
            {
                Console.WriteLine($"{posicion}. {listaProductos[posicion - 1].Nombre}");
                Thread.Sleep(300);
                mostrarProductos(cantidad - 1);
            }
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            program.mostrarProductos(program.listaProductos.Count);
        }
    }
}
