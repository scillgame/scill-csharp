# SCILL.Api.EventsApi

All URIs are relative to *https://virtserver.swaggerhub.com/4Players-GmbH/scill-gaas/1.0.0*

Method | HTTP request | Description
------------- | ------------- | -------------
[**SendEvent**](EventsApi.md#sendevent) | **POST** /api/v1/events | Post an event

<a name="sendevent"></a>
# **SendEvent**
> ActionResponse SendEvent (EventPayload body)

Post an event

Post an event to the SCILL backend

### Example
```csharp
using System;
using System.Diagnostics;
using SCILL.Api;
using SCILL.Client;
using SCILL.Model;

namespace Example
{
    public class SendEventExample
    {
        public void main()
        {
            // Configure API key authorization: ApiKeyType
            Configuration.Default.AddApiKey("auth", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("auth", "Bearer");
            // Configure OAuth2 access token for authorization: oAuthNoScopes
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new EventsApi();
            var body = new EventPayload(); // EventPayload | Event payload

            try
            {
                // Post an event
                ActionResponse result = apiInstance.SendEvent(body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling EventsApi.SendEvent: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**EventPayload**](EventPayload.md)| Event payload | 

### Return type

[**ActionResponse**](ActionResponse.md)

### Authorization

[ApiKeyType](../README.md#ApiKeyType), [BearerAuth](../README.md#BearerAuth), [oAuthNoScopes](../README.md#oAuthNoScopes)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
