using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace myapp.Controllers
{
    [Route( "api/v1/featuretoggle" )]
    [ApiController]
    public class FeatureToggleV1Controller : ControllerBase
    {
		[HttpGet]
		public ActionResult<List<FeatureToggleOptInDto>> GetAll()
		{
			var featureToggleOptIns = new List<FeatureToggleOptInDto>();
			featureToggleOptIns.Add( new FeatureToggleOptInDto() { FeatureName = "SL2Meetings", OptIn = true } );
			featureToggleOptIns.Add( new FeatureToggleOptInDto() { FeatureName = "SL2Monitoring", OptIn = true } );
			featureToggleOptIns.Add( new FeatureToggleOptInDto() { FeatureName = "Bogus1", OptIn = true } );
			return featureToggleOptIns;
		}
	}

	public class FeatureToggleOptInDto
	{
		public string FeatureName { get; set; }
		public bool OptIn { get; set; }
	}
}