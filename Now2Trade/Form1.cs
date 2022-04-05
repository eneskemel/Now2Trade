using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Now2Trade
{
    public partial class Form1 : Form
    {
        private IWebDriver driver = new ChromeDriver();
        string projectURL = "https://now2trade.com/arbitrage/en/";
        string sleepURL = "https://google.com";

        public Form1()
        {
            InitializeComponent();
        }
        int deger = 0;
        int islemBaslamaDurumu = 0;
        int beklemeSuresi = -1;
        int beklemeSuresiGeriSayim = 0;
        int time = 0;
        int loginCheckCount = 0;
        private void tmrAna_Tick(object sender, EventArgs e)
        {
            deger++;
            lblDeger.Text = deger.ToString();
            if (deger == 2)
            {
                islemBaslamaDurumu = 0;
                beklemeSuresi = 0;
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
                driver.Navigate().GoToUrl(projectURL);
            }
            if (deger == 10)
            {
                driver.FindElement(By.Name("userId")).SendKeys("eno_dai@msn.com");
                driver.FindElement(By.Name("passW")).SendKeys("1236asd");
                driver.FindElement(By.Name("passW")).SendKeys(OpenQA.Selenium.Keys.Tab);
                string Giris = "document.querySelector(\"#app > div.view.view-main.view-init.safe-areas > div.page.page-signin.page-current > div.page-content > div.block.bottom-button-container.HIDEONINPUTFOCUS > div > div > button\").click();";
                jsCalistir(Giris);
                listLog.Items.Add("Giris Yaptım");
            }
            if (deger == 20)
            {
                String html = driver.PageSource;
                if (html.Contains("Enes KEMEL"))
                {
                    listLog.Items.Add("Giris Basarili");
                }
                else
                {
                    if (loginCheckCount < 3)
                    {
                        deger = 0;
                        listLog.Items.Add("Giriş Başarısız.");
                        loginCheckCount++;
                    }
                    else
                    {
                        tmrAna.Stop();
                        listLog.Items.Add("Bir şeyler ters gitti login olamıyorum.");
                    }
                 
                }
            }
            if (deger == 21)
            {
                string islemDurumu = driver.FindElement(By.CssSelector(".text-mute.small.text-secondary.mt-0.timelapes")).Text;
                listLog.Items.Add(islemDurumu);
                if (islemDurumu.Contains("Finished")) //Finished
                {
                    islemBaslamaDurumu = 1;
                    listLog.Items.Add("İşleme Başlayacağım");
                    string islemSayfasinaGec = "document.querySelector(\"#app > div.view.view-main.view-init.safe-areas > div.page.page-homepage.light.page-current > div.toolbar.tabbar.toolbar-bottom.o-visible.o-hidden.BOTTOM_MENUS > div > a.BOTTOMTABS.tab-link.exCh\").click()";
                    jsCalistir(islemSayfasinaGec);
                    listLog.Items.Add("İslem Sayfasina Geçtim");
                }
                else if (islemDurumu.Contains("hour")) //hour
                {
                    listLog.Items.Add("Bekleme saati oluşturacağım.");
                    beklemeSuresi = islemDurumuKontrolFNC(islemDurumu);
                    beklemeSuresiGeriSayim = beklemeSuresi;
                    tmrZamanHesaplama.Start();
                }
                else
                {
                    tmrAna.Stop();
                    listLog.Items.Add("Bir sikinti var." + islemDurumu);
                }
            }
            if (deger == 26)
            {
                if (islemBaslamaDurumu == 1)
                {
                    string tumBakiyeSec = "document.querySelector(\"#exchanges > div:nth-child(1) > div > ul > li.item-content.item-input > div:nth-child(3) > button\").click()";
                    jsCalistir(tumBakiyeSec);
                    listLog.Items.Add("Bakiye Seçtim.");
                    tmrIslem.Start();
                    tmrAna.Stop();
                    tmrTime.Start();
                }
            }
            if (deger == 30)
            {
                if (beklemeSuresi < 1)
                {
                    deger = 0;
                }
            }
            if (deger == beklemeSuresi)
            {
                islemBaslamaDurumu = 0;
                beklemeSuresi = 0;
                deger = 0;
                listLog.Items.Clear();
            }
        }
        private void jsCalistir(string jsString)
        {
            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript(jsString);
            }
            catch (Exception ex)
            {
                listLog.Items.Add(ex.ToString());
            }

        }
        double farkKontrol = 0;
        private void tmrIslem_Tick(object sender, EventArgs e)
        {
            listLog.SelectedIndex = listLog.Items.Count - 1;
            try
            {
                try
                {
                    String fark = driver.FindElement(By.CssSelector(".farq2")).Text;
                    String[] farkList = fark.Split(' ');
                    farkKontrol = System.Convert.ToDouble(farkList[0]);
                    listLog.Items.Add(farkKontrol + " Fark durumu ");
                    listLog.SelectedIndex = listLog.Items.Count - 1;
                    if (farkKontrol > Convert.ToDouble(lblFarkMax.Text))
                    {
                        lblFarkMax.Text = farkKontrol.ToString();
                    }
                    if (farkKontrol > Convert.ToInt16(txtFark.Text))
                    {
                        lblSonIslem.Text = (farkKontrol + " Fark durumu " + DateTime.Now.Hour.ToString() + " " + DateTime.Now.Minute.ToString() + " " + DateTime.Now.Second.ToString());
                        string islemYap = "document.querySelector(\"#exchanges > div:nth-child(2) > div.row.PRICELESS > table > tbody > tr:nth-child(7) > td.startButtons > button\").click()";
                        jsCalistir(islemYap);
                        listLog.Items.Add("İşlemi Yaptım");
                        tmrIslem.Stop();
                        tmrAna.Start();
                        tmrTime.Stop();
                        time = 0;
                    }
                }
                catch (Exception exx)
                {
                    listLog.Items.Add(exx.ToString());
                }
            }
            catch (Exception ex)
            {
                listLog.Items.Add(ex.ToString());
            }
        }

        private void btnBaslat_Click(object sender, EventArgs e)
        {
            tmrAna.Start();
        }

        private int islemDurumuKontrolFNC(string islemSaati)
        {
            String[] list = islemSaati.Split(' ');
            int beklemeSaniyesi = 0;
            int saat = Convert.ToInt32(list[0]);
            int dakika = Convert.ToInt32(list[2]);
            int saniye = Convert.ToInt32(list[4]);
            beklemeSaniyesi = saat * 60 * 60;
            beklemeSaniyesi += dakika * 60;
            beklemeSaniyesi += saniye;

            Random rdm = new Random();
            int rdmDeger = rdm.Next(1, 1000);
            beklemeSaniyesi += rdmDeger;

            listLog.Items.Add(beklemeSaniyesi / 60 + " Dakika Sonra");

            driver.Navigate().GoToUrl(sleepURL);
            return beklemeSaniyesi;
        }

        private void tmrZamanHesaplama_Tick(object sender, EventArgs e)
        {
            if (beklemeSuresiGeriSayim > 1)
            {
                lblKalanZaman.Text = beklemeSuresiGeriSayim / 60 + " Kalan dakika";
                beklemeSuresiGeriSayim--;
            }
            else
            {
                tmrZamanHesaplama.Stop();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void tmrTime_Tick(object sender, EventArgs e)
        {
            time++;
            lblDeger.Text = "İşlem Yapılmadan geçen süre " + time;
            if (time == 600)
            {
                time = 0;
                deger = 0;
                islemBaslamaDurumu = 0;
                beklemeSuresi = -1;
                beklemeSuresiGeriSayim = 0;
                tmrTime.Stop();
                tmrIslem.Stop();
                tmrAna.Start();
            }
        }
    }
}
