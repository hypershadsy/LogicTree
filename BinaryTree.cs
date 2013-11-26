using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace LogicTree
{
    class BinaryTreeNode
    {
        public Panel Container { get; private set; }
        public BinaryTreeNode Parent { get; private set; }
        public BinaryTreeNode Left { get; set; }
        public BinaryTreeNode Right { get; set; }
        public bool BranchClosed { get; set; }
        private List<Button> data;
        public int MultidataSpacer = 30;
        public int ChildrenDepthY = 60;

        public BinaryTreeNode()
        {
            this.data = new List<Button>();
        }

        public BinaryTreeNode(Panel container)
            : this()
        {
            this.Container = container;
        }

        public BinaryTreeNode(BinaryTreeNode parent)
            : this()
        {
            this.Parent = parent;
            this.Container = Parent.Container;
        }

        public void AddData(Logical newdata)
        {
            Button buttonData = new Button();
            buttonData.AutoSize = true;
            buttonData.Text = newdata.ToString();
            buttonData.Tag = new ButtonTag(this, newdata);
            buttonData.Click += new EventHandler(buttonData_Click);
            data.Add(buttonData);
        }

        void buttonData_Click(object sender, EventArgs e)
        {
            Button buttonData = (Button)sender;
            ButtonTag tag = (ButtonTag)buttonData.Tag;

            if (tag.Logic is Proposition)
            {
                //it's just a single proposition
                //TODO: check for counterexamples in the tree
            }
            else if (tag.Logic is Expression)
            {
                Expression expressionHere = (Expression)tag.Logic;

                //for every open leaf node underneath me,
                foreach (BinaryTreeNode endpoint in GetOpenBranchLeaves())
                {
                    //TODO: execute tree rules
                    switch (expressionHere.junct)
                    {
                        case Junctor.CONJUNCTION:
                            if (!expressionHere.negated)
                            {
                                //a conjunction is true iff both conjuncts are true
                            }
                            else
                            {
                                //a conjunction is false iff A is false or B is false
                            }
                            break;

                        case Junctor.DISJUNCTION:
                            if (!expressionHere.negated)
                            {
                                //a disjunction is true iff A is true or B is true
                            }
                            else
                            {
                                //a disjunction is false iff both disjuncts are false
                            }
                            break;

                        case Junctor.SUBJUNCTION:
                            if (!expressionHere.negated)
                            {
                                //a subjunction is true iff A is false or B is true
                            }
                            else
                            {
                                //a subjunction is false iff A is true and B is false
                            }
                            break;

                        case Junctor.BISUBJUNCTION:
                            if (!expressionHere.negated)
                            {
                                //a bisubjunction is true iff both sides are true or both are false
                            }
                            else
                            {
                                //a bisubjunction is false iff A is false and B is true or A is true and B is false
                            }
                            break;

                        case Junctor.NONE:
                        default:
                            MessageBox.Show("Invalid junctor: " + (int)expressionHere.junct);
                            break;
                    }
                }
            }
            else
            {
                MessageBox.Show("This isn't a Proposition or Expression.");
            }

            buttonData.Enabled = false; //TODO: check it off
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

        private void SpitToContainerRecurse(int left, int top, double spread)
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

        public bool IsOpenLeaf()
        {
            bool leftDNE = Left == null;
            bool rightDNE = Right == null;

            Debug.Assert(leftDNE == rightDNE);

            return !BranchClosed && leftDNE && rightDNE;
        }

        public List<BinaryTreeNode> GetOpenBranchLeaves()
        {
            List<BinaryTreeNode> openBranchLeaves = new List<BinaryTreeNode>();
            GetOpenBranchLeavesRecurse(openBranchLeaves);

            return openBranchLeaves;
        }

        private void GetOpenBranchLeavesRecurse(List<BinaryTreeNode> running)
        {
            //get self
            if (IsOpenLeaf())
                running.Add(this);

            //get the right
            if (Right != null)
            {
                Right.GetOpenBranchLeavesRecurse(running);
            }

            //get the left
            if (Left != null)
            {
                Left.GetOpenBranchLeavesRecurse(running);
            }
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
