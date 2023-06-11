using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    private int index = 0;

    public GameObject Quadro;
    public EventSO eventSO;
    public TextMeshProUGUI TextoNomeOrador;
    public TextMeshProUGUI TextoEvento;
    public TextMeshProUGUI bt1Texto;
    public TextMeshProUGUI bt2Texto;
    public TextMeshProUGUI bt1Descrição;
    public TextMeshProUGUI bt2Descrição;
    public GameObject Bt1Descriaçãopanel;
    public GameObject Bt2Descriaçãopanel;
    public Image ImagemOrador;
    public Image ImagemDeCorpo;
    public Button BotaoEscolha1;
    public Button BotaoEscolha2;
    public Button BotaoContinuar;
    public Button BotaoFechar;
    private eventos eventoAnterior;


    private int diaaleatorio;
    private int mesaleatorio;
    private int anoaleatorio;

    public int AnoMinimoAleatorio =1221;
    public int AnoMaximoAleatorio = 1900;

    private void Awake()
    {
        foreach (var evento in eventSO.Eventos)
        {
            if (evento.Aleatorio)
            {
                diaaleatorio = Random.Range(1, 29);
                mesaleatorio = Random.Range(1, 13);
                anoaleatorio = Random.Range(AnoMinimoAleatorio, AnoMaximoAleatorio);
                print(diaaleatorio + "/" + mesaleatorio + "/" + anoaleatorio);
                evento.dia = diaaleatorio;
                evento.mes = mesaleatorio;
                evento.ano = anoaleatorio;
               
            }
        }
    }
    void Start()
    {
        BotaoContinuar.onClick.AddListener(ProximaMensagem);
    }

    void Update()
    {
        evento();
        eventoRepete();
    }
    void evento()
    {
        
        eventos eventoAtual = eventSO.Eventos.Find(e => e.dia == Calendar.date.day && e.mes == Calendar.date.month && e.ano == Calendar.date.year && e.Repete == false);
        
        if (eventoAtual != null)
        {
            
            if (eventoAtual != eventoAnterior)
            {
                index = 0;
                eventoAnterior = eventoAtual;
            }
            if (index > eventoAtual.TextoDeCorpo.Length || index >= eventoAtual.nome.Length)
            {
               
                return;
            }

            if (index == 0)
            {
                BotaoFechar.gameObject.SetActive(false);
            }
            
            
           
            Pause.pause.Paused();
            Quadro.SetActive(true);
            if (eventoAtual.ImagemCentral != null && index < eventoAtual.ImagemCentral.Length)
            {
                ImagemOrador.sprite = eventoAtual.ImagemCentral[index];
            }
            if (eventoAtual.ImagemDeCorpo != null && index < eventoAtual.ImagemDeCorpo.Length)
            {
                ImagemDeCorpo.sprite = eventoAtual.ImagemDeCorpo[index];
            }
            if (eventoAtual.EfeitoBotao1 != null && eventoAtual.EfeitoBotao2 != null)
            {
                bt1Texto.text = eventoAtual.TextoEscolha1;
                bt2Texto.text = eventoAtual.TextoEscolha2;
                bt1Descrição.text = eventoAtual.DescriçãoEscolha1;
                bt2Descrição.text = eventoAtual.DescriçãoEscolha2;
            }


            TextoNomeOrador.text = eventoAtual.nome[index];
            TextoEvento.text = eventoAtual.TextoDeCorpo[index];


            if (!eventoAtual.BotaoContinuar)
            {
                BotaoEscolha1.gameObject.SetActive(true);
                BotaoEscolha2.gameObject.SetActive(true);
                BotaoContinuar.gameObject.SetActive(false);
                BotaoFechar.gameObject.SetActive(false);

            }
            else
            {
                BotaoEscolha1.gameObject.SetActive(false);
                BotaoEscolha2.gameObject.SetActive(false);
                BotaoContinuar.gameObject.SetActive(true);
                
                Bt1Descriaçãopanel.SetActive(false);
                Bt2Descriaçãopanel.SetActive(false);
            }


        }
    }
    void eventoRepete()
    {
        
        eventos eventoAtual = eventSO.Eventos.Find(e => e.dia == Calendar.date.day && e.mes == Calendar.date.month && e.Repete == true);

        if (eventoAtual != null)
        {
            
            if (eventoAtual != eventoAnterior)
            {
                index = 0;
                eventoAnterior = eventoAtual;
            }
            if (index > eventoAtual.TextoDeCorpo.Length || index >= eventoAtual.nome.Length)
            {
                
                return;
            }
            if (index == 0)
            {
                BotaoFechar.gameObject.SetActive(false);
            }
            Pause.pause.Paused();
            Quadro.SetActive(true);
            if (eventoAtual.ImagemCentral != null && index < eventoAtual.ImagemCentral.Length)
            {
                ImagemOrador.sprite = eventoAtual.ImagemCentral[index];
            }
            if (eventoAtual.ImagemDeCorpo != null && index < eventoAtual.ImagemDeCorpo.Length)
            {
                ImagemDeCorpo.sprite = eventoAtual.ImagemDeCorpo[index];
            }
            if (eventoAtual.EfeitoBotao1 != null && eventoAtual.EfeitoBotao2 != null)
            {
                bt1Texto.text = eventoAtual.TextoEscolha1;
                bt2Texto.text = eventoAtual.TextoEscolha2;
                bt1Descrição.text = eventoAtual.DescriçãoEscolha1;
                bt2Descrição.text = eventoAtual.DescriçãoEscolha2;
            }


            TextoNomeOrador.text = eventoAtual.nome[index];
            TextoEvento.text = eventoAtual.TextoDeCorpo[index];


            if (!eventoAtual.BotaoContinuar)
            {
                BotaoEscolha1.gameObject.SetActive(true);
                BotaoEscolha2.gameObject.SetActive(true);
                BotaoContinuar.gameObject.SetActive(false);
                BotaoFechar.gameObject.SetActive(false);

            }
            else
            {
                BotaoEscolha1.gameObject.SetActive(false);
                BotaoEscolha2.gameObject.SetActive(false);
                BotaoContinuar.gameObject.SetActive(true);
                
                Bt1Descriaçãopanel.SetActive(false);
                Bt2Descriaçãopanel.SetActive(false);
            }


        }
    }
    void deastivaumavez()
    {
        Bt1Descriaçãopanel.SetActive(false);
        Bt2Descriaçãopanel.SetActive(false);
    }
    void ProximaMensagem()
    {
        eventos eventoAtual = eventSO.Eventos.Find(e => e.dia == Calendar.date.day && e.mes == Calendar.date.month && e.ano == Calendar.date.year);

        if (eventoAtual != null)
        {
           
            index++;
            
        }
        if(index >= eventoAtual.TextoDeCorpo.Length - 1)
        {
            print("entra");
            BotaoFechar.gameObject.SetActive(true);
        }
        else
        {
            BotaoFechar.gameObject.SetActive(false);
        }
        print(index + " " + (eventoAtual.TextoDeCorpo.Length - 1));
        
    }

    public void Fechar()
    {
        deastivaumavez();
        eventos eventoAtual = eventSO.Eventos.Find(e => e.dia == Calendar.date.day && e.mes == Calendar.date.month && e.ano == Calendar.date.year);
        Pause.pause.UnPaused();
        Quadro.SetActive(false);
    

    }
    public void Fechar2()
    {
        deastivaumavez();
        eventos eventoAtual = eventSO.Eventos.Find(e => e.dia == Calendar.date.day && e.mes == Calendar.date.month && e.ano == Calendar.date.year);
 
        Pause.pause.UnPaused();
        Quadro.SetActive(false);
        SendMessage("Efeito", eventoAtual.EfeitoBotao1);
        
    }
    public void Fechar3()
    {
        deastivaumavez();
        eventos eventoAtual = eventSO.Eventos.Find(e => e.dia == Calendar.date.day && e.mes == Calendar.date.month && e.ano == Calendar.date.year);

        Pause.pause.UnPaused();
        Quadro.SetActive(false);
        SendMessage("Efeito", eventoAtual.EfeitoBotao2);
        
    }

}
