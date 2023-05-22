using System.Text.RegularExpressions;
using System.Data;

class ejecucion{

    
    static Stack<string> pilaEjecucion = new Stack<string>();
    static string[] vci;
    static Simbolo[] simbolos; 

    static void Execute(){
        LeerArchivos();

        for(int i = 0; i < vci.Length; i++){
            string nombreToken = vci[i];            
            int token = TokenDe(nombreToken);

            if(token is -51 or -52 or -53 or -54) { // Es identificador
                pilaEjecucion.Push(vci[i]);
            }
            else if (token is -61 or -62 or -63 or -64 or -65) { //Es una constante
                pilaEjecucion.Push(vci[i]);
            }
            else if (token is -21 or -22 or -23 or -24 or -25 or -26) { // Es un operador
                string operador = nombreToken;
                string dos = pilaEjecucion.Pop();
                string uno = pilaEjecucion.Pop();

                var resultado = Calcular(uno + operador + dos);

            }
            else if (token is -4) { // Es funcion leer
                // Si el token es "leer", se lee desde la consola y se guarda en la tabla de símbolos
                string input = Console.ReadLine();
                
            }
            else if (token is ) { // Es funcion escribir

            }
            else if (token is ) { // Es palabra reservada hasta

            }
            else if (token is ) { // 

            }
        }




    }



    static object Calcular(string operacion)
    {
        // Evaluar operacion
        DataTable dt = new DataTable();
        var v = dt.Compute(operacion, null);
        return v;
    }



    static void LeerArchivos(){
        vci = File.ReadAllLines("./txts/Vci.txt");

        string[] lineas = File.ReadAllLines("./txts/tabla_simbolos.txt");
        simbolos = new Simbolo[lineas.Length];
        for (int i = 0; i < lineas.Length; i++) {
            string[] linea = lineas[i].Split('|');
            // Simbolo | Token | Valor 
            simbolos[i] = new Simbolo();
            simbolos[i].setId(linea[0]);
            simbolos[i].setToken(Convert.ToInt32(linea[1]));
            simbolos[i].setValor(linea[2]);
        }
    }

    public static int TokenDe(string token) {
        // Si el input es un identificador
        if (Regex.IsMatch(token, "^[a-zA-Z]+$"))
        {
            // Busca su token en la tabla de simbolos
            return simbolos.Where(s => s.getId() == token).Select(s => s.getToken()).FirstOrDefault();
        }
        // Si el input es la funcion escribir
        else if (Regex.IsMatch(token, "escribir"))
        {
            return -5;
        }
        // Si es la funcion leer
        else if (Regex.IsMatch(token, "leer"))
        {
            return -4;
        }
        // Si es constante verdadero
        else if (Regex.IsMatch(token, "verdadero"))
        {
            return -64;
        }
        // Si es constante falso
        else if (Regex.IsMatch(token, "falso"))
        {
            return -65;
        }
        // Si es constante entera
        else if (Regex.IsMatch(token, "^[0-9]+$"))
        {
            return -61;
        }
        // Si es constante real
        else if (Regex.IsMatch(token, "^[0-9]+[.][0-9]+$"))
        {
            return -62;
        }
        // Si es constante cadena
        else if (Regex.IsMatch(token, "^\"[a-zA-Z0-9 ]+\"$"))
        {
            return -63;
        }
        // Si es un operador suma
        else if (Regex.IsMatch(token, "^\\+$"))
        {
            return -24;
        }
        // Si es un operador resta
        else if (Regex.IsMatch(token, "^-$"))
        {
            return -25;
        }
        // Si es un operador multiplicacion
        else if (Regex.IsMatch(token, "^\\*$"))
        {
            return -21;
        }
        // Si es un operador division
        else if (Regex.IsMatch(token, "^/$"))
        {
            return -22;
        }
        // Si es un operador residuo
        else if (Regex.IsMatch(token, "^%$"))
        {
            return -23;
        }
        // Si es un operador asignacion
        else if (Regex.IsMatch(token, "^=$"))
        {
            return -26;
        }
        // Si es un operador menor que
        else if (Regex.IsMatch(token, "^<$"))
        {
            return -31;
        }
        // Si es un operador menor igual que
        else if (Regex.IsMatch(token, "^<=$"))
        {
            return -32;
        }
        // Si es un operador mayor que
        else if (Regex.IsMatch(token, "^>$"))
        {
            return -33;
        }
        // Si es un operador mayor igual que
        else if (Regex.IsMatch(token, "^>=$"))
        {
            return -34;
        }
        // Si es un operador igual que
        else if (Regex.IsMatch(token, "^==$"))
        {
            return -35;
        }
        // Si es un operador diferente que
        else if (Regex.IsMatch(token, "^!=$"))
        {
            return -36;
        }
        // Si es un operador y
        else if (Regex.IsMatch(token, "and"))
        {
            return -41;
        }
        // Si es un operador o
        else if (Regex.IsMatch(token, "or"))
        {
            return -42;
        }
        // Si es un operador no
        else if (Regex.IsMatch(token, "not"))
        {
            return -43;
        }
        // Si es palabra reservada hasta
        else if (Regex.IsMatch(token, "hasta"))
        {
            return -10;
        }

        // Return 0 if no pattern matches
        return 0;
    }
}