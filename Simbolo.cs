 public class Simbolo {
        string id;
        int token;
        string valor;

        public void setId(string id) {
            this.id = id;
        }

        public void setToken(int token) {
            this.token = token;
        }

        public void setValor(string valor) {
            this.valor = valor;
        }

        public string getId() {
            return id!;
        }

        public int getToken() {
            return token;
        }

        public string getValor() {
            return valor!;
        }

        public override string ToString() {
            return id + "   |" + token + "  |" + valor;
        }
    }