#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LeaveManagement.Web.Data;
using AutoMapper;
using LeaveManagement.Web.Models;
using LeaveManagement.Web.Contracts;
using Microsoft.AspNetCore.Authorization;
using LeaveManagement.Web.Constants;

namespace LeaveManagement.Web.Controllers
{
    [Authorize(Roles = Roles.Administrator)] //"Administrator")]
    public class LeaveTypesController : Controller
    {
        #region Sin Refactor
        //private readonly ApplicationDbContext _context;
        ////El mapeo lo hacemos con el fin de no interactuar con las clases originales del sistema
        //private readonly IMapper mapper;
        ////Inyecta la conexion a la base de datos por medio de _context y un mapper
        ////Dependency inversion
        //public LeaveTypesController(ApplicationDbContext context, IMapper mapper)
        //{
        //    _context = context;
        //    this.mapper = mapper;
        //}

        //// GET: LeaveTypes
        //public async Task<IActionResult> Index()
        //{
        //    //return View(await _context.LeaveTypes.ToListAsync());

        //    //Hace lo mismo que lo anterior pero se ve mas explicito, mapeando tambien al mismo tiempo de la consulta            
        //    var leaveTypes = mapper.Map<List<LeaveTypeVM>>(await _context.LeaveTypes.ToListAsync());
        //    return View(leaveTypes);
        //}

        //// GET: LeaveTypes/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    //if (id == null)
        //    //{
        //    //    return NotFound();
        //    //}

        //    //var leaveType = await _context.LeaveTypes
        //    //    .FirstOrDefaultAsync(m => m.Id == id);
        //    //if (leaveType == null)
        //    //{
        //    //    return NotFound();
        //    //}

        //    //return View(leaveType);

        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var leaveType = await _context.LeaveTypes.FindAsync(id);
        //    if (leaveType == null)
        //    {
        //        return NotFound();
        //    }

        //    //Convirte del tipo original al viewmodel
        //    var leaveTypeVM = mapper.Map<LeaveTypeVM>(leaveType);
        //    return View(leaveTypeVM);
        //}

        //// GET: LeaveTypes/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: LeaveTypes/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        ////public async Task<IActionResult> Create([Bind("Name,DefaultDays,Id,DateCreated,DateModified")] LeaveType leaveType)
        //public async Task<IActionResult> Create(LeaveTypeVM leaveTypeVM)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //Convirte del viewmodel al tipo original
        //        var leaveType = mapper.Map<LeaveType>(leaveTypeVM);
        //        _context.Add(leaveType);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(leaveTypeVM);
        //}

        //// GET: LeaveTypes/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var leaveType = await _context.LeaveTypes.FindAsync(id);
        //    if (leaveType == null)
        //    {
        //        return NotFound();
        //    }

        //    //Convirte del tipo original al viewmodel
        //    var leaveTypeVM = mapper.Map<LeaveTypeVM>(leaveType);
        //    return View(leaveTypeVM);
        //}

        //// POST: LeaveTypes/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        ////public async Task<IActionResult> Edit(int id, [Bind("Name,DefaultDays,Id,DateCreated,DateModified")] LeaveType leaveType)
        //public async Task<IActionResult> Edit(int id, LeaveTypeVM leaveTypeVM)
        //{
        //    if (id != leaveTypeVM.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            //Mapeo al tipo original desde el viewmodel
        //            var leaveType = mapper.Map<LeaveType>(leaveTypeVM);
        //            _context.Update(leaveType);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!LeaveTypeExists(leaveTypeVM.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(leaveTypeVM);
        //}

