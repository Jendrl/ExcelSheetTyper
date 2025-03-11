using WindowsInput;
using WindowsInput.Native;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace ExcelSheetTyper
{
    public class StaggerKeyboardSimulator(IKeyboardSimulator keyboardSimulator, int delayMs)
    {
        public async Task KeyDownAsync(VirtualKeyCode keyCode)
        {
            await Task.Delay(delayMs);
            keyboardSimulator.KeyDown(keyCode);
        }

        public async Task ModifiedKeyStrokeAsync(VirtualKeyCode modifier, VirtualKeyCode keyCode)
        {
            await Task.Delay(delayMs);
            keyboardSimulator.ModifiedKeyStroke(modifier, keyCode);
        }
    }
}
