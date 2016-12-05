


namespace Cake.AWS.CodeDeploy
{
    /// <summary>
    /// Implementation for accessing CodeDeploy AWS CodeDeploy
    /// </summary>
    public interface IDeployManager
    {
        #region Functions (2)
            /// <summary>
            /// Deploys an application revision through the specified deployment group.
            /// </summary>
            /// <param name="applicationName">The name of an AWS CodeDeploy application associated with the applicable IAM user or AWS account.</param>
            /// <param name="deploymentGroup">The name of the deployment group.</param>
            /// <param name="settings">The <see cref="DeploySettings"/> used during the request to AWS.</param>
            bool CreateDeployment(string applicationName, string deploymentGroup, DeploySettings settings);



            /// <summary>
            /// Registers with AWS CodeDeploy a revision for the specified application.
            /// </summary>
            /// <param name="applicationName">The name of an AWS CodeDeploy application associated with the applicable IAM user or AWS account.</param>
            /// <param name="settings">The <see cref="DeploySettings"/> used during the request to AWS.</param>
            bool RegisterApplicationRevision(string applicationName, DeploySettings settings);
        #endregion
    }
}
