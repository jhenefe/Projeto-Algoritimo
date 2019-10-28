using System;
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
 public string getCpf(){
   return cpf;
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
  public static int  verificaCadastradoVoluntario(int numeroCadastroVoluntario,Voluntario[] vetorVoluntario){
      int confirmaVoluntario = 1;
      while(confirmaVoluntario != 0){
      if(vetorVoluntario[numeroCadastroVoluntario-1] != null){
       Voluntario voluntario =Voluntario.retornaVoluntario(numeroCadastroVoluntario,Voluntario.retornaVetorVoluntario());
        Console.WriteLine("Bem vindo(a) {0} !",voluntario.getNome());
        confirmaVoluntario = 0;
        
      }else{
        Console.WriteLine("Opção inválida.Por favor digite um número de usuário válido para verificação ou 0 para sair:");
        confirmaVoluntario = int.Parse( Console.ReadLine());
        
      }
    }
   
    return numeroCadastroVoluntario;
  } 
  
  public static void cadastrarUsuario( int numeroLinhasArquivoVolunatrio){
    Console.WriteLine("Voluntário número:{0}",( numeroLinhasArquivoVolunatrio+1));
    Console.WriteLine("Por Favor passe as seguintes informações para criar seu cadastro seguindo o modelo: Nome/Idade/CPF/Telefone/disponibilidade dia-turno/bairro");
    string dados = Console.ReadLine();
    
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

