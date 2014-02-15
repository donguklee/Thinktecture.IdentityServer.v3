﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Specialized;
using Thinktecture.IdentityServer.Core;
using Thinktecture.IdentityServer.Core.Connect;
using Thinktecture.IdentityServer.Core.Services;

namespace UnitTests
{
    [TestClass]
    public class Authorize_ProtocolValidation_Valid
    {
        ILogger _logger = new DebugLogger();

        [TestMethod]
        [TestCategory("Protocol Validation")]
        public void Valid_OpenId_Code_Request()
        {
            var parameters = new NameValueCollection();
            parameters.Add(Constants.AuthorizeRequest.ClientId, "client");
            parameters.Add(Constants.AuthorizeRequest.Scope, "openid");
            parameters.Add(Constants.AuthorizeRequest.RedirectUri, "https://server/callback");
            parameters.Add(Constants.AuthorizeRequest.ResponseType, Constants.ResponseTypes.Code);

            var validator = new AuthorizeRequestValidator(null, _logger);
            var result = validator.ValidateProtocol(parameters);

            Assert.AreEqual(false, result.IsError);
        }

        [TestMethod]
        [TestCategory("Protocol Validation")]
        public void Valid_Resource_Code_Request()
        {
            var parameters = new NameValueCollection();
            parameters.Add(Constants.AuthorizeRequest.ClientId, "client");
            parameters.Add(Constants.AuthorizeRequest.Scope, "resource");
            parameters.Add(Constants.AuthorizeRequest.RedirectUri, "https://server/callback");
            parameters.Add(Constants.AuthorizeRequest.ResponseType, Constants.ResponseTypes.Code);

            var validator = new AuthorizeRequestValidator(null, _logger);
            var result = validator.ValidateProtocol(parameters);

            Assert.AreEqual(false, result.IsError);
        }

        [TestMethod]
        [TestCategory("Protocol Validation")]
        public void Valid_Mixed_Code_Request()
        {
            var parameters = new NameValueCollection();
            parameters.Add(Constants.AuthorizeRequest.ClientId, "client");
            parameters.Add(Constants.AuthorizeRequest.Scope, "openid resource");
            parameters.Add(Constants.AuthorizeRequest.RedirectUri, "https://server/callback");
            parameters.Add(Constants.AuthorizeRequest.ResponseType, Constants.ResponseTypes.Code);

            var validator = new AuthorizeRequestValidator(null, _logger);
            var result = validator.ValidateProtocol(parameters);

            Assert.AreEqual(false, result.IsError);
        }

        [TestMethod]
        [TestCategory("Protocol Validation")]
        public void Valid_Resource_Token_Request()
        {
            var parameters = new NameValueCollection();
            parameters.Add(Constants.AuthorizeRequest.ClientId, "client");
            parameters.Add(Constants.AuthorizeRequest.Scope, "resource");
            parameters.Add(Constants.AuthorizeRequest.RedirectUri, "https://server/callback");
            parameters.Add(Constants.AuthorizeRequest.ResponseType, Constants.ResponseTypes.Token);

            var validator = new AuthorizeRequestValidator(null, _logger);
            var result = validator.ValidateProtocol(parameters);

            Assert.AreEqual(false, result.IsError);
        }

        [TestMethod]
        [TestCategory("Protocol Validation")]
        public void Mixed_Token_Request()
        {
            var parameters = new NameValueCollection();
            parameters.Add(Constants.AuthorizeRequest.ClientId, "client");
            parameters.Add(Constants.AuthorizeRequest.Scope, "openid resource");
            parameters.Add(Constants.AuthorizeRequest.RedirectUri, "https://server/callback");
            parameters.Add(Constants.AuthorizeRequest.ResponseType, Constants.ResponseTypes.Token);

            var validator = new AuthorizeRequestValidator(null, _logger);
            var result = validator.ValidateProtocol(parameters);

            Assert.AreEqual(true, result.IsError);
            Assert.AreEqual(ErrorTypes.Client, result.ErrorType);
        }
        

