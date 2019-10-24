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
 
  public Cachorro(string cadastroCachorro){
    string[] linhas = cadastroCachorro.Split('/');
    nome = linhas[0];
    raça = linhas[1];
    sexo = linhas[2];
    cor = linhas[3];
    porte = linhas[4];
    diaturno =linhas[5];
    bairroCachorro=linhas[6];
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
   
   
  public static void cadastrarCachorro( string dadosCachorro){
  
    FileStream arqCachorro= new FileStream("Cachorro.text",FileMode.Append,FileAccess.Write);
    StreamWriter informaçoesCachorro= new StreamWriter(arqCachorro, Encoding.UTF7);    
    string infobasicas = dadosCachorro;
    informaçoesCachorro.WriteLine(infobasicas);
    informaçoesCachorro.Close();
    arqCachorro.Close();      
  }

  /*public static void cadastrarCachorro( string dadosCachorro){
  
    FileStream arqCachorro= new FileStream("Cachorro.text",FileMode.Append,FileAccess.Write);
    StreamWriter informaçoesCachorro= new StreamWriter(arqCachorro, Encoding.UTF7);    
    string infobasicas = dadosCachorro;
    informaçoesCachorro.WriteLine(infobasicas);
    informaçoesCachorro.Close();
    arqCachorro.Close();      
  }*/

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
}  
