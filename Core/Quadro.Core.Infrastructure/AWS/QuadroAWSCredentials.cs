using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;

namespace Quadro.Core.Infrastructure.AWS;

public sealed class QuadroAWSCredentials
{
    public static AWSCredentials GetAWSCredentials()
    {
        var chain = new CredentialProfileStoreChain();

        AWSCredentials awsCredentials;
        chain.TryGetAWSCredentials("quadro-dotnet-profile", out awsCredentials);
        if (awsCredentials == null)
        {
            throw new ArgumentNullException("Quadro aws credentials not found!");
        }

        return awsCredentials;
    }

}