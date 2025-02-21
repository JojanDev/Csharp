namespace HospitalPacientes
{
    class Medico
    {
        public string Nombre;
        public List<Residente> residentes;
        public Medico(string nombre)
        {
            Nombre = nombre;
            residentes = new List<Residente>();
        }
    }

    class Residente
    {
        public string Nombre;
        public List<Paciente> pacientes;
        public Residente(string nombre)
        {
            Nombre = nombre;
            pacientes = new List<Paciente>();
        }
    }

    class Paciente
    {
        public string Nombre;
        public Paciente(string nombre)
        {
            Nombre = nombre;
        }
    }
    internal class Program
    {
        public List<Medico> medicos;

        public Program()
        {
            medicos = new List<Medico>();
        }
        public void ingresarMedico()
        {
            Console.Write("\n¿Cuantos medicos hay?: ");
            int cantidad = int.Parse(Console.ReadLine());

            if (cantidad > 0)
            {
                for (int i = 0; i < cantidad; i++)
                {
                    Console.WriteLine("\n---- REGISTRO DE MEDICOS ----");
                    Console.Write($"\nIngrese el nombre del medico #{i + 1}: ");
                    string nombre = Console.ReadLine();

                    Medico medico = new Medico(nombre);
                    medicos.Add(medico);

                    ingresarResidentes(nombre, i);
                }
            }
        }

        public void ingresarResidentes(string medicoNombre, int posicionMedico)
        {

            Console.Write($"\n¿Cuantos residentes tiene el medico {medicoNombre}: ");
            int cantidad = int.Parse(Console.ReadLine());

            if (cantidad > 0)
            {
                for (int i = 0; i < cantidad; i++)
                {
                    Console.WriteLine("\n---- REGISTRO DE RESIDENTES ----"); 
                    Console.Write($"\nIngrese el nombre del residente #{i + 1} del Dr. {medicoNombre}: ");
                    string nombre = Console.ReadLine();

                    Residente residente = new Residente(nombre);

                    medicos[posicionMedico].residentes.Add(residente);
                    ingresarPacientes(nombre, i, posicionMedico);
                }
            }
        }

        public void ingresarPacientes(string residente, int posicionResidente, int posicionMedico)
        {

            Console.Write($"\n¿Cuantos pacientes tiene el residente {residente}: ");
            int cantidad = int.Parse(Console.ReadLine());


            if (cantidad > 0)
            {
                for (int i = 1; i <= cantidad; i++)
                {
                    Console.WriteLine("\n---- REGISTRO DE PACIENTES ----");
                    Console.Write($"\nIngrese el nombre del paciente #{i} del residente {residente}: ");
                    string nombre = Console.ReadLine();

                    Paciente paciente = new Paciente(nombre);
                    medicos[posicionMedico].residentes[posicionResidente].pacientes.Add(paciente);
                }
            }
        }
        
        public void imprimirInformacion()
        {
            Console.WriteLine("\n" +
                "-------------------------------------------------------------\n" +
                "Informacion de los medicos, residentes y pacientes asignados\n");

            for (int i = 0; i < medicos.Count; i++)
            {
                Console.WriteLine($"Medico {i + 1}: {medicos[i].Nombre}");
                var residentes = medicos[i].residentes;
                for (int j = 0; j < residentes.Count; j++)
                {
                    Console.WriteLine($"    Residente {j + 1}: {residentes[j].Nombre}");

                    var pacientes = residentes[j].pacientes;
                    for (int k = 0; k < pacientes.Count; k++)
                    {
                        Console.WriteLine($"        Paciente {k + 1}: {pacientes[k].Nombre}");
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            Program program = new Program();


            program.ingresarMedico();
            program.imprimirInformacion();
        }
    }
}
