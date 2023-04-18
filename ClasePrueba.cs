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