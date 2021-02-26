using Core.Commands;
using Core.Entities;

namespace Adapter.EF.Commands.InsertCruise
{
    public class InsertCruiseCommand : ICommand
    {
        public InsertCruiseCommand(Cruise cruise)
        {
            Cruise = cruise;
        }

        public Cruise Cruise { get; }
    }
}
