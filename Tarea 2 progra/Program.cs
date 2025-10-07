using System;

// Constantes de porcentajes y tipos de empleado (nombres abreviados)
const double DeduCCSS = 0.0917;   // Deducción de la CCSS
const double AumO = 0.15;         // Aumento del 15% a empleados operarios
const double AumT = 0.10;         // Aumento del 10% a empleados técnicos
const double AumP = 0.05;         // Aumento del 5% a empleados profesionales

const int TipoO = 1;              // Tipo operario
const int TipoT = 2;              // Tipo técnico
const int TipoP = 3;              // Tipo profesional

//Cantidad máxima de empleados
int TAM = 6; 

// Arreglos para almacenar los datos de los empleados
string[] cedulas = new string[TAM];         // Cédulas
string[] nombres = new string[TAM];         // Nombres
int[] tipos = new int[TAM];                 // Tipo de empleado
double[] horas = new double[TAM];           // Horas trabajadas
double[] precioHora = new double[TAM];      // Salario por hora
double[] salarioNeto = new double[TAM];     // Salario neto calculado

// Variables para las estadísticas
int cantO = 0; // Cantidad por tipo
int cantT = 0;
int cantP = 0;

double acumO = 0; // Acumulado de salarios netos por tipo
double acumT = 0;
double acumP = 0;     

int indice = 0; // Indica cuántos empleados se han ingresado

void ingresarEmpleado()
{
    if (indice >= TAM)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("No se pueden ingresar más empleados.");
        Console.ForegroundColor = ConsoleColor.White;
        return;
    }

    // Se ingresan los datos del empleado
    Console.Write("Ingrese número de cédula: ");
    cedulas[indice] = Console.ReadLine();

    Console.Write("Ingrese nombre del empleado: ");
    nombres[indice] = Console.ReadLine();

    Console.Write("Ingrese tipo de empleado (1-Operario, 2-Técnico, 3-Profesional): ");
    tipos[indice] = int.Parse(Console.ReadLine());

    Console.Write("Ingrese cantidad de horas laboradas: ");
    horas[indice] = double.Parse(Console.ReadLine());

    Console.Write("Ingrese salario por hora: ");
    precioHora[indice] = double.Parse(Console.ReadLine());

    // Calcula salario ordinario
    double salarioOrdinario = horas[indice] * precioHora[indice];

    // Calcula aumento según tipo
    double aumento = 0;
    if (tipos[indice] == TipoO)
        aumento = salarioOrdinario * AumO;
    else if (tipos[indice] == TipoT)
        aumento = salarioOrdinario * AumT;
    else if (tipos[indice] == TipoP)
        aumento = salarioOrdinario * AumP;

    // Calcula salario bruto
    double salarioBruto = salarioOrdinario + aumento;

    // Calcula deducción CCSS
    double deduccion = salarioBruto * DeduCCSS;

    // Calcula salario neto
    salarioNeto[indice] = salarioBruto - deduccion;

    // Muestra los resultados del empleado
    Console.WriteLine("\nDatos del Empleado");
    Console.WriteLine($"Cédula: {cedulas[indice]}");
    Console.WriteLine($"Nombre: {nombres[indice]}");
    Console.WriteLine($"Tipo Empleado: {tipos[indice]}");
    Console.WriteLine($"Salario por Hora: {precioHora[indice]}");
    Console.WriteLine($"Cantidad de Horas: {horas[indice]}");
    Console.WriteLine($"Salario Ordinario: {salarioOrdinario}");
    Console.WriteLine($"Aumento: {aumento}");
    Console.WriteLine($"Salario Bruto: {salarioBruto}");
    Console.WriteLine($"Deducción CCSS: {deduccion}");
    Console.WriteLine($"Salario Neto: {salarioNeto[indice]}");

    // Actualiza estadísticas
    if (tipos[indice] == TipoO) //Si el empleado es operario, se suma 1 a la cantidad de operarios y se acumula su salario, para luego calcular el promedio
    {
        cantO++;
        acumO += salarioNeto[indice];
    }
    else if (tipos[indice] == TipoT)
    {
        cantT++;
        acumT += salarioNeto[indice];
    }
    else if (tipos[indice] == TipoP)
    {
        cantP++;
        acumP += salarioNeto[indice];
    }

    // Avanza al siguiente índice
    indice++;
}

void mostrarEstadisticas()
{
    Console.WriteLine("\nEstadísticas Finales");

    // Calcula promedios 
    double promO = 0;
    if (cantO > 0)
    {
        promO = acumO / cantO;
    }

    double promT = 0;
    if (cantT > 0)
    {
        promT = acumT / cantT;
    }

    double promP = 0;
    if (cantP > 0)
    {
        promP = acumP / cantP;
    }

    // Muestra resultados
    Console.WriteLine($"Cantidad de empleados operarios: {cantO}");
    Console.WriteLine($"Acumulado de salarios netos operarios: {acumO}");
    Console.WriteLine($"Promedio de salarios netos operarios: {promO}");

    Console.WriteLine($"Cantidad de empleados técnicos: {cantT}");
    Console.WriteLine($"Acumulado de salarios netos técnicos: {acumT}");
    Console.WriteLine($"Promedio de salarios netos técnicos: {promT}");

    Console.WriteLine($"Cantidad de empleados profesionales: {cantP}");
    Console.WriteLine($"Acumulado de salarios netos profesionales: {acumP}");
    Console.WriteLine($"Promedio de salarios netos profesionales: {promP}");
}

void menu()
{
    int opcion;

    do
    {
        // Muestra el menú
        Console.WriteLine("\nMenú Principal");
        Console.WriteLine("1. Ingresar empleado");
        Console.WriteLine("2. Ver estadísticas finales");
        Console.WriteLine("3. Salir");
        Console.Write("Seleccione una opción: ");
        opcion = int.Parse(Console.ReadLine());

        // Ejecuta la opción seleccionada
        switch (opcion)
        {
            case 1:
                ingresarEmpleado();
                break;
            case 2:
                mostrarEstadisticas();
                break;
            case 3:
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Gracias por usar el sistema.");
                break;
            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Opción inválida.");
                Console.ForegroundColor = ConsoleColor.White;
                break;
        }

    } while (opcion != 3); // Repite hasta que el usuario decida salir
}

// Inicia el programa
menu();
