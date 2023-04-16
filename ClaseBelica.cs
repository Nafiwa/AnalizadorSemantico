/*//declaración
//tipoDeDato, variable, asignación(opcional)

int x;
int y = 1;
string?  a;


x = divi(5, 10, 6);
a = Console.ReadLine();
Console.WriteLine($"qionda pa, puro vato belico {x} {x} {y} {x} {y}");
// el $"" se llama String interpolation ou yeah mdfkr

int b = x+y;

Console.WriteLine($"puro corrido tumbado {b} chachay!!!");

//funciones
//tipoDeDato, nombreFunción, (parametros*)      *opcionales

int Suma(int c, int d){
    int e = c + d;
    return e;
}
//tipoDeDato, variable, asignación(opcional)
int z = Suma(5, x);
Console.WriteLine($"Compa que le parece esa morra {z} {a}");



int divi(int u, int o, double h){
    int q = u/o;
    //llamar/usar la varible
    q = q/(int)h;
        //  ^ se llama casting y convierte la variable al tipoDeDato escrito
    return q;
}

int j = divi(500, 10, 2.5);
Console.Beep(j, z*100);

bool Espar(int x){
    int reciduo = x%2;
    if(reciduo == 0){
        return true;
    }else{
        return false;
    }
}

string? f;
Console.WriteLine("Ingresa un fuckin numero: ");
f = Console.ReadLine();
//de string a int
j = Convert.ToInt32(f);
if(Espar(j) == true){
    Console.WriteLine("CTM es par perro.");
}else{
    Console.WriteLine("Deja de estar mamando, no es par");
}
*/


class Vci{
    //pilas
        static Stack<string> operadores = new Stack<string>();
        static Stack<int> prioridades = new Stack<int>();
        static Stack<string> estatutos = new Stack<string>();
        static Stack<int> direcciones = new Stack<int>();
        static List<string> vci = new List<string>();
        static List<string> nombresTk = new List<string>();
        static List<string> tokens = new List<string>();
    public static void VciList(){
        int apuntador = 0;
        bool evaluarHasta = false;
        string repetir;
        /*tokens a usar
        -2 inicio
        -3 fin
        -4 leer
        -5 escribir
        -9 repetir
        -10 hasta
        -51:-70 id, constantes 
        -73 (
        -74 )
        -75 ; */
        
        LeerArchivo();

        for (int i = 0; i < tokens.Count; i++){
            string token = tokens[i];
            string nombreTk = nombresTk[i];//?
            apuntador = vci.Count;

            if (token == "-9"){ // repetir
                estatutos.Push(nombreTk);
                direcciones.Push(apuntador);
            }else if (token == "-10"){ // hasta
                
            }else if (token == "-2"){ //inicio
                //ignorarlo
            }else if (token == "-4" || token == "-5"){ //leer y escribir
                vci.Add(nombreTk);
            }else if (token == "-73"){ // (
                operadores.Push(nombreTk);
                prioridades.Push(PrioridadDe(token));
            }else if (token == "-74"){ // )
                while (operadores.Peek() != "("){ // (
                    vci.Add(operadores.Pop());
                    prioridades.Pop();
                }
                operadores.Pop();
                prioridades.Pop();

                if (evaluarHasta == true){
                    int dir = direcciones.Pop();
                    vci.Add(dir.ToString()); //dir -> dirección guardada
                    vci.Add("hasta");
                    evaluarHasta = false;
                }
            }else if (token == "-75"){ // ;
                while (operadores.Count > 0){
                    string hamburgesa = operadores.Pop();
                    prioridades.Pop();
                    vci.Add(hamburgesa);
                }
            }else if (token == "-3"){ //fin
                //ignorar
                // Checas a quien corresponde. Haces pop a la pila de estatutos
                if(estatutos.Count > 0){
                    repetir = estatutos.Pop();
                    if (repetir == "repetir"){
                        evaluarHasta = true;
                    }
                }
            }else if(EsOperador(token) == true){
                // Si la pila de operadores está vacía, agregas el operador
                if(operadores.Count == 0){
                    operadores.Push(nombreTk);
                    prioridades.Push(PrioridadDe(token)); 
                }else if(prioridades.Peek() < PrioridadDe(token)){
                    // Si la prioridad del tope es MENOR a la del operador acutal, se hace push
                    operadores.Push(nombreTk);
                    prioridades.Push(PrioridadDe(token));
                }else{
                    // Si no, se hace pop hasta que la prioridad del tope sea menor a la del operador actual y luego se hace push
                    while(prioridades.Peek() >= PrioridadDe(token)){
                        vci.Add(operadores.Pop());
                        prioridades.Pop();
                    }
                    operadores.Push(nombreTk);
                    prioridades.Push(PrioridadDe(token));
                }
            }else{
                vci.Add(nombreTk);
            }
        }
    }
    
    public static void ImprimirVCI(){
        using (StreamWriter sw = new StreamWriter("./txts/Vci.txt")){
            sw.WriteLine(string.Join(" | ", vci)); // Guardamos los elementos separados por '|'
            sw.WriteLine(string.Join(" | ", Enumerable.Range(0, vci.Count))); // Guardamos los índices
        }
        Console.WriteLine(string.Join(" | ", vci)); // Imprimimos los elementos separados por '|'
        Console.WriteLine(string.Join(" | ", Enumerable.Range(0, vci.Count))); // Imprimimos los índices
    }
 


    static bool EsOperador(string token){
        switch(token){
            case "-24" or "-25": return true;
            case "-31" or "-32": return true;
            case "-21" or "-22": return true; 
            case "-33" or "-34": return true;
            case "-35" or "-36": return true;
            case "-26": return true;
            case "-43": return true;
            case "-41": return true;
            case "-42": return true;
            default : return false;
        }
    }

    static int PrioridadDe(string operador){
        switch (operador){
            case "-21" or "-22": return 60;
            case "-24" or "-25": return 50;
            case "-31" or "-32": return 40;
            case "-33" or "-34": return 40;
            case "-35" or "-36": return 40;
            case "-43": return 30;
            case "-41": return 20;
            case "-42": return 10;
            case "-26": return 0;
            default : return 0;
            //case "-25": return 50;
        }
    }

    static void LeerArchivo(){
        //string[] lineas = File.ReadAllLines("./txts/nuevatabla.txt");
        //string[] lineas = File.ReadAllLines("./txts/tablaTokensViernes.txt");
        //string[] lineas = File.ReadAllLines("./txts/tokens_noerrors.txt");
        //string[] lineas = File.ReadAllLines("./txts/tokens.txt");
        //string[] lineas = File.ReadAllLines("./txts/Prueba2.txt");
        //string[] lineas = File.ReadAllLines("./txts/Prueba3.txt");
        string[] lineas = File.ReadAllLines("./txts/vciPrueba.txt");

        bool dentroDelCuerpo = false;

        for(int i = 0; i < lineas.Length ; i++){
            // a, -51, -2, 5
            // 0,   1,  2, 3

            // Añadir a las listas de tokens si esta dentro del cuerpo
            string[] separador = lineas[i].Split("|");

            string nombreTk = separador[0];
            string token = separador[1]; // 🙈
            
            if(token == "-2"){
                dentroDelCuerpo = true;
                continue;
            }

            if (dentroDelCuerpo == true) {
                nombresTk.Add(nombreTk);
                tokens.Add(token);
            }
        }
    }
}