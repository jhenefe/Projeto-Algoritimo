using System;
using System.IO;
using System.Text;
class Agenda{
  private Match AgendaVolunatrioCachorro;
 
  
  public Agenda (Match verificaAgenda){
    AgendaVolunatrioCachorro = verificaAgenda ;
    
  }
  public Match getMatchVoluntarioCachorro(){
    return AgendaVolunatrioCachorro;
  }
  
  public static string[] retornaVetorAgenda(){
    FileStream  leituraAgenda= new FileStream("Agenda.text",FileMode.Open,FileAccess.Read);
    StreamReader lerinfoAgenda =new StreamReader(leituraAgenda,Encoding.UTF8);   
   
    string [] vetorAgenda = new string [1000];
    int contador = 0;
    while(!lerinfoAgenda.EndOfStream){
      string agenda= lerinfoAgenda.ReadLine();
      vetorAgenda [contador] = agenda;     
      contador++;
      
    }
    lerinfoAgenda.Close();
    leituraAgenda.Close();
    return vetorAgenda; 
  }
  public static int verificaAgendaCachorro(string[] arquivoAgenda,Cachorro cachorroVerificar){
    
    string nomeCachorroVerificar=cachorroVerificar.getNome();
    
    int retornaDisponibilidadeCachorro = 1;
    int cont = 0;
    while(arquivoAgenda[cont] != null){

      string posiçao  =  arquivoAgenda[cont];
      string[]  vetorAgenda = posiçao.Split(',');
      string cachorroAgendado = vetorAgenda[1];
      Console.WriteLine(cachorroAgendado);
      if(nomeCachorroVerificar == cachorroAgendado){
       
        retornaDisponibilidadeCachorro = 0;
      }
     cont++;
    }
   
    return retornaDisponibilidadeCachorro;
  }

  public static void  agendamento(Voluntario voluntarioAgenda,Cachorro cachorroAgenda ){
    FileStream arqAgenda= new FileStream("Agenda.text",FileMode.Append,FileAccess.Write);
    StreamWriter informaçoesbasicasAgenda= new StreamWriter(arqAgenda, Encoding.UTF7);    
    
    string voluntarioAgendar = voluntarioAgenda.getNome();
    string cachorroAgendar =  cachorroAgenda.getNome();
    string diaAgendar =  cachorroAgenda.getDiaCachorro();
    string turnoAgendar =  cachorroAgenda.getTurnoCachorro();
    string barra= "-";
    string informaçoesComplementares = String.Concat(diaAgendar,barra,turnoAgendar);
    string virgula= ",";
    string marcarAgenda = String.Concat(voluntarioAgendar,virgula ,cachorroAgendar,virgula,informaçoesComplementares);
    informaçoesbasicasAgenda.WriteLine(marcarAgenda);
    informaçoesbasicasAgenda.Close();
    arqAgenda.Close();     
  }














 /* public Agenda(Match[] disponibilidadeCachorro){
    if(verificarAgenda != disponibilidadeCachorro){
      disponibilidadeCachorro = verificarAgenda;

    }
  }*/



    
}