using Atrico.Lib.Common;

namespace Atrico.Lib.Assertions
{
    public abstract class Decorator : ObjectWithElementName, INamedObject
    {
        private Decorator _next;

        public Decorator Append(Decorator next)
        {
            if (ReferenceEquals(_next, null)) _next = next;
            else _next.Append(next);
            return this;
        }

        public virtual bool Test(object actual)
        {
            return !ReferenceEquals(_next, null) && _next.Test(actual);
        }

        public virtual string CreateErrorMessage(object actual)
        {
            return ReferenceEquals(_next, null) ? "" : _next.CreateErrorMessage(actual);
        }

        public string Name
        {
            get
            {
                var after = ReferenceEquals(_next, null) ? "" : _next.Name;
                var before = CreateElementName();
                if (string.IsNullOrWhiteSpace(before)) return after;
                if (string.IsNullOrWhiteSpace(after)) return before;
                return before + "." + after;
            }
        }

        protected override string ElementNameBase
        {
            get { return "Decorator"; }
        }
    }
}