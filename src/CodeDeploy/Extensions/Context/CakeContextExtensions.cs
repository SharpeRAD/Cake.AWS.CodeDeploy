#region Using Statements
    using System;

    using Cake.Core;
#endregion



namespace Cake.AWS.CodeDeploy
{
    /// <summary>
    /// Contains extension methods for <see cref="ICakeContext" />.
    /// </summary>
    public static class CakeContextExtensions
    {
        /// <summary>
        /// Helper method to get the AWS Credentials from environment variables
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <returns>A new <see cref="DeploySettings"/> instance to be used in calls to the <see cref="IDeployManager"/>.</returns>
        public static DeploySettings CreateDeploySettings(this ICakeContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            return context.Environment.CreateDeploySettings();
        }
    }
}
