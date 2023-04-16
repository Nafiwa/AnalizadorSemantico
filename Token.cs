public class Token {
        string nombre;
        int token;
        int tabla;
        int linea;

        public void setLexema(string nombre) {
            this.nombre = nombre;
        }

        public void setToken(int token) {
            this.token = token;
        }

        public void setTabla(int tabla) {
            this.tabla = tabla;
        }

        public void setLinea(int linea) {
            this.linea = linea;
        }

        public string getNombre() {
            return nombre!;
        }

        public int getToken() {
            return token;
        }

        public int getTabla() {
            return tabla;
        }

        public int getLinea() {
            return linea;
        }

        public override string ToString() {
            return nombre + "       |" + token + "      |" + tabla + "      |" + linea;
        }
    }