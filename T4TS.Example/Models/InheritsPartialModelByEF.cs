﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T4TS.Example.Models
{
  /// <summary>
  /// assume this class was generated by EF; can't add (easily) TypeScriptInterface to the generated file
  /// </summary>
  public partial class PartialModelByEF
  {
    public int SomeId { get; set; }
  }

  /// <summary>
  /// This is just to add the TypeScriptInterface to the generated class
  /// </summary>
  [TypeScriptInterface]
  public partial class PartialModelByEF
  {
    //just to add TypeScriptInterface
  }

  /// <summary>
  /// And this is a DTO class with some more properties
  /// </summary>
  [TypeScriptInterface]
  public partial class InheritsPartialModelByEF : PartialModelByEF
  {
    public string NewProperty { get; set; }
  }
}
