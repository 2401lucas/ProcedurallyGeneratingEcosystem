using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreadedDataRequester : MonoBehaviour
{
    public static ThreadedDataRequester instance;
    Queue<ThreadInfo> dataQueue = new Queue<ThreadInfo>();

    void Awake()
    {
        instance = FindObjectOfType<ThreadedDataRequester>();
    }

    public static void RequestData(Func<object> generateDataFunc, Action<object> callback)
    {
        ThreadStart threadStart = delegate
        {
            instance.DataThread(generateDataFunc, callback);
        };

        new Thread(threadStart).Start();
    }

    void DataThread(Func<object> generateDataFunc, Action<object> callback)
    {
        object data = generateDataFunc();
        lock (dataQueue)
        {
            dataQueue.Enqueue(new ThreadInfo(callback, generateDataFunc));
        }
    }

    void Update()
    {
        if (dataQueue.Count > 0)
        {
            for (int i = 0; i < dataQueue.Count; i++)
            {
                ThreadInfo threadInfo = dataQueue.Dequeue();
                threadInfo.callback(threadInfo.parameter);
            }
        }
    }

}

struct ThreadInfo
{
    public readonly Action<object> callback;
    public readonly object parameter;

    public ThreadInfo(Action<object> callback, object parameter)
    {
        this.callback = callback;
        this.parameter = parameter;
    }
}
