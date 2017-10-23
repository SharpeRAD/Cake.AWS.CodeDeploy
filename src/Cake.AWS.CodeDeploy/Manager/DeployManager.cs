#region Using Statements
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

using Cake.Core;
using Cake.Core.Diagnostics;

using Amazon.CodeDeploy;
using Amazon.CodeDeploy.Model;
#endregion



namespace Cake.AWS.CodeDeploy
{
    /// <summary>
    /// Implementation for accessing CodeDeploy AWS CodeDeploy
    /// </summary>
    public class DeployManager : IDeployManager
    {
        #region Fields
        private readonly ICakeEnvironment _Environment;
        private readonly ICakeLog _Log;
        #endregion





        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="DeployManager" /> class.
        /// </summary>
        /// <param name="environment">The environment.</param>
        /// <param name="log">The log.</param>
        public DeployManager(ICakeEnvironment environment, ICakeLog log)
        {
            if (environment == null)
            {
                throw new ArgumentNullException("environment");
            }
            if (log == null)
            {
                throw new ArgumentNullException("log");
            }

            _Environment = environment;
            _Log = log;
        }
        #endregion





        #region Methods
        private AmazonCodeDeployClient CreateClient(DeploySettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }
                
            if (settings.Region == null)
            {
                throw new ArgumentNullException("settings.Region");
            }

            if (settings.Credentials == null)
            {
                if (String.IsNullOrEmpty(settings.AccessKey))
                {
                    throw new ArgumentNullException("settings.AccessKey");
                }
                if (String.IsNullOrEmpty(settings.SecretKey))
                {
                    throw new ArgumentNullException("settings.SecretKey");
                }

                return new AmazonCodeDeployClient(settings.AccessKey, settings.SecretKey, settings.Region);
            }
            else
            {
                return new AmazonCodeDeployClient(settings.Credentials, settings.Region);
            }
        }



        /// <summary>
        /// Deploys an application revision through the specified deployment group.
        /// </summary>
        /// <param name="applicationName">The name of an AWS CodeDeploy application associated with the applicable IAM user or AWS account.</param>
        /// <param name="deploymentGroup">The name of the deployment group.</param>
        /// <param name="settings">The <see cref="DeploySettings"/> used during the request to AWS.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public async Task<bool> CreateDeployment(string applicationName, string deploymentGroup, DeploySettings settings, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (String.IsNullOrEmpty(applicationName))
            {
                throw new ArgumentNullException("applicationName");
            }
            if (String.IsNullOrEmpty(deploymentGroup))
            {
                throw new ArgumentNullException("deploymentGroup");
            }



            // Create Request
            AmazonCodeDeployClient client = this.CreateClient(settings);
            CreateDeploymentRequest request = new CreateDeploymentRequest();

            request.ApplicationName = applicationName;
            request.DeploymentGroupName = deploymentGroup;

            request.Revision = new RevisionLocation()
            {
                RevisionType = RevisionLocationType.S3,

                S3Location = new S3Location()
                {
                    BundleType = BundleType.Zip,

                    Bucket = settings.S3Bucket,
                    Key = settings.S3Key,
                    Version = settings.S3Version
                }
            };



            // Check Response
            CreateDeploymentResponse response = await client.CreateDeploymentAsync(request, cancellationToken);

            if (response.HttpStatusCode == HttpStatusCode.OK)
            {
                _Log.Verbose("Successfully deployed application '{0}'", applicationName);
                return true;
            }
            else
            {
                _Log.Error("Failed to deploy application '{0}'", applicationName);
                return false;
            }
        }

        /// <summary>
        /// Registers with AWS CodeDeploy a revision for the specified application.
        /// </summary>
        /// <param name="applicationName">The name of an AWS CodeDeploy application associated with the applicable IAM user or AWS account.</param>
        /// <param name="settings">The <see cref="DeploySettings"/> used during the request to AWS.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public async Task<bool> RegisterApplicationRevision(string applicationName, DeploySettings settings, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (String.IsNullOrEmpty(applicationName))
            {
                throw new ArgumentNullException("applicationName");
            }



            // Create Request
            AmazonCodeDeployClient client = this.CreateClient(settings);
            RegisterApplicationRevisionRequest request = new RegisterApplicationRevisionRequest();

            request.ApplicationName = applicationName;

            request.Revision = new RevisionLocation()
            {
                RevisionType = RevisionLocationType.S3,

                S3Location = new S3Location()
                {
                    BundleType = BundleType.Zip,

                    Bucket = settings.S3Bucket,
                    Key = settings.S3Key,
                    Version = settings.S3Version
                }
            };



            // Check Response
            RegisterApplicationRevisionResponse response = await client.RegisterApplicationRevisionAsync(request, cancellationToken);

            if (response.HttpStatusCode == HttpStatusCode.OK)
            {
                _Log.Verbose("Successfully deployed application '{0}'", applicationName);
                return true;
            }
            else
            {
                _Log.Error("Failed to deploy application '{0}'", applicationName);
                return false;
            }
        }
        #endregion
    }
}