# SCILL.Api.AuthApi

All URIs are relative to *https://virtserver.swaggerhub.com/4Players-GmbH/scill-gaas/1.0.0*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GenerateAccessToken**](AuthApi.md#generateaccesstoken) | **POST** /api/v1/auth/access-token | Get an access token for any user identifier signed with the API-Key

<a name="generateaccesstoken"></a>
# **GenerateAccessToken**
> AccessToken GenerateAccessToken (ForeignUserIdentifier body)

Get an access token for any user identifier signed with the API-Key

### Example
```csharp
using System;
using System.Diagnostics;
using SCILL.Api;
using SCILL.Client;
using SCILL.Model;

namespace Example
{
    public class GenerateAccessTokenExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: oAuthNoScopes
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthApi();
            var body = new ForeignUserIdentifier(); // ForeignUserIdentifier | Foreign user identifier.

            try
            {
                // Get an access token for any user identifier signed with the API-Key
                AccessToken result = apiInstance.GenerateAccessToken(body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AuthApi.GenerateAccessToken: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**ForeignUserIdentifier**](ForeignUserIdentifier.md)| Foreign user identifier. | 

### Return type

[**AccessToken**](AccessToken.md)

### Authorization

[BearerAuth](../README.md#BearerAuth), [oAuthNoScopes](../README.md#oAuthNoScopes)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
