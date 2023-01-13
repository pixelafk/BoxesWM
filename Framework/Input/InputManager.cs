namespace Framework.Input;

public class InputManager
{
    private static LowLevelKeyboardHook? _keyboardHook;
    
    [STAThread]
    public static void Start()
    {
        if (_keyboardHook != null)
            return;

        _keyboardHook = new LowLevelKeyboardHook();
        _keyboardHook.OnKeyPressed += OnKeyDown;
        _keyboardHook.OnKeyReleased += OnKeyUp;
        _keyboardHook.HookKeyboard();

        AppDomain.CurrentDomain.ProcessExit += QuitHook;
    }

    private static void OnKeyDown(object? sender, Key key)
    {
        if (key == Keys.Escape)
            Application.Exit();

        Console.WriteLine($"Pressed key: {key}");
    }

    private static void OnKeyUp(object? sender, Key key)
    {
        Console.WriteLine($"Released key: {key}");
    }

    private static void QuitHook(object? sender, EventArgs e)
    {
        AppDomain.CurrentDomain.ProcessExit -= QuitHook;

        if (_keyboardHook == null)
            return;
        
        _keyboardHook.OnKeyPressed -= OnKeyDown;
        _keyboardHook.OnKeyReleased -= OnKeyUp;
        _keyboardHook.Dispose();
    }
}    