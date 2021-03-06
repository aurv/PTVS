﻿/* ****************************************************************************
 *
 * Copyright (c) Microsoft Corporation. 
 *
 * This source code is subject to terms and conditions of the Apache License, Version 2.0. A 
 * copy of the license can be found in the License.html file at the root of this distribution. If 
 * you cannot locate the Apache License, Version 2.0, please send an email to 
 * vspython@microsoft.com. By using this source code in any fashion, you are agreeing to be bound 
 * by the terms of the Apache License, Version 2.0.
 *
 * You must not remove this notice, or any other, from this software.
 *
 * ***************************************************************************/

using Microsoft.PythonTools.Interpreter;
using Microsoft.PythonTools.Parsing.Ast;

namespace Microsoft.PythonTools.Analysis.Values {
    class ListBuiltinClassInfo : SequenceBuiltinClassInfo {
        public ListBuiltinClassInfo(IPythonType classObj, PythonAnalyzer projectState)
            : base(classObj, projectState) {
        }

        internal override SequenceInfo MakeFromIndexes(Node node, ProjectEntry entry) {
            if (_indexTypes.Count > 0) {
                var vals = new[] { new VariableDef() };
                vals[0].AddTypes(entry, _indexTypes, false);
                return new ListInfo(vals, this, node, entry);
            } else {
                return new ListInfo(VariableDef.EmptyArray, this, node, entry);
            }
        }
    }
}
