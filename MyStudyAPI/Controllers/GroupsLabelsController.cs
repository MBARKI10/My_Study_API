using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using MyStudyAPI.Context;
using MyStudyAPI.Models;

namespace MyStudyAPI.Controllers
{
    public class GroupsLabelsController : ApiController
    {
        private SubgroupRepository repository = null;

        public GroupsLabelsController()
        {
            this.repository = new SubgroupRepository();
        }

        // GET: api/GroupsLabels
        public ICollection<string> GetSubgroups()
        {
            return this.repository.getSubgroupsLabel();
        }
    }
}