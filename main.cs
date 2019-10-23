using System;
using System.IO;
using System.Text;
class MainClass {
  
  public static void Main (string[] args) {

    string  infobasic= string.Empty;
    string  infoperfil= string.Empty;
    string saidainfobasic = string.Empty;
    int cont=0,c=0,linha=0,posi=0;
    int numerovoluntario=0;
    int  identiusuario=0;
    int  usuariocadastro=0;
    Console.Clear();

    Console.WriteLine("Digite 1 para voluntario ou 2 para dono de um cachorro.");

    identiusuario=int.Parse(Console.ReadLine());
    
   //Acesso arquivo
      FileStream  leiturarqvoluntario= new FileStream("Voluntario.text",FileMode.Open,FileAccess.Read);
          
      //Lendo informaçoes salvas no arquivo
      StreamReader lerinfobasic =new StreamReader(leiturarqvoluntario,Encoding.UTF8);
    

    //saber se usuario é cadastrado ou não
    if(identiusuario == 1){
      
      Console.WriteLine("Digite 1 usuario cadastrado  ou 2 para cadastrar.");
      usuariocadastro=int.Parse(Console.ReadLine());

      if(usuariocadastro == 1){
        Console.WriteLine("Informe seu número de voluntario:");
        numerovoluntario=int.Parse(Console.ReadLine());
        

        

      }else{
        if(usuariocadastro == 2){      
          

          while (!lerinfobasic.EndOfStream){
            lerinfobasic.ReadLine();
            cont++;
          
          }

          lerinfobasic.Close();
          leiturarqvoluntario.Close();


          //Acesso para escrever no arquivo 
          FileStream arqvoluntarios = new FileStream("Voluntario.text",FileMode.Append,FileAccess.Write);
          
          //pegando informaçoes do usuario 
          StreamWriter informaçoesbasicas= new StreamWriter(arqvoluntarios, Encoding.UTF7);
          if(cont == 1 ){
            cont=1;
            numerovoluntario=cont;
            informaçoesbasicas.WriteLine(numerovoluntario);
            
          }else{
            if(cont==2){
              cont=2;
              numerovoluntario=cont;
              informaçoesbasicas.WriteLine(numerovoluntario);

            }else{
              while(cont!=0){
                cont= (cont-2);
                c++;

              }
              numerovoluntario=c+1;
              informaçoesbasicas.WriteLine(numerovoluntario);
            }

          }
        
          //Pegando informaçoes usuario
          Console.WriteLine("Voluntario numero:{0}",numerovoluntario);
        
          //Escrevendo no arquivo 
          Console.WriteLine("Por Favor passe as seguintes informações para criar seu cadastro seguindo o modelo: Nome/Idade/CPF/Telefone/disponibilidade dia hora/Perfil");
        
          infobasic = Console.ReadLine();
          informaçoesbasicas.WriteLine(infobasic);
        

          //Fechando acesso de escrever no arquivo 
          informaçoesbasicas.Close();
          arqvoluntarios.Close();


        }else{
          Console.WriteLine("Opção invalida.Por favor reinicie o programa.");
        }

      }
     
      string [] vetorarquivo = new string[50];
          
      while(!lerinfobasic.EndOfStream){
            
        vetorarquivo[linha]= lerinfobasic.ReadLine();
       
        linha++;
      }
      lerinfobasic.Close();
      leiturarqvoluntario.Close();

      linha=0;
      while(linha<50){
        if( numerovoluntario == 1){
        infobasic = vetorarquivo[1];
         Console.Write(infobasic);

       }else{
         infobasic = vetorarquivo[numerovoluntario+1];
          Console.Write(infobasic);
       }
       linha ++;
      }
    
    


    }

    
    //Parte cachorro .





  }
}