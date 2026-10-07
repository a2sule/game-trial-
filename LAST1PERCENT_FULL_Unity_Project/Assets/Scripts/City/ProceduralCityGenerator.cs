using UnityEngine;

public class ProceduralCityGenerator : MonoBehaviour
{
    public int blocksX=8;
    public int blocksZ=8;
    public float blockSize=28f;
    public float roadWidth=8f;
    public int seed=17;

    public Material roadMaterial;
    public Material buildingMaterial;

    [ContextMenu("Generate City")]
    public void Generate()
    {
        Random.InitState(seed);
        Clear();

        for(int x=-blocksX;x<=blocksX;x++)
        for(int z=-blocksZ;z<=blocksZ;z++)
        {
            if(Mathf.Abs(x)%1==0 && Mathf.Abs(z)%1==0)
            {
                Vector3 pos=new Vector3(x*blockSize,0,z*blockSize);
                CreateBuildingCluster(pos,x,z);
            }
        }

        CreateRoads();
    }

    private void CreateBuildingCluster(Vector3 center,int x,int z)
    {
        int count=Random.Range(2,6);
        for(int i=0;i<count;i++)
        {
            Vector3 offset=new Vector3(Random.Range(-8f,8f),0,Random.Range(-8f,8f));
            GameObject b=GameObject.CreatePrimitive(PrimitiveType.Cube);
            b.name="Building";
            b.transform.position=center+offset+Vector3.up*Random.Range(4f,12f);
            b.transform.localScale=new Vector3(Random.Range(5f,10f),Random.Range(8f,24f),Random.Range(5f,10f));
            if(buildingMaterial)b.GetComponent<Renderer>().sharedMaterial=buildingMaterial;
            b.transform.SetParent(transform);
        }
    }

    private void CreateRoads()
    {
        for(int x=-blocksX;x<=blocksX;x++)
        {
            GameObject r=GameObject.CreatePrimitive(PrimitiveType.Cube);
            r.name="Road_X";
            r.transform.position=new Vector3(x*blockSize,-.1f,0);
            r.transform.localScale=new Vector3(roadWidth,.2f,(blocksZ*2+2)*blockSize);
            if(roadMaterial)r.GetComponent<Renderer>().sharedMaterial=roadMaterial;
            r.transform.SetParent(transform);
        }
        for(int z=-blocksZ;z<=blocksZ;z++)
        {
            GameObject r=GameObject.CreatePrimitive(PrimitiveType.Cube);
            r.name="Road_Z";
            r.transform.position=new Vector3(0,-.1f,z*blockSize);
            r.transform.localScale=new Vector3((blocksX*2+2)*blockSize,.2f,roadWidth);
            if(roadMaterial)r.GetComponent<Renderer>().sharedMaterial=roadMaterial;
            r.transform.SetParent(transform);
        }
    }

    private void Clear()
    {
        for(int i=transform.childCount-1;i>=0;i--)DestroyImmediate(transform.GetChild(i).gameObject);
    }
}
