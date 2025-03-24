public class PyraminxRotation : MonoBehaviour
    {
        public Transform verticeSuperior;
        public Transform verticeA, verticeB, verticeC;
        public Transform tetraedro1, tetraedro2, tetraedro3;

        void Start()
        {
            // Passo 1: Determinar o eixo vertical
            Vector3 eixoVertical = (verticeSuperior.position - ((verticeA.position + verticeB.position + verticeC.position) / 3f)).normalized;

            // Passo 2: Determinar o centro da base
            Vector3 centroBase = (verticeA.position + verticeB.position + verticeC.position) / 3f;

            // Passo 3: Criar um GameObject no centro da base
            GameObject basePivot = new GameObject("BasePivot");
            basePivot.transform.position = centroBase;

            // Passo 4: Definir os tetraedros da base como filhos do basePivot
            tetraedro1.SetParent(basePivot.transform);
            tetraedro2.SetParent(basePivot.transform);
            tetraedro3.SetParent(basePivot.transform);

            // Passo 5: Rotacionar a base em 120 graus
            basePivot.transform.Rotate(eixoVertical, 120f, Space.World);
        }
    }
