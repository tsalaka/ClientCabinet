using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using RC.PublicationManager;
using RC.PublicationManager.PublicationModule.PublicationContent.Content;
using RC.PublicationManager.PublicationModule.PublicationContent.Menu;
using RC.PublicationManager.PublicationModule.PublicationContent.Page;
using RC.PublicationManager.PublicationModule.PublicationContent.SiteMap;
using RC.PublicationManager.PublicationModule.ServerSettings;

namespace RC.Publication.WcfService
{
	[ServiceContract(Namespace = "http://www.rencap.com/CMSAdmin/PublicationService")]
	public interface IPublicationService
	{
		[OperationContract]
		PublicationStatus PublishContentBlock(ContentBase content, PublicationServerSettings serverSettings);

		[OperationContract]
		PublicationStatus Publish(SiteMap sitemap, List<Page> pageList, PublicationServerSettings serverSettings);

		[OperationContract]
		PublicationStatus PublishPageContent(Page page, PublicationServerSettings serverSettings);
		
		[OperationContract]
		PublicationStatus PublishSystemFiles(PublicationServerSettings serverSettings);
		
		[OperationContract]
		PublicationStatus PublishSharedMenu(List<SharedMenu> sharedMenu, PublicationServerSettings serverSettings);
	}
}
