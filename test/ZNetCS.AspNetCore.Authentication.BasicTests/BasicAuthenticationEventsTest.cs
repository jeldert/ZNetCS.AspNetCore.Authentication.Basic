﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BasicAuthenticationEventsTest.cs" company="Marcin Smółka zNET Computer Solutions">
//   Copyright (c) Marcin Smółka zNET Computer Solutions. All rights reserved.
// </copyright>
// <summary>
//   The basic authentication events test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ZNetCS.AspNetCore.Authentication.BasicTests
{
    #region Usings

    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using ZNetCS.AspNetCore.Authentication.Basic;
    using ZNetCS.AspNetCore.Authentication.Basic.Events;

    #endregion

    /// <summary>
    /// The basic authentication events test.
    /// </summary>
    public class BasicAuthenticationEventsTest : BasicAuthenticationEvents
    {
        #region Public Methods

        /// <inheritdoc/>
        public override Task ValidatePrincipalAsync(ValidatePrincipalContext context)
        {
            if ((context.UserName == "userName") && (context.Password == "password"))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, context.UserName, context.Options.ClaimsIssuer)
                };

                var principal = new ClaimsPrincipal(new ClaimsIdentity(claims, BasicAuthenticationDefaults.AuthenticationScheme));
                context.Principal = principal;
                context.AuthenticationFailMessage = null;
            }

            return Task.CompletedTask;
        }

        #endregion
    }
}