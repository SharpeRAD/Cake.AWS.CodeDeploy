# Cake.AWS.CodeDeploy
Cake Build addin for Amazon CodeDeploy

[![Build status](https://ci.appveyor.com/api/projects/status/fdmccfihkycqd0lj?svg=true)](https://ci.appveyor.com/project/SharpeRAD/cake-aws-codedeploy)

[![cakebuild.net](https://img.shields.io/badge/WWW-cakebuild.net-blue.svg)](http://cakebuild.net/)

[![Join the chat at https://gitter.im/cake-build/cake](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/cake-build/cake)



## Table of contents

1. [Implemented functionality](https://github.com/SharpeRAD/Cake.AWS.CodeDeploy#implemented-functionality)
2. [Referencing](https://github.com/SharpeRAD/Cake.AWS.CodeDeploy#referencing)
3. [Usage](https://github.com/SharpeRAD/Cake.AWS.CodeDeploy#usage)
4. [Example](https://github.com/SharpeRAD/Cake.AWS.CodeDeploy#example)
5. [Plays well with](https://github.com/SharpeRAD/Cake.AWS.CodeDeploy#plays-well-with)
6. [License](https://github.com/SharpeRAD/Cake.AWS.CodeDeploy#license)
7. [Share the love](https://github.com/SharpeRAD/Cake.AWS.CodeDeploy#share-the-love)



## Implemented functionality

* Create Deployment
* Uses AWS fallback credentials (app.config / web.config file, SDK store or credentials file, environment variables, instance profile)



## Referencing

[![NuGet Version](http://img.shields.io/nuget/v/Cake.AWS.CodeDeploy.svg?style=flat)](https://www.nuget.org/packages/Cake.AWS.CodeDeploy/)

Cake.AWS.CodeDeploy is available as a nuget package from the package manager console:

```csharp
Install-Package Cake.AWS.CodeDeploy
```

or directly in your build script via a cake addin directive:

```csharp
#addin "Cake.AWS.CodeDeploy"
```



## Usage

```csharp
#addin "Cake.AWS.CodeDeploy"

Task("Create-Deployment")
    .Description("Deploys an application revision via AWS CodeDeploy.")
    .Does(() =>
{
    var settings = Context.CreateDeploySettings()

    settings.RevisionBucket = "company-deployments";
    settings.RevisionKey = "AwesomeApp.zip";

    CreateDeployment("MyApplication", "MyGroup", settings);
});

RunTarget("Create-Deployment");
```



## Example

A complete Cake example can be found [here](https://github.com/SharpeRAD/Cake.AWS.CodeDeploy/blob/master/test/build.cake).



## Plays well with

If your deploying websites to IIS its worth checking out [Cake.IIS](https://github.com/SharpeRAD/Cake.IIS) or if your deploying windows services check out [Cake.Services](https://github.com/SharpeRAD/Cake.Services).

If your looking for a way to trigger cake tasks based on windows events or at scheduled intervals then check out [CakeBoss](https://github.com/SharpeRAD/CakeBoss).



## License

Copyright (c) 2015 - 2016 Phillip Sharpe

Cake.AWS.CodeDeploy is provided as-is under the MIT license. For more information see [LICENSE](https://github.com/SharpeRAD/Cake.AWS.CodeDeploy/blob/master/LICENSE).



## Share the love

If this project helps you in anyway then please :star: the repository.
