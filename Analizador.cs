using System.Text;

public class Analizador {
    Token[] tokens;
    public Simbolo[] simbolos; 
    //Vci [] vciList;


    public Analizador() {
        // Leer tabla de tokens separados por '|'
        //string[] lineas = File.ReadAllLines("./txts/nuevatabla.txt");
        //string[] lineas = File.ReadAllLines("./txts/tablaTokensViernes.txt");
        string[] lineas = File.ReadAllLines("./txts/tokens_noerrors.txt");
        //string[] lineas = File.ReadAllLines("./txts/tokens.txt");
        tokens = new Token[lineas.Length];
        for (int i = 0; i < lineas.Length; i++) {
            string[] linea = lineas[i].Split('|');
            // Lexema | Token | Tabla | Linea
            tokens[i] = new Token();
            tokens[i].setLexema(linea[0]);
            tokens[i].setToken(Convert.ToInt32(linea[1]));
            tokens[i].setTabla(Convert.ToInt32(linea[2]));
            tokens[i].setLinea(Convert.ToInt32(linea[3]));
        }
    }

    public Token[] getIdentificadores() {
        // Buscar identificadores, ignorando los que estan despues de la palabra reservada "inicio"
        bool buscar = false;

        List<Token> identificadores = new List<Token>();

        for (int i = 0; i < tokens.Length; i++) {
            if (tokens[i].getToken() == -15) { // Palabra reservada "var"
                buscar = true;
            }
            else if (tokens[i].getToken() == -2) { // Palabra reservada "inicio". Dejar de buscar identificadores
                buscar = false;
            }
            if (buscar == true) {
                if (tokens[i].getTabla() == -2) { // Identificador (si tiene posicion en la tabla de simbolos de -2)
                    identificadores.Add(tokens[i]); // Agregar a la lista de identificadores
                }
            }
        }

        // Checar si hay repetidos. Por cada identificador, buscar si hay otro con el mismo nombre dentro de la misma lista
        for (int i = 0; i < identificadores.Count; i++) {
            for (int j = 0; j < identificadores.Count; j++) {
                // Hay repetidos si el nombre es igual y no esta en el mismo indice
                if (identificadores[i].getNombre() == identificadores[j].getNombre() && i != j) {
                    Console.WriteLine("Error!! Hay repetidos: '" + identificadores[i].getNombre() + "'" );
                    Environment.Exit(1);
                }
            }
        }

        return identificadores.ToArray();
    }

    public void setTablaDeSimbolos(Token[] identificadores) {
        // Crear tabla de simbolos del tamaño de la cantidad de identificadores
        simbolos = new Simbolo[identificadores.Length];
        
        for (int i = 0; i < identificadores.Length; i++) {
            simbolos[i] = new Simbolo();

            simbolos[i].setId(identificadores[i].getNombre()); // El nombre del identificador es el id del simbolo
            simbolos[i].setToken(identificadores[i].getToken()); // El token del identificador es el token del simbolo

            // Asignar valor por defecto
            if (identificadores[i].getToken() == -51) { // Identificador entero
                simbolos[i].setValor("0");
            }
            else if (identificadores[i].getToken() == -52) { // Identificador real
                simbolos[i].setValor("0.0");
            }
            else if (identificadores[i].getToken() == -53) { // Identificador string
                simbolos[i].setValor("null");
            }
            else if (identificadores[i].getToken() == -54) { // Identificador logico
                simbolos[i].setValor("false");
            }
            else if (identificadores[i].getToken() == -55) { // Identificador general
                simbolos[i].setValor("0");
            }
            else {
                Console.WriteLine("Error!! No se pudo asignar valor por defecto. Token invalido: " + identificadores[i].getNombre());
                Environment.Exit(1);
            }

            // Actualizar posicion en la tabla de simbolos donde el nombre del identificador es igual al nombre del token
            for (var j = 0; j < tokens.Length; j++) {
                if (tokens[j].getNombre() == identificadores[i].getNombre()) {
                    tokens[j].setTabla(i);
                }
            }            
        }
    }

    public void validarCuerpo() {
        // Buscar que los identificadores esten declarados y que sean del tipo correcto en el cuerpo del programa
        bool buscar = false;

        for (int i = 0; i < tokens.Length; i++) {
            if (tokens[i].getToken() == -2) { // Palabra reservada "inicio"
                buscar = true;
                continue;
            }

            if (buscar == true) { // Nos encontramos en el cuerpo del programa
            
                // Buscar que un token identificador (getToken() < -51 y getToken() > -54) este en la tabla de simbolos
                int token = tokens[i].getToken();
                if (token == -51 || token == -52 || token == -53 || token == -54 || token == -55) { // Verificar que sea identificador
                    bool encontrado = false;
                    // Buscarlo en la tabla de simbolos
                    for (int j = 0; j < simbolos!.Length; j++) {
                        if (tokens[i].getNombre() == simbolos[j].getId()) {
                            encontrado = true;
                            break;
                        }
                    }

                    // Checar si el identificador esta declarado
                    if (encontrado == false) {
                        Console.WriteLine("Error!! Identificador no declarado: '" + tokens[i].getNombre() + "'");
                        Environment.Exit(1);
                    }

                    // Checar si el identificador es de tipo correcto
                    Simbolo simbolo = simbolos![0]; // Inicializar para evitar error de compilacion
                    for (int j = 0; j < simbolos!.Length; j++) {
                        if (tokens[i].getNombre() == simbolos[j].getId()) {
                            simbolo = simbolos[j];
                            break;
                        }
                    }
                    if (simbolo.getToken() != tokens[i].getToken()) {
                        Console.WriteLine("Error!! Identificador de tipo incorrecto: '" + tokens[i].getNombre() + "'");
                        Environment.Exit(1);
                    }
                }
            }
        }
    }

    public void crearArchivos() {
        // Este metodo crea los archivos de salida con los datos de las tablas de tokens y simbolos
        File.WriteAllText("./txts/tabla_tokens.txt", tokensFormato());
        File.WriteAllText("./txts/tabla_simbolos.txt", simbolosFormato());
        //File.WriteAllText("./txts/Vci.txt", vciFormato());
    }

    string tokensFormato() {
        var sb = new StringBuilder();
        foreach (var token in tokens)
            sb.AppendLine(token.ToString());
        return sb.ToString();
    }

    string simbolosFormato() {
        var sb = new StringBuilder();
        foreach (var simbolo in simbolos!)
            sb.AppendLine(simbolo.ToString());
        return sb.ToString();
    }

    /*string vciFormato(){
        var sb = new StringBuilder();
        foreach (var vci in vciList!)
            sb.AppendLine(vci.ToString());
        return sb.ToString();
    } */

}
