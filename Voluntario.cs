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
    string[] vetordiaturno= disponibilidadediaturno.Split('-');
    dia=vetordiaturno[0];
    turno =vetordiaturno[1];
    
  }
  public Voluntario(){
   
    
    nome = "Jane Done";
    idade = "indefinido";
    cpf= "Sem numero";
    telefone = "Sem numero";
    disponibilidadediaturno ="Sem disponibilidade";
    bairro= "Sem bairro";
    dia="nenhum";
    turno ="nenhum";
    
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
 public string getDia(){
   return  dia;
 }
  public string getTurno(){
   return  turno;
 }
 public void setDia(string dh){
  dia= dh;
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
  public static int  verificaVoluntarioCadastrado(int numeroCadastroVoluntario,Voluntario[] vetorVoluntario){
    int confirmaçãoVoluntario;
    if(vetorVoluntario[numeroCadastroVoluntario-1] != null){
      confirmaçãoVoluntario = 1;

    }else{
      confirmaçãoVoluntario = 0;
    }
     
    return confirmaçãoVoluntario;
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
  public static Voluntario retornaVoluntario(int numeroVoluntario,Voluntario[] retorna){
    int numerousuario=numeroVoluntario;
    Voluntario [] posiçao = retorna;
    Voluntario voluntarioObjeto= posiçao[numerousuario-1];
    return voluntarioObjeto;
  }
 

}

