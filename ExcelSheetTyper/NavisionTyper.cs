using WindowsInput.Native;

namespace ExcelSheetTyper
{
    public class NavisionTyper(StaggerKeyboardSimulator staggeredKeyboardSimulator, TextTyper textTyper)
    {
        public async Task TypeEntryAsync(NavisionEntry entry)
        {
            await textTyper.TypeContinuouslyAsync(entry.Date);
            await TabulateManyTimes(1);
            await textTyper.TypeContinuouslyAsync(entry.StartTime);
            await TabulateManyTimes(3);
            await textTyper.TypeContinuouslyAsync(entry.EndTime);
            await TabulateManyTimes(5);
            await textTyper.TypeContinuouslyAsync(entry.Action);
            await MoveToStartOfNewRow();
        }

        private async Task TabulateManyTimes(int times)
        {
            foreach (var _ in Enumerable.Range(0, times))
            {
                await staggeredKeyboardSimulator.KeyDownAsync(VirtualKeyCode.TAB);
            }
        }
    
        private async Task MoveToStartOfNewRow()
        {
            await staggeredKeyboardSimulator.KeyDownAsync(VirtualKeyCode.DOWN);
            await staggeredKeyboardSimulator.KeyDownAsync(VirtualKeyCode.LEFT);
            await staggeredKeyboardSimulator.KeyDownAsync(VirtualKeyCode.LEFT);
            await staggeredKeyboardSimulator.KeyDownAsync(VirtualKeyCode.LEFT);
            await staggeredKeyboardSimulator.KeyDownAsync(VirtualKeyCode.LEFT);
            await staggeredKeyboardSimulator.KeyDownAsync(VirtualKeyCode.LEFT);
            await staggeredKeyboardSimulator.KeyDownAsync(VirtualKeyCode.LEFT);
            await staggeredKeyboardSimulator.KeyDownAsync(VirtualKeyCode.LEFT);
        }
    }
}
