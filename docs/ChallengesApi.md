# SCILL.Api.ChallengesApi

All URIs are relative to *https://virtserver.swaggerhub.com/4Players-GmbH/scill-gaas/1.0.0*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ActivatePersonalChallenge**](ChallengesApi.md#activatepersonalchallenge) | **PUT** /api/v1/challenges/personal/activate/{appId}/{cid} | Activate a personal challenges
[**CancelPersonalChallenge**](ChallengesApi.md#cancelpersonalchallenge) | **PUT** /api/v1/challenges/personal/cancel/{appId}/{cid} | Cancel an active personal challenges
[**ClaimPersonalChallengeReward**](ChallengesApi.md#claimpersonalchallengereward) | **PUT** /api/v1/challenges/personal/claim/{appId}/{cid} | Claim the reward of a finished personal challenge
[**GenerateWebsocketAccessToken**](ChallengesApi.md#generatewebsocketaccesstoken) | **GET** /api/v1/challenges/web-socket/generate-token | Get an access token for the Websockets server notifying of updates in real time
[**GetActivePersonalChallenges**](ChallengesApi.md#getactivepersonalchallenges) | **GET** /api/v1/challenges/personal/get-in-progress-challenges/{appId} | Get active personal challenges
[**GetPersonalChallenges**](ChallengesApi.md#getpersonalchallenges) | **GET** /api/v1/challenges/personal/get/{appId} | Get personal challenges
[**UnlockPersonalChallenge**](ChallengesApi.md#unlockpersonalchallenge) | **POST** /api/v1/challenges/personal/unlock/{appId}/{cid} | Unlock a personal challenges

<a name="activatepersonalchallenge"></a>
# **ActivatePersonalChallenge**
> ActionResponse ActivatePersonalChallenge (string appId, string cid)

Activate a personal challenges

Activate a personal challenge by product id and user challenge id

### Example
```csharp
using System;
using System.Diagnostics;
using SCILL.Api;
using SCILL.Client;
using SCILL.Model;

namespace Example
{
    public class ActivatePersonalChallengeExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: oAuthNoScopes
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ChallengesApi();
            var appId = appId_example;  // string | The app id
            var cid = cid_example;  // string | The challenge id (see challenge_id of Challenge object)

            try
            {
                // Activate a personal challenges
                ActionResponse result = apiInstance.ActivatePersonalChallenge(appId, cid);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ChallengesApi.ActivatePersonalChallenge: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **appId** | **string**| The app id | 
 **cid** | **string**| The challenge id (see challenge_id of Challenge object) | 

### Return type

[**ActionResponse**](ActionResponse.md)

### Authorization

[BearerAuth](../README.md#BearerAuth), [oAuthNoScopes](../README.md#oAuthNoScopes)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="cancelpersonalchallenge"></a>
# **CancelPersonalChallenge**
> ActionResponse CancelPersonalChallenge (string appId, string cid)

Cancel an active personal challenges

Cancel an active personal challenge by product id and user challenge id

### Example
```csharp
using System;
using System.Diagnostics;
using SCILL.Api;
using SCILL.Client;
using SCILL.Model;

namespace Example
{
    public class CancelPersonalChallengeExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: oAuthNoScopes
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ChallengesApi();
            var appId = appId_example;  // string | The app id
            var cid = cid_example;  // string | The challenge id (see challenge_id of Challenge object)

            try
            {
                // Cancel an active personal challenges
                ActionResponse result = apiInstance.CancelPersonalChallenge(appId, cid);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ChallengesApi.CancelPersonalChallenge: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **appId** | **string**| The app id | 
 **cid** | **string**| The challenge id (see challenge_id of Challenge object) | 

### Return type

[**ActionResponse**](ActionResponse.md)

### Authorization

[BearerAuth](../README.md#BearerAuth), [oAuthNoScopes](../README.md#oAuthNoScopes)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="claimpersonalchallengereward"></a>
# **ClaimPersonalChallengeReward**
> ActionResponse ClaimPersonalChallengeReward (string appId, string cid)

Claim the reward of a finished personal challenge

Claim the reward of a finished personal challenge by product id and user challenge id

### Example
```csharp
using System;
using System.Diagnostics;
using SCILL.Api;
using SCILL.Client;
using SCILL.Model;

namespace Example
{
    public class ClaimPersonalChallengeRewardExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: oAuthNoScopes
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ChallengesApi();
            var appId = appId_example;  // string | The app id
            var cid = cid_example;  // string | The challenge id (see challenge_id of Challenge object)

            try
            {
                // Claim the reward of a finished personal challenge
                ActionResponse result = apiInstance.ClaimPersonalChallengeReward(appId, cid);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ChallengesApi.ClaimPersonalChallengeReward: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **appId** | **string**| The app id | 
 **cid** | **string**| The challenge id (see challenge_id of Challenge object) | 

### Return type

[**ActionResponse**](ActionResponse.md)

### Authorization

[BearerAuth](../README.md#BearerAuth), [oAuthNoScopes](../README.md#oAuthNoScopes)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="generatewebsocketaccesstoken"></a>
# **GenerateWebsocketAccessToken**
> SocketToken GenerateWebsocketAccessToken ()

Get an access token for the Websockets server notifying of updates in real time

Get an access token for the Websockets server notifying of updates in real time

### Example
```csharp
using System;
using System.Diagnostics;
using SCILL.Api;
using SCILL.Client;
using SCILL.Model;

namespace Example
{
    public class GenerateWebsocketAccessTokenExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: oAuthNoScopes
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ChallengesApi();

            try
            {
                // Get an access token for the Websockets server notifying of updates in real time
                SocketToken result = apiInstance.GenerateWebsocketAccessToken();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ChallengesApi.GenerateWebsocketAccessToken: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**SocketToken**](SocketToken.md)

### Authorization

[BearerAuth](../README.md#BearerAuth), [oAuthNoScopes](../README.md#oAuthNoScopes)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="getactivepersonalchallenges"></a>
# **GetActivePersonalChallenges**
> List<ChallengeCategory> GetActivePersonalChallenges (string appId)

Get active personal challenges

Get active personal challenges organized in categories

### Example
```csharp
using System;
using System.Diagnostics;
using SCILL.Api;
using SCILL.Client;
using SCILL.Model;

namespace Example
{
    public class GetActivePersonalChallengesExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: oAuthNoScopes
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ChallengesApi();
            var appId = appId_example;  // string | The app id

            try
            {
                // Get active personal challenges
                List&lt;ChallengeCategory&gt; result = apiInstance.GetActivePersonalChallenges(appId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ChallengesApi.GetActivePersonalChallenges: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **appId** | **string**| The app id | 

### Return type

[**List<ChallengeCategory>**](ChallengeCategory.md)

### Authorization

[BearerAuth](../README.md#BearerAuth), [oAuthNoScopes](../README.md#oAuthNoScopes)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="getpersonalchallenges"></a>
# **GetPersonalChallenges**
> List<ChallengeCategory> GetPersonalChallenges (string appId)

Get personal challenges

Get personal challenges organized in categories

### Example
```csharp
using System;
using System.Diagnostics;
using SCILL.Api;
using SCILL.Client;
using SCILL.Model;

namespace Example
{
    public class GetPersonalChallengesExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: oAuthNoScopes
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ChallengesApi();
            var appId = appId_example;  // string | The app id

            try
            {
                // Get personal challenges
                List&lt;ChallengeCategory&gt; result = apiInstance.GetPersonalChallenges(appId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ChallengesApi.GetPersonalChallenges: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **appId** | **string**| The app id | 

### Return type

[**List<ChallengeCategory>**](ChallengeCategory.md)

### Authorization

[BearerAuth](../README.md#BearerAuth), [oAuthNoScopes](../README.md#oAuthNoScopes)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="unlockpersonalchallenge"></a>
# **UnlockPersonalChallenge**
> ActionResponse UnlockPersonalChallenge (string appId, string cid)

Unlock a personal challenges

Unlock a personal challenge by product id and challenge id

### Example
```csharp
using System;
using System.Diagnostics;
using SCILL.Api;
using SCILL.Client;
using SCILL.Model;

namespace Example
{
    public class UnlockPersonalChallengeExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: oAuthNoScopes
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ChallengesApi();
            var appId = appId_example;  // string | The app id
            var cid = cid_example;  // string | The challenge id (see challenge_id of Challenge object)

            try
            {
                // Unlock a personal challenges
                ActionResponse result = apiInstance.UnlockPersonalChallenge(appId, cid);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ChallengesApi.UnlockPersonalChallenge: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **appId** | **string**| The app id | 
 **cid** | **string**| The challenge id (see challenge_id of Challenge object) | 

### Return type

[**ActionResponse**](ActionResponse.md)

### Authorization

[BearerAuth](../README.md#BearerAuth), [oAuthNoScopes](../README.md#oAuthNoScopes)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
