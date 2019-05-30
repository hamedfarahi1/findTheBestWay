using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace findBestWay
{
    class results
    {
        public int n;
        public ArrayList Paths;
        public string path;
        public int count;
        public int[,] test;
        public results(int n,ArrayList path,string shortPath,int count,int[,] test)
        {
            this.path = shortPath;
            this.test = test;
            this.n = n;
            this.Paths= new ArrayList(path);
            this.count = count;

        }
    }
}
