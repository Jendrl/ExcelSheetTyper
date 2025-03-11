using WindowsInput;

namespace ExcelSheetTyper
{
    public class TextTyper(StaggerKeyboardSimulator keyboardSimulator, KeyCodeMapper keyCodeMapper)
    {
        public async Task TypeContinuouslyAsync(string text)
        {
            foreach (var character in text)
            {
                var keyCode = keyCodeMapper.MapToCode(character);
                if (keyCode.IsModified)
                    await keyboardSimulator.ModifiedKeyStrokeAsync(keyCode.Modifier, keyCode.KeyCode);
                else
                    await keyboardSimulator.KeyDownAsync(keyCode.KeyCode);
            }
        }
    }
}
