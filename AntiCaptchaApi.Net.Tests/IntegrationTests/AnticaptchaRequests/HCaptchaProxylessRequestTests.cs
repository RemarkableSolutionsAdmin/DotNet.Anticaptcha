﻿using System.Threading.Tasks;
using AntiCaptchaApi.Models.Solutions;
using AntiCaptchaApi.Requests;
using AntiCaptchaApi.Responses;
using AntiCaptchaApi.Tests.Helpers;
using Xunit;

namespace AntiCaptchaApi.Tests.IntegrationTests.AnticaptchaRequests
{
    public class HCaptchaProxylessRequestTests : AnticaptchaTestBase
    {
        [Fact]
        public void ShouldReturnCorrectCaptchaResult_WhenCallingAuthenticRequest()
        {
            var request = new HCaptchaProxylessRequest()
            {
                WebsiteUrl = "https://entwickler.ebay.de/signin?tab=register",
                WebsiteKey = "195eeb9f-8f50-4a9c-abfc-a78ceaa3cdde",
                UserAgent = TestEnvironment.UserAgent
            };
            
            TestCaptchaRequest(request, out TaskResultResponse<HCaptchaSolution> taskResultResponse);
            AssertHelper.NotNullNotEmpty(taskResultResponse.Solution.GRecaptchaResponse);
        }
    }
}