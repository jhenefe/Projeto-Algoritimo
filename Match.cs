using System.ComponentModel;
using System;
using System.IO;
using System.Text;
class Match{ 
  private Voluntario voluntario;
  private Cachorro cachorro;
  private Cachorro[] vetorCachorro = new Cachorro[1000];
   
  public Match (Voluntario voluntarioComparar, Cachorro[] cachorrocomparar){    
    voluntario = voluntarioComparar;
    vetorCachorro = cachorrocomparar;

  } 
  public Match (Voluntario voluntario, Cachorro cachorroEscolhido){    
    voluntario = voluntario;
    cachorro = cachorroEscolhido;
  }  
  public  Cachorro  getCachorro(){
   return cachorro;
  }

  public  Voluntario  getVoluntario(){
   return voluntario;
  }

  public  Cachorro[] getVetorCachorro(){
   return vetorCachorro;
  }
 
  
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
}