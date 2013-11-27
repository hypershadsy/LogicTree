using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LogicTree
{
    public partial class Form1 : Form
    {
        BinaryTreeNode bintree;

        public Form1()
        {
            InitializeComponent();
            bintree = new BinaryTreeNode(panel1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.Assert(CountJunctors("((A→B)↔(A∧¬B))") == 3);
            System.Diagnostics.Debug.Assert(CountParens("((A→B)↔(A∧¬B))") == 6);
            System.Diagnostics.Debug.Assert(CheckIsValid("((A→B)↔(A∧¬B))"));
            System.Diagnostics.Debug.Assert(CheckIsValid("((A→B)↔(A∧∧¬B))") == false);

            ResetTree();
            Hypothetical();
        }

        private void ResetTree()
        {
            bintree.Clear();
            panel1.Controls.Clear();
        }

        private string StupidFormat(string p)
        {
            string result = p;

            //cut out spaces
            result = result.Replace(" ", string.Empty);

            //caps
            result = result.ToUpper();

            return result;
        }

        private bool CheckIsValid(string p)
        {
            if (CountJunctors(p)*2 == CountParens(p))
                return true;
            return false;
        }

        private int CountParens(string p)
        {
            return p.Count(IsParen);
        }

        private int CountJunctors(string p)
        {
            return p.Count(IsJunctor);
        }

        private bool IsParen(char paren)
        {
            return
                paren == '(' ||
                paren == ')';
        }

        private bool IsJunctor(char junc)
        {
            return
                junc == Logical.CONJUNCTION ||
                junc == Logical.DISJUNCTION ||
                junc == Logical.SUBJUNCTION ||
                junc == Logical.BISUBJUNCTION;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //format, parse into expression
            Logical output;
            try
            {
                output = Parse(StupidFormat(textBox1.Text));
            }
            catch (LogicException)
            {
                MessageBox.Show("cannot continue with expression. please reformat");
                return;
            }

            //add the expression to the top of the tree
            bintree.AddData(output);
            bintree.SpitToContainer();
        }

        private void Hypothetical()
        {
            //∧ ∨ → ¬ ↔
            Logical root1 = Parse("((A∧B)∨(A∧B))");
            Logical root2 = Parse("(A→B)");

            Logical left = Parse("(A∧B)");
            Logical right = Parse("(A∧B)");
            
            bintree.AddData(root1);
            bintree.AddData(root2);

            bintree.Left = new BinaryTreeNode(bintree);
            bintree.Left.AddData(left);

            bintree.Right = new BinaryTreeNode(bintree);
            bintree.Right.AddData(right);

            bintree.SpitToContainer();
        }

        private Logical Parse(string inp)
        {
            System.Collections.Generic.Stack<Expression> exp = new Stack<Expression>();
            bool negated = false;

            for (int i = 0; i < inp.Length; i++)
            {
                char here = inp[i];
                if (here == '(')
                {
                    Expression startingNewExpression = new Expression();
                    if (negated)
                    {
                        startingNewExpression.Negated = true; //this expression should be negated
                        negated = false; //negation is used up. we found who it's referring to
                    }
                    exp.Push(startingNewExpression);
                }
                else if (here == Logical.NEGATION)
                {
                    //negate the next Proposition or Expression
                    //TODO: double negation
                    negated = true;
                }
                else if (IsJunctor(here))
                {
                    if (exp.Count == 0)
                    {
                        MessageBox.Show("Malformed expression: found unexpected junctor, wrap the whole expression with parentheses");
                        throw new LogicException();
                    }
                    //if we find a junctor, just assign it to the topmost Expression on the stack
                    exp.Peek().Junctor = Logical.CharToJunctor(here);
                }
                else if (char.IsLetter(here))
                {
                    if (exp.Count == 0)
                    {
                        //no expression and we found a proposition, interpret it as a single prop for return value
                        Proposition newprop = new Proposition(here, negated);
                        return newprop;
                    }
                    //it's a Logical Proposition! let's put it where it belongs
                    Expression parent = exp.Peek();
                    Proposition newProposition = new Proposition(here, negated);

                    //negation is used up, if it was even enabled.
                    negated = false;
                    
                    //check where in the parent expression it should be placed
                    if (parent.LeftHandSide == null)
                    {
                        parent.LeftHandSide = newProposition;
                    }
                    else if (parent.RightHandSide == null)
                    {
                        parent.RightHandSide = newProposition;
                    }
                    else
                    {
                        MessageBox.Show("Malformed expression: nowhere to put proposition in parent");
                        throw new LogicException();
                    }

                }
                else if (here == ')')
                {
                    //a ) means we've just finished an expression and
                    //are assigning it to it's parent
                    Expression complete = exp.Pop();

                    if (complete.Junctor == Junctor.NONE) //this invalidates crap like (AB)
                    {
                        MessageBox.Show("Malformed expression: missing junctor");
                        throw new LogicException();
                    }

                    //this could be the last of the expressions in the stack
                    if (exp.Count == 0)
                    {
                        //if this is true, the index for the for loop should be last.
                        //is it? if not, bad expression (or bad programming?)
                        if (i != inp.Length - 1)
                        {
                            MessageBox.Show("Malformed expression: extra junk after the last parentheses");
                            throw new LogicException();
                        }
                        return complete;
                    }

                    Expression hisParent = exp.Peek();

                    if (hisParent.LeftHandSide == null) //if lhs is not yet, put it there
                    {
                        hisParent.LeftHandSide = complete;
                    }
                    else if (hisParent.RightHandSide == null) //or put it in rhs
                    {
                        hisParent.RightHandSide = complete;
                    }
                    else
                    {
                        MessageBox.Show("Malformed expression: nowhere to put expression in parent");
                        throw new LogicException();
                    }
                }
            }

            MessageBox.Show("Malformed expression: unexpected end of expression");
            throw new LogicException();
        }

        #region specialchars
        private void buttonTextConjunction_Click(object sender, EventArgs e)
        {
            InsertSpecial(Logical.CONJUNCTION);
        }

        private void buttonTextDisjunction_Click(object sender, EventArgs e)
        {
            InsertSpecial(Logical.DISJUNCTION);
        }

        private void buttonTextSubjunction_Click(object sender, EventArgs e)
        {
            InsertSpecial(Logical.SUBJUNCTION);
        }

        private void buttonTextNegation_Click(object sender, EventArgs e)
        {
            InsertSpecial(Logical.NEGATION);
        }

        private void buttonTextBisubjunction_Click(object sender, EventArgs e)
        {
            InsertSpecial(Logical.BISUBJUNCTION);
        }

        private void InsertSpecial(char which)
        {
            //TODO: insert at insertion point
            //TODO: insert overwriting selected text
            textBox1.AppendText(char.ToString(which));
        }
        #endregion

        private void Form1_Resize(object sender, EventArgs e)
        {
            bintree.SpitToContainer();
            panel1.Invalidate();
        }
    }

    public class LinedPanel : Panel
    {
        static Random rand = new Random();

        public LinedPanel()
            : base()
        {
            this.Name = "LinedPanel";
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            Pen thePen = new Pen(Color.FromArgb(64,64,64));
            thePen.Width = 2;

            //TODO: real line drawing
            //g.DrawLines(thePen, RandPoints(10, Width, Height));
        }

        protected static Point[] RandPoints(int howmany, int maxX, int maxY)
        {
            Point[] pts = new Point[howmany];

            for (int i = 0; i < pts.Length; i++)
            {
                pts[i] = new Point(rand.Next(maxX), rand.Next(maxY));
            }

            return pts;
        }
    }

    class LogicException : Exception
    {
    }
}
