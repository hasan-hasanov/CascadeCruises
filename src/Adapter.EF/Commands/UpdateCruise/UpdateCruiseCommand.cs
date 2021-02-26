using Core.Commands;
using Core.Entities;

namespace Adapter.EF.Commands.UpdateCruise
{
    public class UpdateCruiseCommand : ICommand
    {
        public UpdateCruiseCommand(Cruise cruise)
        {
            Cruise = cruise;
        }

        public Cruise Cruise { get; }
    }
}
