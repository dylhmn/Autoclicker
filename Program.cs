using System.Windows;
using System.Runtime.InteropServices; // For DLL
// IMPORTS
[DllImport("user32.dll")] // Windows API
static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, IntPtr dwExtraInfo); // Click
[DllImport("user32.dll")]
static extern short GetAsyncKeyState(int vKey); // Hotkey
const uint LEFTDOWN = 0x02;
const uint LEFTUP = 0x04;
bool enableClicker = false;
//
//
//
int clickInterval = 5;
const int HOTKEY = 0x26;
//  Intervals are in miliseconds. 
//  Hotkeys: https://learn.microsoft.com/en-us/windows/win32/inputdev/virtual-key-codes
//
string ? HOTKEYname = Enum.GetName(typeof(ConsoleKey), HOTKEY); // Gives the hotkey a name

Console.Title = "AUTOCLICKER";
Greeting();

while (true) // AUTOCLICKER LOOP
{
    if (GetAsyncKeyState(HOTKEY) < 0)
    {
        Console.Clear();
        enableClicker = !enableClicker; // Enable / Disable vice versa
        Console.ForegroundColor = enableClicker ? ConsoleColor.Green : ConsoleColor.Red;
        Console.WriteLine(enableClicker ? " + ACTIVE" : " - INACTIVE");
        Thread.Sleep(300); // Stops spam
    }
    if (enableClicker)
    {
        MouseClick();
    }
    Thread.Sleep(clickInterval);
}
void MouseClick() // MOUSE CLICK FUNCTION
{
    mouse_event(LEFTDOWN, 0, 0, 0, IntPtr.Zero);
    mouse_event(LEFTUP, 0, 0, 0, IntPtr.Zero);
    // 0,0,0 = no mouse movements
}
void Greeting()
{
    Console.Write("WELCOME!\nTHE CURRENT HOTKEY IS: ");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write(HOTKEYname.ToUpper());
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write("\nINTERVAL: ");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write(clickInterval.ToString());
}