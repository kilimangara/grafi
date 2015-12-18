using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grafi
{  
    class G1
    {
        public delegate void Showarray(bool[] message);
        public delegate void Showmessage(string message);
        const int max = 1000;
       public class V
        {
            private int _num;
            private string _label;
            public int num
            {
                set
                {
                    _num = value;
                }
                get
                {
                    return _num;
                }
            }
            public string label
            {
                set
                {
                    _label = value;
                }
                get
                {
                    return _label;
                }
            }
        }
        public class X
        {
            private int _nachalo;
            private int _konec;
            private string _label;
            private int _w;
            public int nachalo
            {
                set
                {
                    _nachalo = value;
                }
                get
                {
                    return _nachalo;
                }
            }
            public string label
            {
                set
                {
                    _label = value;
                }
                get
                {
                    return _label;
                }
            }
            public int w
            {
                set
                {
                    _w = value;
                }
                get
                {
                    return _w;
                }
            }
            public int konec
            {
                set
                {
                    _konec = value;
                }
                get
                {
                    return _konec;
                }
            }
        }
        private class Node
        {
            public string label;
            public int num;
            public int w;
            public Node next=new Node();
        }
       private struct Matrix
        {
            public Node H=new Node();
            public V v;
          
        }
        Matrix[] ar = new Matrix[max];
        Node Nv = new Node();
        private bool vivod=true; 
        private Node add(V v1, V v2,int w,string label)
        {
            bool h = false;
            Node last = new Node();
            Node k = new Node();
            last.num = v2.num;
            last.w = w;
            last.label = label;
            if (ar[v1.num].H == null) return last;
            else
            {
                k = ar[v1.num].H;
                while ((k != null) && (!h))
                {
                    if (k.num > last.num)
                    {
                        last.next = k;
                        h = true;
                       
                    }
                    else
                    {
                        k = k.next;
                    }
                }
                return ar[v1.num].H;
            } 
        }
        private Node add(V v)
        {
            bool h = false;
            Node last = new Node();
            Node k = new Node();
            last.num = v.num;
            if (Nv == null) return last;
            else
            {
                k = Nv;
                while ((k != null) && (!h))
                {
                    if (k.num > last.num)
                    {
                        last.next = k;
                        h = true;
                       
                    }
                    else
                    {
                        k = k.next;
                    }
                }
                return Nv;
            } 
        }
        private Node delete(V v)
        {
            Node k = Nv;
            Node tmp = new Node();
            while ((v.num != Nv.num)&&(k!=null))
            {
                tmp = k;
                k = k.next;
            }
            if (k != null)
            {
                tmp.next = k.next;
                return Nv;
            }
            return Nv;
        }
        public void VINSERT(V v,Showmessage method)
        {
            ar[v.num].v.label = v.label;
            Nv = add(v);
            method("Вершина добавлена");
        }
        public void XINSERT(V v1, V v2, int w,string label,Showmessage method)
        {   Node s =new Node();
            s=ar[v1.num].H;
            if ((v1.num != 0))
            {
                while ((s != null) && (s.num != v2.num))
                {
                    s = s.next;
                }
                if (s != null)
                {
                    method("Данная дуга уже существет");

                    return;
                }
                    ar[v1.num].H = add(v1, v2, w, label);
                method("Дуга добавлена");
                return;
            }
            else
            {
                method("Начальной вершины не существует");
                return;
            }
        }
        public void XLABEL(V v1, V v2,Showmessage method)
        {
        Node p = ar[v1.num].H;
        if (v1.num != 0)
        {
            while ((p.num != v2.num) && (p != null))
            {
                p = p.next;
            }
            if (p != null)
            {
                method( p.label);
            }
            else
            { 
                method("Данная дуга не найдена");
                return ;
            }
        }
        else
        {
           method("Данная дуга не найдена");
            return ;
        }
        
        }
        public void VLABEL(V v,Showmessage method)
        {
            if (v.num != 0)
            {
                method(string.Format(ar[v.num].v.label));
                return;
            }
            else
            {
                method("Данной вершины не существует");
                return ;
            }
        }
        public void XDELETE(V v1, V v2, Showmessage method)
        {
            Node s = ar[v1.num].H;
            Node tmp = new Node();
            if (v1.num != 0)
            {
                while ((s != null) && (s.num != v2.num))
                {
                    tmp = s;
                    s = s.next;
                }
                if (s == null)
                {
                    method("Данной дуги не существует");
                    return;
                }
                else
                {
                    tmp.next = s.next;
                    method("Дуга удалена");
                    return;
                }
            }
        }
        private void XDELETE (V v1,V v2)
    {     
                Showmessage del =(x) => {return;};
                XDELETE(v1,v2,del);
    }
        public void VDELETE(V v,Showmessage method)
        {
            Node k = Nv;
            ar[v.num].H = null;
            ar[v.num].v.label = null;
            ar[v.num].v.num = 0;
            Nv = delete(v);
           while(k!=null)
            {
                V v1 = new V();
                v1.num = k.num;
                XDELETE(v1, v);
                k = k.next;
            }
        }
        public void SLabel(int i, V v, Showmessage method)
        { Node k=ar[v.num].H;
            for (int u = 1; u < i; ++u)
            {
                k = k.next;
            }
            method(string.Format("Метка {0}-смежной вершине дуги: {1}", i, k.label));
        }
        public void SHeight(int i, V v, Showmessage method)
        {
            Node k = ar[v.num].H;
            for (int u = 1; u < i; ++u)
            {
                k = k.next;
            }
            method(string.Format("Вес {0}-смежной вершине дуги: {1}", i, k.w));
        }
        public void Worshall(Showmessage method)
        {
            Node tmp = Nv;
            Node k = Nv;
            int i = 0; int ii = 0;
            int jj = 0;
            while (k != null)
            {
                i++;
                k = k.next;
            }
            bool[,] A= new bool [i,i];
            while (tmp != null)
            {
              
                Node t = ar[tmp.num].H;
                while (t != null)
                { jj=0;
                    Node tmp1 = Nv;
                    while (tmp1.num != t.num)
                    {
                        tmp1 = tmp1.next;
                        ++jj;
                    }
                    if (tmp1 != null)
                    {
                        A[ii, jj] = true;
                    }
                    t = t.next;
                }
                tmp = tmp.next;
                ++ii;
            }
            for (int k1 = 0; k1 <= i; ++k1)
            {
                for (int i1 = 0; i1 <= i; ++i1)
                {
                    for (int j1 = 0; j1 <= i; ++j1)
                    {
                        if (A[j1, i1] == false)
                        {
                            A[j1, i1]=(A[j1, k1] && A[k1, i1]);
                        }
                    }
                }
            }

        }
        }
    }
