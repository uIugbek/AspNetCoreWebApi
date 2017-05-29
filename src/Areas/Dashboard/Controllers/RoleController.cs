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

namespace PortfolioBackend.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Route("api/dashboard/[controller]/[action]")]
    public class RoleController : BaseEntityController<Role, RoleViewModel, RoleService>
    {
        //public override IActionResult Get()
        //{
        //    var query = Service.AllIncluding(a => a.Localizations);
        //    var result = query.Select(a => a.ConvertToModel<Role, RoleViewModel>());

        //    return Ok(result);
        //}

        public IActionResult GetSigle(int id)
        {
            Role ent = null;
            using (var dbContext = new ApplicationDbContext())
            {
                ent = dbContext.Roles.Include(a => a.Localizations).FirstOrDefault(a => a.Id == id);
            }
            //var ent = await Service.AllIncluding(a => a.Localizations)
                                   //.FirstOrDefaultAsync(a => a.Id == id);//.ByID(a => a.Id == id, a => a.Localizations);

            if (ent == null)
                return NotFound();

            RoleViewModel model = Activator.CreateInstance<RoleViewModel>();
            model.LoadEntity(ent);

            return Ok(model);
        }

        //public override IActionResult Update(int id, [FromBody] RoleViewModel model)
        //{
        //    using (var db = new ApplicationDbContext())
        //    {
        //        var ent = db.Roles.AsNoTracking().FirstOrDefault(a => a.Id == id);

        //        if (ent == null)
        //            return NotFound();

        //        var newEnt = model.UpdateEntity(ent);

        //        if (!ModelState.IsValid)
        //            return BadRequest(ModelState);

        //        db.Entry(ent).Context.Update(newEnt);
        //        db.SaveChanges();

        //        return Ok(newEnt);
        //    }
        //}
    }
}
