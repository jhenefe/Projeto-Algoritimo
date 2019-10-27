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
  //RETORNA TODO O AQUIVO AGENDA
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
  //VERIFICA SE O CACHORRO TEM AGENDA MARCADA 
  public static int verificaAgendaCachorro(string[] arquivoAgenda,Cachorro cachorroVerificar,int consulta){
    
    string nomeCachorroVerificar = cachorroVerificar.getNome();
    string telefoneCachorroVerificar = cachorroVerificar.getTelefoneDono();
    int retornaDisponibilidadeCachorro = 1;
    int cont = 0;
    while(arquivoAgenda[cont] != null){

      string posiçao  =  arquivoAgenda[cont];
      string[]  vetorAgenda = posiçao.Split(',');
      string cachorroAgendado = vetorAgenda[4];
      string cachorroTelefoneDono= vetorAgenda[5];
      if(nomeCachorroVerificar == cachorroAgendado){
       if(cachorroTelefoneDono == telefoneCachorroVerificar ){
         if(consulta ==1){
            Console.WriteLine("Informções Agendamento:");
            Console.WriteLine("Voluntario");
            Console.WriteLine(vetorAgenda[0]);
            Console.WriteLine(vetorAgenda[6]);
            Console.WriteLine("Telefone contato: {0}",vetorAgenda[3]);
         }
         
        }
        retornaDisponibilidadeCachorro = 0;
      }
     cont++;
    }
   
    return retornaDisponibilidadeCachorro;
  }
  //VERIFICA SE VOLUNTARIO TEM AGENDAMENTO
  public static void verificaAgendaVoluntario(string[] arquivoAgenda,Voluntario voluntarioVerificar){
    
    string nomeVoluntarioVerificar = voluntarioVerificar.getNome();
    string cpfVoluntarioVerificar = voluntarioVerificar.getCpf();
    int retornaDisponibilidadeVoluntario = 1;
    int cont = 0;
    while(arquivoAgenda[cont] != null){

      string posiçao  =  arquivoAgenda[cont];
      string[]  vetorAgenda = posiçao.Split(',');
      string voluntarioAgendado = vetorAgenda[0];
      string cpfAgenda= vetorAgenda[1];
      Console.WriteLine(voluntarioAgendado);
      if(nomeVoluntarioVerificar == voluntarioAgendado){
       if(cpfVoluntarioVerificar == cpfAgenda ){
         Console.WriteLine("Informções Agendamento:");
         Console.WriteLine("Cachorro");
          Console.WriteLine(vetorAgenda[4]);
          Console.WriteLine(vetorAgenda[6]);
          Console.WriteLine("telefone contato Dono: {0}",vetorAgenda[5]);
        }
      }
      cont++;  
    }
    
  }
   
  
  public static void  agendamento(Voluntario voluntarioAgenda,Cachorro cachorroAgenda ){
    FileStream arqAgenda= new FileStream("Agenda.text",FileMode.Append,FileAccess.Write);
    StreamWriter informaçoesbasicasAgenda= new StreamWriter(arqAgenda, Encoding.UTF7);    
    
    string voluntarioAgendar = voluntarioAgenda.getNome();
    string voluntarioCpf = voluntarioAgenda.getCpf();
    string voluntarioTelefone = voluntarioAgenda.getTelefone();
    string cachorroAgendar =  cachorroAgenda.getNome();
    string diaAgendar =  cachorroAgenda.getDiaCachorro();
    string cachorroContadoDono =  cachorroAgenda.getTelefoneDono();
    string turnoAgendar =  cachorroAgenda.getTurnoCachorro();
    string barra= "-";
    string informaçoesComplementares = String.Concat(diaAgendar,barra,turnoAgendar);
    string virgula= ",";
    string marcarAgenda = String.Concat(voluntarioAgendar,virgula,voluntarioCpf,virgula,voluntarioTelefone,virgula,cachorroAgendar,virgula,cachorroContadoDono,virgula,informaçoesComplementares);
    informaçoesbasicasAgenda.WriteLine(marcarAgenda);
    informaçoesbasicasAgenda.Close();
    arqAgenda.Close();     
  }

}