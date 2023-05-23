public class Programa{ // Te pedi permiso, hola como estas uwuwuwuwuwuuwuwuwuwuwu
    public static void Main(String[] args) {
        //Console.WriteLine("ETAPA 1: ANALISIS SEMANTICO");
        //AnalisisSemantico();
        //Console.WriteLine("\n");
        //Console.WriteLine("ETAPA 2: VCI");
        //VCI();
        //Console.WriteLine("\n");
        Console.WriteLine("ETAPA 3: EJECUCION");

        EjecutarVCI();
    }

    public static void EjecutarVCI() {
        Ejecucion.Ejecutar();
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