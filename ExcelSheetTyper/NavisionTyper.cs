using WindowsInput;
using WindowsInput.Native;

namespace ExcelSheetTyper
{
    public class NavisionTyper(StaggerKeyboardSimulator staggeredKeyboardSimulator, TextTyper textTyper)
    {
        public async Task TypeEntryAsync(NavisionEntry entry)
        {
            await textTyper.TypeContinuouslyAsync(entry.StartDate);
            await staggeredKeyboardSimulator.KeyDownAsync(VirtualKeyCode.TAB);
            await textTyper.TypeContinuouslyAsync(entry.EndDate);
            await staggeredKeyboardSimulator.KeyDownAsync(VirtualKeyCode.TAB);
            await textTyper.TypeContinuouslyAsync(entry.Action);
            await staggeredKeyboardSimulator.KeyDownAsync(VirtualKeyCode.TAB);
        }
    }
}
