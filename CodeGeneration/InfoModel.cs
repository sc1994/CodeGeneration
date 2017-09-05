using System.Collections.Generic;

namespace CodeGeneration
{
    public class InfoModel
    {
        public static Info Info = "../../Info.json".GetFileText().ToObjectByJson<Info>();

        public static Dictionary<string, NuGetInfo> NuGetInfo =
            new Dictionary<string, NuGetInfo>
            {
                {
                    "Dapper",
                    new NuGetInfo
                    {
                        Reference = new ProjectItemGroupReference
                                    {
                                        Include = "Dapper, Version=1.50.2.0, Culture=neutral, processorArchitecture=MSIL",
                                        HintPath = @"..\packages\Dapper.1.50.2\lib\net451\Dapper.dll"
                                    },
                        Version = "1.50.2.0"
                    }
                },
                {
                    "Newtonsoft.Json",
                    new NuGetInfo
                    {
                        Reference = new ProjectItemGroupReference
                                    {
                                        Include = "Newtonsoft.Json",
                                        HintPath = @"..\packages\Newtonsoft.Json.10.0.3\lib\net45\Newtonsoft.Json.dll"
                                    },
                        Version = "10.0.3"
                    }
                },
                {
                    "System.configuration",
                    new NuGetInfo
                    {
                        Reference = new ProjectItemGroupReference
                                    {
                                        Include = "System.configuration"
                                    },
                        Version = ""
                    }
                },
                {
                    "System.Web.Mvc",
                    new NuGetInfo
                    {
                        Reference = new ProjectItemGroupReference
                                    {
                                        Include = "System.Web.Mvc, Version=5.2.3.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, processorArchitecture=MSIL",
                                        HintPath = @"..\packages\Microsoft.AspNet.Mvc.5.2.3\lib\net45\System.Web.Mvc.dll"
                                    },
                        Version = "5.2.3"
                    }
                },
                {
                    "Ninject",
                    new NuGetInfo
                    {
                        Reference = new ProjectItemGroupReference
                                    {
                                        Include = "Ninject, Version=3.2.0.0, Culture=neutral, PublicKeyToken=c7192dc5380945e7, processorArchitecture=MSIL",
                                        HintPath = @"..\packages\Ninject.3.2.2.0\lib\net45-full\Ninject.dll",
                                    },
                        Version = "3.2.2.0"
                    }
                },
                {
                    "Ninject.MVC",
                    new NuGetInfo
                    {
                        Version = "3.2.1.0"
                    }
                },
                {
                    "Ninject.MVC5",
                    new NuGetInfo
                    {
                        Version = "3.2.1.0"
                    }
                },
                {
                    "Ninject.Web.Common.WebHost",
                    new NuGetInfo
                    {
                        Version = "3.2.0.0"
                    }
                },
                {
                    "WebActivatorEx",
                    new NuGetInfo
                    {
                        Reference = new ProjectItemGroupReference
                                    {
                                        Include = "WebActivatorEx, Version=2.0.0.0, Culture=neutral, PublicKeyToken=7b26dc2a43f6a0d4, processorArchitecture=MSIL",
                                        HintPath = @"..\packages\WebActivatorEx.2.0\lib\net40\WebActivatorEx.dll"
                                    },
                        Version = "2.0"
                    }
                },
                {
                    "System.Diagnostics.DiagnosticSource",
                    new NuGetInfo
                    {
                        Reference = new ProjectItemGroupReference
                                    {
                                        Include = "System.Diagnostics.DiagnosticSource, Version=4.0.2.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51, processorArchitecture=MSIL",
                                        HintPath = @"..\packages\System.Diagnostics.DiagnosticSource.4.4.0\lib\net45\System.Diagnostics.DiagnosticSource.dll"
                                    },
                        Version = "4.4.0"
                    }
                },
                {
                    "Ninject.Web.Common",
                    new NuGetInfo
                    {
                        Reference = new ProjectItemGroupReference
                                    {
                                        Include = "Ninject.Web.Common, Version=3.2.0.0, Culture=neutral, PublicKeyToken=c7192dc5380945e7, processorArchitecture=MSIL",
                                        HintPath = @"..\packages\Ninject.Web.Common.3.2.3.0\lib\net45-full\Ninject.Web.Common.dll",
                                    },
                        Version = "3.2.3.0"
                    }
                },
                {
                    "Ninject.Web.WebApi",
                    new NuGetInfo
                    {
                        Reference = new ProjectItemGroupReference
                                    {
                                        Include = "Ninject.Web.WebApi, Version=3.2.0.0, Culture=neutral, PublicKeyToken=c7192dc5380945e7, processorArchitecture=MSIL",
                                        HintPath = @"..\packages\Ninject.Web.WebApi.3.2.4.0\lib\net45-full\Ninject.Web.WebApi.dll",
                                    },
                        Version = "3.2.0.0"
                    }
                },
                {
                    "System.Net.Http.Formatting",
                    new NuGetInfo
                    {
                        Reference = new ProjectItemGroupReference
                                    {
                                        Include = "System.Net.Http.Formatting",
                                        HintPath = @"..\packages\Microsoft.AspNet.WebApi.Client.5.2.3\lib\net45\System.Net.Http.Formatting.dll",
                                    },
                        Version = "5.2.3.0"
                    }
                },
                {
                    "System.Web.Http",
                    new NuGetInfo
                    {
                        Reference = new ProjectItemGroupReference
                                    {
                                        Include = "System.Web.Http",
                                        HintPath = @"..\packages\Microsoft.AspNet.WebApi.Core.5.2.3\lib\net45\System.Web.Http.dll",
                                    },
                        Version = "5.2.3.0"
                    }
                },
                {
                    "System.Web.Http.WebHost",
                    new NuGetInfo
                    {
                        Reference = new ProjectItemGroupReference
                                    {
                                        Include = "System.Web.Http",
                                        HintPath = @"..\packages\Microsoft.AspNet.WebApi.WebHost.5.2.3\lib\net45\System.Web.Http.WebHost.dll"
                                    },
                        Version = "5.2.3.0"
                    }
                },
                {
                    "Ninject.Web.Mvc",
                    new NuGetInfo
                    {
                        Reference = new ProjectItemGroupReference
                                    {
                                        Include = "Ninject.Web.Mvc, Version=3.2.0.0, Culture=neutral, PublicKeyToken=c7192dc5380945e7, processorArchitecture=MSIL",
                                        HintPath = @"..\packages\Ninject.MVC5.3.2.1.0\lib\net45-full\Ninject.Web.Mvc.dll",
                                    },
                        Version = "3.2.1.0"
                    }
                },
                {
                    "Microsoft.AspNet.WebApi.Client",
                    new NuGetInfo
                    {
                        Version = "5.2.3"
                    }
                },
                {
                    "Microsoft.AspNet.WebApi.Core",
                    new NuGetInfo
                    {
                        Version = "5.2.3"
                    }
                },
                {
                    "Microsoft.AspNet.WebPages",
                    new NuGetInfo
                    {
                        Version = "3.2.3"
                    }
                },
                {
                    "System.Web.Razor",
                    new NuGetInfo
                    {
                        Reference = new ProjectItemGroupReference
                                    {
                                        Include = "System.Web.Razor, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, processorArchitecture=MSIL",
                                        HintPath = @"..\packages\Microsoft.AspNet.Razor.3.2.3\lib\net45\System.Web.Razor.dll",
                                        Private = "True"
                                    },
                        Version = "3.2.3"
                    }
                },
                {
                    "System.Web.WebPages",
                    new NuGetInfo
                    {
                        Reference = new ProjectItemGroupReference
                                    {
                                        Include = "System.Web.WebPages, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, processorArchitecture=MSIL",
                                        HintPath = @"..\packages\Microsoft.AspNet.WebPages.3.2.3\lib\net45\System.Web.WebPages.dll",
                                        Private = "True"
                                    },
                        Version = "3.2.3"
                    }
                },
                {
                    "System.Web.WebPages.Deployment",
                    new NuGetInfo
                    {
                        Reference = new ProjectItemGroupReference
                                    {
                                        Include = "System.Web.WebPages.Deployment, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, processorArchitecture=MSIL",
                                        HintPath = @"..\packages\Microsoft.AspNet.WebPages.3.2.3\lib\net45\System.Web.WebPages.Deployment.dll"
                                    },
                        Version = "3.2.3"
                    }
                },
                {
                    "System.Web.WebPages.Razor",
                    new NuGetInfo
                    {
                        Reference = new ProjectItemGroupReference
                                    {
                                        Include = "System.Web.WebPages.Razor, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, processorArchitecture=MSIL",
                                        HintPath = @"..\packages\Microsoft.AspNet.WebPages.3.2.3\lib\net45\System.Web.WebPages.Razor.dll"
                                    },
                        Version = "3.2.3"
                    }
                },
                {
                    "Microsoft.AspNet.Mvc",
                    new NuGetInfo
                    {
                        Version = "5.2.3",
                    }
                },
                {
                    "Microsoft.AspNet.Razor",
                    new NuGetInfo
                    {
                        Version = "3.2.3",
                    }
                }
            };
    }
}
