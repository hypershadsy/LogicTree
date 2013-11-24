using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LogicTree
{
    class BinaryTreeNode
    {
        public Panel Container { get; private set; }
        public BinaryTreeNode Parent { get; private set; }
        public BinaryTreeNode Left { get; set; }
        public BinaryTreeNode Right { get; set; }
        private List<Button> data;
        public int MultidataSpacer = 30;
        public int ChildrenDepthY = 60;

        public BinaryTreeNode(Panel container)
        {
            this.Container = container;
            data = new List<Button>();
        }

        public BinaryTreeNode(BinaryTreeNode parent)
        {
            this.Parent = parent;
            this.Container = Parent.Container;
            this.data = new List<Button>();
        }

        public void AddData(Logical newdata)
        {
            Button me = new Button();
            me.AutoSize = true;
            me.Text = newdata.ToString();
            me.Tag = new ButtonTag(this, newdata);
            data.Add(me);
        }

        public int CountLeaves()
        {
            int many = 0;
            
            if (Left == null)
                many++;
            else
                many += Left.CountLeaves();

            if (Right == null)
                many++;
            else
                many += Right.CountLeaves();

            return many;
        }

        public void SpitToContainer()
        {
            SpitToContainerRecurse(Container.Width / 2, 4, Container.Width / 4);
        }

        protected void SpitToContainerRecurse(int left, int top, double spread)
        {
            for (int i = 0; i < data.Count; i++)
            {
                Button btn = data[i];
                //make sure everything is added to the panel
                bool btnadded = Container.Controls.Contains(btn);
                if (!btnadded)
                {
                    Container.Controls.Add(btn);
                }

                //position these datas at this node
                //center the button
                btn.Left = left - btn.Width / 2;
                //stack multi data at this node vertically
                btn.Top = top + i * MultidataSpacer;
            }

            if (Left != null)
                Left.SpitToContainerRecurse((int)(left - spread), top + (data.Count - 1) * MultidataSpacer + ChildrenDepthY, spread / 2);

            if (Right != null)
                Right.SpitToContainerRecurse((int)(left + spread), top + (data.Count - 1) * MultidataSpacer + ChildrenDepthY, spread / 2);
        }

        public bool IsLeaf()
        {
            return Left == null && Right == null;
        }

        public void Clear()
        {
            //hopefully you called this in the context of the root.
            Left = null;
            Right = null;
            data.Clear();
        }
    }

    class ButtonTag
    {
        public BinaryTreeNode BelongingNode { get; set; }
        public Logical Logic { get; set; }

        public ButtonTag(BinaryTreeNode belongingNode, Logical logic)
        {
            this.BelongingNode = belongingNode;
            this.Logic = logic;
        }
    }
}
