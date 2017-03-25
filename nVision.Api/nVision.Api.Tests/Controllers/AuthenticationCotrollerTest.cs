using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using nVision.Api.Controllers;
using nVision.Api.Models.interfaces;
using nVision.Api.Models.responses;

namespace nVision.Api.Tests.Controllers
{
    [TestClass]
    public class AuthenticationCotrollerTest
    {
        private Mock<IAuthenticateWorkFlow> _authenticateWorkFlow;

        [TestInitialize]
        public void SetUp()
        {
            _authenticateWorkFlow = new Mock<IAuthenticateWorkFlow>();
        }

        [TestMethod]
        public void TestAuthenticatePass()
        {
            var controller = new AuthenticationController(_authenticateWorkFlow.Object);

            _authenticateWorkFlow.Setup(flow => flow.Authwnticate(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(new AuthenticationResponse
                {
                    Status = true,
                    ResponseMessage = "success"
                });

            var response = controller.Authenticate("{\"cardNumber\" : \"123456789\",	\"pin\" : \"1478\"}");

            Assert.AreEqual("success", response.ResponseMessage);
        }

        [TestMethod]
        public void TestAuthenticateFail()
        {
            var controller = new AuthenticationController(_authenticateWorkFlow.Object);

            _authenticateWorkFlow.Setup(flow => flow.Authwnticate(It.IsAny<string>(), It.IsAny<string>()))
                .Returns((new AuthenticationResponse
                {
                    Status = false,
                    ResponseMessage = "failed"
                }));

            var response = controller.Authenticate("{\"cardNumber\" : \"123456789\",	\"pin\" : \"1478\"}");

            Assert.AreEqual("failed", response.ResponseMessage);
        }


        [TestMethod]
        public void TestAuthenticateCardBlacked()
        {
            var controller = new AuthenticationController(_authenticateWorkFlow.Object);

            _authenticateWorkFlow.Setup(flow => flow.Authwnticate(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(new AuthenticationResponse
                    {Blocked = true, ResponseMessage = "failed", Status = false});

            var response = controller.Authenticate("{\"cardNumber\" : \"123456789\",	\"pin\" : \"1478\"}");

            Assert.AreEqual(true, response.Blocked);
        }
    }
}
