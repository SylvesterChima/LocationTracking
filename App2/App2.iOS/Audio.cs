using App2.iOS;
using AVFoundation;
using Foundation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(Audio))]
namespace App2.iOS
{
    public class Audio : IAudio
    {
        AVAudioPlayer _player;
        public bool PlayAudio()
        {

            var fileName = "filename.mp3";
            string sFilePath = NSBundle.MainBundle.PathForResource
              (Path.GetFileNameWithoutExtension(fileName), Path.GetExtension(fileName));
            var url = NSUrl.FromString(sFilePath);
            _player = AVAudioPlayer.FromUrl(url);
            _player.FinishedPlaying += (object sender, AVStatusEventArgs e) => {
                _player = null;
            };
            _player.Play();
            return true;
        }
    }
}