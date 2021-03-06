﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using T4TS.Example.Models;
using T4TS.Tests.Fixtures.Basic;
using T4TS.Tests.Utils;

namespace T4TS.Tests.Fixtures.Inheritance
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void InheritanceModelHasExpectedOutput()
        {
            // Expect
            new OutputForAttributeBuilder(
                typeof(InheritanceModel),
                typeof(OtherInheritanceModel),
                typeof(ModelFromDifferentProject),
                typeof(BasicModel)
            ).ToEqual(ExpectedOutput);
        }

        [TestMethod]
        public void InheritanceModelHasExpectedOutputDirect()
        {
            // Expect
            new OutputForDirectBuilder(
                typeof(InheritanceModel),
                typeof(OtherInheritanceModel),
                typeof(ModelFromDifferentProject),
                typeof(BasicModel))
                    .WithSettings((settings) =>
                    {
                        settings.NamespaceToModuleMap.Add(
                            typeof(ModelFromDifferentProject).Namespace,
                            "External");
                        settings.NamespaceToModuleMap.Add(
                            typeof(InheritanceModel).Namespace,
                            "T4TS");
                        settings.NamespaceToModuleMap.Add(
                            typeof(BasicModel).Namespace,
                            "T4TS");
                    })
                    .ToEqual(ExpectedOutput);
        }

        [TestMethod]
        public void InheritanceModelReferenceOrderHasExpectedOutputDirect()
        {
            // Expect
            new OutputForDirectBuilder(
                typeof(InheritanceModel),
                typeof(OtherInheritanceModel),
                typeof(ModelFromDifferentProject),
                typeof(BasicModel))
                    .WithSettings((settings) =>
                    {
                        settings.NamespaceToModuleMap.Add(
                            typeof(ModelFromDifferentProject).Namespace,
                            "External");
                        settings.NamespaceToModuleMap.Add(
                            typeof(InheritanceModel).Namespace,
                            "T4TS");
                        settings.NamespaceToModuleMap.Add(
                            typeof(BasicModel).Namespace,
                            "T4TS");
                    })
                    .Edit((builder) =>
                    {
                        builder.OutputSettings.OrderInterfacesByReference = true;
                        builder.TraverserSettings.ResolveReferences = true;
                    })
                    .ToEqual(ExpectedOutputReferenceOrder);
        }


        const string ExpectedOutput =
@"/****************************************************************************
  Generated by T4TS.tt - don't make any changes in this file
****************************************************************************/

declare module External {
    /** Generated from T4TS.Example.Models.ModelFromDifferentProject */
    export interface ModelFromDifferentProject {
        Id: number;
    }
}

declare module T4TS {
    /** Generated from T4TS.Tests.Fixtures.Basic.BasicModel */
    export interface BasicModel {
        MyProperty: number;
        SomeDateTime: string;
    }
    /** Generated from T4TS.Tests.Fixtures.Inheritance.InheritanceModel */
    export interface InheritanceModel extends T4TS.OtherInheritanceModel {
        OnInheritanceModel: T4TS.BasicModel;
    }
    /** Generated from T4TS.Tests.Fixtures.Inheritance.OtherInheritanceModel */
    export interface OtherInheritanceModel extends External.ModelFromDifferentProject {
        OnOtherInheritanceModel: T4TS.BasicModel;
    }
}
";
        const string ExpectedOutputReferenceOrder = @"/****************************************************************************
  Generated by T4TS.tt - don't make any changes in this file
****************************************************************************/

declare module External {
    /** Generated from T4TS.Example.Models.ModelFromDifferentProject */
    export interface ModelFromDifferentProject {
        Id: number;
    }
}

declare module T4TS {
    /** Generated from T4TS.Tests.Fixtures.Inheritance.OtherInheritanceModel */
    export interface OtherInheritanceModel extends External.ModelFromDifferentProject {
        OnOtherInheritanceModel: T4TS.BasicModel;
    }
    /** Generated from T4TS.Tests.Fixtures.Basic.BasicModel */
    export interface BasicModel {
        MyProperty: number;
        SomeDateTime: string;
    }
    /** Generated from T4TS.Tests.Fixtures.Inheritance.InheritanceModel */
    export interface InheritanceModel extends T4TS.OtherInheritanceModel {
        OnInheritanceModel: T4TS.BasicModel;
    }
}";


    }
}