        [TestMethod]
        [TestCategory("Protocol Validation")]
        public void Valid_OpenId_IdToken_Request()
        {
            var parameters = new NameValueCollection();
            parameters.Add(Constants.AuthorizeRequest.ClientId, "client");
            parameters.Add(Constants.AuthorizeRequest.Scope, "openid");
            parameters.Add(Constants.AuthorizeRequest.RedirectUri, "https://server/callback");
            parameters.Add(Constants.AuthorizeRequest.ResponseType, Constants.ResponseTypes.IdToken);
            parameters.Add(Constants.AuthorizeRequest.Nonce, "abc");

            var validator = new AuthorizeRequestValidator(null, _logger);
            var result = validator.ValidateProtocol(parameters);

            Assert.AreEqual(false, result.IsError);
        }

        [TestMethod]
        [TestCategory("Protocol Validation")]
        public void Valid_Mixed_IdToken_Request()
        {
            var parameters = new NameValueCollection();
            parameters.Add(Constants.AuthorizeRequest.ClientId, "client");
            parameters.Add(Constants.AuthorizeRequest.Scope, "openid resource");
            parameters.Add(Constants.AuthorizeRequest.RedirectUri, "https://server/callback");
            parameters.Add(Constants.AuthorizeRequest.ResponseType, Constants.ResponseTypes.IdToken);
            parameters.Add(Constants.AuthorizeRequest.Nonce, "abc");

            var validator = new AuthorizeRequestValidator(null, _logger);
            var result = validator.ValidateProtocol(parameters);

            Assert.AreEqual(false, result.IsError);
        }

        [TestMethod]
        [TestCategory("Protocol Validation")]
        public void Valid_OpenId_IdTokenToken_Request()
        {
            var parameters = new NameValueCollection();
            parameters.Add(Constants.AuthorizeRequest.ClientId, "client");
            parameters.Add(Constants.AuthorizeRequest.Scope, Constants.StandardScopes.OpenId);
            parameters.Add(Constants.AuthorizeRequest.RedirectUri, "https://server/callback");
            parameters.Add(Constants.AuthorizeRequest.ResponseType, Constants.ResponseTypes.IdTokenToken);
            parameters.Add(Constants.AuthorizeRequest.Nonce, "abc");

            var validator = new AuthorizeRequestValidator(null, _logger);
            var result = validator.ValidateProtocol(parameters);

            Assert.AreEqual(false, result.IsError);
        }

        [TestMethod]
        [TestCategory("Protocol Validation")]
        public void Valid_Mixed_IdTokenToken_Request()
        {
            var parameters = new NameValueCollection();
            parameters.Add(Constants.AuthorizeRequest.ClientId, "client");
            parameters.Add(Constants.AuthorizeRequest.Scope, "openid resource");
            parameters.Add(Constants.AuthorizeRequest.RedirectUri, "https://server/callback");
            parameters.Add(Constants.AuthorizeRequest.ResponseType, Constants.ResponseTypes.IdTokenToken);
            parameters.Add(Constants.AuthorizeRequest.Nonce, "abc");

            var validator = new AuthorizeRequestValidator(null, _logger);
            var result = validator.ValidateProtocol(parameters);

            Assert.AreEqual(false, result.IsError);
        }

        [TestMethod]
        [TestCategory("Protocol Validation")]
        public void Valid_OpenId_IdToken_With_FormPost_ResponseMode_Request()
        {
            var parameters = new NameValueCollection();
            parameters.Add(Constants.AuthorizeRequest.ClientId, "client");
            parameters.Add(Constants.AuthorizeRequest.Scope, Constants.StandardScopes.OpenId);
            parameters.Add(Constants.AuthorizeRequest.RedirectUri, "https://server/callback");
            parameters.Add(Constants.AuthorizeRequest.ResponseType, Constants.ResponseTypes.IdToken);
            parameters.Add(Constants.AuthorizeRequest.ResponseMode, Constants.ResponseModes.FormPost);
            parameters.Add(Constants.AuthorizeRequest.Nonce, "abc");

            var validator = new AuthorizeRequestValidator(null, _logger);
            var result = validator.ValidateProtocol(parameters);

            Assert.AreEqual(false, result.IsError);
        }
    }
}