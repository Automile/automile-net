namespace Automile.API.Types
{
    public enum ApiPublishSubscribeAuthenticationType : byte
    {
        NoneAnonymous = 0,
        BasicUsernameAndPassword = 1,
        BearerToken = 2,
        Salesforce = 3
    }
}
