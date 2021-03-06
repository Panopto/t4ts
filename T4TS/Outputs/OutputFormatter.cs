﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T4TS.Outputs;

namespace T4TS
{
    public static class OutputFormatter
    {
        public static string GetOutput(
            List<TypeScriptModule> modules,
            OutputSettings settings,
            TypeContext typeContext)
        {
            var output = new StringBuilder();
            
            output.AppendLine("/****************************************************************************");
            output.AppendLine("  Generated by T4TS.tt - don't make any changes in this file");
            output.AppendLine("****************************************************************************/");

            var moduleAppender = new ModuleOutputAppender(
                settings,
                typeContext);
            foreach (var module in modules)
            {
                output.AppendLine();
                moduleAppender.AppendOutput(
                    output,
                    0,
                    module);
            }

            return output.ToString();
        }
    }
}
