public class Identificadores{
    public int KwPrograma = -1;
    public int KwInicio = -2;
    public int KwFin = -3;
    public int KwLeer = -4;
    public int KwEscribir = -5;
    public int KwSi = -6;
    public int KwSino = -7;
    public int KwMientras = -8;
    public int KwRepetir = -9;
    public int KwHasta = -10;
    public int KwEntero = -11;
    public int KwReal = -12;
    public int KwString = -13;
    public int KwLogico = -14;
    public int KwVar = -15;
    public int KwEntonces = -16;
    public int KwHacer = -17;


    public int OpMult = -21;
    public int OpDiv = -22;
    public int OpRec = -23;
    public int OpSum = -24;
    public int OpRes = -25;
    public int OpAsig = -26;



    public int OpRMen = -31;
    public int OpRMenEq = -32;
    public int OpRMay = -33;
    public int OpRMayEq = -34;
    public int OpREq = -35;
    public int OpRDif = -36;




    public int OpLAnd = -41;
    public int OpLOr = -42;
    public int OpLNot = -43;






    public int IdEntero = -51;
    public int IdReal = -52;
    public int IdString = -53;
    public int IdLogico = -54;
    public int IdGral = -55;




    public int CoEntero = -61;
    public int CoReal = -62;
    public int CoString = -63;
    public int CoLogTrue = -64;
    public int CoLogFalse = -65;







    public int OpParentesis = -73;
    public int ClParentesis = -74;
    public int DotComma = -75;
    public int Comma = -76;
}

public class Prioridades{
    //Prioridades

    public int OpMult = 60;
    public int OpDiv = 60;

    public int OpSum = 50;
    public int OpRes = 50;

    public int OpRMen = 40;
    public int OpRMenEq = 40;
    public int OpRMay = 40;
    public int OpRMayEq = 40;
    public int OpREq = 40;
    public int OpRDif = 40;

    public int OpLNot = 30; 
    public int OpLAnd = 20;
    public int OpLOr = 10;

    public int OpAsig = 0;
}