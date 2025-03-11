using WindowsInput;
using WindowsInput.Native;

namespace ExcelSheetTyper
{
    public class KeyCodeMapper
    {
        public KeyCodeResult MapToCode(char c)
        {
            if (char.IsLetter(c) || char.IsDigit(c))
            {
                var stringCode = $"VK_{c}".ToUpper();
                return KeyCodeResult.CreateSimple(Enum.Parse<VirtualKeyCode>(stringCode));
            }

            if (c == ':')
                return KeyCodeResult.CreateModified(VirtualKeyCode.SHIFT, VirtualKeyCode.OEM_PERIOD);

            if (c == '-')
                return KeyCodeResult.CreateSimple(VirtualKeyCode.OEM_MINUS);

            throw new InvalidOperationException($"Character {c} ({char.GetNumericValue(c)}) is not supported");
        }

        public class KeyCodeResult
        {
            public bool IsModified { get; set; }

            public VirtualKeyCode KeyCode { get; set; }

            public VirtualKeyCode Modifier { get; set; }

            public static KeyCodeResult CreateSimple(VirtualKeyCode keyCode) => new KeyCodeResult
            {
                KeyCode = keyCode
            };

            public static KeyCodeResult CreateModified(VirtualKeyCode modifier, VirtualKeyCode keyCode) => new KeyCodeResult
            {
                KeyCode = keyCode,
                IsModified = true,
                Modifier = modifier
            };
        }
    }
}
