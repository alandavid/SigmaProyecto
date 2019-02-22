using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ninja.Mapping.Interfaces
{
    public interface ITransformMapper
    {
        Tresult Transform<TFrom, Tresult>(TFrom from);
    }
}