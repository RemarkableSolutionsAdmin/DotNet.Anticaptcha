﻿using AntiCaptchaApi.Net.Internal.Extensions;
using AntiCaptchaApi.Net.Internal.Serializers.Base;
using AntiCaptchaApi.Net.Models.Solutions;
using AntiCaptchaApi.Net.Requests;
using AntiCaptchaApi.Net.Requests.Abstractions;
using Newtonsoft.Json.Linq;

namespace AntiCaptchaApi.Net.Internal.Serializers;

internal  class FunCaptchaRequestProxylessSerializer : CaptchaRequestSerializer<FunCaptchaRequestProxyless, FunCaptchaSolution>
{
    public override string TypeName => "FunCaptchaTaskProxyless";

    public override JObject Serialize(FunCaptchaRequestProxyless request) =>
        base.Serialize(request)
            .With("websiteURL", request.WebsiteUrl)
            .With("websitePublicKey", request.WebsitePublicKey)
            .With("funcaptchaApiJSSubdomain", request.FunCaptchaApiJsSubdomain)
            .With("data", request.Data);
}