        //// GET: LeaveTypes/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var leaveType = await _context.LeaveTypes
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (leaveType == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(leaveType);
        //}

        //// POST: LeaveTypes/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var leaveType = await _context.LeaveTypes.FindAsync(id);
        //    _context.LeaveTypes.Remove(leaveType);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool LeaveTypeExists(int id)
        //{
        //    return _context.LeaveTypes.Any(e => e.Id == id);
        //}
        #endregion

        #region Con Refactor
        //Se agrega el contrato/interface para su uso y no mostrar lo que se hace directament con la db
        private readonly ILeaveTypeRepository leaveTypeRepository;
        //El mapeo lo hacemos con el fin de no interactuar con las clases originales del sistema
        private readonly IMapper mapper;
        //Inyecta la conexion a la base de datos por medio de _context y un mapper
        //Dependency inversion
        public LeaveTypesController(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            this.leaveTypeRepository = leaveTypeRepository;
            this.mapper = mapper;
        }

        // GET: LeaveTypes
        public async Task<IActionResult> Index()
        {
            //return View(await _context.LeaveTypes.ToListAsync());

            //Hace lo mismo que lo anterior pero se ve mas explicito, mapeando tambien al mismo tiempo de la consulta            
            //var leaveTypes = mapper.Map<List<LeaveTypeVM>>(await _context.LeaveTypes.ToListAsync());

            //Aqui hacemos lo mismo que en la linea anterior, pero haciendo uso del contrato/interfaz
            var leaveTypes = mapper.Map<List<LeaveTypeVM>>(await leaveTypeRepository.GetAllAsync());
            return View(leaveTypes);
        }

        // GET: LeaveTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var leaveType = await _context.LeaveTypes
            //    .FirstOrDefaultAsync(m => m.Id == id);
            //if (leaveType == null)
            //{
            //    return NotFound();
            //}

            //return View(leaveType);

            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var leaveType = await _context.LeaveTypes.FindAsync(id);
            //Aqui hacemos lo mismo que en la linea anterior, pero haciendo uso del contrato/interfaz,
            //pero adicionalmente se hacen las validaciones de id == null para devolver el null o el valor
            var leaveType = await leaveTypeRepository.GetAsync(id);
            if (leaveType == null)
            {
                return NotFound();
            }

            //Convirte del tipo original al viewmodel
            var leaveTypeVM = mapper.Map<LeaveTypeVM>(leaveType);
            return View(leaveTypeVM);
        }

        // GET: LeaveTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Name,DefaultDays,Id,DateCreated,DateModified")] LeaveType leaveType)
        public async Task<IActionResult> Create(LeaveTypeVM leaveTypeVM)
        {
            if (ModelState.IsValid)
            {
                //Convirte del viewmodel al tipo original
                var leaveType = mapper.Map<LeaveType>(leaveTypeVM);

                //_context.Add(leaveType);
                //await _context.SaveChangesAsync();

                //Hace el mismo proceso con el contrato/interfaz
                await leaveTypeRepository.AddAsync(leaveType);
                return RedirectToAction(nameof(Index));
            }
            return View(leaveTypeVM);
        }

        // GET: LeaveTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var leaveType = await _context.LeaveTypes.FindAsync(id);
            //if (leaveType == null)
            //{
            //    return NotFound();
            //}

            //Se hace lo mismo que arriba pero igual que en Details, mas limpio y usando el contrato/interfaz
            var leaveType = await leaveTypeRepository.GetAsync(id);
            if (leaveType == null)
            {
                return NotFound();
            }

            //Convirte del tipo original al viewmodel
            var leaveTypeVM = mapper.Map<LeaveTypeVM>(leaveType);
            return View(leaveTypeVM);
        }

        // POST: LeaveTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Name,DefaultDays,Id,DateCreated,DateModified")] LeaveType leaveType)
        public async Task<IActionResult> Edit(int id, LeaveTypeVM leaveTypeVM)
        {
            if (id != leaveTypeVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //Mapeo al tipo original desde el viewmodel
                    var leaveType = mapper.Map<LeaveType>(leaveTypeVM);

                    //_context.Update(leaveType);
                    //await _context.SaveChangesAsync();

                    //Hace el mismo proceso con el contrato/interfaz
                    await leaveTypeRepository.UpdateAsync(leaveType);
                }
                catch (DbUpdateConcurrencyException)
                {
                    //if (!LeaveTypeExists(leaveTypeVM.Id))
                    if (!await leaveTypeRepository.Exist(leaveTypeVM.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(leaveTypeVM);
        }

        // GET: LeaveTypes/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var leaveType = await _context.LeaveTypes
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (leaveType == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(leaveType);
        //}

        // POST: LeaveTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var leaveType = await _context.LeaveTypes.FindAsync(id);
            //_context.LeaveTypes.Remove(leaveType);
            //await _context.SaveChangesAsync();

            //Mismo proceso usando el contrato/interfaz
            await leaveTypeRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        //private async Task<bool> LeaveTypeExists(int id)
        //{
        //    //return _context.LeaveTypes.Any(e => e.Id == id);
        //    return await leaveTypeRepository.Exist(id);
        //}       
        #endregion
    }
}
