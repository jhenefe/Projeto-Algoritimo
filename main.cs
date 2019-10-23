using System;
using System.IO;
using System.Text;

class MainClass {

  public static void Main (string[] args) {
    int sair = 0;

    while(sair == 0){
      Voluntario voluntarioCadastrado= new Voluntario();
      int identiUsuario=0,usuarioCadastro=0,numeroVoluntario=0;
      Console.Clear();
      Console.WriteLine("##########################################################");
      Console.WriteLine("## Digite 1 para voluntario                             ##");
      Console.WriteLine("##                                                      ##");   
      Console.WriteLine("## Digite 2 para Dono de um cachorro                    ##");
      Console.WriteLine("##                                                      ##");      
      Console.WriteLine("## Digite 3 para sair                                   ##");
      Console.WriteLine("##########################################################");
      identiUsuario=int.Parse(Console.ReadLine());
      
      if(identiUsuario == 3){
        sair = 1;
        Console.WriteLine("Obrigado por utilizar nosso programa!");
      }else{
        //saber se usuario é cadastrado ou não
        if(identiUsuario == 1){    
          Console.WriteLine("Digite 1 usuario cadastrado  ou 2 para cadastrar.");
          usuarioCadastro = int.Parse(Console.ReadLine());
          
          if(usuarioCadastro == 1){
            Console.WriteLine("Informe seu número de voluntario:");
            numeroVoluntario=int.Parse(Console.ReadLine());
            Voluntario [] posiçao = Voluntario.retornaVetorVoluntario();
            voluntarioCadastrado = posiçao[numeroVoluntario-1];
            Console.WriteLine("Bem vindo(a) {0} !",voluntarioCadastrado.getNome());
            
          }else{
            if(usuarioCadastro == 2){
              Console.WriteLine("Voluntario numero:{0}",(Voluntario.qtdLinhas()+1));
              Console.WriteLine("Por Favor passe as seguintes informações para criar seu cadastro seguindo o modelo: Nome,Idade/CPF/Telefone/disponibilidade dia-turno/bairro");
              string dados= Console.ReadLine();
              Voluntario.cadastrarUsuario(dados);
              Console.Clear();

            }else{
              Console.WriteLine("Opção invalida.Por favor reinicie o programa.");
              Console.Clear();
            }

          }
          
          Console.WriteLine("Se deseja procurar seu companheiro agora digite sim.Se deseja finalizar o programa digite sair ");
          string resposta = Console.ReadLine();
          if(resposta=="sim"){
            Match teste = new Match(Voluntario.retornaVetorVoluntario(),Cachorro.retornaVetorCachorro());
            string[] teste2  = Match.compatibilidade(numeroVoluntario,voluntarioCadastrado,Cachorro.retornaVetorCachorro());
            for(int t=0;t<100;t++){
            Console.WriteLine(teste2[t]);
            }
          }else{
            if(resposta== "sair")
            Console.WriteLine("Obrigado por utilizar nosso programa!");
          }

        }else{
          if(identiUsuario == 2){
            Console.WriteLine("Digite 1 cachorro cadastrado  ou 2 para cadastrar: ");
            int usuarioCachorro = int.Parse(Console.ReadLine());
            
            //Cachorro já cadastrado:>>
            if(usuarioCachorro == 1){
              Console.WriteLine("Informe seu número de cadastro:");
              int numeroCadastroCachorro = int.Parse(Console.ReadLine());
              Cachorro[] posiçao =Cachorro.retornaVetorCachorro();
              Cachorro cachorroCadastrado = posiçao[usuarioCachorro-1];
              Console.WriteLine("Bem vindo dono(a) da pet {0}",cachorroCadastrado.getNome());
              Console.Clear();

            }else{
              if(usuarioCachorro == 2){
                int numeroCachorro=Cachorro.qtdLinhasCachorro();
                Console.WriteLine("Cachorro número: {0}",numeroCachorro);
                //Escrevendo no arquivo 
                Console.WriteLine("Por favor preencha as informações a seguir conforme solicitado: Nome / Raça / Sexo / Cor / Porte / Horário disponível /:");
                string dadosCachorro= Console.ReadLine();
                Cachorro.cadastrarCachorro(dadosCachorro);
                Console.Clear();
              }

            }

          }  

        }
        
    
        
      }
    }
      
  }

} 
