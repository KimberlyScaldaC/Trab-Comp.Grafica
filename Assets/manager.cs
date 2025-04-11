using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manager : MonoBehaviour
{

    public GameObject tetrahedron; // prefab da camrera
    public GameObject[] vetGameObj = new GameObject[24];
    //GameObject pai;
    GameObject vetorRotPlano1;
    GameObject basePivot; 
    GameObject vetorRotPlano2;
    GameObject vetorRotPlano3;
    Vector3 m_Center;
    double CP1x, CP1y, CP1z;
    double CP2x, CP2y, CP2z;
    double CP3x, CP3y, CP3z;
    double dx, dy, dz;
    // Use this for initialization
    void Start()
    {
        GameObject plano = GameObject.CreatePrimitive(PrimitiveType.Plane);
        plano.transform.position = new Vector3(0, 0.432f, 2);
        plano.transform.rotation = Quaternion.Euler(0, 0, 0);

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
        //vetGameObj[0].transform.position = new Vector3(0f, 0f, 0f); //Magenta BAIXO DIREITO
        //vetGameObj[1].transform.position = new Vector3(1f, 0f, 0f); //Magenta BAIXO MEIO
        vetGameObj[4].transform.position = new Vector3(2f, 0f, 0f); //Magenta BAIXO ESQUERDO
        //vetGameObj[2].transform.position = new Vector3(0.5f, -0.13397f, 0.28868f); //Magenta MEIO ESQUERDO
        vetGameObj[5].transform.position = new Vector3(1.5f, 0.87f, 0.29f); //Magenta MEIO DIREITO
        vetGameObj[6].transform.position = new Vector3(1f, 1.732f, 0.578f); //Magenta CIMA
        vetGameObj[7].transform.position = new Vector3(1.5f, 0f, 0.86f); //Amarelo BAIXO MEIO
        vetGameObj[8].transform.position = new Vector3(1f, 0f, 1.73f); //Amarelo BAIXO ESQUEDO
        vetGameObj[9].transform.position = new Vector3(1f, 0.86f, 1.15f); //Amarelo MEIO ESQUERDO
        vetGameObj[10].transform.position = new Vector3(0.5f, 0f, 0.86f); //Vermelho BAIXO MEIO
        vetGameObj[11].transform.position = new Vector3(2.5f, 0f, 0.87f); //Baixo
        vetGameObj[12].transform.position = new Vector3(1.5f, 0f, 0.86f); //Baixo
        vetGameObj[13].transform.position = new Vector3(2f, 0f, 1.73f); //Baixo
        vetGameObj[14].transform.position = new Vector3(1.5f, 0.866f, 0.289f); //Magenta Inverso Direito
        vetGameObj[15].transform.position = new Vector3(2.5f, 0.866f, 0.289f); //Magenta Inverso Esquerdo
        vetGameObj[16].transform.position = new Vector3(2f, 1.732f, 0.578f); //Magenta Inverso Cima
        vetGameObj[17].transform.position = new Vector3(1.656f, 0.338f, 0.374f); //Amarelo Inverso Direito
        vetGameObj[18].transform.position = new Vector3(1.154f, 0.33f, 1.23f); //Amarelo Inverso Esquerdo
        vetGameObj[19].transform.position = new Vector3(1.152f, 1.199f, 0.658f); //Amarelo Inverso Cima
        vetGameObj[20].transform.position = new Vector3(1.507945f, 0.8542254f, 2.008367f); //Vermelho Inverso Direito
        vetGameObj[21].transform.position = new Vector3(1.019f, 0.853f, 1.159f); //Vermelho Inverso Esquerdo
        vetGameObj[22].transform.position = new Vector3(1.513f, 1.725f, 1.432f); //Vermelho Inverso Cima

        //ROTAÇOES
        vetGameObj[11].transform.rotation = Quaternion.Euler(0f, 180f, 0f); //Baixo
        vetGameObj[12].transform.rotation = Quaternion.Euler(0f, 180f, 0f); //Baixo
        vetGameObj[13].transform.rotation = Quaternion.Euler(0f, 180f, 0f); //Baixo
        vetGameObj[14].transform.rotation = Quaternion.Euler(37f, 0f, 180f); //Magenta
        vetGameObj[15].transform.rotation = Quaternion.Euler(37f, 0f, 180f); //Magenta
        vetGameObj[16].transform.rotation = Quaternion.Euler(37f, 0f, 180f); //Magenta
        vetGameObj[17].transform.rotation = Quaternion.Euler(-162.24f, -54.88599f, -33.29901f); //Amarelo
        vetGameObj[18].transform.rotation = Quaternion.Euler(-162.24f, -54.88599f, -33.29901f); //Amarelo
        vetGameObj[19].transform.rotation = Quaternion.Euler(-162.24f, -54.88599f, -33.29901f); //Amarelo
        vetGameObj[20].transform.rotation = Quaternion.Euler(-162.086f, 55.098f, 34.017f); //Vermelho
        vetGameObj[21].transform.rotation = Quaternion.Euler(-162.086f, 55.098f, 34.017f); //Vermelho
        vetGameObj[22].transform.rotation = Quaternion.Euler(-162.086f, 55.098f, 34.017f); //Vermelho


        float CP1x = (0f + 3f + 1.5f) / 3f;
        float CP1y = (0.432f + 0.432f + 0.432f) / 3f;
        float CP1z = (0f + 0f + 2.595f) / 3f;

        Vector3 centroBase = new Vector3(CP1x, CP1y, CP1z);

        // Passo 3: Criar um GameObject no centro da base
        basePivot = new GameObject("BasePivot");
        basePivot.transform.position = centroBase;




        // METADE DO TAMANHO DE UM TETRAEDRO = 0.432

        // pai = new GameObject();
        //pai.transform.position = new Vector3(0,1,0); //pivo
        // pai.transform.position = new Vector3(0, 1, 0); //pivo
        //vetGameObj[3].transform.parent = pai.transform;
        //vetGameObj[3].transform.bounds

        /*centro do tetraedro DE PLANO 1 ENCONTRA O CENTRO DA BASE
        CP1x = (0 + 3 + 1.5) / 3;
        CP1y = (0.432 + 0.432 + 0.432) / 3;
        CP1z = (0 + 0 + 2.595) / 3;

        //centro do tetraedro DE PLANO 2
        CP2x = (0.5 + 2.5 + 1.5) / 3;
        CP2y = (1.296 + 1.296 + 1.296) / 3;
        CP2z = (0.29 + 0.29 + 2.014) / 3;

        //centro do tetraedro DE PLANO 3
        CP3x = (1 + 2 + 1.5) / 3;
        CP3y = (2.163 + 2.163 + 2.163) / 3;
        CP3z = (0.578 + 0.578 + 1.442) / 3;


        dx = 1.5;
        dy = 2.595;
        dz = 0.864;
        /*VETOR DA ROTACAO DO PLANO 1
        vetorRotPlano1 = new GameObject();
        GameObject vetorRotPlano1 = new GameObject(x, y, z);
        vetorRotPlano1.transform.position = (CP1x - dx; CP1y - dy; CP1z - dz);

        vetorRotPlano2 = new GameObject();
        GameObject vetorRotPlano2 = new GameObject(CP2x - dx, CP2y - dy, CP2z - dz);

        vetorRotPlano3 = new GameObject();
        GameObject vetorRotPlano3 = new GameObject(CP3x - dx, CP3y - dy, CP3z - dz);*/
        /*




        //centro do tetraedro DE PLANO DIAGONAL AMARELA 1
        //CP3x = () / 3;
        //CP3y = () / 3;
        //CP3z = () / 3;
        */




        //centro do tetraedro

        //Cx = (Ax + Bx + Cx + Dx) / 4
        //Cx = (0+2+1+1)/4;
        //Cy = (Ay + By + Cy + Dy) / 4
        //Cy = (0 + 0 + 0 + 1.73)/4;
        //Cz = (Az + Bz + Cz + Dz) / 4
        //Cz = (0 + 0 + 1.73 + 0.578) / 4;
    }
    void onTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody != null) 
        {
            other.transform.SetParent(basePivot.transform);
        }
        
    }


    // Update is called once per frame
    void Update()
    {
        basePivot.transform.Rotate(Vector3.up * 20 * Time.deltaTime);

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
/*using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;


public class PyraminxRotation : MonoBehaviour
{
    //public Transform verticeSuperior;
    //public Transform verticeA, verticeB, verticeC;
   
    public List<GameObject> objetosParaTestar;
    public Vector3 normalDoPlano = Vector3.up;
    
    float CP1x, CP1y, CP1z;
   

    void Start()
    {
        // Passo 1: Determinar o eixo vertical
        Vector3 p0 = new Vector3(0, 0, 0);
        Vector3 p1 = new Vector3(1, 0, 0);
        Vector3 p2 = new Vector3(0.5f, 0, Mathf.Sqrt(0.75f));
        Vector3 p3 = new Vector3(0.5f, Mathf.Sqrt(0.75f), Mathf.Sqrt(0.75f) / 3);


       // Cx = (0 + 1 + 0.5f + 0.5f) / 4
        //Cy = ( p1.y+ p2.y + p3.y + p0.y) / 4
        //Cz = (Az + Bz + Cz + ) / 4

        //Vector3 eixoVertical = (verticeSuperior.position - ((verticeA.position + verticeB.position + verticeC.position) / 3f)).normalized;




        // Passo 2: Determinar o centro da base



        // Passo 4: Definir os tetraedros da base como filhos do basePivot

        // Cria um �nico plano
        Plane plano = new Plane(normalDoPlano, centroBase);
        // Converte para o formato esperado pela API (array de planos)
        Plane[] planoUnico = new Plane[] { plano };

        List<GameObject> objetosIntersectados = new List<GameObject>();

        foreach (GameObject obj in objetosParaTestar)
        {
            Renderer rend = obj.GetComponent<Renderer>();
            if (rend == null) continue;

            Bounds bounds = rend.bounds;

            // Testa se a bounding box do objeto intersecta o plano
            if (GeometryUtility.TestPlanesAABB(planoUnico, bounds))
            {
                objetosIntersectados.Add(obj);
            }
        }

        // Debug do resultado
        foreach (var obj in objetosIntersectados)
        {
           // Debug.Log($"Objeto intersectado pelo plano: {obj.name}");
        }


       // tetraedro1.SetParent(basePivot.transform);

        //tetraedro2.SetParent(basePivot.transform);
        //tetraedro3.SetParent(basePivot.transform);

        // Passo 5: Rotacionar a base em 120 graus
       // basePivot.transform.Rotate(eixoVertical, 120f, Space.World);
    }

}*/