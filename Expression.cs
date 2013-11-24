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
        public Logical lhs;
        public Logical rhs;
        public Junctor junct = Junctor.NONE;

        public Expression()
        {
        }

        public Expression(Logical lhs, Logical rhs, Junctor junct)
        {
            this.lhs = lhs;
            this.rhs = rhs;
            this.junct = junct;

            //if no junctor and left hand exists
            System.Diagnostics.Debug.Assert(junct != Junctor.NONE);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            ToStringRecurse(sb);
            return sb.ToString();
        }

        internal override void ToStringRecurse(StringBuilder sb)
        {
            if (negated)
                sb.Append(Logical.NEGATION);
            sb.Append('(');
            lhs.ToStringRecurse(sb);
            sb.Append(Logical.JunctorToChar(junct));
            rhs.ToStringRecurse(sb);
            sb.Append(')');
        }
    }

    class Proposition : Logical
    {
        char symbol;

        public Proposition(char symbol)
        {
            System.Diagnostics.Debug.Assert(char.IsUpper(symbol) && char.IsLetter(symbol)); // must be uppercase letter
            this.symbol = symbol;
        }

        internal override void ToStringRecurse(StringBuilder sb)
        {
            sb.Append(ToString()); 
        }

        public override string ToString()
        {
            if (negated)
                return Logical.NEGATION.ToString() + symbol;
            return symbol.ToString();
        }
    }

    abstract class Logical
    {
        public const char CONJUNCTION = '∧';
        public const char DISJUNCTION = '∨';
        public const char SUBJUNCTION = '→';
        public const char NEGATION = '¬';
        public const char BISUBJUNCTION = '↔';

        public bool negated;

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
    }
}
