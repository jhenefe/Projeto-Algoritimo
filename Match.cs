class Match{
  
  private Voluntario[] vetorVoluntario = new Voluntario[1000];
  private Cachorro[] vetorCachorro = new Cachorro[1000];



  public Match (Voluntario[] voluntariocomparar, Cachorro[] cachorrocomparar ){    
    vetorVoluntario = voluntariocomparar;
    vetorCachorro = cachorrocomparar;
   
      
  }  

  public static  string [] compatibilidade (int numeroVoluntario,Voluntario voluntario ,Cachorro[] vetorCachorro ){
    int identificaVoluntario= numeroVoluntario;
    Voluntario voluntaSelecionado=voluntario;
    Cachorro[] vetorC = vetorCachorro;
    string [] voluntarioCompCachorro =new string[1000];
    int c=0;
    Voluntario objetoV =voluntaSelecionado;
    string diaV = objetoV.getDia();
    string turnoV = objetoV.getTurno();
    string bairroV = objetoV.getBairro();
    for(int i = 0; i<1000; i++){
      Cachorro objetoC = vetorC[i];
      string diaC = objetoC.getDiaCachorro();
      string turnoC = objetoC.getTurnoCachorro();
      string bairroC = objetoC.getBairroCachorro();
      
      if(bairroV ==bairroC){
        if(diaV ==diaC){
          if(turnoV == turnoC){
            voluntarioCompCachorro[c]=(i+"/"+identificaVoluntario);
            c++;
          }
        }
      }
  
    } 
    return voluntarioCompCachorro;
  }
  

}