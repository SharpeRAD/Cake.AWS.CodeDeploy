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
        #region Constructor (1)
            /// <summary>
            /// Initializes a new instance of the <see cref="DeploySettings" /> class.
            /// </summary>
            public DeploySettings()
            {
                this.Region = RegionEndpoint.EUWest1;
                this.RevisionVersion = "";
            }
        #endregion





        #region Properties (4)
            /// <summary>
            /// The AWS Access Key ID
            /// </summary>
            public string AccessKey { get; set; }

            /// <summary>
            /// The AWS Secret Access Key.
            /// </summary>
            public string SecretKey { get; set; }
        
            internal AWSCredentials Credentials { get; set; }



            /// <summary>
            /// The endpoints available to AWS clients.
            /// </summary>
            public RegionEndpoint Region { get; set; }



            /// <summary>
            /// The name of the Amazon S3 bucket where the application revision is stored.
            /// </summary>
            public string RevisionBucket { get; set; }
        
            /// <summary>
            /// The name of the Amazon S3 object that represents the bundled artifacts for the application revision.
            /// </summary>
            public string RevisionKey { get; set; }
        
            /// <summary>
            /// A specific version of the Amazon S3 object that represents the bundled artifacts for the application revision.
            /// </summary>
            public string RevisionVersion { get; set; }
        #endregion
    }
}
