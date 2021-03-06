﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Gov.Lclb.Cllb.Public.Contexts;
using Gov.Lclb.Cllb.Public.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Gov.Lclb.Cllb.Public.Controllers
{
    [Route("api/[controller]")]
    public class PolicyDocumentController : Controller
    {
        private readonly IConfiguration Configuration;
        private readonly AppDbContext db;

        public PolicyDocumentController(AppDbContext db, IConfiguration configuration)
        {
            Configuration = configuration;
            this.db = db;
        }

        /// <summary>
        /// Get a list of all policy documents for a given category
        /// </summary>
        /// <param name="category">The policy document category</param>
        /// <returns></returns>
        [HttpGet()]
        [AllowAnonymous]
        public JsonResult GetPolicyDocuments(string category)
        {
            List<ViewModels.PolicyDocumentSummary> PolicyDocuments = null;
            if (string.IsNullOrEmpty(category))
            {
                PolicyDocuments = db.PolicyDocuments                
                .OrderBy(x => x.DisplayOrder)
                .Select(x => x.ToSummaryViewModel())
                .ToList();
            }
            else
            {
                PolicyDocuments = db.PolicyDocuments
                .Where(x => x.Category == category)
                .OrderBy(x => x.DisplayOrder)
                .Select(x => x.ToSummaryViewModel())
                .ToList();
            }
            
            return Json(PolicyDocuments);
        }

        /// <summary>
        /// Get a specific policy document
        /// </summary>
        /// <param name="slug"></param>
        /// <returns></returns>
        [HttpGet("{slug}")]
        [AllowAnonymous]
        public JsonResult GetPolicy(string slug)
        {
            PolicyDocument PolicyDocument = db.GetPolicyDocumentBySlug(slug);
            return Json(PolicyDocument.ToViewModel());
        }

    }
}
