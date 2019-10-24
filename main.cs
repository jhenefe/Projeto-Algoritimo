using System;
using System.IO;
using System.Text;

class MainClass {

  public static void Main (string[] args) {
    int sair = 0;
    Voluntario voluntarioCadastrado= new Voluntario();
    int identiUsuario=0;
    int usuarioCadastro=0;
    int numeroVoluntario=0;
    Console.Clear();
    Console.WriteLine("## Digite 1 para voluntario ##");
    Console.WriteLine("## Digite 2 para Dono de um cachorro##");    
   // Console.WriteLine("## Digite 3 para sair##");
    
    identiUsuario=int.Parse(Console.ReadLine());
    //saber se usuario é cadastrado ou não
     if(identiUsuario == 1)
     {    
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

        }
        else{
          Console.WriteLine("Opção invalida.Por favor reinicie o programa.");
          Console.Clear();
        }

      }
      
      Console.Clear();
      int nv=numeroVoluntario;
      Voluntario v= voluntarioCadastrado;
      Console.WriteLine("Se deseja procurar seu companheiro agora digite 1 .Se deseja finalizar o programa digite 2 para sair ");
      int resposta = int.Parse(Console.ReadLine());
      if(resposta==1){
        
        Voluntario[] vetor1 = Voluntario.retornaVetorVoluntario();
        Cachorro[] vetor2 =Cachorro.retornaVetorCachorro();
        Match teste = new Match(vetor1,vetor2);
        
        string[] compativel= Match.compatibilidade(numeroVoluntario,voluntarioCadastrado,vetor2);
        Console.WriteLine(voluntarioCadastrado);
        /*for(int t=0;t<100;t++)
        {
          Console.WriteLine(compativel[t]);
        
        }*/
      }
      else
      {
        if(resposta== 2){
          Console.WriteLine("Obrigado por utilizar nosso programa!");
        }
        
      }
     //Cachorro
    }else
    {
      if(identiUsuario == 2)
      {
        Console.WriteLine("Digite 1 cachorro cadastrado  ou 2 para cadastrar: ");
        int usuarioCachorro = int.Parse(Console.ReadLine());
        
        //Cachorro já cadastrado:>>
        if(usuarioCachorro == 1){
          Console.WriteLine("Informe seu número de cadastro:");
          int numerocadastrocachorro = int.Parse(Console.ReadLine());
          Cachorro[] posiçao =Cachorro.retornaVetorCachorro();
          Cachorro cachorroCadastrado = posiçao[usuarioCachorro-1];
          Console.WriteLine("Bem vindo dono(a) da pet {0}",cachorroCadastrado.getNome());

        }
        else{
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