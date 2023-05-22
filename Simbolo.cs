 public class Simbolo {
        string simbolo;
        int token;
        string valor;

        public void setId(string id) {
            this.simbolo = id;
        }

        public void setToken(int token) {
            this.token = token;
        }

        public void setValor(string valor) {
            this.valor = valor;
        }

        public string getId() {
            return simbolo!;
        }

        public int getToken() {
            return token;
        }

        public string getValor() {
            return valor!;
        }

        public override string ToString() {
            return simbolo + "   |" + token + "  |" + valor;
        }
    }