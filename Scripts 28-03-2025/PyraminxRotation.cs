using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyraminxRotation : MonoBehaviour
{
    public Transform verticeSuperior;
    public Transform verticeA, verticeB, verticeC;
    public Transform tetraedro1, tetraedro2, tetraedro3;
    public List<GameObject> objetosParaTestar;
    public Vector3 normalDoPlano = Vector3.up;
    
    float CP1x, CP1y, CP1z;


    void Start()
    {
        // Passo 1: Determinar o eixo vertical
        Vector3 p0 = (0, 0, 0);
        Vector3 p1 = new Vector3(1, 0, 0);
        Vector3 p2 = new Vector3(0.5f, 0, Mathf.Sqrt(0.75f));
        Vector3 p3 = new Vector3(0.5f, Mathf.Sqrt(0.75f), Mathf.Sqrt(0.75f) / 3);

        Vector3 eixoVertical = (verticeSuperior.position - ((verticeA.position + verticeB.position + verticeC.position) / 3f)).normalized;




        // Passo 2: Determinar o centro da base

         CP1x = (0 + 3 + 1.5f) / 3;
         CP1y = (0.432f + 0.432f + 0.432f) / 3;
         CP1z = (0 + 0 + 2.595f) / 3;

        Vector3 centroBase = new Vector3(CP1x, CP1y, CP1z);
        
        // Passo 3: Criar um GameObject no centro da base
        GameObject basePivot = new GameObject("BasePivot");
        basePivot.transform.position = centroBase;

        // Passo 4: Definir os tetraedros da base como filhos do basePivot
        
        // Cria um único plano
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
            Debug.Log($"Objeto intersectado pelo plano: {obj.name}");
        }


        tetraedro1.SetParent(basePivot.transform);

        tetraedro2.SetParent(basePivot.transform);
        tetraedro3.SetParent(basePivot.transform);

        // Passo 5: Rotacionar a base em 120 graus
        basePivot.transform.Rotate(eixoVertical, 120f, Space.World);
    }
}