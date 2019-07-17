using System;
//using System.Runtime.InteropServices;
//using System.Windows.Forms;
using System.Windows.Input;
using WindowsInput.Native;
using WindowsInput;


namespace Ikarus
{
    static class SendKeyToHandle
    {
        //[DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        //public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        //// Activate an application window.
        //[DllImport("USER32.DLL")]
        //public static extern bool SetForegroundWindow(IntPtr hWnd);

        //public static void SendSimulateKeyPress (string lpClassName, string lpWindowName, string keyPressed)
        //{
        //                                                            // Get a handle to the Calculator application. The window class
        //                                                            // and window name were obtained using the Spy++ tool.
        //    IntPtr whandle = FindWindow(lpClassName, lpWindowName); // IntPtr calculatorHandle = FindWindow("CalcFrame", "Calculator");

        //    if (whandle == IntPtr.Zero)
        //    {
        //        MessageBox.Show(lpWindowName + " is not running.");
        //        return;
        //    }
        //    SetForegroundWindow(whandle);

        //    SendKeys.SendWait(keyPressed);
        //}
    }
    /// <summary>
    /// https://ourcodeworld.com/articles/read/520/simulating-keypress-in-the-right-way-using-inputsimulator-with-csharp-in-winforms
    /// https://docs.microsoft.com/de-de/dotnet/api/system.windows.input.key?view=netframework-4.8
    /// </summary>
    public static class SendKeys
    {
        /// <summary>
        ///   Sends the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// https://michlg.wordpress.com/2013/02/05/wpf-send-keys/
        public static void Send(Key key)
        {
            try
            {
                if (Keyboard.PrimaryDevice != null)
                {
                    if (Keyboard.PrimaryDevice.ActiveSource != null)
                    {
                        var e1 = new System.Windows.Input.KeyEventArgs(Keyboard.PrimaryDevice, Keyboard.PrimaryDevice.ActiveSource, 0, key) { RoutedEvent = Keyboard.KeyDownEvent };
                        InputManager.Current.ProcessInput(e1);
                    }
                }
            }
            catch { }
        }
    }
    public static class SendKeyStroke
    {
        static InputSimulator sim = new InputSimulator();

        public static void Send(string keypressed)
        {
            try
            {
                VirtualKeyCode vkKeypressed = (VirtualKeyCode)Enum.Parse(typeof(VirtualKeyCode), keypressed.ToUpper());
                sim.Keyboard.KeyPress(vkKeypressed);
            }
            catch { }
        }
        public static void Send(string modifier, string keypressed)
        {
            try
            {
                VirtualKeyCode vkModifier = (VirtualKeyCode)Enum.Parse(typeof(VirtualKeyCode), modifier.ToUpper());
                VirtualKeyCode vkKeypressed = (VirtualKeyCode)Enum.Parse(typeof(VirtualKeyCode), keypressed.ToUpper());

                sim.Keyboard.ModifiedKeyStroke(vkModifier, vkKeypressed);
            }
            catch { }
        }
    }
}
