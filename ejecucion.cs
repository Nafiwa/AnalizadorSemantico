
class ejecucion{

    
    static Stack<string> pilaEjecuion = new Stack<string>();
    static string[] vci;
    public Simbolo[] simbolos; 

    static void Execute(){
    //LeerVci();
        for(int i = 0; i < vci.Length; i++){

            

        }



    }







    void LeerArchivos(){
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

    public static int MatchString(string input)
    {
        // Check if the input contains only letters
        if (Regex.IsMatch(input, "^[a-zA-Z]+$"))
        {
            return 1;
        }

        // Check if the input matches the word "true"
        if (Regex.IsMatch(input, "^true$"))
        {
            return 2;
        }

        // Return 0 if no pattern matches
        return 0;
    }
}