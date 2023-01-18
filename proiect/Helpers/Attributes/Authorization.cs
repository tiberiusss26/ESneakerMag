using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using proiect.Models;
using proiect.Models.Enums;

namespace proiect.Helpers.Attributes
{
	public class Authorization: Attribute, IAuthorizationFilter
	{
		private readonly ICollection<Role> _roles;

		public Authorization(params Role[] roles)
		{
			_roles = roles;
		}

        public void OnAuthorization(AuthorizationFilterContext context)
        {
			var unauthorizedStatudObject = new JsonResult(new { Message = "Unauthorized" }){ StatusCode = StatusCodes.Status401Unauthorized };

			if(_roles == null)
			{
				context.Result = unauthorizedStatudObject;
			}

			var user = (User)context.HttpContext.Items["User "];
			if(user==null ||!_roles.Contains(user.Role))
			{
				context.Result = unauthorizedStatudObject;
			}
        }
     }
}

