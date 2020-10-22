# SCILL.Model.BattlePassLevel
## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**battle_pass_level_id** | **string** | Unique id of this BattlePassLevel object. | 
**level_priority** | **int?** | The position of the level inside the stack of levels. Every level in this array will have this value incremented by 1. | 
**completed** | **bool?** | Indicates if this level is completed, i.e. all challenges have been completed. | 
**can_claim** | **bool?** | If all challenges in this level have been completed and can be claimed, this flag is true. I.e. show a “Claim Reward” button if this is true. | 
**unlocked** | **bool?** | Levels need to be unlocked one after the other. You can decide if you already want to show users the challenges waiting behind a locked challenge or if you hide them to make it more exciting for the user to unlock the next level. | 
**claimed** | **bool?** | Indicates if the reward for this level has already been claimed. Important: Users need to claim the reward to unlock the next level! Of course, you can also do that via REST-API automatically. | 
**reward_description** | **string** | The description of the reward in the local language set in the request (see Setting Language). In the admin panel you can either create HTML content or plain text. | 
**reward_image** | **string** | The mobile sized image name of the reward. For example you can use reward_image and reward_image_desktop to build a srcset in HTML or use and size them manually where you need them. This can be freely set in the Admin Panel. Either indicates a local asset via name or you can also use a URL. | 
**reward_image_desktop** | **string** | The desktop sized image name of the reward. Either indicates a local asset via name or you can also use a URL. | 
**challenges** | [**List&lt;BattlePassLevelChallenge&gt;**](BattlePassLevelChallenge.md) | An array of BattlePassLevelChallenge objects. | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

