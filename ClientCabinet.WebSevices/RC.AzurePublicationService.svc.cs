using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using RC.Publication.AzureService.EndPoints.Config;
using RC.Publication.WcfService;
using RC.PublicationManager;
using RC.PublicationManager.Builder;
using RC.PublicationManager.Common.Utilities;
using RC.PublicationManager.PublicationModule.PublicationContent.Content;
using RC.PublicationManager.PublicationModule.PublicationContent.Menu;
using RC.PublicationManager.PublicationModule.PublicationContent.Page;
using RC.PublicationManager.PublicationModule.PublicationContent.SiteMap;
using RC.PublicationManager.PublicationModule.ServerSettings;


namespace RC.Publication.AzureService.EndPoints
{
	[ACSBehavior.PublicationServiceMessageInspectorBehavior(typeof(AppSettings.ACS))]
	[ServiceBehavior(Namespace = "http://www.rencap.com/CMSAdmin/PublicationService2")]
	public class AzurePublicationService : IPublicationService
	{
		public byte[] FtpFilePut(string path, string username, string password)
		{
			FtpManager fpt = new FtpManager(path, username, password);

			return fpt.GetFile("web.config");
		}

		public PublicationStatus PublishContentBlock(ContentBase content, PublicationServerSettings serverSettings, bool isForcePublication)
		{
			var builder = new AzurePublicationProcess(serverSettings) { IsForcePublication = isForcePublication };
			var director = new PublicationProcessDirector(builder);
			return director.PublishContentOnly(content);
		}

		public PublicationStatus Publish(SiteMap sitemap, List<Page> pageList, PublicationServerSettings serverSettings, bool isForcePublication)
		{
			AzurePublicationProcess builder = new AzurePublicationProcess(serverSettings) { IsForcePublication = isForcePublication }; ;
			var director = new PublicationProcessDirector(builder);
			return director.Publish(sitemap,pageList);
		}

		public PublicationStatus PublishPageContent(Page page, PublicationServerSettings serverSettings, bool isForcePublication)
		{
			var builder = new AzurePublicationProcess(serverSettings) { IsForcePublication = isForcePublication };
			var director = new PublicationProcessDirector(builder);
			return director.PublishPageWithContent(page);
		}

		public PublicationStatus PublishSystemFiles(PublicationServerSettings serverSettings)
		{
			var builder = new AzurePublicationProcess(serverSettings);
			var director = new PublicationProcessDirector(builder);
			return director.PublishSystemFiles();
		}
		
		public PublicationStatus PublishSharedMenu(List<SharedMenu> sharedMenu, PublicationServerSettings serverSettings, bool isForcePublication)
		{
			var builder = new AzurePublicationProcess(serverSettings) { IsForcePublication = isForcePublication };
			var director = new PublicationProcessDirector(builder);
			return director.PublishSharedMenu(sharedMenu);
		}
	}

	
}
