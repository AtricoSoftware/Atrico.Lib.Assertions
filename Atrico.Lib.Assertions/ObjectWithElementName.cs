using Atrico.Lib.Common.Collections;
using Atrico.Lib.Common.NamesByConvention;
using System.Collections;

namespace Atrico.Lib.Assertions
{
    public abstract class ObjectWithElementName
    {
        protected virtual string CreateElementName()
        {
            return new EverythingBefore(GetType().Name, ElementNameBase) + CreateElementNameArguments.ToCollectionString(CreateElementOpenBrace, CreateElementCloseBrace, ",", CreateElementNameBracesIfNoArguments);
        }

        protected virtual IEnumerable CreateElementNameArguments
        {
            get { return new object[] {}; }
        }

        protected virtual string CreateElementOpenBrace
        {
            get { return "("; }
        }
        protected virtual string CreateElementCloseBrace
        {
            get { return ")"; }
        }

        protected virtual bool CreateElementNameBracesIfNoArguments
        {
            get { return false; }
        }

        protected abstract string ElementNameBase { get; }
    }
}