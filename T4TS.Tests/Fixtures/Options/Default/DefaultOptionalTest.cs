﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using T4TS.Tests.Utils;

namespace T4TS.Tests.Fixtures.Options.Default
{
    [TestClass]
    public class DefaultOptionalTest
    {
        [TestMethod]
        public void DefaultOptionalSettingHasExpectedOutput()
        {
            // Expect
            new OutputForAttributeBuilder(
                typeof(DefaultOptionalModel),
                typeof(DefaultOptionalOverrideModel)
            ).With(new Settings {
                DefaultOptional = true
            }).ToEqual(ExpectedOutput);
        }

const string ExpectedOutput = 
@"/****************************************************************************
  Generated by T4TS.tt - don't make any changes in this file
****************************************************************************/

declare module T4TS {
    /** Generated from T4TS.Tests.Fixtures.Options.Default.DefaultOptionalModel */
    export interface DefaultOptionalModel {
        SomeProp?: string;
    }
    /** Generated from T4TS.Tests.Fixtures.Options.Default.DefaultOptionalOverrideModel */
    export interface DefaultOptionalOverrideModel {
        SomeProp: string;
    }
}
";
    }
}
