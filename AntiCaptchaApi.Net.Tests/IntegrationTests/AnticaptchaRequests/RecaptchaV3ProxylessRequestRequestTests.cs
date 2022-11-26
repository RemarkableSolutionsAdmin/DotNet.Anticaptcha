﻿using System.Threading.Tasks;
using AntiCaptchaApi.Net.Models.Solutions;
using AntiCaptchaApi.Net.Requests;
using AntiCaptchaApi.Net.Requests.Abstractions;
using AntiCaptchaApi.Net.Responses;
using AntiCaptchaApi.Net.Tests.Helpers;
using AntiCaptchaApi.Net.Tests.IntegrationTests.Base;
using Xunit;

namespace AntiCaptchaApi.Net.Tests.IntegrationTests.AnticaptchaRequests
{
    public class RecaptchaV3ProxylessRequestRequestTests : AnticaptchaRequestTestBase<RecaptchaSolution>
    {
        [Fact]
        public async Task ShouldReturnCorrectCaptchaResult_WhenCallingAuthenticRequest()
        {
            await TestAuthenticRequest();
        }

        protected override RecaptchaV3ProxylessRequest CreateAuthenticRequest()
        {
            return new RecaptchaV3ProxylessRequest()
            {
                WebsiteUrl = "https://www.netflix.com/login",
                WebsiteKey = "6Lf8hrcUAAAAAIpQAFW2VFjtiYnThOjZOA5xvLyR",
                IsEnterprise = true
            };
        }

        protected override void AssertTaskResult(TaskResultResponse<RecaptchaSolution> taskResult)
        {
            AssertHelper.NotNullNotEmpty(taskResult.Solution.GRecaptchaResponse);
        }
    }
}