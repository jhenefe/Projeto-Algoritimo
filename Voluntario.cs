using System.IO;
using System.Text;

class Voluntario{

  //Atributos
  private string nome;
  private string idade;
  private string cpf;
  private string telefone;
  private string disponibilidadediaturno;
  private string bairro;
  private string horadispo;
  string dia;
  string turno;
 //construtor
 public Voluntario(string cadastro){
   
    string[] linhainformaçoes = cadastro.Split('/');
    nome = linhainformaçoes[0];
    idade = linhainformaçoes[1];
    cpf= linhainformaçoes[2];
    telefone = linhainformaçoes[3];
    disponibilidadediaturno =linhainformaçoes[4];
    bairro= linhainformaçoes[5];
  }
  
 //metodos de acesso
 public string getNome(){
   return nome;
 }
 public void setNome(string n){
   nome=n ;
 }
  public string getBairro(){
   return bairro;
 }
 public string getIdade(){
   return idade;
 }
 public string getTelefone(){
   return telefone;
 }
 public string getDisponibilidadediaturno(){
   return  disponibilidadediaturno;
 }
 public void setDisponibilidadediaturno(string dh){
  disponibilidadediaturno= dh;
 }
 
  public static int qtdLinhas(){
    FileStream  leiturarqvoluntario= new FileStream("Voluntario.text",FileMode.Open,FileAccess.Read);

    //Lendo informaçoes salvas no arquivo
    StreamReader lerinfobasic =new StreamReader(leiturarqvoluntario,Encoding.UTF8);

    int cont = 0;
    while(!lerinfobasic.EndOfStream){
      lerinfobasic.ReadLine();
      cont++;
    } 

    //Fechando leitura
    lerinfobasic.Close();
    leiturarqvoluntario.Close();

    return cont;
  }
   
  public static void cadastrarUsuario( string dados){
  
    FileStream arqvoluntarios = new FileStream("Voluntario.text",FileMode.Append,FileAccess.Write);
    StreamWriter informaçoesbasicas= new StreamWriter(arqvoluntarios, Encoding.UTF7);    
    string infobasic = dados;
    informaçoesbasicas.WriteLine(infobasic);
    informaçoesbasicas.Close();
    arqvoluntarios.Close();      
  }
  public static Voluntario[] retornaVetorVoluntario(){
    FileStream  leituraVoluntario= new FileStream("Voluntario.text",FileMode.Open,FileAccess.Read);
    StreamReader lerinfovoluntario =new StreamReader(leituraVoluntario,Encoding.UTF8);   
   
    Voluntario [] vetorVo = new Voluntario[1000];
    int contador = 0;
    while(!lerinfovoluntario.EndOfStream){
      string infoVoluntario = lerinfovoluntario.ReadLine();
      Voluntario voluntario = new Voluntario(infoVoluntario);
      vetorVo [contador] = voluntario;     
      contador++;
      
    }
    //Fechando leitura
    lerinfovoluntario.Close();
    leituraVoluntario.Close();

    return vetorVo; 
  }

 

}

