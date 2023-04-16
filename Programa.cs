public class Programa{
    public static void Main(String[] args) {
        VCI();
    }

    public static void VCI() {
        Vci.VciList();
        Vci.ImprimirVCI();
    }

    public static void AnalisisSemantico() {
        Analizador p = new Analizador();

        Token[] identificadores = p.getIdentificadores(); // Obtener identificadores
        p.setTablaDeSimbolos(identificadores); // Crear tabla de simbolos basada en los identificadores
        p.validarCuerpo(); // Validar que los identificadores esten declarados y que sean del tipo correcto, si no, terminar el programa

        Console.WriteLine("\nIdentificadores:" );
        Console.WriteLine("Nombre: " + "|#token:" + "  |°tabla " + "|linea:");
        Mostrar(identificadores);

        Console.WriteLine("\nSimbolos:");
        Mostrar(p.simbolos!);

        p.crearArchivos(); // Crear archivos de salida

        static void Mostrar<T>(IEnumerable<T> arreglo) {
            for (int i = 0; i < arreglo.Count(); i++) {
                Console.WriteLine(arreglo.ElementAt(i));
            }
        }
    }
}