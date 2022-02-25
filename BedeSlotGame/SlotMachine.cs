using PlayService.Interfaces;

namespace BedeSlotGame
{
    public class SlotMachine : ISlotMachine
    {
        private readonly IStartGame _startGame;
        public SlotMachine(
            IStartGame startGame
            )
        {
            _startGame = startGame;
        }

        public void BedeSlot()
        {
            _startGame.Start();
        }
    }
}
