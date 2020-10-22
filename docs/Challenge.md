# SCILL.Model.Challenge
## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**challenge_id** | **string** | The unique id of this challenge. Every challenge is linked to a product. | [optional] 
**challenge_name** | **string** | The name of the challenge in the language set by the language parameter. | [optional] 
**challenge_duration_time** | **int?** | The duration of the challenge in seconds. Challenges auto lock after time-out and need to be unlocked again. | [optional] 
**live_date** | **string** | The date this challenge should start. Use that field to create challenges that start in the future. | [optional] 
**challenge_goal** | **int?** | Indicates how many “tasks” must be completed or done to complete this challenge. | [optional] 
**user_challenge_current_score** | **int?** | Indicates how many tasks the user already has completed. Use this in combination with challenge_goal to render a nice progress bar. | [optional] 
**challenge_icon** | **string** | In the admin panel you can set a string representing an image. This can be a URL, but it can also be an image or texture that you have in your games asset database. | [optional] 
**challenge_icon_hd** | **string** | This is the HD variant of the challenge icon image. If you have a game, that runs on multiple platforms that could come in handy. Otherwise just leave blank. | [optional] 
**repeatable** | **bool?** | If this challenge can be only activated once per user this will be false. Otherwise this challenge will always be added to list of available challenges (see personal or alliance challenges). | [optional] 
**type** | **string** | Indicates the status of the challenge. This can be one of the following unlock: Challenge does not track anything. in-progress: Challenge is active and tracking. overtime: User did not manage to finish the challenge in time. unclaimed: The challenge has been completed but the reward has not yet been claimed. finished: The challenge has been successfully be completed and the reward has been claimed | [optional] 
**is_claimed** | **bool?** | If the challenge reward has been claimed this is true otherwise its false. | [optional] 
**user_challenge_unlocked_at** | **string** | This is the timestamp the challenge has been unlocked. | [optional] 
**user_challenge_activated_at** | **string** | This is the timestamp the challenge has been activated. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

