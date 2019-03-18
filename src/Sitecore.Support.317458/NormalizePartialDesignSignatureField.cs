namespace Sitecore.Support.XA.Foundation.Presentation.EventHandlers
{
  using Sitecore.Data.Events;
  using Sitecore.Data.Items;
  using Sitecore.Events;
  using Sitecore.XA.Foundation.Presentation.Extensions;
  using Sitecore.XA.Foundation.SitecoreExtensions;
  using Sitecore.XA.Foundation.SitecoreExtensions.Extensions;
  using System;

  public class NormalizePartialDesignSignatureField
  {
    public void OnItemCreated(object sender, EventArgs args)
    {
      if (!JobsHelper.IsPublishing())
      {
        Item item = Event.ExtractParameter<ItemCreatedEventArgs>(args, 0).Item;
        if (item != null && item.IsPartialDesign())
        {
          string normalizedName = item.Name.GetNormalizedName();
          using (new EditContext(item))
          {
            item[Sitecore.XA.Foundation.Presentation.Templates.PartialDesign.Fields.Signature] = normalizedName;
          }
        }
      }
    }
  }
}