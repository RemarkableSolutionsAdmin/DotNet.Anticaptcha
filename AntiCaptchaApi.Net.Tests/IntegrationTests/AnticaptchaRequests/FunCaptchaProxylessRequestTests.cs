﻿using System.Threading.Tasks;
using AntiCaptchaApi.Net.Models.Solutions;
using AntiCaptchaApi.Net.Requests;
using AntiCaptchaApi.Net.Requests.Abstractions;
using AntiCaptchaApi.Net.Responses;
using AntiCaptchaApi.Net.Tests.IntegrationTests.Base;
using Xunit;

namespace AntiCaptchaApi.Net.Tests.IntegrationTests.AnticaptchaRequests;

public class FunCaptchaProxylessRequestTests : AnticaptchaRequestTestBase<FunCaptchaSolution>
{
    private const string FunCaptchaUriExample = "https://api.funcaptcha.com/fc/api/nojs/?pkey=69A21A01-CC7B-B9C6-0F9A-E7FA06677FFC";

    protected override FunCaptchaProxylessRequest CreateAuthenticRequest() =>
        new()
        {
            WebsiteUrl = FunCaptchaUriExample,
            WebsitePublicKey = "69A21A01-CC7B-B9C6-0F9A-E7FA06677FFC",
            FunCaptchaApiJsSubdomain = "test",
            Data = "test",
        };

    [Fact]
    public async Task ShouldReturnCorrectCaptchaResult_WhenCallingAuthenticRequest()
    {
        await TestAuthenticRequest();
    }

    protected override void AssertTaskResult(TaskResultResponse<FunCaptchaSolution> taskResult)
    {
        Assert.NotNull(taskResult.Solution);
        Assert.NotNull(taskResult.Solution.Token);
    }
}