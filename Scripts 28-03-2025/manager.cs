using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class manager : MonoBehaviour
{
    private Vector3 p0 = new Vector3(0, 0, 0);
    private Vector3 p1 = new Vector3(1, 0, 0);
    private Vector3 p2 = new Vector3(0.5f, 0, Mathf.Sqrt(0.75f));
    private Vector3 p3 = new Vector3(0.5f, Mathf.Sqrt(0.75f), Mathf.Sqrt(0.75f) / 3);

    public Vector3 eixoVertical, eixoHorizontal, eixoParalelo, eixoParalelo2;

    public GameObject tetrahedron; // prefab da camrera
    public GameObject[] vetGameObj = new GameObject[22];
    GameObject basePivot, basePivot2, basePivot3, basePivot4, basePivot5;
    Plane plano1, plano2, plano3;
    float CP1x, CP1y, CP1z, CP2x, CP2y, CP2z, CP3x, CP3y, CP3z;
   
   // double dx, dy, dz;
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

        vetGameObj[0].transform.position = new Vector3(0f, 0f, 0f);
        vetGameObj[1].transform.position = new Vector3(1f, 0f, 0f);
        vetGameObj[2].transform.position = new Vector3(0.5f, 0f, 0.866f);
        vetGameObj[3].transform.position = new Vector3(0.5f, 0.86603f, 0.28868f);
        vetGameObj[4].transform.position = new Vector3(2f, 0f, 0f);
        vetGameObj[5].transform.position = new Vector3(1.5f, 0.87f, 0.29f);
        vetGameObj[6].transform.position = new Vector3(1f, 1.7321f, 0.578f);
        vetGameObj[7].transform.position = new Vector3(1.5f, 0f, 0.86f);
        vetGameObj[8].transform.position = new Vector3(1f, 0f, 1.73f);
        vetGameObj[9].transform.position = new Vector3(1f, 0.86603f, 1.15f);
        vetGameObj[10].transform.position = new Vector3(0.5f, 0f, 0.86f);
        vetGameObj[11].transform.position = new Vector3(2.5f, 0f, 0.87f);
        vetGameObj[12].transform.position = new Vector3(1.5f, 0f, 0.86f);
        vetGameObj[13].transform.position = new Vector3(2f, 0f, 1.73f);
        vetGameObj[14].transform.position = new Vector3(1.5f, 0.866f, 0.289f);
        vetGameObj[15].transform.position = new Vector3(2.5f, 0.866f, 0.289f);
        vetGameObj[16].transform.position = new Vector3(2f, 1.732f, 0.578f);
        vetGameObj[17].transform.position = new Vector3(1.656f, 0.338f, 0.374f);
        vetGameObj[18].transform.position = new Vector3(1.154f, 0.33f, 1.23f);
        vetGameObj[19].transform.position = new Vector3(1.152f, 1.199f, 0.658f);
        vetGameObj[20].transform.position = new Vector3(1.507945f, 0.8542254f, 2.008367f);
        vetGameObj[21].transform.position = new Vector3(1.019f, 0.853f, 1.159f);
        vetGameObj[22].transform.position = new Vector3(1.513f, 1.725f, 1.432f);


        // ROTAÇOES (mantido)
        vetGameObj[11].transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        vetGameObj[12].transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        vetGameObj[13].transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        vetGameObj[14].transform.rotation = Quaternion.Euler(37f, 0f, 180f);
        vetGameObj[15].transform.rotation = Quaternion.Euler(37f, 0f, 180f);
        vetGameObj[16].transform.rotation = Quaternion.Euler(37f, 0f, 180f);
        vetGameObj[17].transform.rotation = Quaternion.Euler(-162.24f, -54.88599f, -33.29901f);
        vetGameObj[18].transform.rotation = Quaternion.Euler(-162.24f, -54.88599f, -33.29901f);
        vetGameObj[19].transform.rotation = Quaternion.Euler(-162.24f, -54.88599f, -33.29901f);
        vetGameObj[20].transform.rotation = Quaternion.Euler(-162.086f, 55.098f, 34.017f);
        vetGameObj[21].transform.rotation = Quaternion.Euler(-162.086f, 55.098f, 34.017f);
        vetGameObj[22].transform.rotation = Quaternion.Euler(-162.086f, 55.098f, 34.017f);



        CP1x = (0f + 3f + 1.5f) / 3f;
         CP1y = (0.432f + 0.432f + 0.432f) / 3f;
         CP1z = (0f + 0f + 2.595f) / 3f;

         CP2x = (0.5f + 2.5f + 1.5f) / 3;
         CP2y = (1.296f + 1.296f + 1.296f) / 3;
         CP2z = (0.29f + 0.29f + 2.014f) / 3;
        
        //centro do tetraedro DE PLANO 3
        CP3x = (1f + 2f + 1.5f) / 3;
        CP3y = (2.163f + 2.163f + 2.163f) / 3;
        CP3z = (0.578f + 0.578f + 1.442f) / 3;


        Vector3 centroBase = new Vector3(CP1x, CP1y, CP1z);
        Vector3 centroBase2 = new Vector3(CP2x,CP2y, CP2z);
        Vector3 centroBase3 = new Vector3(CP3x, CP3y, CP3z);
        float Cx = (p0.x + p1.x + p2.x + p3.x) / 4;
        float Cy = (p0.y + p1.y + p2.y + p3.y) / 4;
        float Cz = (p0.z + p1.z + p2.z + p3.z) / 4;
        Vector3 temp = new Vector3(Cx, Cy, Cz);
        Vector3 temp1 = new Vector3(Cx, Cy, Cz);
        Vector3 temp2 = new Vector3(Cx, Cy, Cz);
        Vector3 temp3 = new Vector3(Cx, Cy, Cz); 
        
        temp -= p3;
        temp1 -= p0;
        temp2-= p2;
        temp3 -= p1;
        eixoHorizontal = temp.normalized;
        eixoVertical = temp1.normalized;
        eixoParalelo = temp2.normalized;
        eixoParalelo2 = temp3.normalized;
        // Passo 3: Criar um GameObject no centro da base
        basePivot = new GameObject("BasePivot");
        basePivot.transform.position = centroBase;
       
        basePivot2 = new GameObject("BasePivot2");
        basePivot2.transform.position = centroBase2;

        basePivot3 = new GameObject("BasePivot3");
        basePivot3.transform.position = centroBase3;
            
        basePivot4 = new GameObject("BasePivot4");
        Vector3 centroFaceL = new Vector3(1.25f, 0.866f, 1.15f); // ajuste fino se necessário
        basePivot4.transform.position = centroFaceL;

        basePivot4.transform.position = centroFaceL;
        basePivot5 = new GameObject("BasePivot5");
        Vector3 centroFaceR = new Vector3(1.75f, 0.866f, 0.57f); // ajuste conforme a face
        basePivot5.transform.position = centroFaceR;

       
        List<GameObject> tetrasNaBase = new List<GameObject>();
        List<GameObject> tetrasNaBase2 = new List<GameObject>();
        List<GameObject> tetrasNaBase3 = new List<GameObject>();

        for (int i = 0; i < vetGameObj.Length; i++)
        {
        float y = vetGameObj[i].transform.position.y;
       

            // Tolerância pequena para evitar problemas de precisão
           
                if(Mathf.Abs(y) <= 0.866f)
                {
                    tetrasNaBase.Add(vetGameObj[i]);
                }
                //Debug.Log("Tetra na base (Y=0): " + vetGameObj[i].name);
            
        }
        for (int i = 0; i < tetrasNaBase.Count; i++)
        {
            GameObject tetra = tetrasNaBase[i];

            tetra.transform.SetParent(basePivot.transform);

            // Muda cor para vermelho
           // tetra.GetComponent<Renderer>().material.color = Color.red;
        }
        for (int i = 0; i < vetGameObj.Length; i++)
        {
            float y2 = vetGameObj[i].transform.position.y;

            // Tolerância pequena para evitar problemas de precisão
            if (y2>= 0.86603f && y2 <= 1.7320f)
            {
                tetrasNaBase2.Add(vetGameObj[i]);
                
                //Debug.Log("Tetra na base (Y=0): " + vetGameObj[i].name);
            }
        }
        for (int i = 0; i < tetrasNaBase2.Count; i++)
        {
            GameObject tetra = tetrasNaBase2[i];
            tetra.transform.SetParent(basePivot2.transform);

            // Muda cor para vermelho
            // tetra.GetComponent<Renderer>().material.color = Color.red;
        }

       
       vetGameObj[6].transform.SetParent(basePivot3.transform); //pivo
        //vetGameObj[3].transform.parent = pai.transform;
        //vetGameObj[3].transform.bounds

        /*centro do tetraedro DE PLANO 1 ENCONTRA O CENTRO DA BASE
        CP1x = (0 + 3 + 1.5) / 3;
        CP1y = (0.432 + 0.432 + 0.432) / 3;
        CP1z = (0 + 0 + 2.595) / 3;

        dx = 1.5;
        dy = 2.595;
        dz = 0.864;
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
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            basePivot.transform.Rotate(eixoHorizontal, 120f, Space.World);
            //basePivot.transform.Rotate(Vector3.up * 120);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            //basePivot2.transform.Rotate(Vector3.up * 120);
            basePivot2.transform.Rotate(eixoHorizontal, 120f, Space.World);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            basePivot3.transform.Rotate(eixoHorizontal, 120f, Space.World);
        }
        

    }
}
