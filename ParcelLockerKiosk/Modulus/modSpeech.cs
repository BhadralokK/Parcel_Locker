using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Speech;
using System.Speech.Synthesis;
using System.IO;

namespace RailwayInformationKiosk
{
    public class modSpeech
    {
        public static void text2speech(string str)
        {
            SpeechSynthesizer reader = new SpeechSynthesizer();
            reader.Volume = 100;
            reader.Rate = 0;
            reader.SelectVoiceByHints(VoiceGender.Female);
            reader.SpeakAsync(str.ToString());
        }

       
    }
}
