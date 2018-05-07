﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class ViewLayoutAttribute : ResultFilterAttribute
{
	private string layout;
	public ViewLayoutAttribute(string layout)
	{
		this.layout = layout;
	}

	public override void OnResultExecuting(ResultExecutingContext context)
	{
		var viewResult = context.Result as ViewResult;
		if (viewResult != null)
		{
			viewResult.ViewData["Layout"] = this.layout;
		}
	}
}

