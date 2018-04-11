﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using T4TS.Tests.Utils;

namespace T4TS.Tests.Fixtures.Options.Default
{
    [TestClass]
    public class UseNativeDatesTest
    {
        [TestMethod]
        public void UseNativeDatesSettingHasExpectedOutput()
        {
            // Expect
            new OutputForAttributeBuilder(
                typeof(UseNativeDatesModel))
                    .WithTypeSettings(new TypeContext.Settings
                        {
                            UseNativeDates = true
                        })
                    .ToEqual(ExpectedOutput);
        }

const string ExpectedOutput = 
@"/****************************************************************************
  Generated by T4TS.tt - don't make any changes in this file
****************************************************************************/

declare module T4TS {
    /** Generated from T4TS.Tests.Fixtures.Options.Default.UseNativeDatesModel **/
    export interface UseNativeDatesModel {
        SomeDateTime: Date;
        SomeDateTimeOffset: Date;
    }
}
";
    }
}
