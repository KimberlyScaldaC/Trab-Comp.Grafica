using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manager : MonoBehaviour
{

    public GameObject tetrahedron; // prefab da camrera
    public GameObject[] vetGameObj = new GameObject[24];
    GameObject pai;
    Vector3 m_Center;
    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < 24; i++)
        {
            if (i == 0)
            {
                vetGameObj[i] = Instantiate(tetrahedron, new Vector3(0, 0, 0), Quaternion.identity); // tetraedro base
            }
            else
                vetGameObj[i] = Instantiate(tetrahedron, new Vector3(vetGameObj[i - 1].transform.position.x + 1, 0, 0), vetGameObj[i - 1].transform.rotation);
            //i-1 posicao anterior
        }

        //pegar tetra da posicao 3 e transladar
        vetGameObj[3].transform.position = new Vector3(0.5f, 0.86603f, 0.28868f);
        //vetGameObj[3].transform.Rotate(110f,0f,0); // 90f
        // vetGameObj[3].transform.RotateAround(transform.position, Vector3.forward, 5f);

        //Posicionar as piramides
        vetGameObj[4].transform.position = new Vector3(2f, 0f, 0f); //Magenta
        vetGameObj[5].transform.position = new Vector3(1.5f, 0.87f, 0.29f); //Magenta
        vetGameObj[6].transform.position = new Vector3(1f, 1.73f, 0.57f); //Magenta
        vetGameObj[7].transform.position = new Vector3(1.5f, 0f, 0.86f); //Amarelo
        vetGameObj[8].transform.position = new Vector3(1f, 0f, 1.73f); //Amarelo
        vetGameObj[9].transform.position = new Vector3(1f, 0.86f, 1.15f); //Amarelo
        vetGameObj[10].transform.position = new Vector3(0.5f, 0f, 0.86f); //Vermelho
        vetGameObj[11].transform.position = new Vector3(2.5f, 0f, 0.87f); //Baixo
        vetGameObj[12].transform.position = new Vector3(1.5f, 0f, 0.86f); //Baixo
        vetGameObj[13].transform.position = new Vector3(2f, 0f, 1.73f); //Baixo
        vetGameObj[14].transform.position = new Vector3(1.5f, 0.866f, 0.289f); //Magenta
        vetGameObj[15].transform.position = new Vector3(2.5f, 0.866f, 0.289f); //Magenta
        vetGameObj[16].transform.position = new Vector3(2f, 1.732f, 0.578f); //Magenta
        vetGameObj[17].transform.position = new Vector3(1.656f, 0.338f, 0.374f); //Amarelo
        vetGameObj[18].transform.position = new Vector3(0f, 0f, 0f); //Amarelo
        vetGameObj[19].transform.position = new Vector3(0f, 0f, 0f); //Amarelo
        vetGameObj[20].transform.position = new Vector3(0f, 0f, 0f); //Vermelho
        vetGameObj[21].transform.position = new Vector3(0f, 0f, 0f); //Vermelho
        vetGameObj[22].transform.position = new Vector3(0f, 0f, 0f); //Vermelho

        //ROTAÇOES
        vetGameObj[11].transform.rotation = Quaternion.Euler(0f, 180f, 0f); //Baixo
        vetGameObj[12].transform.rotation = Quaternion.Euler(0f, 180f, 0f); //Baixo
        vetGameObj[13].transform.rotation = Quaternion.Euler(0f, 180f, 0f); //Baixo
        vetGameObj[14].transform.rotation = Quaternion.Euler(37f, 0f, 180f); //Magenta
        vetGameObj[15].transform.rotation = Quaternion.Euler(37f, 0f, 180f); //Magenta
        vetGameObj[16].transform.rotation = Quaternion.Euler(37f, 0f, 180f); //Magenta
        vetGameObj[17].transform.rotation = Quaternion.Euler(197.823f, -54.92499f, -33.62201f); //Amarelo
        vetGameObj[18].transform.rotation = Quaternion.Euler(0f, 0f, 0f); //Amarelo
        vetGameObj[19].transform.rotation = Quaternion.Euler(0f, 0f, 0f); //Amarelo
        vetGameObj[20].transform.rotation = Quaternion.Euler(0f, 0f, 0f); //Vermelho
        vetGameObj[21].transform.rotation = Quaternion.Euler(0f, 0f, 0f); //Vermelho
        vetGameObj[22].transform.rotation = Quaternion.Euler(0f, 0f, 0f); //Vermelho







        pai = new GameObject();
        //pai.transform.position = new Vector3(0,1,0); //pivo
        pai.transform.position = new Vector3(0, 1, 0); //pivo
        vetGameObj[3].transform.parent = pai.transform;
        //vetGameObj[3].transform.bounds
    }


    // Update is called once per frame
    void Update()
    {
        //vetGameObj[3].transform.RotateAround(transform.position, Vector3.forward, 5f);
        //cria um gameobject: Pai. Tem eixo de rotacao
        //por o objeto como filho deste gameobject
        //rotaciona o gameObjet(pai): consequencia o filho rotaciona
        //Instantiate(Object original, Vector3 position, Quaternion rotation, Transform parent);
        //pai.transform.Rotate(Vector3.right * 5);


        //roda a piramide
        //vetGameObj[4].transform.Rotate((Vector3.right + Vector3.up) * 5);
    }
}
