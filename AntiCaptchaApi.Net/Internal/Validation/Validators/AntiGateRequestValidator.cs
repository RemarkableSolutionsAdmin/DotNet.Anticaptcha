﻿using AntiCaptchaApi.Internal.Extensions;
using AntiCaptchaApi.Internal.Validation.Validators.Base;
using AntiCaptchaApi.Requests;

namespace AntiCaptchaApi.Internal.Validation.Validators;

public class AntiGateRequestValidator : CaptchaRequestValidator<AntiGateRequest>
{
    public override ValidationResult Validate(AntiGateRequest request) =>
        base.Validate(request)
            .ValidateIsNotNullOrEmpty(nameof(request.WebsiteUrl), request.WebsiteUrl)
            .ValidateIsNotNull(nameof(request.Variables), request.Variables)
            .ValidateIsNotNullOrEmpty(nameof(request.TemplateName), request.TemplateName)
            .ValidateOptionalProxy(request.ProxyConfig);
}