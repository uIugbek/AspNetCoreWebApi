using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PortfolioBackend.Core.Controllers;
using PortfolioBackend.Core.DAL;
using PortfolioBackend.Models.ViewModels;
using PortfolioBackend.Core.BLL.Services;
using Microsoft.EntityFrameworkCore;
using PortfolioBackend;

namespace PortfolioBackend.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Route("api/dashboard/[controller]/[action]")]
    public class PermissionController : BaseEntityController<Permission, PermissionViewModel, PermissionService>
    {
        public IActionResult Get1()
        {
            IEnumerable<Permission> ents = null;
            using (var dbContext = new ApplicationDbContext())
            {
                ents = dbContext.Permissions.Include(a => a.Localizations).AsEnumerable();
            }
            //var ents = Service.AllAsQueryable.Include(a => a.Localizations);

            //var result = await ents.ToListAsync();
             var result = ents.Select(a => a.ConvertToModel<Permission, PermissionViewModel>());

            return Ok(result);
        }
    }
}
