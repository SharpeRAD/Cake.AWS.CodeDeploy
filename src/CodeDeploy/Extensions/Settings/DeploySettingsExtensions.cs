#region Using Statements
    using System;

    using Amazon;
#endregion



namespace Cake.AWS.CodeDeploy
{
    /// <summary>
    /// Contains extension methods for <see cref="DeploySettings" />.
    /// </summary>
    public static class DeploySettingsExtensions
    {
        /// <summary>
        /// Specifies the AWS Access Key to use as credentials.
        /// </summary>
        /// <param name="settings">The LoadBalancing settings.</param>
        /// <param name="key">The AWS Access Key</param>
        /// <returns>The same <see cref="DeploySettings"/> instance so that multiple calls can be chained.</returns>
        public static DeploySettings SetAccessKey(this DeploySettings settings, string key)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            settings.AccessKey = key;
            return settings;
        }

        /// <summary>
        /// Specifies the AWS Secret Key to use as credentials.
        /// </summary>
        /// <param name="settings">The LoadBalancing settings.</param>
        /// <param name="key">The AWS Secret Key</param>
        /// <returns>The same <see cref="DeploySettings"/> instance so that multiple calls can be chained.</returns>
        public static DeploySettings SetSecretKey(this DeploySettings settings, string key)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            settings.SecretKey = key;
            return settings;
        }



        /// <summary>
        /// Specifies the endpoints available to AWS clients.
        /// </summary>
        /// <param name="settings">The LoadBalancing settings.</param>
        /// <param name="region">The endpoints available to AWS clients.</param>
        /// <returns>The same <see cref="DeploySettings"/> instance so that multiple calls can be chained.</returns>
        public static DeploySettings SetRegion(this DeploySettings settings, string region)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            settings.Region = RegionEndpoint.GetBySystemName(region);
            return settings;
        }

        /// <summary>
        /// Specifies the endpoints available to AWS clients.
        /// </summary>
        /// <param name="settings">The LoadBalancing settings.</param>
        /// <param name="region">The endpoints available to AWS clients.</param>
        /// <returns>The same <see cref="DeploySettings"/> instance so that multiple calls can be chained.</returns>
        public static DeploySettings SetRegion(this DeploySettings settings, RegionEndpoint region)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            settings.Region = region;
            return settings;
        }
    }
}
