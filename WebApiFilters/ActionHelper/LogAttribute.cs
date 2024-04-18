using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;
using System.Web.Http.Controllers;



namespace WebApiFilters.ActionHelper
{

	public class LogAttribute : ActionFilterAttribute
	{
		public LogAttribute()
		{

		}

		public override void OnActionExecuting(ActionExecutingContext actionContext)
		{
			var descriptor = actionContext.ActionDescriptor as ControllerActionDescriptor;
			var actionName = descriptor.ActionName;
			var methodinfo = descriptor.MethodInfo;

			Debug.WriteLine(string.Format("Action Method {0} executing at {1}", actionName, DateTime.Now.ToShortDateString()), "Web API Logs");
		}

		public override void OnActionExecuted(ActionExecutedContext actionExecutedContext)
		{
			var descriptor = actionExecutedContext.ActionDescriptor as ControllerActionDescriptor;
			var actionName = descriptor.ActionName;
			var methodinfo = descriptor.MethodInfo;

			Debug.WriteLine(string.Format("Action Method {0} executed at {1}", actionName, DateTime.Now.ToShortDateString()), "Web API Logs");
		}
	}



	//Another Way
	//public class LogAttribute : Attribute, IActionFilter
	//{
	//	public LogAttribute()
	//	{

	//	}

	//	public Task<HttpResponseMessage> ExecuteActionFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
	//	{
	//		Trace.WriteLine(string.Format("Action Method {0} executing at {1}", actionContext.ActionDescriptor.ActionName, DateTime.Now.ToShortDateString()), "Web API Logs");

	//		var result = continuation();

	//		result.Wait();

	//		Trace.WriteLine(string.Format("Action Method {0} executed at {1}", actionContext.ActionDescriptor.ActionName, DateTime.Now.ToShortDateString()), "Web API Logs");

	//		return result;
	//	}

	//	public bool AllowMultiple
	//	{
	//		get { return true; }
	//	}
	//}

}
