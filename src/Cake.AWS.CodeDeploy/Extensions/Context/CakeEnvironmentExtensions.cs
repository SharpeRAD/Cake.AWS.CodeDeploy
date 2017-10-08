#region Using Statements
using System;

using Cake.Core;

using Amazon;
using Amazon.Runtime;
#endregion



namespace Cake.AWS.CodeDeploy
{
    /// <summary>
    /// Contains extension methods for <see cref="ICakeEnvironment" />.
    /// </summary>
    public static class CakeEnvironmentExtensions
    {
        /// <summary>
        /// Helper method to get the AWS Credentials from environment variables
        /// </summary>
        /// <param name="environment">The cake environment.</param>
        /// <returns>A new <see cref="DeploySettings"/> instance to be used in calls to the <see cref="IDeployManager"/>.</returns>
        public static DeploySettings CreateDeploySettings(this ICakeEnvironment environment)
        {
            if (environment == null)
            {
                throw new ArgumentNullException("environment");
            }

            DeploySettings settings = new DeploySettings();



            //AWS Fallback
            AWSCredentials creds = FallbackCredentialsFactory.GetCredentials();

            if (creds != null)
            {
                settings.Credentials = creds;
            }



            //Environment Variables
            string region = environment.GetEnvironmentVariable("AWS_REGION");

            if (!String.IsNullOrEmpty(region))
            {
                settings.Region = RegionEndpoint.GetBySystemName(region);
            }

            return settings;
        }
    }
}
