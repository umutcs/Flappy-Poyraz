﻿using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Net;

namespace Flappy_Bird_Windows_Form
{
    public partial class Form1 : Form
    {

        
        int pipeSpeed = 8; 
        int gravity = 15; 
        int score = 0; 
        

        public Form1()
        {
            InitializeComponent();
        }

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
          
            if (e.KeyCode == Keys.Space)
            {
               
                gravity = -15;
            }


        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            

            if (e.KeyCode == Keys.Space)
            {
                gravity = 15;
                

            }
        }


        private void endGame()
        {
            gameTimer.Stop();
            scoreText.Text += "OYUN BİTTİ!";

            // Oyun bitti sesi çal
            string dosyaAdi = "oyunBitti.wav";
            string debugKlasoru = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string dosyaYolu = Path.Combine(debugKlasoru, dosyaAdi);
            SoundPlayer sesCalar = new SoundPlayer(dosyaYolu);
            sesCalar.Play();
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            flappyBird.Top += gravity; 
            pipeBottom.Left -= pipeSpeed; 
            pipeTop.Left -= pipeSpeed; 
            scoreText.Text = "Score: " + score; 

            

            if(pipeBottom.Left < -150)
            {
               
                pipeBottom.Left = 800;
                score++;
            }
            if(pipeTop.Left < -180)
            {
              
                pipeTop.Left = 950;
                score++;
            }

           
            
            if (flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                flappyBird.Bounds.IntersectsWith(ground.Bounds) || flappyBird.Top < -25
                )
            {
               
                endGame();
            }


           
            if(score > 5)
            {
                pipeSpeed = 15;
            }

        }


        

    }
}
