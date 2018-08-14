﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace ODataValidator.Rule
{
    #region Namespace
    using System;
    using System.Net;
    using System.ComponentModel.Composition;
    using ODataValidator.Rule.Helper;
    using ODataValidator.RuleEngine;
    #endregion

    /// <summary>
    /// Class of extension rule for Intermediate.Conformance.1005
    /// </summary>
    [Export(typeof(ExtensionRule))]
    public class IntermediateConformance1005 : ConformanceIntermediateExtensionRule
    {
        /// <summary>
        /// Gets rule name
        /// </summary>
        public override string Name
        {
            get
            {
                return "Intermediate.Conformance.1005";
            }
        }

        /// <summary>
        /// Gets rule description
        /// </summary>
        public override string Description
        {
            get
            {
                return "5. MUST support $top (section 11.2.5.3)";
            }
        }

        /// <summary>
        /// Gets rule specification in OData document
        /// </summary>
        public override string V4SpecificationSection
        {
            get
            {
                return "13.1.2";
            }
        }

        /// <summary>
        /// Verifies the extension rule.
        /// </summary>
        /// <param name="context">The Interop service context</param>
        /// <param name="info">out parameter to return violation information when rule does not pass</param>
        /// <returns>true if rule passes; false otherwise</returns>
        public override bool? Verify(ServiceContext context, out ExtensionRuleViolationInfo info)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            
            bool? passed = null;
            info = null;
            HttpStatusCode? statusCode = VerificationHelper.VerifyTop(context, out passed, out info);
            if (info != null)
            {
                info.SetDetailsName(this.Name);
            }

            return passed;
        }
    }
}
