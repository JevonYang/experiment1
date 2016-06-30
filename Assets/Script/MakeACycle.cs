using UnityEngine;
using System.Collections;

public class MakeACycle : MonoBehaviour {

	public Transform m_Transform;
	public float m_Radius = 0.005f; // 圆环的半径
	public float m_Theta = 0.1f; // 值越低圆环越平滑
	public Color m_Color = Color.green; // 线框颜色

	public Transform Line;

    public static float radius;

    private bool startFlag;
    
    public void setRadius(float radius)
    {
        m_Radius = radius;
    }

	void Start()
	{

        //m_Radius = 0.05f;

	}

	void Update()
	{

        radius = m_Radius;
        
		if((Line.position.x-m_Transform.position.x)*(Line.position.x-m_Transform.position.x)+(Line.position.y-m_Transform.position.y)*(Line.position.y-m_Transform.position.y)>0.005f*0.005f)
		{
			m_Color=Color.red;
		}
		else 
		{
			m_Color=Color.green;
		}
        
        if (((m_Transform.position.x + m_Radius) > Line.position.x) && ((m_Transform.position.x + m_Radius) > Line.position.y) && (m_Transform.position.z == 0.1f))
        {
            Main.spanTime1 = System.DateTime.Now;
            startFlag = true;

            print(Main.spanTime1);

        }
        
        if ((Main.destoryFlag3==false) && (m_Transform.position.z+MakeALine.length== 0.1f)&&(startFlag==true))
        {
            //Main.spanTime2 = System.DateTime.Now;
            startFlag = false;
            Main.sw.WriteLine((System.DateTime.Now - Main.spanTime1).TotalMilliseconds);
            print((System.DateTime.Now-Main.spanTime1).TotalMilliseconds);

        }


        if (Main.destoryFlag3==true)
        {
            Main.destoryFlag3 = false;
            Size_Switch(Main.circleFlag);
        }
	}

	void OnDrawGizmos()
	{
		if (m_Transform == null) return;
		if (m_Theta < 0.0001f) m_Theta = 0.0001f;
		
		// 设置矩阵
		Matrix4x4 defaultMatrix = Gizmos.matrix;
		Gizmos.matrix = m_Transform.localToWorldMatrix;
		
		// 设置颜色
		Color defaultColor = Gizmos.color;
		Gizmos.color = m_Color;
		
		// 绘制圆环
		Vector3 beginPoint = Vector3.zero;
		Vector3 firstPoint = Vector3.zero;
		for (float theta = 0; theta < 2 * Mathf.PI; theta += m_Theta)
		{
			float x = m_Radius * Mathf.Cos(theta);
			float z = m_Radius * Mathf.Sin(theta);
			Vector3 endPoint = new Vector3(x, 0, z);
			if (theta == 0)
			{
				firstPoint = endPoint;
			}
			else
			{
				Gizmos.DrawLine(beginPoint, endPoint);
			}
			beginPoint = endPoint;
		}
		
		// 绘制最后一条线段
		Gizmos.DrawLine(firstPoint, beginPoint);
		
		// 恢复默认颜色
		Gizmos.color = defaultColor;
		
		// 恢复默认矩阵
		Gizmos.matrix = defaultMatrix;

        //print("cicle has been built!");
	}

    void Size_Switch(int caseSwitch)
    {
        switch (caseSwitch)
        {
            case 0:
                m_Radius = 0.01f;
                break;

            case 1:
                m_Radius = 0.02f;
                break;

            case 2:
                m_Radius = 0.03f;
                break;
        }

        print("Cicle size was changed!");
    }
}
