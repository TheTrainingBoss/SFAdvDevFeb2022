/* ------------------------------------------------------------------------------
<auto-generated>
    This file was generated by Sitefinity CLI v1.1.0.22
</auto-generated>
------------------------------------------------------------------------------ */

using Progress.Sitefinity.Renderer.Designers.Attributes;
using Progress.Sitefinity.Renderer.Entities.Content;
using SFAdvDev2022.Mvc.Models;
using System;
using System.Web.Mvc;
using Telerik.Sitefinity.Mvc;
using Telerik.Sitefinity.Personalization;

namespace SFAdvDev2022.Mvc.Controllers
{
	[ControllerToolboxItem(Name = "Nick", Title = "Nick", SectionName = "SFAdvDev2022")]
	public class NickController : Controller, IPersonalizable
	{
		// GET: Nick
		public ActionResult Index()
		{
			var model = new NickModel();
			model.Message = this.Message;
			model.Enum = this.Enum;
			model.Flag = this.Flag;
			model.MyDate = this.MyDate;
			model.Number = this.Number;
			return View(model);
		}
		
        protected override void HandleUnknownAction(string actionName)
        {
            this.ActionInvoker.InvokeAction(this.ControllerContext, "Index");
        }

		public string Message { get; set; }
		public bool Flag { get; set; }
		public Enumeration Enum { get; set; }
		public int Number { get; set; }
		public DateTime MyDate { get; set; }
		[Content(Type = KnownContentTypes.Pages)]
		public MixedContentContext Page { get; set; }
		[Content(Type = KnownContentTypes.Images)]
		public MixedContentContext Images { get; set; }
		[Content(Type = KnownContentTypes.Tags)]
		public MixedContentContext Tags { get; set; }
		[Content(Type = KnownContentTypes.News)]
		public MixedContentContext News { get; set; }
	}
}