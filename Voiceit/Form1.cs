using System;
using System.Windows.Forms;
using System.Media;
using System.Diagnostics;
using System.IO.Ports;
using System.Drawing;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Net.Mail;
using System.Speech;
using System.Speech.Synthesis;
using System.Speech.Recognition;

namespace Voiceit
{
    public partial class Form1 : Form
    {




        SpeechSynthesizer synthesizer;
        SpeechRecognitionEngine recognition;

        bool enabled = false;

        SoundPlayer soundPlayer;




        string VoiceOn = @"C:\Users\Jayesh\documents\visual studio 2017\Projects\Voiceit\Voiceit\Voice\On.wav";
        string VoiceOff = @"C:\Users\Jayesh\Documents\Visual Studio 2015\Projects\WindowsFormsApplication3\WindowsFormsApplication3\Sounds\Off.wav";
        string VoiceUnderstood = @"C:\Users\Jayesh\Documents\Visual Studio 2015\Projects\WindowsFormsApplication3\WindowsFormsApplication3\Sounds\Understood.wav";

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
                "open the curtain","curtain close","close the curtain","curtain open halfway","open half curtain" , "weather" ,"show weather" , "current weather" ,"forecast","Show Cricket News",
                "Cricket info" , "Cricket information" ,"Cricket News" , "Live Cricket Score" , "ABC News"});

            Grammar grammar = new Grammar(new GrammarBuilder(myList));
            recognition.LoadGrammar(grammar);

            recognition.SetInputToDefaultAudioDevice();
            recognition.RecognizeAsync(RecognizeMode.Multiple);

            soundPlayer = new SoundPlayer();
            label2.Visible = false;
            //pictureBox2.Visible = false;


            //MailMessage mail = new MailMessage();
            //SmtpClient SmtpServer = new SmtpClient("smtp.live.com");

            //mail.From = new MailAddress("forprojectjm@outlook.com");
            //mail.To.Add("officialjayesh@gmail.com");
            //mail.Subject = "Test Mail";
            //mail.Body = "This is for testing SMTP mail from GMAIL";
            //SmtpServer.Port = 587;
            //SmtpServer.Credentials = new System.Net.NetworkCredential("forprojectjm@outlook.com", "VoiceitAssistant");
            //SmtpServer.EnableSsl = true;
            //SmtpServer.Send(mail);
            ////MessageBox.Show("mail Send");
            //Console.WriteLine("Mail Sent");


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (!enabled)
            {
                soundPlayer.SoundLocation = VoiceOn;
                soundPlayer.Play();

                recognition.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sr_SpeechRecognized);
                enabled = true;
                label2.Visible = true;
                //pictureBox2.Visible = true;

            }
            else if (enabled)
            {
                soundPlayer.SoundLocation = VoiceOff;
                soundPlayer.Play();

                recognition.SpeechRecognized -= new EventHandler<SpeechRecognizedEventArgs>(sr_SpeechRecognized);
                enabled = false;
                label2.Visible = false;
                // pictureBox2.Visible = false;
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

                pictureBox1_Click(this.pictureBox1, null);


            }
            else if (e.Result.Text == "morning")
            {
                soundPlayer.SoundLocation = VoiceUnderstood;
                soundPlayer.Play();

                System.Threading.Thread.Sleep(500);

                richTextBox1.AppendText("You:" + e.Result.Text + Environment.NewLine);

                synthesizer.SpeakAsync("Good Morning Jayesh");
                richTextBox1.AppendText("Voice: Good Morning Jayesh" + Environment.NewLine);


                pictureBox1_Click(this.pictureBox1, null);


            }
            else if (e.Result.Text == "afternoon")
            {
                soundPlayer.SoundLocation = VoiceUnderstood;
                soundPlayer.Play();

                System.Threading.Thread.Sleep(500);

                richTextBox1.AppendText("You:" + e.Result.Text + Environment.NewLine);

                synthesizer.SpeakAsync("Good Afternoon Jayesh");
                richTextBox1.AppendText("Voice: Good Afternoon Jayesh" + Environment.NewLine);

                pictureBox1_Click(this.pictureBox1, null);
            }
            else if (e.Result.Text == "evening")
            {
                soundPlayer.SoundLocation = VoiceUnderstood;
                soundPlayer.Play();

                System.Threading.Thread.Sleep(500);

                richTextBox1.AppendText("You:" + e.Result.Text + Environment.NewLine);

                synthesizer.SpeakAsync("Good Evening Jayesh");
                richTextBox1.AppendText("Voice: Good Evening Jayesh" + Environment.NewLine);

                pictureBox1_Click(this.pictureBox1, null);
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

                pictureBox1_Click(this.pictureBox1, null);
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

                pictureBox1_Click(this.pictureBox1, null);
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

                pictureBox1_Click(this.pictureBox1, null);
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

                pictureBox1_Click(this.pictureBox1, null);
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

                pictureBox1_Click(this.pictureBox1, null);
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

                pictureBox1_Click(this.pictureBox1, null);
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

                pictureBox1_Click(this.pictureBox1, null);

            }
            else if (e.Result.Text == "who are you")
            {
                soundPlayer.SoundLocation = VoiceUnderstood;
                soundPlayer.Play();

                System.Threading.Thread.Sleep(500);

                richTextBox1.AppendText("You:" + e.Result.Text + Environment.NewLine);

                synthesizer.SpeakAsync("I am your virtual assistant");
                richTextBox1.AppendText("Voice: I am your virtual assistant" + Environment.NewLine);

                pictureBox1_Click(this.pictureBox1, null);
            }
            else if (e.Result.Text == "shutdown")
            {
                soundPlayer.SoundLocation = VoiceUnderstood;
                soundPlayer.Play();

                System.Threading.Thread.Sleep(500);

                richTextBox1.AppendText("You:" + e.Result.Text + Environment.NewLine);

                synthesizer.SpeakAsync("Select the Appropriate Option from dialog");
                richTextBox1.AppendText("Voice: Select the Appropriate Option from Dialog" + Environment.NewLine);
                pictureBox1_Click(this.pictureBox1, null);
                DialogResult dialogResult = MessageBox.Show("Do you really want to shutdown the system, select an option", "Shutdown", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    Process.Start("shutdown", "/s /t 0");
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
                pictureBox1_Click(this.pictureBox1, null);
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
                pictureBox1_Click(this.pictureBox1, null);
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
                pictureBox1_Click(this.pictureBox1, null);
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
                pictureBox1_Click(this.pictureBox1, null);
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
                pictureBox1_Click(this.pictureBox1, null);
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
                connectionport.Write("*fan stop");
                connectionport.Close();
                pictureBox1_Click(this.pictureBox1, null);
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
                pictureBox1_Click(this.pictureBox1, null);
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
                pictureBox1_Click(this.pictureBox1, null);
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
                pictureBox1_Click(this.pictureBox1, null);
            }

            // Home Automation Finished

            else if (e.Result.Text == "weather" || e.Result.Text == "show weather" || e.Result.Text == "current weather")
            {

                //to be done

                string results = "";

                using (WebClient wc = new WebClient())
                {


                    results = wc.DownloadString("https://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20weather.forecast%20where%20woeid%20in%20(select%20woeid%20from%20geo.places(1)%20where%20text%3D%22pune%20and%20unit%20%3D%20'C'%2C%20in%22%20)&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys");
                }

                dynamic jo = JObject.Parse(results);



                var items = jo.query.results.channel.item.condition;

                var date = items.date;
                var temp = items.temp;
                var text = items.text;




                var tempc = (0.5555) * (Convert.ToDouble(temp) - 32);


                pictureBox1_Click(this.pictureBox1, null);

                synthesizer.SpeakAsync("Current Weather for Pune is as follows");

                richTextBox1.AppendText("Temperature =  " + tempc + " C  " + Environment.NewLine);

                richTextBox1.AppendText(Environment.NewLine);

                richTextBox1.AppendText("Condition = " + text + Environment.NewLine);

                richTextBox1.AppendText(Environment.NewLine);

                richTextBox1.AppendText("Date  " + date + Environment.NewLine);

                synthesizer.SpeakAsync("Temperature is " + tempc + "degree Celcius");
                synthesizer.SpeakAsync("Condition is " + text);

                Console.WriteLine("Temperature =  " + tempc + "C" + "  " + "Date" + date + "  " + "Condition" + text);

                Console.Read();


            }

            else if (e.Result.Text == "forecast")
            {

                string results = "";

                using (WebClient wc = new WebClient())
                {
                    results = wc.DownloadString("https://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20weather.forecast%20where%20woeid%20in%20(select%20woeid%20from%20geo.places(1)%20where%20text%3D%22pune%20and%20unit%20%3D%20'C'%2C%20in%22%20)&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys");
                }

                dynamic jo = JObject.Parse(results);

                var items = jo.query.results.channel.item.condition;

                var code = items.code;
                var date = items.date;
                var day = items.day;
                var high = items.high;
                var low = items.low;
                var text = items.text;

                pictureBox1_Click(this.pictureBox1, null);
                richTextBox1.AppendText(Environment.NewLine);
                synthesizer.SpeakAsync("Current Forecast is as follows");
                richTextBox1.AppendText("Date  " + date + Environment.NewLine);
                richTextBox1.AppendText("Day  " + day + Environment.NewLine);
                richTextBox1.AppendText("High Temp  " + high + Environment.NewLine);
                richTextBox1.AppendText("Low Temp  " + low + Environment.NewLine);
                richTextBox1.AppendText("Condition  " + text + Environment.NewLine);
                Console.WriteLine("Date" + date + Environment.NewLine);

            }


            else if (e.Result.Text == "Show Cricket News" || e.Result.Text == "Cricket News")
            {
                soundPlayer.SoundLocation = VoiceUnderstood;
                soundPlayer.Play();
                pictureBox1_Click(this.pictureBox1, null);
                System.Threading.Thread.Sleep(500);

                richTextBox1.AppendText("You:" + e.Result.Text + Environment.NewLine);
                richTextBox1.AppendText("Opening Cricket News" + Environment.NewLine);
                synthesizer.Speak("Opening Cricket News");
                System.Diagnostics.Process.Start(@"http://www.cricbuzz.com/cricket-news");
                //string results = "";

                //using (WebClient wc = new WebClient())
                //{
                //    results = wc.DownloadString("https://newsapi.org/v1/articles?source=espn-cric-info&sortBy=top&apiKey=65121f9588cc4b02926240712e4e189c");
                //}

                //dynamic jo = JObject.Parse(results);

                //var items = jo.articles;
                //var status = jo[0].articles[0].author;
                //richTextBox1.AppendText("Date  " + status + Environment.NewLine);



            }
            else if (e.Result.Text == "Cricket info" || e.Result.Text == "Cricket information")
            {
                soundPlayer.SoundLocation = VoiceUnderstood;
                soundPlayer.Play();

                System.Threading.Thread.Sleep(500);
                pictureBox1_Click(this.pictureBox1, null);
                richTextBox1.AppendText("You:" + e.Result.Text + Environment.NewLine);
                richTextBox1.AppendText("Opening Cricket Info" + Environment.NewLine);
                synthesizer.Speak("Opening Cricket Info");
                System.Diagnostics.Process.Start(@"http://www.cricbuzz.com/");

            }
            else if (e.Result.Text == "Cricket" || e.Result.Text == "Live Cricket Score")
            {
                soundPlayer.SoundLocation = VoiceUnderstood;
                soundPlayer.Play();

                System.Threading.Thread.Sleep(500);
                pictureBox1_Click(this.pictureBox1, null);
                richTextBox1.AppendText("You:" + e.Result.Text + Environment.NewLine);
                richTextBox1.AppendText("Opening Live Cricket Score" + Environment.NewLine);
                synthesizer.Speak("Opening Live Cricket Score");
                System.Diagnostics.Process.Start(@"http://www.cricbuzz.com/cricket-match/live-scores");

            }
            else if (e.Result.Text == "ABC News")
            {
                soundPlayer.SoundLocation = VoiceUnderstood;
                soundPlayer.Play();
                pictureBox1_Click(this.pictureBox1, null);
                System.Threading.Thread.Sleep(500);

                richTextBox1.AppendText("You:" + e.Result.Text + Environment.NewLine);
                richTextBox1.AppendText("Opening ABC News" + Environment.NewLine);
                synthesizer.Speak("Opening ABC News");

                Process.Start(@"C:\Program Files (x86)\Mozilla Firefox\firefox.exe", @"C:\Users\Jayesh\Desktop\angula.html");


            }


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







