#region Using Statements
using Amazon;
using Amazon.Runtime;
#endregion



namespace Cake.AWS.CodeDeploy
{
    /// <summary>
    /// The settings to use with downlad requests to Amazon CodeDeploy
    /// </summary>
    public class DeploySettings
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="DeploySettings" /> class.
        /// </summary>
        public DeploySettings()
        {
            this.Region = RegionEndpoint.EUWest1;

            this.S3Version = null;
        }
        #endregion





        #region Properties
        /// <summary>
        /// The AWS Access Key ID
        /// </summary>
        public string AccessKey { get; set; }

        /// <summary>
        /// The AWS Secret Access Key.
        /// </summary>
        public string SecretKey { get; set; }

        /// <summary>
        /// The AWS Session Token, if using temporary credentials.
        /// </summary>
        public string SessionToken { get; set; }

        internal AWSCredentials Credentials { get; set; }



        /// <summary>
        /// The endpoints available to AWS clients.
        /// </summary>
        public RegionEndpoint Region { get; set; }



        /// <summary>
        /// The name of the Amazon S3 bucket where the application revision is stored.
        /// </summary>
        public string S3Bucket { get; set; }
        
        /// <summary>
        /// The name of the Amazon S3 object that represents the bundled artifacts for the application revision.
        /// </summary>
        public string S3Key { get; set; }
        
        /// <summary>
        /// A specific version of the Amazon S3 object that represents the bundled artifacts for the application revision.
        /// </summary>
        public string S3Version { get; set; }
        #endregion
    }
}
