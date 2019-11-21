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
      Console.WriteLine("## Digite 1 para voluntário ##");
      Console.WriteLine("## Digite 2 para dono de um cachorro##"); 
      Console.WriteLine("## Digite 0 para finalizar Match Dog"); 
    
      string entrada = Console.ReadLine();
      verificaResposta = digitosCertos(entrada) ;
      //Tratar a entrada inicial
      if(verificaResposta == false ){
        Console.WriteLine("Opção inválida");  
      }else{
        entradaInicialUsuario = int.Parse(entrada);
        switch (entradaInicialUsuario){
          case 1:
            verificaResposta = false;
            while(verificaResposta == false){
              Console.WriteLine("Digite 1 para usuário cadastrado, 2 para se cadastrar ou 0 para sair.");
              consultaString = Console.ReadLine();
              verificaResposta = digitosCertosDuasOpçoes(consultaString);
              Console.Clear();
            }
            consulta = int.Parse(consultaString);
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
            usuarioVoluntario = consulta;
            //CONFIRMAR CADASTRO OU CADASTRAR USUÁRIO.
            switch(usuarioVoluntario){
              //VOLUNTARIO CADASTRADO
              case 1:
                verificaResposta = false;
                while(verificaResposta == false){
                  Console.WriteLine("Informe seu número de voluntário:");
                  consultaString = Console.ReadLine();
                  verificaResposta = digitosCertosNumeroQualquer(consultaString);
                  System.Threading.Thread.Sleep(TimeSpan.FromSeconds(3));
                  Console.Clear();
                }
                consulta = int.Parse(consultaString);
                numeroVoluntario = consulta;
                //CONFIRMAR CADASTRADO VOLUNTARIO
                int numeroVoluntarioConfirmado = Voluntario.verificaCadastradoVoluntario(numeroVoluntario,Voluntario.retornaVetorVoluntario());
                voluntario = Voluntario.retornaVoluntario(numeroVoluntarioConfirmado,Voluntario.retornaVetorVoluntario());  
                if(numeroVoluntarioConfirmado == 0){
                  sair = 0;
                }else{
                  //MATCH VOLUNTARIO/CACHORRO.
                  verificaResposta = false;
                  while(verificaResposta == false){
                    Console.WriteLine("Se deseja procurar seu companheiro digite 1.");
                    Console.WriteLine("Se deseja consultar seu agendamento digite 2.");
                    Console.WriteLine("Se deseja finalizar o programa digite 0.");
                    consultaString = Console.ReadLine();
                    verificaResposta = digitosCertosDuasOpçoes(consultaString);
                    Console.Clear();
                  }
                  int resposta = int.Parse(consultaString);
                  if(resposta == 1){
                    Cachorro [] vetorCachorroCompativel = Match.verificaCachorroCompatibilidade (voluntario,Cachorro.retornaVetorCachorro());
                    Match voluntariomatch = new Match(voluntario);
                    Match.match(vetorCachorroCompativel,voluntario);
                  }else{
                    if(resposta == 2){
                      Agenda.verificaAgendaVoluntario(Agenda.retornaVetorAgenda(),voluntario);
                    }else{
                      sair = 1;
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
              Console.WriteLine("Digite 1 para cachorro cadastrado, 2 para se cadastrar ou 0 para sair: ");
              consultaString = Console.ReadLine();
              verificaResposta = digitosCertosDuasOpçoes(consultaString);
              Console.Clear();
            }
            usuarioCachorro = int.Parse(consultaString);
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
                    Console.WriteLine(" Se deseja consultar seu agendamento digite 1, ou 0 para finalizar o programa.");
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
            Console.WriteLine("Opção invalida");
          break;
          default:
            sair = 1;
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
    if(codigoAscii < 48 || codigoAscii > 50 || entrada.Length > 1){
      Console.WriteLine("Opção inválida");
      Console.WriteLine("Digite uma opção correta ou 0 prar sair");
      return false;
      System.Threading.Thread.Sleep(TimeSpan.FromSeconds(3));
    }
    
    return true;  
  }
  //FUNÇAO TRATAR ENTRADA NUMERO 1 E 0
  public static bool digitosCertosDuasOpçoes(string entrada){
    char primeiroCaracter = entrada[0];
    int codigoAscii = Convert.ToInt32(primeiroCaracter );
    if(codigoAscii < 47 || codigoAscii > 50 || entrada.Length > 1){
      Console.WriteLine("Opção inválida");
      Console.WriteLine("Digite uma opção correta ou 0 para sair");
      return false;
      System.Threading.Thread.Sleep(TimeSpan.FromSeconds(2));
    }
    return true;  
  }
  //FUNÇAO TRATAR ENTRADA NUMERO 0,1,2.
  public static bool digitosCertosUmDois(string entrada){
    char primeiroCaracter = entrada[0];
    int codigoAscii = Convert.ToInt32(primeiroCaracter );
    if(codigoAscii < 47 || codigoAscii > 51 || entrada.Length > 1){
      Console.WriteLine("Opção inválida");
      Console.WriteLine("Digite uma opção correta ou 0 para sair");
      return false;
      System.Threading.Thread.Sleep(TimeSpan.FromSeconds(3));
    }
    return true;  
  }
  //FUNÇAO TRATAR ENTRADA NUMERO CADASTRO
  public static bool digitosCertosNumeroQualquer(string entrada){
    char primeiroCaracter = entrada[0];
    int codigoAscii = Convert.ToInt32(primeiroCaracter );
    if(codigoAscii < 47 || codigoAscii > 57 || entrada.Length > 1){
      Console.WriteLine("Opção inválida");
      Console.WriteLine("Digite uma opção correta ou 0 para sair");
      return false;
      System.Threading.Thread.Sleep(TimeSpan.FromSeconds(3));
    }
    return true;  
  }
}
  