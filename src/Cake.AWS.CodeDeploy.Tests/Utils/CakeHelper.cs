#region Using Statements
using System.IO;

using Cake.Core;
using Cake.Core.IO;
using Cake.Testing;
#endregion



namespace Cake.AWS.CodeDeploy.Tests
{
    internal static class CakeHelper
    {
        #region Methods
        public static ICakeEnvironment CreateEnvironment()
        {
            var environment = FakeEnvironment.CreateWindowsEnvironment();
            environment.WorkingDirectory = Directory.GetCurrentDirectory();
            environment.WorkingDirectory = environment.WorkingDirectory.Combine("../../../");

            return environment;
        }



        public static IDeployManager CreateS3Manager()
        {
            return new DeployManager(CakeHelper.CreateEnvironment(), new DebugLog());
        }
        #endregion
    }
}
