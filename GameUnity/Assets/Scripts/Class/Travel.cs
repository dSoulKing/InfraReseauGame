using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Travel {

    private int m_numWorker;
    private int m_numTravel;
    private GameObject m_travelLoad;
    private int m_numChildren;
    private GameObject m_travel;

    public Travel(int numWorker, int numTravel)
    {
        m_numWorker = numWorker;
        m_numTravel = numTravel;

        switch (m_numWorker)
        {
            case 1:
                m_travelLoad = Resources.Load("TravelNo" + m_numTravel, typeof(GameObject)) as GameObject;
                break;

            case 2:
                m_travelLoad = Resources.Load("TravelNi" + m_numTravel, typeof(GameObject)) as GameObject;
                break;

            case 3:
                m_travelLoad = Resources.Load("TravelF" + m_numTravel, typeof(GameObject)) as GameObject;
                break;
        }

        //m_numChildren = m_travelLoad.transform.childCount;
    }

    public int NumTravel
    {
        get
        {
            return m_numTravel;
        }

        set
        {
            m_numTravel = value;
        }
    }

    public int NumWorker
    {
        get
        {
            return m_numWorker;
        }

        set
        {
            m_numWorker = value;
        }
    }

    public GameObject TravelLoad
    {
        get
        {
            return m_travelLoad;
        }

        set
        {
            m_travelLoad = value;
        }
    }

    public int NumChildren
    {
        get
        {
            return m_numChildren;
        }

        set
        {
            m_numChildren = value;
        }
    }

}
