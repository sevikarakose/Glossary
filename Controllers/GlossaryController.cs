using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace Glossary.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GlossaryController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<string>> Get()
        {
            var bulletClient = BulletTrain.BulletTrainClient.instance;
            
            bool featureEnabled = await bulletClient.HasFeatureFlag("show_feature");
            if (featureEnabled)
            {
                // Run the code to execute enabled feature
                return "show_feature is true";
            }
            else
            {
                // Run the code if feature switched off
                return "show_feature is false";
            }

        }
    }
}