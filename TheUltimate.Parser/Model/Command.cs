using System.Collections.Generic;

namespace TheUltimate.Interpreter.Model
{
    public class Command
    {
        public string Line { get; set; }
        public string Verb { get; set; }
        public string Argument { get; set; }
        public string Response { get; set; }
        public bool IsValid { get; set; }

        //public IEnumerable<Argument> Arguments { get; set; }

        #region Equals

        protected bool Equals(Command other)
        {
            return string.Equals(Line, other.Line) && string.Equals(Verb, other.Verb) && string.Equals(Argument, other.Argument) && string.Equals(Response, other.Response) && IsValid.Equals(other.IsValid);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Command) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (Line != null ? Line.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Verb != null ? Verb.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Argument != null ? Argument.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Response != null ? Response.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ IsValid.GetHashCode();
                return hashCode;
            }
        }

        #endregion
    }
}