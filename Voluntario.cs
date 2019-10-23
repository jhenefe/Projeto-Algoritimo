class Voluntario{

  //Atributos
  private string nome;
  private int idade;
  private int cpf;
  private int telefone;
  //private string bairro;
  private string disponibilidadediahora;
  private string perfil;
  
  private int horadispo;
 //metodos
 public Voluntario(string cadastro){
    // Console.WriteLine(cadastro);
   //Usar split
    string[] linhainformaçoes = cadastro.Split('/');
    nome = linhainformaçoes[0];
    idade = int.Parse(linhainformaçoes[1]);
    cpf= int.Parse(linhainformaçoes[2]);
    telefone = int.Parse(linhainformaçoes[3]);
    disponibilidadediahora =linhainformaçoes[4];
    perfil = linhainformaçoes[5];
  
  }
  
 //metodos de acesso
 public string getNome(){
   return nome;
 }
 public void setNome(string jhenefer){
   nome=jhenefer ;
 }

 /*public string getbairro(){
   return bairro;
 }*/

 public string getPerfil(){
   return perfil;
 }

 public int getIdade(){
   return idade;
 }
 
 public int getTelefone(){
   return telefone;
 }

 public string getDisponibilidadediahora(){
   return  disponibilidadediahora;
 }

 

 public void setDisponibilidadediahora(string dh){
  disponibilidadediahora= dh;
 }




}
