using System;
using System.IO;
using System.Text;

class MainClass {

  public static void Main (string[] args) { 
    Console.Clear();
    int sair = 0;
     bool verificaResposta;
    while(sair == 0 ){
      Voluntario voluntario;
      int entradaInicialUsuario= 0;
      int usuarioVoluntario= 0;
      int usuarioCachorro= 0;
      int numeroCachorro = 0;
      int numeroVoluntario = 0;
      int numerousuario = 0;
      int numeroCadastroCachorro = 0;
      string consultaString = null;
      int consulta = 0;
      //Voluntario voluntarioCadastrado = new Voluntario();
    
      Console.WriteLine("## Digite 1 para voluntário ##");
      Console.WriteLine("## Digite 2 para Dono de um cachorro##"); 
      Console.WriteLine("## Digite 0 para finalizar Match Dog"); 
    
      string entrada = Console.ReadLine();
      verificaResposta = digitosCertos(entrada) ;
      //Tratar a entrada inicial
      if(verificaResposta== false ){
        Console.WriteLine("Opção inválida");
      }
      else{
       
        entradaInicialUsuario = int.Parse(entrada);

        switch (entradaInicialUsuario){
          case 1:
          verificaResposta = false;
          while(verificaResposta == false){  
            Console.WriteLine("Digite 1 para usuário cadastrado ou 2 para se cadastrar.");
            consultaString = Console.ReadLine();
            usuarioVoluntario = int.Parse(consultaString);
            verificaResposta = digitosCertosDuasOpçoes(consultaString);
            while(usuarioVoluntario!= 1 && usuarioVoluntario != 2){
              Console.Clear();
              verificaResposta = false;
              while(verificaResposta == false){
                Console.WriteLine("Digite 1 para usuario cadastrado ou 2 para se cadastrar.");
                consultaString = Console.ReadLine();
                usuarioVoluntario = int.Parse(consultaString);
                verificaResposta = digitosCertosDuasOpçoes(consultaString);
                if(verificaResposta == true){
                  if( consulta == 1 || consulta == 2){
                    usuarioVoluntario = int.Parse(consultaString);
                  }
                  else{
                    sair = 1;
                  }   
                }
              }  
            }
          }  
            //CONFIRMAR CADASTRO OU CADASTRAR USUÁRIO.
            switch(usuarioVoluntario){
              //VOLUNTARIO CADASTRADO
              case 1:
                Console.WriteLine("Informe seu número de voluntário:");
                numeroVoluntario=int.Parse(Console.ReadLine());
                //CONFIRMAR CADASTRADO VOLUNTARIO
                int numeroVoluntarioConfirmado = Voluntario.verificaCadastradoVoluntario(numeroVoluntario,Voluntario.retornaVetorVoluntario());
                voluntario = Voluntario.retornaVoluntario(numeroVoluntarioConfirmado,Voluntario.retornaVetorVoluntario());  
                if(numeroVoluntarioConfirmado == 0){
                  sair = 0;
                }else{
                  //MATCH VOLUNTARIO/CACHORRO.
                  verificaResposta = false;
                  while(verificaResposta == false){
                    Console.WriteLine("Se deseja procurar seu companheiro digite 1. ");
                    Console.WriteLine("Se deseja consultar seus agendamentos digite 2");
                    Console.WriteLine("Se deseja finalizar o programa digite 0");
                    consultaString = Console.ReadLine();
                    int resposta = int.Parse(consultaString);
                    verificaResposta = digitosCertosDuasOpçoes(consultaString);
                  
                    if(resposta == 1){
                      Cachorro [] vetorCachorroCompativel = Match.verificaCachorroCompatibilidade (voluntario,Cachorro.retornaVetorCachorro());
                      Match voluntariomatch = new Match(voluntario);
                      Match.match(vetorCachorroCompativel,voluntario);
                  }
                    else{
                      if(resposta == 2){
                      Agenda.verificaAgendaVoluntario(Agenda.retornaVetorAgenda(),voluntario);
                      }
                      else{
                      sair = 1;
                      }
                   
                    }
                  }
                
                }
              break;
              //VOLUNTARIO CADASTRAR
              case 2:
                //Voluntario.cadastrarUsuario(Voluntario.qtdLinhas());
                Voluntario[] atualizaVetorAgenda = Voluntario.retornaVetorVoluntario();
                voluntario = Voluntario.retornaVoluntario((Voluntario.qtdLinhas()-1),atualizaVetorAgenda);
                Cachorro [] vetorSeleçaoCachorroCompativel = Match.verificaCachorroCompatibilidade (voluntario,Cachorro.retornaVetorCachorro());
                Match.match(vetorSeleçaoCachorroCompativel,voluntario);
              break;
              
              default:
                Console.WriteLine("Opção inválida");
              break;

            } 
          break;
          //CACHORRO
          case 2:
            verificaResposta = false;
            while(verificaResposta == false){
              Console.WriteLine("Digite 1 para cachorro cadastrado ou 2 para se cadastrar: ");
              consultaString = Console.ReadLine();
              usuarioCachorro = int.Parse(consultaString);
              verificaResposta = digitosCertosDuasOpçoes(consultaString);
            } 
            while(usuarioCachorro  != 1 && usuarioCachorro  != 2 ){
              Console.Clear();
              verificaResposta = false;
              while(verificaResposta == false){
                Console.WriteLine("Digite 1 para usuario cadastrado ou 2 para se cadastrar.");
                consultaString = Console.ReadLine();
                usuarioCachorro = int.Parse(consultaString);
                verificaResposta = digitosCertosDuasOpçoes(consultaString);
                if(verificaResposta == true){
                  if( consulta == 1 || consulta == 2){
                    usuarioCachorro = int.Parse(consultaString);
                  }
                  else{
                    sair = 1;
                  }
                }      
              }
            }  
            switch(usuarioCachorro){
              //CACHORRO CADASTRADO
              case 1:
                Console.Clear();
                verificaResposta = false;
                while(verificaResposta == false){
                  Console.WriteLine("Informe o número de cadastro do seu cachorro:");
                  consultaString = Console.ReadLine();
                  numeroCachorro=int.Parse(Console.ReadLine());
                }

                //CONFIRMAR CADASTRADO CACHORRO
                numeroCadastroCachorro = Cachorro.verificaCachorroCadastrado(numeroCachorro ,Cachorro.retornaVetorCachorro());
                Console.WriteLine(numeroCadastroCachorro );
                Cachorro cachorro = Cachorro.retornaCachorro(numeroCadastroCachorro,Cachorro.retornaVetorCachorro());  
                Console.WriteLine(cachorro);
                if(numeroCadastroCachorro == 0){
                  sair = 1;
                }else{
                  //CONSULTAR SE TEM AGENDAMENTO
                  verificaResposta = false;
                  while(verificaResposta == false){
                    Console.WriteLine(" Se deseja consultar seus agendamentos digite 1, ou digite 0 para finalizar o programa");
                    consultaString = Console.ReadLine();
                    consulta = int.Parse(consultaString);
                    verificaResposta = digitosCertosDuasOpçoes(consultaString);
                    if(verificaResposta == true){
                      if( consulta == 1){
                      Agenda.verificaAgendaCachorro(Agenda.retornaVetorAgenda(),cachorro,consulta);
                      }else{
                        sair = 1;
                      }
                    }
                  }
  
                }

              break;
              //CADASTRAR
              case 2:
                Cachorro.cadastrarCachorro(Cachorro.qtdLinhasCachorro());
                
              break;
              
              default:
              Console.WriteLine("Opção inválida");
              break;

            } 

          break;
          case 3:
               sair = 1;
              break;default:
            Console.WriteLine("Opção inv");
          break;
        
        }
      
      }
    }
   
    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(4));
    Console.Clear();
  }
  //FUNÇAO TRATAR ENTRADA INICIAL 
  public static bool digitosCertos(string entrada){
    char primeiroCaracter = entrada[0];
    int codigoAscii = Convert.ToInt32(primeiroCaracter );
    //Tratar a entrada inicial
    if(codigoAscii < 47 || codigoAscii > 52 || entrada.Length > 1){
      Console.WriteLine("Opção inválida");
      Console.WriteLine("Digite uma opção correta ou 0 para sair");
      return false;
    }
    return true;  
  }
  public static bool digitosCertosDuasOpçoes(string entrada){
    char primeiroCaracter = entrada[0];
    int codigoAscii = Convert.ToInt32(primeiroCaracter );
    //Tratar a entrada inicial
    if(codigoAscii < 47 || codigoAscii > 50 || entrada.Length > 1){
      Console.WriteLine("Opção inválida");
      Console.WriteLine("Digite uma opção correta ou 0 para sair");
      return false;
    }
    return true;  
  }
}
  