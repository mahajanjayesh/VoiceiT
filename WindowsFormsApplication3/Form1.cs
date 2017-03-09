using System;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Media;
using System.Diagnostics;
using System.IO.Ports;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {


        SpeechSynthesizer synthesizer;
        SpeechRecognitionEngine recognition;

        bool enabled = false;

        SoundPlayer soundPlayer;

        string VoiceOn = @"C:\Voice\On.wav";
        string VoiceOff = @"C:\Voice\Off.wav";
        string VoiceUnderstood = @"C:\Voice\Understood.wav";

        public object MessageBoxButton { get; private set; }
        public object MessageBoxImage { get; private set; }


        
        

        public Form1()
        {
            InitializeComponent();

            synthesizer = new SpeechSynthesizer();

            synthesizer.Rate = -2;

            recognition = new SpeechRecognitionEngine();

            Choices myList = new Choices();

            myList.Add(new string[] { "hi", "morning", "social", "open", "afternoon", "evening", "shutdown" , "restart" ,"notepad", "open chrome",
                "who are you?", "open facebook", "open twitter" , "open github", "open my college mail" , "open my mail" , "lock" ,
                "light on" , "light off" , "fan on" , "fan off" , "switch on the light", "switch off the light", "switch on the fan", "switch off the fan","curtain open",
                "open the curtain","curtain close","close the curtain","curtain open halfway","open half curtain"});

            Grammar grammar = new Grammar(new GrammarBuilder(myList));
            recognition.LoadGrammar(grammar);

            recognition.SetInputToDefaultAudioDevice();
            recognition.RecognizeAsync(RecognizeMode.Multiple);

            soundPlayer = new SoundPlayer();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (!enabled)
            {
                soundPlayer.SoundLocation = VoiceOn;
                soundPlayer.Play();

                recognition.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sr_SpeechRecognized);
                enabled = true;

            }
            else if (enabled)
            {
                soundPlayer.SoundLocation = VoiceOff;
                soundPlayer.Play();

                recognition.SpeechRecognized -= new EventHandler<SpeechRecognizedEventArgs>(sr_SpeechRecognized);
                enabled = false;
            }

        }

        private void sr_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Text == "hi")
            {
                soundPlayer.SoundLocation = VoiceUnderstood;
                soundPlayer.Play();

                System.Threading.Thread.Sleep(500);

                richTextBox1.AppendText("You:" + e.Result.Text + Environment.NewLine);

                synthesizer.SpeakAsync("Whats Up? Jayesh");
                richTextBox1.AppendText("Voice: Whats Up? Jayesh" + Environment.NewLine);
            }
            else if (e.Result.Text == "morning")
            {
                soundPlayer.SoundLocation = VoiceUnderstood;
                soundPlayer.Play();

                System.Threading.Thread.Sleep(500);

                richTextBox1.AppendText("You:" + e.Result.Text + Environment.NewLine);

                synthesizer.SpeakAsync("Good Morning Jayesh");
                richTextBox1.AppendText("Voice: Good Morning Jayesh" + Environment.NewLine);
            }
            else if (e.Result.Text == "afternoon")
            {
                soundPlayer.SoundLocation = VoiceUnderstood;
                soundPlayer.Play();

                System.Threading.Thread.Sleep(500);

                richTextBox1.AppendText("You:" + e.Result.Text + Environment.NewLine);

                synthesizer.SpeakAsync("Good Afternoon Jayesh");
                richTextBox1.AppendText("Voice: Good Afternoon Jayesh" + Environment.NewLine);
            }
            else if (e.Result.Text == "evening")
            {
                soundPlayer.SoundLocation = VoiceUnderstood;
                soundPlayer.Play();

                System.Threading.Thread.Sleep(500);

                richTextBox1.AppendText("You:" + e.Result.Text + Environment.NewLine);

                synthesizer.SpeakAsync("Good Evening Jayesh");
                richTextBox1.AppendText("Voice: Good Evening Jayesh" + Environment.NewLine);
            }
            else if (e.Result.Text == "open facebook")
            {
                soundPlayer.SoundLocation = VoiceUnderstood;
                soundPlayer.Play();

                System.Threading.Thread.Sleep(500);

                richTextBox1.AppendText("You:" + e.Result.Text + Environment.NewLine);
                richTextBox1.AppendText("Opening Facebook" + e.Result.Text + Environment.NewLine);
                synthesizer.Speak("Opening Facebook");
                System.Diagnostics.Process.Start("http://www.facebook.com");
            }

            else if (e.Result.Text == "open twitter")
            {
                soundPlayer.SoundLocation = VoiceUnderstood;
                soundPlayer.Play();

                System.Threading.Thread.Sleep(500);

                richTextBox1.AppendText("You:" + e.Result.Text + Environment.NewLine);
                richTextBox1.AppendText("Opening Twitter" + e.Result.Text + Environment.NewLine);
                synthesizer.Speak("Opening Twitter");
                System.Diagnostics.Process.Start("http://www.twitter.com");
            }
            else if (e.Result.Text == "open github")
            {
                soundPlayer.SoundLocation = VoiceUnderstood;
                soundPlayer.Play();

                System.Threading.Thread.Sleep(500);

                richTextBox1.AppendText("You:" + e.Result.Text + Environment.NewLine);
                richTextBox1.AppendText("Opening Github" + e.Result.Text + Environment.NewLine);
                synthesizer.Speak("Opening Github");
                System.Diagnostics.Process.Start("http://www.github.com");
            }
            else if (e.Result.Text == "open my college mail")
            {
                soundPlayer.SoundLocation = VoiceUnderstood;
                soundPlayer.Play();

                System.Threading.Thread.Sleep(500);

                richTextBox1.AppendText("You:" + e.Result.Text + Environment.NewLine);
                richTextBox1.AppendText("Opening College Outlook" + e.Result.Text + Environment.NewLine);
                synthesizer.Speak("Opening College Outlook");
                System.Diagnostics.Process.Start("http://mail.office365.com");
            }
            else if (e.Result.Text == "open my mail")
            {
                soundPlayer.SoundLocation = VoiceUnderstood;
                soundPlayer.Play();

                System.Threading.Thread.Sleep(500);

                richTextBox1.AppendText("You:" + e.Result.Text + Environment.NewLine);
                richTextBox1.AppendText("Opening Gmail" + e.Result.Text + Environment.NewLine);
                synthesizer.Speak("Opening Gmail");
                System.Diagnostics.Process.Start("http://mail.google.com");
            }
            else if (e.Result.Text == "notepad")
            {
                soundPlayer.SoundLocation = VoiceUnderstood;
                soundPlayer.Play();

                System.Threading.Thread.Sleep(500);

                richTextBox1.AppendText("You:" + e.Result.Text + Environment.NewLine);
                richTextBox1.AppendText("Opening Notepad" + e.Result.Text + Environment.NewLine);
                synthesizer.Speak("Opening Notepad");
                System.Diagnostics.Process.Start(@"C:\Windows\System32\Notepad.exe");
            }
            else if (e.Result.Text == "open chrome")
            {
                soundPlayer.SoundLocation = VoiceUnderstood;
                soundPlayer.Play();

                System.Threading.Thread.Sleep(500);

                richTextBox1.AppendText("You:" + e.Result.Text + Environment.NewLine);
                richTextBox1.AppendText("Opening Chrome" + e.Result.Text + Environment.NewLine);
                synthesizer.Speak("Opening Chrome");
                System.Diagnostics.Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe");

            }
            else if (e.Result.Text == "who are you")
            {
                soundPlayer.SoundLocation = VoiceUnderstood;
                soundPlayer.Play();

                System.Threading.Thread.Sleep(500);

                richTextBox1.AppendText("You:" + e.Result.Text + Environment.NewLine);

                synthesizer.SpeakAsync("I am your virtual assistant");
                richTextBox1.AppendText("Voice: I am your virtual assistant" + Environment.NewLine);
            }
            else if (e.Result.Text == "shutdown")
            {
                soundPlayer.SoundLocation = VoiceUnderstood;
                soundPlayer.Play();

                System.Threading.Thread.Sleep(500);

                richTextBox1.AppendText("You:" + e.Result.Text + Environment.NewLine);

                synthesizer.SpeakAsync("Select the Appropriate Option from dialog");
                richTextBox1.AppendText("Voice: Select the Appropriate Option from Dialog" + Environment.NewLine);
                //MessageBox.Show("Dot Net Perls is awesome.");
                DialogResult dialogResult = MessageBox.Show("Do you really want to shutdown the system, select an option", "Shutdown", MessageBoxButtons.YesNo);
                
                if (dialogResult == DialogResult.Yes)
                {
                    Process.Start("shutdown","/s /t 0");
                }
                else if (dialogResult == DialogResult.No)
                {
                    //will exit the dialog box and return to main application
                }

            }
            else if (e.Result.Text == "restart")
            {
                soundPlayer.SoundLocation = VoiceUnderstood;
                soundPlayer.Play();

                System.Threading.Thread.Sleep(500);

                richTextBox1.AppendText("You:" + e.Result.Text + Environment.NewLine);

                synthesizer.SpeakAsync("Select the Appropriate Option from dialog");
                richTextBox1.AppendText("Voice: Select the Appropriate Option from Dialog" + Environment.NewLine);
                
                DialogResult dialogResult = MessageBox.Show("Do you really want to restart the system, select an option", "Restart", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    Process.Start("shutdown", "/r /t 0");
                }
                else if (dialogResult == DialogResult.No)
                {
                    //will exit the dialog box and return to main application
                }

            }
            else if (e.Result.Text == "lock")
            {
                soundPlayer.SoundLocation = VoiceUnderstood;
                soundPlayer.Play();

                System.Threading.Thread.Sleep(500);

                richTextBox1.AppendText("You:" + e.Result.Text + Environment.NewLine);

                synthesizer.SpeakAsync("Select the Appropriate Option from dialog");
                richTextBox1.AppendText("Voice: Select the Appropriate Option from Dialog" + Environment.NewLine);
                
                DialogResult dialogResult = MessageBox.Show("Do you really want to lock the system, select an option", "Lock", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    Process.Start(@"C:\WINDOWS\system32\rundll32.exe", "user32.dll,LockWorkStation");

                }
                else if (dialogResult == DialogResult.No)
                {
                    //will exit the dialog box and return to main application
                }

            }


            //Home Automation
            //Starts Here
            else if (e.Result.Text == "light on" || e.Result.Text == "switch on the light")
            {
                soundPlayer.SoundLocation = VoiceUnderstood;
                soundPlayer.Play();

                System.Threading.Thread.Sleep(500);

                richTextBox1.AppendText("You:" + e.Result.Text + Environment.NewLine);

                synthesizer.SpeakAsync("Switching on the light");
                richTextBox1.AppendText("Voice: Switching on the light" + Environment.NewLine);

                SerialPort connectionport = new SerialPort();
                connectionport.PortName = "COM9";
                connectionport.BaudRate = 9600;
                connectionport.Open();
                connectionport.Write("*light on");
                connectionport.Close();
            }

            else if (e.Result.Text == "light off" || e.Result.Text == "switch off the light")
            {
                soundPlayer.SoundLocation = VoiceUnderstood;
                soundPlayer.Play();

                System.Threading.Thread.Sleep(500);

                richTextBox1.AppendText("You:" + e.Result.Text + Environment.NewLine);

                synthesizer.SpeakAsync("Switching off the light");
                richTextBox1.AppendText("Voice: Switching off the light" + Environment.NewLine);

                SerialPort connectionport = new SerialPort();
                connectionport.PortName = "COM9";
                connectionport.BaudRate = 9600;
                connectionport.Open();
                connectionport.Write("*light off");
                connectionport.Close();
            }

            else if (e.Result.Text == "fan on" || e.Result.Text == "switch on the fan")
            {
                soundPlayer.SoundLocation = VoiceUnderstood;
                soundPlayer.Play();

                System.Threading.Thread.Sleep(500);

                richTextBox1.AppendText("You:" + e.Result.Text + Environment.NewLine);

                synthesizer.SpeakAsync("Switching on the fan");
                richTextBox1.AppendText("Voice: Switching on the fan" + Environment.NewLine);

                SerialPort connectionport = new SerialPort();
                connectionport.PortName = "COM9";
                connectionport.BaudRate = 9600;
                connectionport.Open();
                connectionport.Write("*fan on");
                connectionport.Close();
            }

            else if (e.Result.Text == "fan off" || e.Result.Text == "switch off the fan")
            {
                soundPlayer.SoundLocation = VoiceUnderstood;
                soundPlayer.Play();

                System.Threading.Thread.Sleep(500);

                richTextBox1.AppendText("You:" + e.Result.Text + Environment.NewLine);

                synthesizer.SpeakAsync("Switching off the fan");
                richTextBox1.AppendText("Voice: Switching off the fan" + Environment.NewLine);

                SerialPort connectionport = new SerialPort();
                connectionport.PortName = "COM9";
                connectionport.BaudRate = 9600;
                connectionport.Open();
                connectionport.Write("*fan off");
                connectionport.Close();
            }

            else if (e.Result.Text == "curtain open" || e.Result.Text == "open the curtain")
            {
                soundPlayer.SoundLocation = VoiceUnderstood;
                soundPlayer.Play();

                System.Threading.Thread.Sleep(500);

                richTextBox1.AppendText("You:" + e.Result.Text + Environment.NewLine);

                synthesizer.SpeakAsync("Opening the Curtain");
                richTextBox1.AppendText("Voice: Opening the Curtain" + Environment.NewLine);

                SerialPort connectionport = new SerialPort();
                connectionport.PortName = "COM9";
                connectionport.BaudRate = 9600;
                connectionport.Open();
                connectionport.Write("*curtain open");
                connectionport.Close();
            }

            else if (e.Result.Text == "curtain close" || e.Result.Text == "close the curtain")
            {
                soundPlayer.SoundLocation = VoiceUnderstood;
                soundPlayer.Play();

                System.Threading.Thread.Sleep(500);

                richTextBox1.AppendText("You:" + e.Result.Text + Environment.NewLine);

                synthesizer.SpeakAsync("Closing the Curtain");
                richTextBox1.AppendText("Voice: Closing the Curtain" + Environment.NewLine);

                SerialPort connectionport = new SerialPort();
                connectionport.PortName = "COM9";
                connectionport.BaudRate = 9600;
                connectionport.Open();
                connectionport.Write("*curtain close");
                connectionport.Close();
            }

            else if (e.Result.Text == "curtain open halfway" || e.Result.Text == "open half curtain")
            {
                soundPlayer.SoundLocation = VoiceUnderstood;
                soundPlayer.Play();

                System.Threading.Thread.Sleep(500);

                richTextBox1.AppendText("You:" + e.Result.Text + Environment.NewLine);

                synthesizer.SpeakAsync("Opening half curtain");
                richTextBox1.AppendText("Voice: Opening the Curtain" + Environment.NewLine);

                SerialPort connectionport = new SerialPort();
                connectionport.PortName = "COM9";
                connectionport.BaudRate = 9600;
                connectionport.Open();
                connectionport.Write("*curtain half open");
                connectionport.Close();
            }

            // Home Automation Finished
        }

        private void ExitWindowsEx(int v1, int v2)
        {
            throw new NotImplementedException();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ActiveControl = pictureBox1;
        }

      
    }
    }

    

  


    

