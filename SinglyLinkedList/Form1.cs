using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SinglyLinkedList
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        LinkedList objListe = new LinkedList();

        private void btnCreate_Click(object sender, EventArgs e)
        {
            int i = 0;
            Random r = new Random();
            for (i = 0; i < 100; i++)
            {
                objListe.InsertFirst(r.Next(1, 30));
            }


            MessageBox.Show(objListe.DisplayElements());
            btnCreate.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int i = 0;
            int sinir = 0;
            int headKontrol = 0;
            int deger = Convert.ToInt32(txtSil.Text);
            Node iter = new Node();
            iter = objListe.Head;

            if (deger == objListe.Head.Data)
            {
                objListe.DeleteFirst();
                headKontrol = 1;
                MessageBox.Show(objListe.DisplayElements());
            }

            else
            {
                headKontrol = 0;
                while (iter != null)
                {
                    if (deger == iter.Data)
                    {
                        sinir = sinir + 1;
                    }
                    iter = iter.Next;
                }
                for (i = 0; i < sinir; i++)
                    Sil();
            }
            if (sinir == 0 && headKontrol == 0)
                MessageBox.Show("Enter a Non-Array Member");

            sinir = 0;
            iter = objListe.Head;
        }

        private void btnYazdir_Click(object sender, EventArgs e)
        {
            tersCevir(ref objListe.Head);
            MessageBox.Show(objListe.DisplayElements());
        }

        public void tersCevir(ref Node head)
        {
            Node currNode = head;
            Node nextNode = null;
            Node prevNode = null;

            while (currNode.Next != null)
            {
                nextNode = currNode.Next;
                currNode.Next = prevNode;
                prevNode = currNode;
                currNode = nextNode;
            }
            currNode.Next = prevNode;
            head = currNode;
        }

        public void Sil()
        {
            try
            {
                objListe.DeletePos(Convert.ToInt32(txtSil.Text));
                MessageBox.Show(objListe.DisplayElements());
            }
            catch (Exception)
            {
                MessageBox.Show("Enter a Non-Array Member");

            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            Node deger;
            deger = objListe.GetElement(Convert.ToInt32(txtGetE.Text));
            MessageBox.Show("" + deger.Data);
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            MessageBox.Show(objListe.DisplayElements());
        }

        private void txtDeger_KeyPress(object sender, KeyPressEventArgs e)
        {
            {
                char a = e.KeyChar;
                switch (a)
                {
                    case '1': // Desired Character
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                    case '0':
                    case '\b': // deleted
                        e.Handled = false; // Required keys are allowed here
                        break;
                    default:
                        e.Handled = true; // Here, all other keys are being rejected
                        break;
                }
            }
        }
    }
}
