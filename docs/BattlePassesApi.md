# SCILL.Api.BattlePassesApi

All URIs are relative to *https://virtserver.swaggerhub.com/4Players-GmbH/scill-gaas/1.0.0*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ClaimBattlePassLevelReward**](BattlePassesApi.md#claimbattlepasslevelreward) | **POST** /api/v1/battle-passes/{appId}/{bpid}/claim-level | Claim the reward of a finished personal challenge
[**GetBattlePass**](BattlePassesApi.md#getbattlepass) | **GET** /api/v1/battle-passes/{appId}/{bpid} | Get battle passe by id
[**GetBattlePasses**](BattlePassesApi.md#getbattlepasses) | **GET** /api/v1/battle-passes/{appId} | Get battle passes
[**UnlockBattlePassLevel**](BattlePassesApi.md#unlockbattlepasslevel) | **POST** /api/v1/battle-passes/{appId}/{bpid}/unlock | Unlock the level of a battle pass

<a name="claimbattlepasslevelreward"></a>
# **ClaimBattlePassLevelReward**
> ActionResponse ClaimBattlePassLevelReward (BattlePassLevelId body, string appId, string bpid)

Claim the reward of a finished personal challenge

Claim the reward of a battle pass level

### Example
```csharp
using System;
using System.Diagnostics;
using SCILL.Api;
using SCILL.Client;
using SCILL.Model;

namespace Example
{
    public class ClaimBattlePassLevelRewardExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: oAuthNoScopes
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new BattlePassesApi();
            var body = new BattlePassLevelId(); // BattlePassLevelId | Provide the battle pass level id in this payload.
            var appId = appId_example;  // string | The app id
            var bpid = bpid_example;  // string | The id of the battle pass. It’s the same as in battle_pass_id you received in earlier requests (i.e. getting all active battle passes for a product).

            try
            {
                // Claim the reward of a finished personal challenge
                ActionResponse result = apiInstance.ClaimBattlePassLevelReward(body, appId, bpid);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling BattlePassesApi.ClaimBattlePassLevelReward: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**BattlePassLevelId**](BattlePassLevelId.md)| Provide the battle pass level id in this payload. | 
 **appId** | **string**| The app id | 
 **bpid** | **string**| The id of the battle pass. It’s the same as in battle_pass_id you received in earlier requests (i.e. getting all active battle passes for a product). | 

### Return type

[**ActionResponse**](ActionResponse.md)

### Authorization

[BearerAuth](../README.md#BearerAuth), [oAuthNoScopes](../README.md#oAuthNoScopes)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="getbattlepass"></a>
# **GetBattlePass**
> BattlePass GetBattlePass (string appId, string bpid)

Get battle passe by id

Get battle pass for the product with id

### Example
```csharp
using System;
using System.Diagnostics;
using SCILL.Api;
using SCILL.Client;
using SCILL.Model;

namespace Example
{
    public class GetBattlePassExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: oAuthNoScopes
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new BattlePassesApi();
            var appId = appId_example;  // string | The app id
            var bpid = bpid_example;  // string | The id of the battle pass. It’s the same as in battle_pass_id you received in earlier requests (i.e. getting all active battle passes for a product).

            try
            {
                // Get battle passe by id
                BattlePass result = apiInstance.GetBattlePass(appId, bpid);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling BattlePassesApi.GetBattlePass: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **appId** | **string**| The app id | 
 **bpid** | **string**| The id of the battle pass. It’s the same as in battle_pass_id you received in earlier requests (i.e. getting all active battle passes for a product). | 

### Return type

[**BattlePass**](BattlePass.md)

### Authorization

[BearerAuth](../README.md#BearerAuth), [oAuthNoScopes](../README.md#oAuthNoScopes)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="getbattlepasses"></a>
# **GetBattlePasses**
> List<BattlePass> GetBattlePasses (string appId)

Get battle passes

Get battle passes for the product

### Example
```csharp
using System;
using System.Diagnostics;
using SCILL.Api;
using SCILL.Client;
using SCILL.Model;

namespace Example
{
    public class GetBattlePassesExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: oAuthNoScopes
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new BattlePassesApi();
            var appId = appId_example;  // string | The app id

            try
            {
                // Get battle passes
                List&lt;BattlePass&gt; result = apiInstance.GetBattlePasses(appId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling BattlePassesApi.GetBattlePasses: " + e.Message );
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

[**List<BattlePass>**](BattlePass.md)

### Authorization

[BearerAuth](../README.md#BearerAuth), [oAuthNoScopes](../README.md#oAuthNoScopes)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="unlockbattlepasslevel"></a>
# **UnlockBattlePassLevel**
> ActionResponse UnlockBattlePassLevel (BattlePassLevelId body, string appId, string bpid)

Unlock the level of a battle pass

Unlock a battle pass level

### Example
```csharp
using System;
using System.Diagnostics;
using SCILL.Api;
using SCILL.Client;
using SCILL.Model;

namespace Example
{
    public class UnlockBattlePassLevelExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: oAuthNoScopes
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new BattlePassesApi();
            var body = new BattlePassLevelId(); // BattlePassLevelId | Provide the battle pass level id in this payload
            var appId = appId_example;  // string | The app id
            var bpid = bpid_example;  // string | The id of the battle pass. It’s the same as in battle_pass_id you received in earlier requests (i.e. getting all active battle passes for a product).

            try
            {
                // Unlock the level of a battle pass
                ActionResponse result = apiInstance.UnlockBattlePassLevel(body, appId, bpid);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling BattlePassesApi.UnlockBattlePassLevel: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**BattlePassLevelId**](BattlePassLevelId.md)| Provide the battle pass level id in this payload | 
 **appId** | **string**| The app id | 
 **bpid** | **string**| The id of the battle pass. It’s the same as in battle_pass_id you received in earlier requests (i.e. getting all active battle passes for a product). | 

### Return type

[**ActionResponse**](ActionResponse.md)

### Authorization

[BearerAuth](../README.md#BearerAuth), [oAuthNoScopes](../README.md#oAuthNoScopes)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
