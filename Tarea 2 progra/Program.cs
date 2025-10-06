using System;

class Program
{
    // Constantes de porcentajes y tipos de empleado
    const double DEDUCCIONES_CCSS = 0.0917; // Deducción de la CCSS
    const double AUMENTO_OPERARIO = 0.15; // Aumento del 15% a empleados operarios
    const double AUMENTO_TECNICO = 0.10; // Aumento del 10% a empleados técnicos
    const double AUMENTO_PROFESIONAL = 0.05; // Aumento del 5% a empleados profesionales
    const int TIPO_OPERARIO = 1;
    const int TIPO_TECNICO = 2;
    const int TIPO_PROFESIONAL = 3;

    // Variables para estadísticas 
    static int cantOperarios = 0, cantTecnicos = 0, cantProfesionales = 0; // la cantidad total de cada tipo de empleado
    static double acumNetoOperarios = 0, acumNetoTecnicos = 0, acumNetoProfesionales = 0; // la suma total de todos los salarios netos 

    static void Main()
    {
        int opcion = 0; // Variable para controlar el menú

        // Bucle principal del menú
        do
        {
            Console.WriteLine("\nMenú Principal");
            Console.WriteLine("1. Ingresar empleado");
            Console.WriteLine("2. Ver estadísticas finales");
            Console.WriteLine("3. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = int.Parse(Console.ReadLine());

            if (opcion == 1)
            {
                IngresarEmpleado(); // Llama al proceso de ingreso de empleado
            }
            else if (opcion == 2)
            {
                MostrarEstadisticas(); // Muestra las estadísticas finales
            }
            else if (opcion == 3)
            {
                Console.WriteLine("Gracias por usar el sistema.");
            }
            else
            {
                Console.WriteLine("Opción inválida. Intente de nuevo.");
            }

        } while (opcion != 3); // El menú se repite mientras no se elija salir
    }

    static void IngresarEmpleado()
    {
        // Mensajes de entrada
        string Ma1 = "Ingrese número de cédula: ";
        string Ma2 = "Ingrese nombre del empleado: ";
        string Ma3 = "Ingrese tipo de empleado (1-Operario, 2-Técnico, 3-Profesional): ";
        string Ma4 = "Ingrese cantidad de horas laboradas: ";
        string Ma5 = "Ingrese salario por hora: ";

        // Entrada de datos del empleado
        Console.Write(Ma1); // Lectura de la cédula
        string cedula = Console.ReadLine();

        Console.Write(Ma2); // Lectura del nombre
        string nombre = Console.ReadLine();

        Console.Write(Ma3); // Lectura del tipo de empleado
        int tipoEmpleado = int.Parse(Console.ReadLine());

        Console.Write(Ma4); // Lectura de horas
        double horas = double.Parse(Console.ReadLine());

        Console.Write(Ma5); // Lectura del precio por hora
        double precioHora = double.Parse(Console.ReadLine());

        // Cálculo del salario ordinario
        double salarioOrdinario = horas * precioHora;

        // Cálculo del aumento según tipo
        double aumento = 0;
        if (tipoEmpleado == TIPO_OPERARIO)
            aumento = salarioOrdinario * AUMENTO_OPERARIO;
        else if (tipoEmpleado == TIPO_TECNICO)
            aumento = salarioOrdinario * AUMENTO_TECNICO;
        else if (tipoEmpleado == TIPO_PROFESIONAL)
            aumento = salarioOrdinario * AUMENTO_PROFESIONAL;

        // Cálculo del salario bruto
        double salarioBruto = salarioOrdinario + aumento;

        // Cálculo de deducción CCSS
        double deduccion = salarioBruto * DEDUCCIONES_CCSS;

        // Cálculo del salario neto
        double salarioNeto = salarioBruto - deduccion;

        // Mostrar resultados del empleado
        Console.WriteLine("\nDatos del Empleado ");
        Console.WriteLine($"Cédula: {cedula}");
        Console.WriteLine($"Nombre: {nombre}");
        Console.WriteLine($"Tipo Empleado: {tipoEmpleado}");
        Console.WriteLine($"Salario por Hora: {precioHora}");
        Console.WriteLine($"Cantidad de Horas: {horas}");
        Console.WriteLine($"Salario Ordinario: {salarioOrdinario}");
        Console.WriteLine($"Aumento: {aumento}");
        Console.WriteLine($"Salario Bruto: {salarioBruto}");
        Console.WriteLine($"Deducción CCSS: {deduccion}");
        Console.WriteLine($"Salario Neto: {salarioNeto}");

        // Actualizar estadísticas
        if (tipoEmpleado == TIPO_OPERARIO)
        {
            cantOperarios++;
            acumNetoOperarios += salarioNeto;
        }
        else if (tipoEmpleado == TIPO_TECNICO)
        {
            cantTecnicos++;
            acumNetoTecnicos += salarioNeto;
        }
        else if (tipoEmpleado == TIPO_PROFESIONAL)
        {
            cantProfesionales++;
            acumNetoProfesionales += salarioNeto;
        }
    }

    static void MostrarEstadisticas()
    {
        string Ma7 = "Estadísticas Finales";

        // Promedio de salarios netos
        double promedioOperarios = cantOperarios > 0 ? acumNetoOperarios / cantOperarios : 0;
        double promedioTecnicos = cantTecnicos > 0 ? acumNetoTecnicos / cantTecnicos : 0;
        double promedioProfesionales = cantProfesionales > 0 ? acumNetoProfesionales / cantProfesionales : 0;

        // Mostrar estadísticas finales
        Console.WriteLine($"\n{Ma7}");
        Console.WriteLine($"Cantidad de empleados operarios: {cantOperarios}");
        Console.WriteLine($"Acumulado de salarios netos para los operarios: {acumNetoOperarios}");
        Console.WriteLine($"Promedio de salarios netos para los operarios: {promedioOperarios}");

        Console.WriteLine($"Cantidad de empleados técnicos: {cantTecnicos}");
        Console.WriteLine($"Acumulado de salarios netos para los técnicos: {acumNetoTecnicos}");
        Console.WriteLine($"Promedio de salarios netos para los técnicos: {promedioTecnicos}");

        Console.WriteLine($"Cantidad de empleados profesionales: {cantProfesionales}");
        Console.WriteLine($"Acumulado de salarios netos para los profesionales: {acumNetoProfesionales}");
        Console.WriteLine($"Promedio de salarios netos para los profesionales: {promedioProfesionales}");
    }
}


