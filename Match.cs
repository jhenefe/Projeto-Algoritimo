using System;
using System.IO;
using System.Text;
class Match{ 
  private Voluntario voluntario;
  private Cachorro cachorro;
  //CONSTRUTOR
  public Match (Voluntario voluntarioComparar){    
    voluntario = voluntarioComparar;
  } 
  public Match (Voluntario voluntario, Cachorro cachorroEscolhido){    
    voluntario = voluntario;
    cachorro = cachorroEscolhido;
  }
  //METODOS DE ACESSO
  public  Voluntario  getVoluntario(){
   return voluntario;
  }
   public  Cachorro  getCachorro(){
   return cachorro;
  }
  //METODO VERIFICA TODOS CACHORROS COMPATIVEIS COM O OBJETO VOLUNTARIO SELECIONADO
  public static Cachorro [] verificaCachorroCompatibilidade (Voluntario voluntario,Cachorro[] vetorCachorro){
    string diaVoluntario = voluntario.getDia();
    string turnoVoluntario = voluntario.getTurno();
    string bairroVoluntario= voluntario.getBairro();
    Cachorro[] cachorroCompativel = new Cachorro[1000];
    int contador=0;
    for(int i = 0; i<1000; i++){
      if(vetorCachorro[i] != null){
       Cachorro objetoCachorro = vetorCachorro[i];
        string diaCachorro = objetoCachorro.getDiaCachorro();
        string turnoCachorro = objetoCachorro.getTurnoCachorro();
        string bairroCachorro = objetoCachorro.getBairroCachorro();
        if(bairroVoluntario == bairroCachorro && diaVoluntario == diaCachorro && turnoVoluntario == turnoCachorro){    
          cachorroCompativel[contador] = objetoCachorro;
          contador++;
        }
      }else{
        i = 1000;
      }
    } 
   return cachorroCompativel;
  }
  //METODO QUE PRINTA NA TELA TODOS OS CACHORROS COMPATÍVEIS, VERIFICA DISPONIBILIDADE,E CHAMA METODO AGENDAMENTO DA CLASSE AGENDA
  public static void match(Cachorro[] vetorCachorroCompativel,Voluntario voluntario){
    int verificaSeTemCahorro = 0; 
    while(vetorCachorroCompativel[verificaSeTemCahorro] != null){
      verificaSeTemCahorro++;  
    }
    if(verificaSeTemCahorro != 0){
      Console.WriteLine("Informações do(s) cachorro(s) compatível(s)");
      Cachorro cachorroMatch;
      for(int cont = 0;vetorCachorroCompativel[cont] != null;cont++){
      
        cachorroMatch = vetorCachorroCompativel[cont];
        Console.WriteLine("Nome:{0}",cachorroMatch.getNome());
        Console.WriteLine("Raça:{0}",cachorroMatch.getRaça());
        Console.WriteLine("Sexo:{0}",cachorroMatch.getSexo());
        Console.WriteLine("Cor:{0}",cachorroMatch.getCor());
        Console.WriteLine("   ");
      }
        
      int finalizarAgendamento = 1;
      int cachorroLiberado = 0;
      while( finalizarAgendamento != 0){
        int agendar=0; 
        Console.WriteLine("Informe número do cachorro escolhido");
        int cachorroEscolhido = int.Parse(Console.ReadLine());
        cachorroMatch = vetorCachorroCompativel[cachorroEscolhido-1];
        string[] vetorAgenda = Agenda.retornaVetorAgenda(); 
        int consulta = 0;
        cachorroLiberado= Agenda.verificaAgendaCachorro( vetorAgenda,cachorroMatch,consulta);
        if(cachorroLiberado == 1){
        
          Console.WriteLine("-------------------------------------------------------");
          Console.WriteLine("--------         Deuuuuuu  Matchh              --------");
          Console.WriteLine("-------------------------------------------------------");
          System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
          Console.WriteLine("Vamos agendar?");
          Console.WriteLine("Digite 1 para sim");
          Console.WriteLine("Digite 0 para finalizar sair");
          int agendamento = int.Parse(Console.ReadLine());
          if (agendamento == 1){
            Agenda.agendamento(voluntario,cachorroMatch);
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(2));
            Console.WriteLine("Agendamento realizado!");
            Cachorro.informaçõesMatchCachorro(cachorroMatch);
            finalizarAgendamento = 0;
          }
          System.Threading.Thread.Sleep(TimeSpan.FromSeconds(2));
          Console.Clear();
        }else{
          Console.WriteLine("Cachorro já agendado.");
          Console.WriteLine("Digite 1 para  escolher outro cacchorro, digite  0 para finalizar");
          finalizarAgendamento=int.Parse (Console.ReadLine());
        
          
        }
      }
    
    }else{
    Console.WriteLine("Infelizmente não há cachorro compativel");
    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(3));
    }

  }
   
}