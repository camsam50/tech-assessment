using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CSharp.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class Test : ControllerBase
	{ 
		[HttpGet]
		public string Get()
		{
			return "Success!";
		}
		

		//What we would like to see from this exercise:
		//	Create order endpoint
		//	List all orders by customer endpoint
		//	Update order endpoint
		//	Cancel order endpoint
		//	Tests to prove your code works as expected







	}
}
