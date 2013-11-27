using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicTree
{
    enum Junctor
    {
        NONE = 0,
        CONJUNCTION,
        DISJUNCTION,
        SUBJUNCTION,
        BISUBJUNCTION
    }

    class Expression : Logical
    {
        public Logical LeftHandSide { get; set; }
        public Logical RightHandSide { get; set; }
        public Junctor Junctor = Junctor.NONE;

        public Expression()
        {
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            ToStringRecurse(sb);
            return sb.ToString();
        }

        internal override void ToStringRecurse(StringBuilder sb)
        {
            if (Negated)
                sb.Append(Logical.NEGATION);
            sb.Append('(');
            LeftHandSide.ToStringRecurse(sb);
            sb.Append(Logical.JunctorToChar(Junctor));
            RightHandSide.ToStringRecurse(sb);
            sb.Append(')');
        }

        public override Logical Clone()
        {
            Expression toReturn = new Expression();
            toReturn.LeftHandSide = LeftHandSide.Clone();
            toReturn.RightHandSide = RightHandSide.Clone();
            toReturn.Junctor = Junctor;
            return toReturn;
        }
    }

    class Proposition : Logical
    {
        public char Symbol { get; set; }

        public Proposition(char symbol, bool negated)
        {
            System.Diagnostics.Debug.Assert(char.IsUpper(symbol) && char.IsLetter(symbol)); // must be uppercase letter
            this.Symbol = symbol;
            this.Negated = negated;
        }

        //public Proposition(char symbol) : this(symbol, false)
        //{
        //}

        internal override void ToStringRecurse(StringBuilder sb)
        {
            sb.Append(ToString());
        }

        public override string ToString()
        {
            if (Negated)
                return Logical.NEGATION.ToString() + Symbol;
            return Symbol.ToString();
        }

        public override Logical Clone()
        {
            return new Proposition(Symbol, Negated);
        }
    }

    abstract class Logical
    {
        public const char CONJUNCTION = '∧';
        public const char DISJUNCTION = '∨';
        public const char SUBJUNCTION = '→';
        public const char NEGATION = '¬';
        public const char BISUBJUNCTION = '↔';

        public bool Negated { get; set; }

        //take a junctor and give the character representation of it
        public static char JunctorToChar(Junctor j)
        {
            switch (j)
            {
                case Junctor.CONJUNCTION:
                    return CONJUNCTION;
                case Junctor.DISJUNCTION:
                    return DISJUNCTION;
                case Junctor.SUBJUNCTION:
                    return SUBJUNCTION;
                case Junctor.BISUBJUNCTION:
                    return BISUBJUNCTION;
                case Junctor.NONE:
                default:
                    return '?';
            }
        }

        //take a char representation of a junctor and return it's Junctor equivalent
        public static Junctor CharToJunctor(char possibleJunctor)
        {
            switch (possibleJunctor)
            {
                case CONJUNCTION:
                    return Junctor.CONJUNCTION;
                case DISJUNCTION:
                    return Junctor.DISJUNCTION;
                case SUBJUNCTION:
                    return Junctor.SUBJUNCTION;
                case BISUBJUNCTION:
                    return Junctor.BISUBJUNCTION;
                default:
                    return Junctor.NONE;
            }
        }

        abstract internal void ToStringRecurse(StringBuilder sb);

        abstract public Logical Clone();

        public void FlipNegation()
        {
            Negated = !Negated;
        }
    }
}
