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
    static void main(){
        Stack<string> operadores = new Stack<string>();
        Stack<string> estatutos = new Stack<string>();
        Stack<string> direcciones = new Stack<string>();

        int apuntador = 0;

        List<string> vci = new List<string>();
        List<string> lexemas = new List<string>();
        List<string> tokens = new List<string>();
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

        for(int i = 0; i < tokens.Count; i++){
            string token = tokens[i];
            string lexema = lexemas[i];//?

            if(token == "-9"){
                estatutos.Push(lexema);
                direcciones.Push(apuntador.ToString());
            }else if(token == "-2"){
                //ignorarlo
            }else if(token == "-4" || token == "-5"){
                vci.Add(lexema);
            }else if(token == "-73"){
                operadores.Push(lexema);
            }else if(token == "-74"){
                while(operadores.Peek() != "-73"){
                    operadores.Pop();
                    vci.Add(lexema);
                }
                operadores.Pop();
                vci.Add(lexema);
            }else if(token == "-75"){
                operadores.Pop();
                vci.Add(lexema);
            } else if (lexema == "-3") {
                /* string condicion = "";
                string token_siguiente = lexemas[i + 1];

                if (token_siguiente == "-10") {
                    // Guardar token siguiente momentaneamente
                    i++;
                    token_siguiente = lexemas[i + 1];
                }

                for (int j = i + 1; j < lexemas.Count; j++) {
                    string lexema_actual = lexemas[j];
                    condicion += lexema_actual;

                    if (lexema_actual == ";") {
                        vci.Add(condicion);
                        vci.Add(direcciones.ToString());
                        vci.Add("KwHasta");
                        i = j;
                        break;
                    }
                }*/
            } else {
                vci.Add(lexema);
            }
        }
    }
}