using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Assessment_3
{
    class MobilePhone
    {
        public delegate void RingEventHandler();
        public event RingEventHandler OnRing;

        public void ReceiveCall()
        {
            Console.WriteLine("Incoming call/Receiving call");

            if (OnRing != null) { OnRing(); }
        }
    }
    class RingtonePlayer
    {
        public void PlayRingtone()
        {
            Console.WriteLine("Playing ringtone...");
        }
    }
    class ScreenDisplay
    {
        public void ShowCaller()
        {
            Console.WriteLine("Displaying caller information...");
        }
    }
    class VibrationMotor
    {
        public void Vibrate()
        {
            Console.WriteLine("Phone is vibrating...");
        }
    }
    internal class Ques3
    {
        public static void Main()
        {
            MobilePhone phone = new MobilePhone();

            RingtonePlayer ringtone = new RingtonePlayer();
            ScreenDisplay display = new ScreenDisplay();
            VibrationMotor vibration = new VibrationMotor();

            phone.OnRing += ringtone.PlayRingtone;
            phone.OnRing += display.ShowCaller;
            phone.OnRing += vibration.Vibrate;

            phone.ReceiveCall();
        }
    }
}
