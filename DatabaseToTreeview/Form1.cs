using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace DatabaseToTreeview
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void BtnExpandAll_Click(object sender, EventArgs e)
        {
            treeView1.ExpandAll();
        }

        private void BtnLoadXML_Click(object sender, EventArgs e)
        {
            try
            {
                string xmlPath = Application.StartupPath + "\\" + textBox1.Text;
                XmlDocument doc = new XmlDocument();
                doc.Load(xmlPath);
                //XmlNodeList list = doc.SelectNodes("NewDataSet");
                textBox2.Text = xmlPath;

                XmlNode root = doc.ChildNodes[0];

                treeView1.Nodes.Clear();
                treeView1.Nodes.Add(new TreeNode(root.Name));
                TreeNode tNode = treeView1.Nodes[0];
                addNode(root, tNode);
            }
            catch(Exception)
            {

            }
        }
        void addNode(XmlNode inXmlNode, TreeNode inTreeNode)
        {
            XmlNode xNode;
            TreeNode tNode;
            XmlNodeList nodeList;
            int i = 0;
            if (inXmlNode.HasChildNodes)
            {
                nodeList = inXmlNode.ChildNodes;
                for (i = 0; i <= nodeList.Count - 1; i++)
                {
                    xNode = inXmlNode.ChildNodes[i];
                    inTreeNode.Nodes.Add(new TreeNode(xNode.Name));
                    tNode = inTreeNode.Nodes[i];
                    addNode(xNode, tNode);
                }
            }
            else
            {
                inTreeNode.Text = inXmlNode.InnerText.ToString();
            }
        }

        private void BtnLoadText_Click(object sender, EventArgs e)
        {
            try
            {
                string xmlPath = Application.StartupPath + @"\" + textBox1.Text;
                XmlDocument doc = new XmlDocument();
                doc.Load(xmlPath);
                //treeView1.Nodes.Add("NewDataSet");
                foreach(XmlNode node in doc.DocumentElement)
                {
                    foreach(XmlNode childNode in doc.ChildNodes)
                    {
                        textBox1.Text += childNode.InnerText+"\n";
                    }
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
