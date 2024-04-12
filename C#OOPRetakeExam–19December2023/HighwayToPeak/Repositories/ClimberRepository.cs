using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories.Contracts;

namespace HighwayToPeak.Repositories
{
    public class ClimberRepository : IRepository<IClimber>
    {
        private List<IClimber> climbers = new List<IClimber>();
        public IReadOnlyCollection<IClimber> All => climbers.AsReadOnly();

        public void Add(IClimber model)
        {
            climbers.Add(model);
        }

        public IClimber Get(string name) => climbers.FirstOrDefault(f => f.Name == name);
    }
}
