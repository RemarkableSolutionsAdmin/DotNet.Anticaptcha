﻿using System.Threading.Tasks;
using RemarkableSolutions.Anticaptcha.Models.Solutions;
using RemarkableSolutions.Anticaptcha.Requests;
using RemarkableSolutions.Anticaptcha.Responses;
using RemarkableSolutions.Anticaptcha.Tests.Helpers;
using Xunit;

namespace RemarkableSolutions.Anticaptcha.Tests.IntegrationTests.AnticaptchaRequests
{
    public class ImageToTextRequestTests : AnticaptchaTestBase
    {
        private const string ExpectedCaptchaResult = "W68HP";

        private static ImageToTextRequest CreateImageToTextRequest(string? clientKey, string filePath = "")
        {
            return new ImageToTextRequest
            {
                ClientKey = clientKey ?? TestConfig.ClientKey,
                FilePath = filePath
            };
        }
        
        [Fact]
        public void ShouldReturnCorrectCaptchaResult_WhenCallingAuthenticRequest()
        {
            var request = CreateImageToTextRequest(null, filePath: "Resources\\captchaexample.png");
            TestCaptchaRequest(request, out TaskResultResponse<ImageToTextSolution> taskResult);
            AssertHelper.NotNullNotEmpty(taskResult.Solution.Url);
            AssertHelper.NotNullNotEmpty(taskResult.Solution.Text);
        }

        [Fact]
        public void ShouldReturnFalseWithCorrectException_WhenCallingWithIncorrectFilePath()
        {
            var request = CreateImageToTextRequest(null, filePath: "dsa.png");
            var result = AnticaptchaManager.CreateCaptchaTask(request);
            Assert.NotEmpty(result.ErrorDescription);
            Assert.Contains(nameof(ImageToTextRequest.BodyBase64), result.ErrorDescription);
        }
    }
}