using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Collections.Generic;
using System;

namespace karekok
{
    [Activity(Label = "karekok", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        EditText textBox1, textBox2, textBox3;
        Button btn1,btn2;
      //  TextView label1,label2;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            textBox1 = FindViewById<EditText>(Resource.Id.editText1);
            textBox2 = FindViewById<EditText>(Resource.Id.editText2);
            textBox3 = FindViewById<EditText>(Resource.Id.editText3);
            //  label1 = FindViewById<TextView>(Resource.Id.textView1);
            // label2 = FindViewById<TextView>(Resource.Id.textView2);
            btn1 = FindViewById<Button>(Resource.Id.button1);
            btn2 = FindViewById<Button>(Resource.Id.button2);
            btn1.Click += Btn1_Click;
            btn2.Click += Btn2_Click;
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            textBox1.Text += "√";
        }

        public string karekok(int a)
        {
            
            int sayi = a;
            //ArrayList dizi = new ArrayList();
            List<int> dizi = new List<int>();
            for (int i = 2; i <= sayi;)//bölündüğü sayıları bulmak için 
            {
                if (sayi % i == 0)
                {
                    sayi = sayi / i;
                    dizi.Add(i);
                    i = 2;
                    if (sayi < 2)
                    {

                        break;
                    }
                    if (sayi == 2)
                    {
                        dizi.Add(2);
                        break;
                    }
                }
                else
                    i++;
            }

            int dis = 1, ic = 1, sayac = 0;
            for (int j = 2; j <= a; j++)
            {
                for (int i = 0; i < dizi.Count/*dizideki eleman sayısı*/; i++)
                {
                    if (j == dizi[i])
                    {
                        sayac++;
                        if (sayac == 2)
                        {
                            dis = dis * j;
                            sayac = 0;
                        }
                    }
                }
                if (sayac == 1)
                {
                    ic *= j;
                    sayac = 0;
                }
            }
            if (dis > 1 && ic > 1)
                return dis.ToString() + "√" + ic.ToString();
            else if (dis == 1)
                return "√" + ic.ToString();
            else
                return dis.ToString();

        }
        private void Btn1_Click(object sender, System.EventArgs e)
        {
            try
            {
                textBox2.Text = "";
                textBox3.Text = "";
                if (textBox1.Text != "" || textBox1.Text.IndexOf("-") != -1)
                {
                    string b = textBox1.Text;
                    int index = b.IndexOf("√");
                    if (index == 0)
                    {
                        b = b.Remove(index, 1);
                        textBox3.Text = textBox1.Text;
                        textBox2.Text = karekok(int.Parse(b));

                    }
                    else if (index > 0)
                    {
                        int a1 = int.Parse(b.Substring(0, index));
                        int a2 = int.Parse(b.Substring(index + 1));
                        int a3 = a1 * a1 * a2;
                        textBox3.Text = "√" + a3.ToString();
                        textBox2.Text = karekok(a3);
                    }
                    else if (index == -1)
                    {
                        textBox3.Text = "√" + (int.Parse(b) * int.Parse(b)).ToString();
                        textBox2.Text = karekok(int.Parse(b) * int.Parse(b));
                    }
                }
            }
            catch 
            {
             
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}