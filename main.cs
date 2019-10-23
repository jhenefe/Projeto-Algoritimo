using System;
using System;
using System.IO;
using System.Text;

class MainClass {

  public static void Main (string[] args) {
    int identiusuario=0,usuariocadastro=0,numerovoluntario=0;
    Console.Clear();
    Console.WriteLine("Digite 1 para voluntario ou 2 para Dono de um cachorro.");
    identiusuario=int.Parse(Console.ReadLine());
    
    
    //saber se usuario é cadastrado ou não
    if(identiusuario == 1){    
      Console.WriteLine("Digite 1 usuario cadastrado  ou 2 para cadastrar.");
      usuariocadastro = int.Parse(Console.ReadLine());
      
      if(usuariocadastro == 1){
        Console.WriteLine("Informe seu número de voluntario:");
        numerovoluntario=int.Parse(Console.ReadLine());
        Voluntario [] posiçao = Voluntario.retornaVetorVoluntario();
        Voluntario voluntarioCadastrado = posiçao[numerovoluntario-1];
        Console.WriteLine("Bem vindo(a) {0} !",voluntarioCadastrado.getNome());
         
      }else{
        if(usuariocadastro == 2){
          Console.WriteLine("Voluntario numero:{0}",(Voluntario.qtdLinhas()+1));
          Console.WriteLine("Por Favor passe as seguintes informações para criar seu cadastro seguindo o modelo: Nome,Idade/CPF/Telefone/disponibilidade dia-turno/bairro");
          string dados= Console.ReadLine();
          Voluntario.cadastrarUsuario(dados);

        }else{
          Console.WriteLine("Opção invalida.Por favor reinicie o programa.");
        }

      }
      Console.WriteLine("Se deseja procurar seu companheiro agora digite sim.Se deseja finalizar o programa digite sair ");
      string resposta = Console.ReadLine();
      if(resposta=="sim"){
       
      }else{
        if(resposta== "sair")
        Console.WriteLine("Obrigado por utilizar nosso programa!");
      }
    


    }else{
      if(identiusuario == 2){
        Console.WriteLine("Digite 1 cachorro cadastrado  ou 2 para cadastrar: ");
        int usuarioCachorro = int.Parse(Console.ReadLine());
        
        //Cachorro já cadastrado:>>
        if(usuarioCachorro == 1){
          Console.WriteLine("Informe seu número de cadastro:");
          int numerocadastrocachorro = int.Parse(Console.ReadLine());
          Cachorro[] posiçao =Cachorro.retornaVetorCachorro();
          Cachorro cachorroCadastrado = posiçao[usuarioCachorro-1];
          Console.WriteLine("Bem vindo dono(a) da pet {0}",cachorroCadastrado.getNome());

        }else{
          if(usuarioCachorro == 2){
            int numerocachorro=Cachorro.qtdLinhasCachorro();
            Console.WriteLine("Cachorro número: {0}",numerocachorro);
            //Escrevendo no arquivo 
            Console.WriteLine("Por favor preencha as informações a seguir conforme solicitado: Nome / Raça / Sexo / Cor / Porte / Horário disponível /:");
            string dadosCachorro= Console.ReadLine();
            Cachorro.cadastrarCachorro(dadosCachorro);
          }

        }
      }  
    
      

    }

  }
  
 

  


} 
