#region Using Statements
using System.Threading;
using System.Threading.Tasks;

using Amazon.CodeDeploy.Model;
#endregion



namespace Cake.AWS.CodeDeploy
{
    /// <summary>
    /// Implementation for accessing CodeDeploy AWS CodeDeploy
    /// </summary>
    public interface IDeployManager
    {
        #region Methods
        /// <summary>
        /// Deploys an application revision through the specified deployment group.
        /// </summary>
        /// <param name="applicationName">The name of an AWS CodeDeploy application associated with the applicable IAM user or AWS account.</param>
        /// <param name="deploymentGroup">The name of the deployment group.</param>
        /// <param name="settings">The <see cref="DeploySettings"/> used during the request to AWS.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        Task<bool> CreateDeployment(string applicationName, string deploymentGroup, DeploySettings settings, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the deployment info
        /// </summary>
        /// <param name="deploymentID">A deployment ID associated with the applicable IAM user or AWS account.</param>
        /// <param name="settings">The <see cref="DeploySettings"/> used during the request to AWS.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        Task<DeploymentInfo> GetDeploymentInfo(string deploymentID, DeploySettings settings, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Registers with AWS CodeDeploy a revision for the specified application.
        /// </summary>
        /// <param name="applicationName">The name of an AWS CodeDeploy application associated with the applicable IAM user or AWS account.</param>
        /// <param name="settings">The <see cref="DeploySettings"/> used during the request to AWS.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        Task<bool> RegisterApplicationRevision(string applicationName, DeploySettings settings, CancellationToken cancellationToken = default(CancellationToken));
        #endregion
    }
}
