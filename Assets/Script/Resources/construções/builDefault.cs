using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = " new build", menuName = "Resources/new build", order = 1)]
public class builDefault : ScriptableObject
{
    [Header("--Informações Gerais sobre os objetos--")]
    public Sprite Image;
    public GameObject prefabBuild;
    public float tempo;
    public string teste = "testando0";

    [Header("--Recursos necessários para construção--")]
    public int MadeiraGastoC;
    public int PedraGastoC;
    public int ManaGastoC;
    public int PessoaGastoC;
    public bool EstaConstruindo;
    public bool Posicionado;

    [Header("--Recursos gerados ao longo do tempo--")]
    public int Madeira;
    public int Pedra;
    public int mana;
    public int Pessoas;
    public int marvita;
    public int vegetal;
    public int animal;
    public bool PodeGerar;

    [Header("--Recursos gastos ao longo do tempo--")]
    public int MadeiraGasta;
    public int PedraGasta;
    public int ManaGasto;
    public int PessoasGastas;
    public int marvitaGastas;
    public int vegetalGastos;
    public int animalGastos;


}
