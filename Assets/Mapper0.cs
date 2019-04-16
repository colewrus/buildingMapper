using UnityEngine;

public class Mapper0 : MonoBehaviour
{

    public Texture2D map;
    public Color ignoreColor;
    public ColorBlock[] colorBlocks;

    // Start is called before the first frame update
    void Start()
    {
        Generate();
    }

    void Generate()
    {
      
        Debug.Log("begin " + map.name);
        for(int x=0; x < map.width; x++)
        {
            for(int y=0; y<map.height; y++)
            {
                ReadSource(x, y);
            }
        }
    }

    void ReadSource(int x, int y)
    {

        Color pixelColor = map.GetPixel(x, y);


        if(pixelColor.a == 0)
        {            
            return;
        }else if(pixelColor == ignoreColor)
        {
            return;
        }
       

        

        foreach(ColorBlock block in colorBlocks)
        {
            
            if (block.color.Equals(pixelColor))
            {
                float blockHeight = block.prefab.transform.localScale.y;
                Vector3 position = new Vector3(x, blockHeight/2, y);
               
                Instantiate(block.prefab, position, Quaternion.identity);
                
            }
        }

    }


}
