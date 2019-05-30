using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Linq;

namespace findBestWay
{
    class bestWay
    {
        public static results res;
        public ArrayList Result = new ArrayList();
        public ArrayList testResult = new ArrayList();

        private Node[,] table;
        private int[,] test =new int[8,8] { { 0, 1, 0, 1, 1, 0, 1, 1 }, { 0, 1, 1, 1, 1, 1, 0, 1 }, { 1, 0, 1, 1, 0, 1, 0, 1 }, { 1, 1, 1, 0, 1, 1, 1, 1 }, { 1, 0, 1, 0, 1, 1, 0, 1 }, { 1, 1, 0, 1, 1, 1, 0, 0 }, { 1, 0, 1, 1, 1, 0, 1, 1 }, { 1, 0, 1, 1, 1, 1, 1, 1 } };

        private int size;

        public bestWay(int n)
        {
            this.table = new Node[n,n];
            this.size = n;
        }

        public void fillTable()
        {
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                {
                    if (test[i,j] == 1)
                        table[i,j] = new Node(test[i,j] == 1);
                }

        }
        public Node setStartEnd()
        {
            int i = 3;
            int j = 0;
            table[i,j].start = true;
            Node start = table[i,j];
            int k = 7;
            int m = 7;
            table[k,m].end = true;
            return start;
        }

        public void fillTableCustom()
        {
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                {
                    if (table[i,j] != null)
                    {
                        if (i - 1 >= 0 && table[i - 1,j] != null)
                        {
                            table[i,j].up = table[i - 1,j];
                            table[i,j].location = Convert.ToString(i) + Convert.ToString(j);
                        }
                        if (i + 1 < size && table[i + 1,j] != null)
                        {
                            table[i,j].down = table[i + 1,j];
                            table[i,j].location = Convert.ToString(i) + Convert.ToString(j);
                        }
                        if (j + 1 < size && table[i,j + 1] != null)
                        {
                            table[i,j].right = table[i,j + 1];
                            table[i,j].location = Convert.ToString(i) + Convert.ToString(j);
                        }
                        if (j - 1 >= 0 && table[i,j - 1] != null)
                        {
                            table[i,j].left = table[i,j - 1];
                            table[i,j].location = Convert.ToString(i) + Convert.ToString(j);
                        }
                    }

                }
        }
        public void showTable()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (table[i, j] != null) ;
                    
                }
             
            }
            
        }

        public string best(Node node, ArrayList partners, string s)
        {
            if (node.end)
            {
                Result.Add(s + node.location);
                return s;
            }
            else if (node.right != null || node.left != null || node.up != null || node.down != null)
            {


                if (node.down != null)
                    if (!partners.Contains(node.down))
                    {

                        ArrayList p = new ArrayList(partners);
                        p.Add(node.down.up);
                        best(node.down, p, s + node.location);
                    }

                if (node.up != null)
                    if (!partners.Contains(node.up))
                    {
                        ArrayList p = new ArrayList(partners);
                        
                        p.Add(node.up.down);
                        best(node.up, p, s + node.location);
                    }
                if (node.right != null)
                    if (!partners.Contains(node.right))
                    {
                        ArrayList p = new ArrayList(partners);
                       
                        p.Add(node.right.left);
                        best(node.right, p, s + node.location);
                    }
                if (node.left != null)
                    if (!partners.Contains(node.left))
                    {
                        ArrayList p = new ArrayList(partners);
                        p.Add(node.left.right);
                        best(node.left, p, s + node.location);
                    }

            }
            else
            {

                //System.out.println(RED+string+node.location);

                return "";
            }
            return "";
        }


        public void bestWayFinder()
        {
            testResult = new ArrayList(Result);
            int[] count = new int[Result.Count]; int k = 0;
            while (Result.Count != 0)
            {
                Console.WriteLine(Result[0].ToString());
                string st = Result[0].ToString(); int i = 0;
                Result.Remove(Result[0]);
                while (i < st.Length)
                {

                    while (i + 2 < st.Length && st[i] == st[i + 2])
                    {
                        i += 2;
                    }
                    count[k]++;
                    i = i + 1;
                    while (i + 2 < st.Length && st[i] == st[i + 2])
                    {
                        i += 2;
                    }
                    i = i - 1;
                    if (i == st.Length - 2) break;
                    count[k]++;
                }
                k++;
            }



            /*   for (int i=0;!Result.isEmpty();i++){
                   for (int j=0;j+3<Result.get(i).length();j+=2){
                       if (j+2<Result.size() && Result.get(i).charAt(j)==Result.get(i).charAt(j+2))
                           continue;
                       else if(j+2<Result.size() && Result.get(i).charAt(j)!=Result.get(i).charAt(j+2))
                           count[i]++;
                       else if(j+3<Result.size() && Result.get(i).charAt(j+1)==Result.get(i).charAt(j+3))
                           continue;
                       else
                           count[i]++;

                   }
               }*/
            string result = "";
            int m = 0;
            for (int i = 0; i < count.Length; i++)
                if (count.Min() == count[i])
                    m = i;
             res = new results(size, testResult, testResult[m].ToString(), count[m],test);
            Console.WriteLine(testResult[m].ToString()+"  "+count[m]);
            
        }

    }
}
