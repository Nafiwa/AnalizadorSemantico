class Vci{
    /*Pilas
    /   Se crean las pilas de direcciones, estatutos y operadores, esta ultima se apoya de otra pila llamada prioridades que 
    /   guardara las prioridades de cada operador respectivamente
    */
        static Stack<string> operadores = new Stack<string>();
        static Stack<int> prioridades = new Stack<int>();
        static Stack<string> estatutos = new Stack<string>();
        static Stack<int> direcciones = new Stack<int>();

    /* Listas
    /   Se crean las listas que nos permitiran crear e imprimir el vci
    */
        static List<string> vci = new List<string>();
        static List<string> nombresTk = new List<string>();
        static List<string> tokens = new List<string>();
    
    public static void VciList(){
        ///el apuntador nos va a ayudar a guardar la dirección en pila
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
        
        //empieza a verificar la lectura de los tokens
        for (int i = 0; i < tokens.Count; i++){
            string token = tokens[i];
            string nombreTk = nombresTk[i];//?
            apuntador = vci.Count;

            //si el token es repetir, hace un push en la pila de estatutos y anota su dirección 
            if (token == "-9"){ // repetir
                estatutos.Push(nombreTk);
                direcciones.Push(apuntador);
            }else if (token == "-10"){ // hasta
            //la regla se aplica despues de escribir la condición
            //y se encuentre con el ')' 
            }else if (token == "-2"){ //inicio
                //El token inicio se ignora
            }else if (token == "-4" || token == "-5"){ //leer y escribir, se añaden directamente a vci
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
                    string finpyc = operadores.Pop();
                    prioridades.Pop();
                    vci.Add(finpyc);
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
            sw.WriteLine("VCI: " + vci.Count + "celdas usadas");
            sw.WriteLine(string.Join(" | ", vci)); // Guardamos los elementos separados por '|'
            sw.WriteLine(string.Join(" | ", Enumerable.Range(0, vci.Count))); // Guardamos los índices
        }
        Console.WriteLine("VCI: " + vci.Count + "celdas usadas");
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
            string token = separador[1]; // 🙈❤
            
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