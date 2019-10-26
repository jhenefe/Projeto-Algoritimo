using System;
using System.IO;
using System.Text;

class MainClass {

  public static void Main (string[] args) { 
      Console.Clear();
      int sair = 0;
    while(sair == 0 ){
      Voluntario voluntario;
      int entradaInicialUsuario= 0;
      int usuarioCadastrado = 0;
      int usuarioCachorro = 0;
      int numeroVoluntario = 0;
      int numerousuario = 0;
      int numerocadastrocachorro = 0;
      //Voluntario voluntarioCadastrado = new Voluntario();
    
      Console.WriteLine("## Digite 1 para voluntario ##");
      Console.WriteLine("## Digite 2 para Dono de um cachorro##"); 
    
      string entrada = Console.ReadLine();
      char primeiroCaracter = entrada[0];
      int codigoAscii = Convert.ToInt32(primeiroCaracter );
      //Tratar a entrada inicial
      if(codigoAscii < 48 || codigoAscii > 57 || entrada.Length > 1){
        Console.WriteLine("Opção inválida");
      }else{
        entradaInicialUsuario = int.Parse(entrada);

        switch (entradaInicialUsuario)
        {
          case 1:
            Console.WriteLine("Digite 1 usuario cadastrado  ou 2 para cadastrar.");
            usuarioCadastrado = int.Parse(Console.ReadLine());
            while(usuarioCadastrado != 1 && usuarioCadastrado != 2){
              Console.Clear();
              Console.WriteLine("Digite 1 usuario cadastrado  ou 2 para cadastrar.");
              usuarioCadastr
              ado = int.Parse(Console.ReadLine());
            }
          break;
          case 2:
            Console.WriteLine("Digite 1 cachorro cadastrado  ou 2 para cadastrar: ");
            usuarioCachorro = int.Parse(Console.ReadLine());
            while(usuarioCachorro  != 1 && usuarioCachorro  != 2){
              Console.Clear();
              Console.WriteLine("Digite 1 usuario cadastrado  ou 2 para cadastrar.");
              usuarioCachorro = int.Parse(Console.ReadLine());
            }
          break;
          default:
            Console.WriteLine("Opção inv");
          break;
        }
          
        if(entradaInicialUsuario == 1){
          //PARTE DE VOLUNTARIO
            
          if(usuarioCadastrado == 1){
            Console.WriteLine("Informe seu número de voluntario:");
            numeroVoluntario=int.Parse(Console.ReadLine());
            int confirmaçãoVoluntario = Voluntario.verificaVoluntarioCadastrado(numeroVoluntario,Voluntario.retornaVetorVoluntario());
            if(confirmaçãoVoluntario == 1){
              voluntario = Voluntario.retornaVoluntario(numeroVoluntario,Voluntario.retornaVetorVoluntario());
              Console.WriteLine("Bem vindo(a) {0} !",voluntario.getNome());
            }else{
              while(confirmaçãoVoluntario != 0){
                Console.WriteLine("Opção inválida.Por favor digite o numero de usuario válido para verificação ou 0 para sair:");
                numeroVoluntario = int.Parse( Console.ReadLine());
                if(numeroVoluntario != 0){
                  confirmaçãoVoluntario = Voluntario.verificaVoluntarioCadastrado(numeroVoluntario,Voluntario.retornaVetorVoluntario());
                }else{
                  confirmaçãoVoluntario = 0;
                  sair = 0;
                }
                
              }
            
            }
            
          }else{
            Console.WriteLine("Voluntario numero:{0}",(Voluntario.qtdLinhas()+1));
            Console.WriteLine("Por Favor passe as seguintes informações para criar seu cadastro seguindo o modelo: Nome,Idade/CPF/Telefone/disponibilidade dia-turno/bairro");
            string dados = Console.ReadLine();
            Voluntario.cadastrarUsuario(dados);
            Console.Clear();

          }
          
          Console.Clear();
          Console.WriteLine("Se deseja procurar seu companheiro agora digite 1 .Se deseja finalizar o programa digite 0 para sair ");
          int resposta = int.Parse(Console.ReadLine());
          voluntario = Voluntario.retornaVoluntario(numeroVoluntario,Voluntario.retornaVetorVoluntario());
          if(resposta==1){
            Cachorro [] vetorCachorroCompativel = Match.verificaCachorroCompatibilidade (voluntario, Cachorro.retornaVetorCachorro());
            Console.WriteLine("Informações do(s) cachorro(s) compatível(s)");
            Cachorro cachorroCadastrado;
            for(int cont = 0;vetorCachorroCompativel[cont] != null;cont++){
              Console.WriteLine(cont+1);
              cachorroCadastrado = vetorCachorroCompativel[cont];
              Console.WriteLine("Nome:{0}",cachorroCadastrado.getNome());
              Console.WriteLine("Raça:{0}",cachorroCadastrado.getRaça());
              Console.WriteLine("Sexo:{0}",cachorroCadastrado.getSexo());
              Console.WriteLine("Cor:{0}",cachorroCadastrado.getCor());
              Console.WriteLine("   ");
            }
           
            int finalizarAgendamento = 1;
            int cachorroLiberado = 0;
            while( finalizarAgendamento == 1){
              int agendar=0; 
              Console.WriteLine("Informe número do cachorro escolhido");
              int cachorroEscolhido = int.Parse(Console.ReadLine());
              cachorroCadastrado = vetorCachorroCompativel[cachorroEscolhido-1];
              
              Match verificarCachorroAgenda = new Match(voluntario, cachorroCadastrado);
              Agenda agenda= new Agenda(verificarCachorroAgenda); 
              Cachorro cachorroAgenda= agenda.getMatchVoluntarioCachorro().getCachorro();
              
              string[] vetorAgenda = Agenda.retornaVetorAgenda(); 
              cachorroLiberado= Agenda.verificaAgendaCachorro( vetorAgenda,cachorroAgenda);
              if(cachorroLiberado == 1){
                Console.WriteLine("-------------------------------------------------------");
                Console.WriteLine("--------         Deuuuuuu  Matchh              --------");
                Console.WriteLine("-------------------------------------------------------");
                Console.Clear();
                Console.WriteLine("Vamos agendar?");
                Console.WriteLine("Digite 1 para sim");
                Console.WriteLine("Digite  para finalizar sair");
                finalizarAgendamento=int.Parse(Console.ReadLine());

              }else{
                Console.WriteLine("Cachorro já agendado.");
                Console.WriteLine("Digite 1 para  escolher outro cacchorro digite  0 para finalizar");
                finalizarAgendamento=int.Parse (Console.ReadLine());
              }
            }
            
            
            
            
            
             
            
            
          

          }else{
            //PARTE DO CACHORRO
            //Cachorro já cadastrado:>>
            if(usuarioCachorro == 1){
              Console.WriteLine("Informe seu número de cadastro:");
              numerocadastrocachorro = int.Parse(Console.ReadLine());
              Cachorro[] posiçao = Cachorro.retornaVetorCachorro();
              Cachorro cachorroCadastrado = posiçao[usuarioCachorro-1];
              Console.WriteLine("Bem vindo dono(a) da pet {0}",cachorroCadastrado.getNome());

            }else{
              numerocadastrocachorro=Cachorro.qtdLinhasCachorro();
              numerousuario=numerocadastrocachorro;
              Console.WriteLine("Cachorro número: {0}", numerocadastrocachorro);
              //Escrevendo no arquivo 
              Console.WriteLine("Por favor preencha as informações a seguir conforme solicitado: Nome / Raça / Sexo / Cor / Porte / Horário disponível /:");
              string dadosCachorro = Console.ReadLine();
              Cachorro.cadastrarCachorro(dadosCachorro);
              Console.Clear();
              
            }
          }

        }
      }
    }
  }
  
}