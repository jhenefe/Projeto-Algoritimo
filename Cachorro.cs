using System;
using System.IO;
using System.Text;
class Cachorro{  
  private string nome;
  private string raça;
  private string sexo;
  private string cor;
  private string porte;
  private string diaturno;
  private string diaCachorro;
  private string turnoCachorro;
  private string bairroCachorro;
  private string telefoneDono;
  public Cachorro(string cadastroCachorro){
    string[] linhas = cadastroCachorro.Split('/');
    nome = linhas[0];
    raça = linhas[1];
    sexo = linhas[2];
    cor = linhas[3];
    porte = linhas[4];
    diaturno =linhas[5];
    bairroCachorro=linhas[6];
    telefoneDono=linhas[7];
    string []vetordiaturno= diaturno.Split('-');
    diaCachorro=vetordiaturno[0];
    turnoCachorro=vetordiaturno[1];
  }
   
  public string getNome(){
    return nome;
  }

  public  string getRaça(){
    return raça;
  }

  public  string getSexo(){
    return sexo;
  }
  public  string getCor(){
    return cor;
  }

  public  string getPorte(){
    return porte;
  }
  
  public string getDiaCachorro(){
    return diaCachorro;
  } 

  public string getTurnoCachorro(){
    return turnoCachorro;
  }
  
  public string getBairroCachorro(){
    return bairroCachorro;
  } 
   public string getTelefoneDono(){
    return telefoneDono;
  } 
  public static int qtdLinhasCachorro(){
    FileStream  leituraCachorro= new FileStream("Cachorro.text",FileMode.Open,FileAccess.Read);

    //Lendo informaçoes salvas no arquivo
    StreamReader lerinfobasic =new StreamReader(leituraCachorro,Encoding.UTF8);

    int cont = 0;
    while(!lerinfobasic.EndOfStream){
      lerinfobasic.ReadLine();
      cont++;
    } 

    //Fechando leitura
    lerinfobasic.Close();
    leituraCachorro.Close();

    return cont;
  }
  public static int  verificaCachorroCadastrado(int numeroCadastroCachorrro,Cachorro[] vetorCachorro){
    int confirmaCachorro = 1;
    while(confirmaCachorro != 0){
      if(vetorCachorro[numeroCadastroCachorrro - 1] != null){
        Cachorro cachorro = retornaCachorro(numeroCadastroCachorrro,retornaVetorCachorro());
        Console.WriteLine("Bem vindo dono(a) do(a) pet {0}",cachorro.getNome());
        confirmaCachorro = 0;
      }else{
        Console.WriteLine("Opção inválida.Por favor digite o número de usuário válido para verificação ou 0 para sair:");
        confirmaCachorro = int.Parse( Console.ReadLine());
        
      }
    }
  
    return numeroCadastroCachorrro;
  } 
   
  
  public static void cadastrarCachorro( int numeroLinhaArquiCachorro){
    Console.WriteLine("Cachorro número: {0}", (numeroLinhaArquiCachorro+1));
    Console.WriteLine("Por favor preencha as informações a seguir conforme solicitado: Nome / Raça / Sexo / Cor / Porte /Dia-Turno/Telefone do Responsável pelo pet");
    string dadosCachorro = Console.ReadLine();

    FileStream arqCachorro= new FileStream("Cachorro.text",FileMode.Append,FileAccess.Write);
    StreamWriter informaçoesCachorro= new StreamWriter(arqCachorro, Encoding.UTF7);    
    string infobasicas = dadosCachorro;
    informaçoesCachorro.WriteLine(infobasicas);
    informaçoesCachorro.Close();
    arqCachorro.Close();      
  }

  public static Cachorro [] retornaVetorCachorro(){
    FileStream  leituraCachorro= new FileStream("Cachorro.text",FileMode.Open,FileAccess.Read);

    //Lendo informaçoes salvas no arquivo
    StreamReader lerinfobasica =new StreamReader(leituraCachorro,Encoding.UTF8);

    Cachorro [] vetorCa = new Cachorro[1000];
    int cont = 0;
    while(!lerinfobasica.EndOfStream){
      string infoCachorro = lerinfobasica.ReadLine();
      Cachorro cachorroSelecionado = new Cachorro(infoCachorro);
      vetorCa[cont]=cachorroSelecionado;      
      cont++;
      
    }
    //Fechando leitura
    lerinfobasica.Close();
    leituraCachorro.Close();

    return vetorCa; 
  }
  public static Cachorro retornaCachorro(int numeroCachorro,Cachorro[] retorna){
    int cachorroId=numeroCachorro;
    Cachorro [] posiçao = retorna;
    Cachorro cachorro= posiçao[cachorroId-1];
    return cachorro;
  }
  public static void informaçõesMatchCachorro(Cachorro cachorroMatch){
    Console.WriteLine(" Informações Cachorro:");
    Console.WriteLine(" Nome: {0}",cachorroMatch.getNome());
    Console.WriteLine(" Raça: {0}",cachorroMatch.getRaça());
    Console.WriteLine(" Dia: {0}",cachorroMatch.getDiaCachorro());
    Console.WriteLine(" Turno: {0}",cachorroMatch.getTurnoCachorro());
    Console.WriteLine(" Numero de telefone do Dono: {0}",cachorroMatch.getTelefoneDono());
    
  }

}  
