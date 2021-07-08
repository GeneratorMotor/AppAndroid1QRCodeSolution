using Android.Media;
using Android.Content.Res;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppAndroid1.Droid.Classess
{
    public class MyMediaPlayer
    {
       private MediaPlayer player;

        private string filePath = string.Empty;

        public MyMediaPlayer(string filePath)
        {
            this.filePath = filePath;
        }

        public void StartPlayer()
        {
            if (player == null)
            {
                player = new MediaPlayer();
            }
            else
            {
                var fd = global::Android.App.Application.Context.Assets.OpenFd(filePath);
                player.Reset();
                player.SetDataSource(fd.FileDescriptor, fd.StartOffset, fd.Length);
                player.Prepare();
                player.Start();
            }
        }
    }
}