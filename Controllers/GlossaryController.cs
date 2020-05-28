using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BulletTrain;
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
            BulletTrainConfiguration configuration = new BulletTrainConfiguration()
            {
                ApiUrl = "http://localhost:8000/api/v1/",
                EnvironmentKey = "nx8GEprrr6gL5t3ckRUCfy"
            };

            BulletTrainClient bulletClient = new BulletTrainClient(configuration);
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