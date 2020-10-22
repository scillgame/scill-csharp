# SCILL.Model.BattlePassLevelChallenge
## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**challenge_goal** | **int?** | The number of things a user needs to achieve until this challenge is completed. | 
**name** | **string** | The name in the local language indicated what to do. | 
**current_challenge_amount** | **int?** | The current number of things the user already has achieved. Use this in combination with challenge_goal to calculate progress and to render a nice progress bar/indicator. | 
**completed** | **bool?** | Indicates if this challenge is completed. Once all challenges in a BattlePassLevel object are completed, the current level reward can be claimed and the next level is unlocked. | 
**active** | **bool?** | Indicates if the challenge is active, thus tracking progress. | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

