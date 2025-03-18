using System.Runtime.InteropServices;
// For DLL (Dynamic-link library)

// IMPORTS - Because C# doesn't have mouse events
[DllImport("user32.dll")] // User 32 module (Windows API)
static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, IntPtr dwExtraInfo); // click
[DllImport("user32.dll")]
static extern short GetAsyncKeyState(int vKey); // hotkey

const uint LEFTDOWN = 0x02; // LEFTDOWN = Left click
const uint LEFTUP = 0x04; // LEFTUP = Releasing left click
//(https://learn.microsoft.com/en-us/windows/win32/inputdev/virtual-key-codes)

const int HOTKEY = 0x26; // Up arrow key

bool enableClicker = false; // ON/OFF for hotkey
int clickInterval = 5; // Miliseconds between clicks

Console.WriteLine("Welcome! The current hotkey is the Up arrow key");
// AUTOCLICKER LOOP
while (true)
{
    if (GetAsyncKeyState(HOTKEY) < 0) // if hotkey is down
    {
        Console.Clear(); // Prevents clogging the terminal
        enableClicker = !enableClicker; // Enable / Disable vice versa
        Console.WriteLine(enableClicker ? "Autoclicker ACTIVE" : "Autoclicker DISABLED");
        Thread.Sleep(300); // Stops spam
    }
    if (enableClicker)
    {
        MouseClick();

    }
    Thread.Sleep(clickInterval);
}
// MOUSE CLICK FUNCTION
void MouseClick()
{
    mouse_event(LEFTDOWN, 0, 0, 0, IntPtr.Zero);
    // No more information is needed than the click (No mouse movements)
    mouse_event(LEFTUP, 0, 0, 0, IntPtr.Zero);
}