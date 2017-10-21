#region Using Statements
using System.Threading;
using System.Threading.Tasks;

using Cake.Core;
using Cake.Core.Annotations;
#endregion



namespace Cake.AWS.CodeDeploy
{
    /// <summary>
    /// Contains Cake aliases for configuring Amazon Elastic Computing instances
    /// </summary>
    [CakeAliasCategory("AWS")]
    [CakeNamespaceImport("Amazon")]
    [CakeNamespaceImport("Amazon.CodeDeploy")]
    public static class CodeDeployAliases
    {
        private static IDeployManager CreateManager(this ICakeContext context)
        {
            return new DeployManager(context.Environment, context.Log);
        }



        /// <summary>
        /// Deploys an application revision through the specified deployment group.
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="applicationName">The name of an AWS CodeDeploy application associated with the applicable IAM user or AWS account.</param>
        /// <param name="deploymentGroup">The name of the deployment group.</param>
        /// <param name="settings">The <see cref="DeploySettings"/> used during the request to AWS.</param>
        [CakeMethodAlias]
        [CakeAliasCategory("EC2")]
        public static async Task<bool> CreateDeployment(this ICakeContext context, string applicationName, string deploymentGroup, DeploySettings settings)
        {
            return await context.CreateManager().CreateDeployment(applicationName, deploymentGroup, settings);
        }

        /// <summary>
        /// Deploys an application revision through the specified deployment group.
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="applicationName">The name of an AWS CodeDeploy application associated with the applicable IAM user or AWS account.</param>
        /// <param name="deploymentGroup">The name of the deployment group.</param>
        /// <param name="settings">The <see cref="DeploySettings"/> used during the request to AWS.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        [CakeMethodAlias]
        [CakeAliasCategory("EC2")]
        public static async Task<bool> CreateDeployment(this ICakeContext context, string applicationName, string deploymentGroup, DeploySettings settings, CancellationToken cancellationToken)
        {
            return await context.CreateManager().CreateDeployment(applicationName, deploymentGroup, settings, cancellationToken);
        }



        /// <summary>
        /// Registers with AWS CodeDeploy a revision for the specified application.
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="applicationName">The name of an AWS CodeDeploy application associated with the applicable IAM user or AWS account.</param>
        /// <param name="settings">The <see cref="DeploySettings"/> used during the request to AWS.</param>
        [CakeMethodAlias]
        [CakeAliasCategory("EC2")]
        public static async Task<bool> RegisterApplicationRevision(this ICakeContext context, string applicationName, DeploySettings settings)
        {
            return await context.CreateManager().RegisterApplicationRevision(applicationName, settings);
        }

        /// <summary>
        /// Registers with AWS CodeDeploy a revision for the specified application.
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="applicationName">The name of an AWS CodeDeploy application associated with the applicable IAM user or AWS account.</param>
        /// <param name="settings">The <see cref="DeploySettings"/> used during the request to AWS.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        [CakeMethodAlias]
        [CakeAliasCategory("EC2")]
        public static async Task<bool> RegisterApplicationRevision(this ICakeContext context, string applicationName, DeploySettings settings, CancellationToken cancellationToken)
        {
            return await context.CreateManager().RegisterApplicationRevision(applicationName, settings, cancellationToken);
        }
    }
}