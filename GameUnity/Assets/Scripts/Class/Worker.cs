using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker {

    private int m_typeWorker;
    private Travel m_travel;
    private float m_timeToMove;
    private float m_timeToMoveUsed;
    private GameObject m_workerObject;
    private GameObject[] m_workerObjectTab;
    private GameObject worker1;
    private GameObject worker2;
    private int i;
    private int timeToPoint = -1;

    public Worker(int typeWorker, Travel travel)
    {
        m_typeWorker = typeWorker;
        m_travel = travel;
        i = 0;

        m_workerObject = Resources.Load("Worker" + m_typeWorker, typeof(GameObject)) as GameObject;
        
        ReloadTime();
    }


    public int TypeWorker
    {
        get
        {
            return m_typeWorker;
        }

        set
        {
            m_typeWorker = value;
        }
    }

    public float TimeToMoveUsed
    {
        get
        {
            return m_timeToMoveUsed;
        }

        set
        {
            m_timeToMoveUsed = value;
        }
    }

    public float TimeToMove
    {
        get
        {
            return m_timeToMove;
        }

        set
        {
            m_timeToMove = value;
        }
    }

    public GameObject WorkerObject
    {
        get
        {
            return m_workerObject;
        }

        set
        {
            m_workerObject = value;
        }
    }

    public Travel Travel
    {
        get
        {
            return m_travel;
        }

        set
        {
            m_travel = value;
        }
    }

    public int I
    {
        get
        {
            return i;
        }

        set
        {
            i = value;
        }
    }

    public GameObject[] WorkerObjectTab
    {
        get
        {
            return m_workerObjectTab;
        }

        set
        {
            m_workerObjectTab = value;
        }
    }

    public GameObject Worker1
    {
        get
        {
            return worker1;
        }

        set
        {
            worker1 = value;
        }
    }

    public GameObject Worker2
    {
        get
        {
            return worker2;
        }

        set
        {
            worker2 = value;
        }
    }

    public int TimeToPoint
    {
        get
        {
            return timeToPoint;
        }

        set
        {
            timeToPoint = value;
        }
    }

    public void ReloadTime()
    {
        switch (m_typeWorker)
        {
            case 1:
                m_timeToMove = 1.2f;
                m_timeToMoveUsed = m_timeToMove;
                break;
            case 2:
                m_timeToMove = 0.4f;
                m_timeToMoveUsed = m_timeToMove;
                break;
            case 3:
                m_timeToMove = 4;
                m_timeToMoveUsed = m_timeToMove;
                break;
        }
    }

    public void MoveWorker()
    {
        if (i < m_travel.NumChildren)
        {
            if (i % 2 == 0)
            {
                worker1.SetActive(true);
                worker2.SetActive(false);
            }
            else if (i % 2 == 1)
            {
                worker2.SetActive(true);
                worker1.SetActive(false);
            }

            if (m_travel.TravelLoad.transform.GetChild(i).name == "neg")
            {
                m_workerObject.transform.Rotate(0, -90, 0, Space.World);
            }
            else if (m_travel.TravelLoad.transform.GetChild(i).name == "pos")
            {
                m_workerObject.transform.Rotate(0, 90, 0, Space.World);
            }
            
            if (m_travel.TravelLoad.transform.GetChild(i).name == "ClickToSetUp")
            {
                timeToPoint = 5;
            }
            else
            {
                m_workerObject.transform.position = m_workerObjectTab[i].transform.position;
                m_workerObjectTab[i].SetActive(false);
            }

            i++;
            //if (i == numChildren)
            //{
            //    spriteWorker1.material = bigHead;
            //    spriteWorker2.material = bigHead;
            //}

        }
        //else if (i == m_travel.NumChildren - 1)
        //{
        //    timeToPoint = 5;
        //    i++;
        //}
    }

    public void MakeTab()
    {
        m_workerObjectTab = new GameObject[m_travel.NumChildren];
        for (int y = 0; y < (m_travel.NumChildren); y++)
        {
            m_workerObjectTab[y] = m_travel.TravelLoad.transform.GetChild(y).gameObject;
        }
    }
}
