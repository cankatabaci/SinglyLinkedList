using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinglyLinkedList
{
    class LinkedList : ListBASE
    {
        public override void InsertFirst(int value)
        {
            Node tmpHead = new Node
            {
                Data = value
            };

            if (Head == null)
                Head = tmpHead;
            else
            {
                //En kritik nokta: tmpHead'in next'i eski Head'i göstermeli
                tmpHead.Next = Head;
                //Yeni Head artık tmpHead oldu
                Head = tmpHead;
            }
            //Bağlı listedeki eleman sayısı bir arttı
            Size++;
        }

        public override void InsertLast(int value)
        {
            Node tmpHead = new Node
            {
                Data = value
            };
            Node last;
            Node iter;
            iter = Head;

            if (iter == null)
            {
                Head = iter;
            }
            else
            {
                while (iter.Next != null)
                {
                    iter = iter.Next;
                }
                last = iter;
                last.Next = tmpHead;

            }

            Size++;
        }

        public override void InsertPos(int position, int value)
        {
            Node tmpHead = new Node
            {
                Data = value
            };

            Node iter;
            iter = Head;

            int i;
            for (i = 1; i < position - 1; i++)
            {
                iter = iter.Next;
            }
            tmpHead.Next = iter.Next;
            iter.Next = tmpHead;

            Size++;
        }

        public override void DeleteFirst()
        {
            if (Head != null)
            {
                //Head'in next'i HeadNext'e atanıyor
                Node HeadNext = this.Head.Next;
                //HeadNext null ise zaten tek kayıt olan Head silinir.
                if (HeadNext == null)
                    Head = null;
                else
                    //HeadNext null değilse yeni Head, HeadNext olur.
                    Head = HeadNext;
                //Listedeki eleman sayısı bir azaltılıyor
                Size--;
            }
        }

        public override void DeleteLast()
        {
            if (Head != null)
            {
                Node iter;
                int poz = Size;
                Node tmp;
                iter = this.Head;
                int i;
                for (i = 1; i < poz - 1; i++)
                {
                    iter = iter.Next;
                }
                //iter = null;

                iter.Next = null;

                Size--;
            }
        }

        public override void DeletePos(int position)
        {
            if (Head != null)
            {
                Node iter;
                Node tmp;
                iter = this.Head;

                while (iter.Next.Data != position)
                {
                    iter = iter.Next;
                }
                tmp = iter.Next.Next;
                iter.Next = null;
                iter.Next = tmp;


                Size--;
            }
        }


        public override Node GetElement(int position)
        {
            Node iter;
            iter = this.Head;
            int i;
            for (i = 1; i < position; i++)
            {
                iter = iter.Next;
            }

            return iter;
        }

        public override string DisplayElements()
        {
            string temp = "";
            Node item = Head;
            while (item != null)
            {
                temp += item.Data + "-->";
                item = item.Next;
            }

            return temp;
        }
    }
}
