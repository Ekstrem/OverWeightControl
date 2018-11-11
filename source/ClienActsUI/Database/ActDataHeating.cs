using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using OverWeightControl.Common.Model;
using OverWeightControl.Core.Console;

namespace OverWeightControl.Clients.ActsUI.Database
{
    public class ActDataHeating
    {
        private readonly IConsoleService _console;
        private readonly ModelContext _context;
        private Task<List<Act>> _task;
        public ActDataHeating(
            DbContext context,
            IConsoleService console)
        {
            _console = console;
            _context = (ModelContext) context;
            StartTask();
        }

        private void StartTask()
        {
            try
            {
                _task = Task<List<Act>>.Factory.StartNew(
                    function: () => _context
                        .Set<Act>()
                        .Include(d => d.Driver)
                        .Include(c => c.Cargo)
                        .Include(a => a.Cargo.Axises)
                        .Include(w => w.Weighter)
                        .Include(v => v.Vehicle)
                        .Include(vd => vd.Vehicle.Detail)
                        .ToList(),
                    cancellationToken: CancellationToken);
            }
            catch (Exception e)
            {
                _console.AddException(e);
            }
        }

        public CancellationToken CancellationToken { get; set; }

        public async Task<ICollection<Act>> GetActsAsync()
        {
            try
            {
                return await _task;
            }
            catch (Exception e)
            {
                _console.AddException(e);
                return null;
            }
        }

    }
}