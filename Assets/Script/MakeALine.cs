using UnityEngine;
using System.Collections;

public class MakeALine : MonoBehaviour
{

	public Transform m_Transform;
	public float m_Length=0.1f; // 线的长度
	public Color m_Color = Color.blue; // 线框颜色

    public static float length=0.1f;

	public Vector3 beginPoint;
	public Vector3 endPoint;
	
    /*public void setLength(float i)
    {
        m_Length = i;
    }*/


	void Start()
	{
        print(m_Length);

	}
	
    void Update()
    {

        m_Length=length;

    }
	
	void OnDrawGizmos()
	{
		// 设置矩阵
		Matrix4x4 defaultMatrix = Gizmos.matrix;

		Gizmos.matrix = m_Transform.localToWorldMatrix;

        Gizmos.color = m_Color;

        //print(m_Transform.position.x);
        //System.Console.WriteLine("{0},{1},{2}",m_Transform.position.x,m_Transform.position.y,m_Transform.position.z);
        print(m_Length);

        Gizmos.DrawLine(m_Transform.position,new Vector3(m_Transform.position.x,m_Transform.position.y,m_Transform.position.z+0.1f));

		// 恢変默认矩阽
		Gizmos.matrix = defaultMatrix;

        //print("Line has been built!");
	}


    public void Length_switch(int caseSwitch)
    {
        switch (caseSwitch)
        {
            case 0:
                m_Length = 0.10f;
                break;
            case 1:
                m_Length = 0.20f;
                break;
            case 2:
                m_Length = 0.30f;
                break;

        }

        print("Line size was chaneged!");
    }

    void OnTriggerStay(Collider e)
    {
        if (Main.destoryFlag2==true)
        {
            Destroy(gameObject);
            Main.destoryFlag2 = false;
            Length_switch(Main.lineFlag);
        }
    }

    void OnTriggerExit(Collider e)
    {

    }
}