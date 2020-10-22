# SCILL.Model.BattlePass
## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**battle_pass_id** | **string** | The unique id of this battle pass. | 
**package_sku** | **string** | If you want to sell Battle Passes you can use this field to trigger in-app purchase products within your mobile app. You can set this value in the Admin Panel. | 
**name** | **string** | The name of the Battle Pass in the local language set in the request (see Setting Language). In the admin panel you can either create HTML content or plain text. | 
**description** | **string** | The description of the Battle Pass in the local language set in the request (see Setting Language). In the admin panel you can either create HTML content or plain text. | 
**truncated_description** | **string** | A short description in the local language you can use to teaser battle passes or implement “expand for more” functionality. | 
**image** | **string** | The mobile sized image name. For example you can use image and image_desktop to build a srcset in HTML or use them and size manually where you need them. | 
**image_desktop** | **string** | The desktop sized image name or URL | 
**battle_pass_start_date** | **string** | The date (in iso format) when the Battle Pass starts. Tracking begins once this date is passed. | 
**battle_pass_end_date** | **string** | The date (in iso format) when the Battle Pass ends. Tracking stops once the end is reached and users will not be able to progress further than what they have achieved up to that point. | 
**read_more_link** | **string** | If the Battle Pass costs “money” you may want to route the user to a web site/page, where they can learn more about this battle pass. You can also use this field to route the user inside your application by providing a path or whatever works for you. | 
**page_id** | **string** | Another field you can set in the admin panel. SCILL Play uses this field to show a specific page by name. | 
**battle_pass_completed** | **bool?** | This option is not available in all requests. It indicates if the user has completed this Battle Pass. | [optional] 
**package_value_eur** | **string** | Price for the Battle Pass. You can set this field in the Admin Panel. Often it makes sense to use Pricing functionality of in-app purchase APIs in the relevant eco system (Steam, AppStore, Google Play Store) to request the price, but if you don’t have access to that, you can use this field. | [optional] 
**purchased_at** | **string** | The date in iso format when the user purchased/unlocked this Battle Pass. | [optional] 
**can_purchase_with_money** | **bool?** | Indicates that this Battle Pass can be purchased via in-app purchase. This can be set in the Admin Panel. | [optional] 
**can_purchase_with_coins** | **bool?** | Indicates that this Battle Pass can be purchased with SCILL Coins. This can be set in the Admin Panel. | [optional] 
**levels** | [**List&lt;BattlePassLevel&gt;**](BattlePassLevel.md) | An array of BattlePassLevel objects. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

