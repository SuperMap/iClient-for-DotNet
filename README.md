一、	产品简介
SuperMap iServer Connector for .NET 是一套基于微软 .NET 平台开发的 SDK 包，通过该产品可以快速的在 .NET 平台下访问 SuperMap iServer REST 服务。该产品满足了SuperMap iSever 用户进行 Web 扩展开发的需求，方便了 .NET 开发人员构建自定义应用系统，能极大的节约开发成本，缩短项目的开发周期。
SuperMap iServer Connector for .NET 作为新一代轻量级开发类库，以纯端的方式对接 SuperMap iServer REST 服务以及企业级的私有云 GIS服务，方便了 .NET 平台用户使用 SuperMap iServer REST 服务。用户可在 ASP.NET MVC 的应用系统中通过 SuperMap iServer Connector 访问服务；也可以通过扩展 SuperMap Deskpro .NET 的插件来访问 SuperMap iServer REST 服务；还可以结合开源的第三方客户端（如 GMap.NET,SharpMap,Mapsui 等）访问 SuperMap iServer REST 服务。这样，对于.NET 开发人员，降低了学习成本、提高了开发效率；对企业，则大大减少了应用GIS的开发成本。 
SuperMap iServer Connector for .NET 产品提供 .NET Framework SDK 有： .NET 2.0、.NET 3.5 和 .NET 4.0。 
此处提供的是产品的源码包，用户可以根据自己的需求进行相应的需求扩展。

产品包的获取：
http://support.supermap.com.cn/ProductCenter/DownloadCenter/ProductPlatform.aspx

二、	产品特点

1、	丰富的 GIS 功能接口
SuperMap iServer 6R（2012）产品提供了完善的 GIS 功能服务，包括地图服务、数据服务以及高级的空间分析服务和网络分析服务。SuperMap iServer Connector for .NET 开发包中提供相应的接口对接iServer提供的REST服务，主要包括：地图、面积/距离量算、地物查询、地物编辑、网络分析、空间分析功能接口。

2、	轻量级开发包
SuperMap iServer Connector for .NET 开发包只有300kb左右，并且只有两个dll，用户使用时只需引用SDK包提供的SuperMap.Connector.dll即可。

3、	SDK接口使用简单，文档接口说明详细
SuperMap iServer Connector for .NET 接口设计简单易用，用户只需根据接口约定的参数使用功能，而无需了解 iServer REST 服务的发布和使用规则。此外，iConnector 帮助文档对每个接口提供示范代码和详细说明，帮助用户快速熟悉接口使用方法。

4、	提供多种开发与部署方式
基于 .NET Framework 平台开发的 iConnector 能适应多种开发与部署方式，包括 WinForm、WPF、ASP.NET、WebService、WCF，同时 iConnector 还提供 Windows Phone OS 7.1版本的SDK包，满足了 Windows Phone 平台用户使用 iConnector 快速访问 iServer REST 服务的需求。图3展示了 Windows Phone模拟器访问 iServer 发布的地图服务。

5、	支持 SuperMap Cloud 云服务
iConnector 开发包中提供 CloudMap 接口用于对接 SuperMap Cloud 云地图服务，并且该接口与 iConnector 中的用于访问 iSevrer REST 服务的 Map 接口的使用方法相一致。
