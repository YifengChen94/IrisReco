using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Emgu.CV;
using Emgu.CV.Structure;
using RIS.UI;

namespace RIS.ThreadPool
{
    public class ThreadParallel
    {
        int n;
        public List<ThreadReco> threadparallel;
        MainWindow mainWindow;
        public ThreadParallel(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            threadparallel = new List<ThreadReco>();
            n = 10;//zhousc modify
            CreateThreads();
        }

        void CreateThreads()
        {
            for (int i = 0; i < n; i++)
            {
                ThreadReco t = new ThreadReco(this.mainWindow);
                t.tid = i;
                t.StartThread();
                threadparallel.Add(t);
            }
        }

    }
}
