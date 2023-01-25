using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using WindowsInputCore.Native;

namespace WindowsInputCore.SampleClient.WPF
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly IInputSimulator inputSimulator;

        public MainViewModel(IInputSimulator inputSimulator)
        {
            this.inputSimulator = inputSimulator ?? throw new ArgumentNullException(nameof(inputSimulator));
        }

        [RelayCommand]
        public void OpenWindowsExplorer()
        {
            inputSimulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.LWIN, VirtualKeyCode.VK_E);
        }

        [RelayCommand]
        public void SayHello()
        {
            inputSimulator.Keyboard
               .ModifiedKeyStroke(VirtualKeyCode.LWIN, VirtualKeyCode.VK_R)
               .Sleep(1000)
               .TextEntry("notepad")
               .Sleep(1000)
               .KeyPress(VirtualKeyCode.RETURN)
               .Sleep(1000)
               .TextEntry("These are your orders if you choose to accept them...")
               .TextEntry("This message will self destruct in 5 seconds.")
               .Sleep(5000)
               .ModifiedKeyStroke(VirtualKeyCode.MENU, VirtualKeyCode.SPACE)
               .KeyPress(VirtualKeyCode.DOWN)
               .KeyPress(VirtualKeyCode.RETURN);

            var i = 10;
            while (i-- > 0)
            {
                inputSimulator.Keyboard.KeyPress(VirtualKeyCode.DOWN).Sleep(100);
            }

            inputSimulator.Keyboard
               .KeyPress(VirtualKeyCode.RETURN)
               .Sleep(1000)
               .ModifiedKeyStroke(VirtualKeyCode.MENU, VirtualKeyCode.F4)
               .KeyPress(VirtualKeyCode.VK_N);
        }
        
        [RelayCommand]
        public void OpenPaint()
        {
            inputSimulator.Keyboard.KeyPress(VirtualKeyCode.SPACE);

            inputSimulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.LWIN, VirtualKeyCode.VK_R)
               .Sleep(1000)
               .TextEntry("mspaint")
               .Sleep(1000)
               .KeyPress(VirtualKeyCode.RETURN)
               .Sleep(1000)
               .Mouse
               .LeftButtonDown()
               .MoveMouseToPositionOnVirtualDesktop(65535 / 2, 65535 / 2)
               .LeftButtonUp();

        }

        [RelayCommand]
        public void MouseMoveTo()
        {
            inputSimulator.Mouse
               .MoveMouseTo(0, 0)
               .Sleep(1000)
               .MoveMouseTo(65535, 65535)
               .Sleep(1000)
               .MoveMouseTo(65535 / 2, 65535 / 2);
        }
    }
}
