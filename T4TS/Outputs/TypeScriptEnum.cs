﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T4TS.Outputs
{
    public class TypeScriptEnum : TypeReference
    {
        public IList<TypeScriptEnumValue> Values { get; set; }

        public TypeScriptModule Module { get; set; }
        

        public TypeScriptEnum(
            TypeName sourceType,
            TypeReferenceFactory referenceFactory)
                : base(
                      sourceType,
                      referenceFactory)
        {
            this.Values = new List<TypeScriptEnumValue>();
        }
    }
}
