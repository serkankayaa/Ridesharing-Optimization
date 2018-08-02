using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;


namespace RV_Graph
{
    public partial class Ridesharing : Form
    {
        public Ridesharing()
        {
            InitializeComponent();
        }

        List<Vehicle> Araclar = new List<Vehicle>();
        List<Request> Istekler = new List<Request>();
        List<string> enlemKoordinatlari = new List<string>();
        List<string> boylamKoordinatlari = new List<string>();
        int kapasiteSiniri = 5;
        double waitingTimeSiniri = 0.10;
        double delaySiniri = 0.10;       // Eğer istek-istek eşleşmesi travel fonk. ile olursa sinir değişkenlerini travel fonk. içine alabilirsin.
        double[,] Delay;
        List<Vehicle> VehicleRequestMatch_Vehicles = new List<Vehicle>();
        List<Request> VehicleRequestMatch_Requests = new List<Request>();

        List<Request> RequestRequestMatch_Request1 = new List<Request>();
        List<Request> RequestRequestMatch_Request2 = new List<Request>();

        double globalWaitingTime;
        double globalDelay;

        //ArrayList VehicleRequestMatch_Vehicles = new ArrayList();
        //ArrayList VehicleRequestMatch_Requests = new ArrayList();
        //ArrayList RequestRequestMatch_Request1 = new ArrayList();
        //ArrayList RequestRequestMatch_Request2 = new ArrayList();

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;   // Pencereyi tam ekran yapmak için
        }

        private void btnDegerAta_Click(object sender, EventArgs e)
        {
            Random rastgele = new Random();
            GetDatabase();
            EkranaBastir();
            btnRunRV.Enabled = true;
        }

        public SqlConnection baglanti;

        private void GetDatabase()
        {
            Araclar.Clear();
            Istekler.Clear();
            baglanti = new SqlConnection("server=.; Initial Catalog=RideSharingDB;Integrated Security=SSPI");
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                SqlCommand komut = new SqlCommand();
                komut.CommandText = "Select top 10 * from Request Order By Rand()";
                komut.Connection = baglanti;
                komut.ExecuteNonQuery();
                SqlDataReader oku = komut.ExecuteReader();

                while (oku.Read())
                {
                    Request tempRequest = new Request();
                    tempRequest.request_ID = Convert.ToInt32(oku["request_ID"]);
                    tempRequest.AlinanKoordinatX = oku["AlinanKoordinatX"].ToString().Trim();
                    tempRequest.AlinanKoordinatY = oku["AlinanKoordinatY"].ToString().Trim();
                    tempRequest.HedefKoordinatX = oku["HedefKoordinatX"].ToString().Trim();
                    tempRequest.HedefKoordinatY = oku["HedefKoordinatY"].ToString().Trim();

                    string[] words = tempRequest.AlinanKoordinatX.Split(',');
                    tempRequest.AlinanKoordinatX = words[0] + "." + words[1];
                    string[] words2 = tempRequest.AlinanKoordinatY.Split(',');
                    tempRequest.AlinanKoordinatY = words2[0] + "." + words2[1];
                    string[] words3 = tempRequest.HedefKoordinatX.Split(',');
                    tempRequest.HedefKoordinatX = words3[0] + "." + words3[1];
                    string[] words4 = tempRequest.HedefKoordinatY.Split(',');
                    tempRequest.HedefKoordinatY = words4[0] + "." + words4[1];

                    Istekler.Add(tempRequest);
                }
                oku.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show("İstekler eklenirken hata oluştu! Hata -> " + error);
            }

            try
            {
                SqlCommand komut2 = new SqlCommand();
                komut2.CommandText = "Select top 5 * from Vehicle";
                komut2.Connection = baglanti;
                komut2.ExecuteNonQuery();
                SqlDataReader oku = komut2.ExecuteReader();

                while (oku.Read())
                {
                    Vehicle tempVehicle = new Vehicle();
                    tempVehicle.vehicle_ID = Convert.ToInt32(oku["vehicle_ID"]);
                    tempVehicle.AnlikKonumX = oku["AnlikKonumX"].ToString().Trim();
                    tempVehicle.AnlikKonumY = oku["AnlikKonumY"].ToString().Trim();
                    tempVehicle.HedefKonumX = oku["HedefKonumX"].ToString().Trim();
                    tempVehicle.HedefKonumY = oku["HedefKonumY"].ToString().Trim();

                    string[] words = tempVehicle.AnlikKonumX.Split(',');
                    tempVehicle.AnlikKonumX = words[0] + "." + words[1];
                    string[] words2 = tempVehicle.AnlikKonumY.Split(',');
                    tempVehicle.AnlikKonumY = words2[0] + "." + words2[1];
                    string[] words3 = tempVehicle.HedefKonumX.Split(',');
                    tempVehicle.HedefKonumX = words3[0] + "." + words3[1];
                    string[] words4 = tempVehicle.HedefKonumY.Split(',');
                    tempVehicle.HedefKonumY = words4[0] + "." + words4[1];

                    Araclar.Add(tempVehicle);
                }
                oku.Close();

                //SqlCommand komut3 = new SqlCommand();
                //komut3.CommandText = "";
                //komut3.Connection = baglanti;
                //komut3.ExecuteNonQuery();
                //SqlDataReader oku = komut3.ExecuteReader();    // Araclara atanan istekleri çekmesi gerekiyor

                //while (oku.Read())
                //{
                    
                //}

            }
            catch (Exception error)
            {
                MessageBox.Show("Araçlar eklenirken hata oluştu! Hata -> " + error);
            }

            baglanti.Close();
        }

        private void EkranaBastir()
        {
            lstPickUpX.Items.Clear();
            lstPickUpY.Items.Clear();
            lstDropOffX.Items.Clear();
            lstDropOffY.Items.Clear();
            lstVehicleInstantX.Items.Clear();
            lstVehicleInstantY.Items.Clear();
            lstAtananIstekler.Items.Clear();

            for (int i = 0; i < Istekler.Count; i++)
            {
                lstPickUpX.Items.Add(Istekler[i].AlinanKoordinatX);
                lstPickUpY.Items.Add(Istekler[i].AlinanKoordinatY);
                lstDropOffX.Items.Add(Istekler[i].HedefKoordinatX);
                lstDropOffY.Items.Add(Istekler[i].HedefKoordinatY);
            }

            for (int i = 0; i < Araclar.Count; i++)
            {
                lstVehicleInstantX.Items.Add(Araclar[i].AnlikKonumX);
                lstVehicleInstantY.Items.Add(Araclar[i].AnlikKonumY);
            }
        }

        private void EslesmeleriVeritabaninaAktar()
        {
            baglanti = new SqlConnection("server=.; Initial Catalog=RideSharingDB;Integrated Security=SSPI");
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();

            try
            {
                for (int i = 0; i < VehicleRequestMatch_Vehicles.Count; i++)
                {
                    SqlCommand komut = new SqlCommand();
                    komut.CommandText = "Insert into RV_Matchs(vehicle_ID, request_ID, waitingTime, delay) values ('" + VehicleRequestMatch_Vehicles[i].vehicle_ID + "', '" + VehicleRequestMatch_Requests[i].request_ID + "', '" + VehicleRequestMatch_Requests[i].waitingTime.ToString() + "', '" + VehicleRequestMatch_Requests[i].delay.ToString() + "')";
                    komut.Connection = baglanti;
                    komut.ExecuteNonQuery();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Vehicle-Request veritabanı eklemesinde sorun oluştu! Sorun -> " + error);
            }

            try
            {
                for (int i = 0; i < RequestRequestMatch_Request1.Count; i++)
                {
                    SqlCommand komut = new SqlCommand();
                    komut.CommandText = "Insert into RR_Matchs(request1_ID, request2_ID, waitingTime1, delay1, waitingTime2, delay2) values ('" + RequestRequestMatch_Request1[i].request_ID + "', '" + RequestRequestMatch_Request2[i].request_ID + "', '" + RequestRequestMatch_Request1[i].waitingTime.ToString() + "', '" + RequestRequestMatch_Request1[i].delay.ToString() + "', '" + RequestRequestMatch_Request2[i].waitingTime.ToString() + "', '" + RequestRequestMatch_Request2[i].delay.ToString() + "')";
                    komut.Connection = baglanti;
                    komut.ExecuteNonQuery();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Request-Request veritabanı eklemesinde sorun oluştu! Hata -> " + error);
            }
            baglanti.Close();
        }

        private void btnRunRV_Click(object sender, EventArgs e)
        {
            AracIstekEslesmesi();
            //IstekIstekEslesmesi();
            EslesmeleriVeritabaninaAktar();
        }

        private void AracIstekEslesmesi()
        {
            Request[] array = new Request[1];
            for (int i = 0; i < Araclar.Count; i++)
            {
                for (int j = 0; j < Istekler.Count; j++)
                {
                    array[0] = Istekler[j];
                    if (Travel(Araclar[i], array))
                    {
                        Istekler[j].waitingTime = globalWaitingTime;
                        Istekler[j].delay = globalDelay;

                        VehicleRequestMatch_Vehicles.Add(Araclar[i]);
                        VehicleRequestMatch_Requests.Add(Istekler[j]);

                        lstEslesme.Items.Add("Vehicle" + i + " <--> Request" + j);
                    }
                }
            }
        }

        private void IstekIstekEslesmesi()
        {
            Delay = new double[lstPickUpX.Items.Count, lstPickUpX.Items.Count];
            for (int i = 0; i < lstPickUpX.Items.Count; i++)    // Request sayısı kadar dönecek
            {
                for (int j = 0; j < lstPickUpX.Items.Count; j++)    // Request sayısı kadar dönecek
                {
                    if (lstPickUpX.Items[i] != lstPickUpX.Items[j])
                    {
                        Distance d = new Distance();
                        double istek1_yolculuk_mesafe;
                        istek1_yolculuk_mesafe = d.Distance_Measure(Istekler[i].AlinanKoordinatX + ", " + Istekler[i].AlinanKoordinatY, Istekler[i].HedefKoordinatX + ", " + Istekler[i].HedefKoordinatY);
                        double istek2_yolculuk_mesafe;
                        istek2_yolculuk_mesafe = d.Distance_Measure(Istekler[j].AlinanKoordinatX + ", " + Istekler[j].AlinanKoordinatY, Istekler[j].HedefKoordinatX + ", " + Istekler[j].HedefKoordinatY);

                        double r1denr2yemesafe = d.Distance_Measure(Istekler[i].AlinanKoordinatX + ", " + Istekler[i].AlinanKoordinatY, Istekler[j].AlinanKoordinatX + ", " + Istekler[j].AlinanKoordinatY);
                        double mesafe;
                        if (istek1_yolculuk_mesafe >= istek2_yolculuk_mesafe)   // SENARYO 1
                        {
                            // Sanal aracı r1'de farzediyoruz, r1 için bekleme süresi olmayacak, delay hesaplanacak.
                            Istekler[i].waitingTime = 0;
                            double r1varistanr2varisamesafe = d.Distance_Measure(Istekler[i].HedefKoordinatX + ", " + Istekler[i].HedefKoordinatY, Istekler[j].HedefKoordinatX + ", " + Istekler[j].HedefKoordinatY);
                            double r2denr1varisamesafe = d.Distance_Measure(Istekler[j].AlinanKoordinatX + ", " + Istekler[j].AlinanKoordinatY, Istekler[i].HedefKoordinatX + ", " + Istekler[i].HedefKoordinatY);
                            mesafe = (r1denr2yemesafe + r2denr1varisamesafe) - istek1_yolculuk_mesafe;
                            Istekler[i].delay = Math.Round(SureHesapla(mesafe), 6);     // Math.Round sayesinde virgülden sonra 5 basamak gelecek
                            // istek1 bekleme süresi ve gecikme süresi atandı

                            Istekler[j].waitingTime = SureHesapla(r1denr2yemesafe);
                            mesafe = (r2denr1varisamesafe + r1varistanr2varisamesafe) - istek2_yolculuk_mesafe;
                            Istekler[j].delay = Math.Round(SureHesapla(mesafe), 6);
                            // istek2 bekleme süresi ve gecikme süresi atandı

                            //lstEslesme.Items.Add("Request" + i + "-" + j + " eşleşmesi senaryo1 istek1 waiting->" + Istekler[i].waitingTime + " istek1 delay->" + Istekler[i].delay + " istek2 waiting->" + Istekler[j].waitingTime + " istek2 delay->" + Istekler[j].delay);
                        }

                        else   // SENARYO 2
                        {
                            // Sanal aracı r1'de farzediyoruz, r1 için bekleme süresi olmayacak, delay hesaplanacak.
                            Istekler[i].waitingTime = 0;
                            double r2varistanr1varisamesafe = d.Distance_Measure(Istekler[j].HedefKoordinatX + ", " + Istekler[j].HedefKoordinatY, Istekler[i].HedefKoordinatX + ", " + Istekler[i].HedefKoordinatY);
                            mesafe = (r1denr2yemesafe + istek2_yolculuk_mesafe + r2varistanr1varisamesafe) - istek1_yolculuk_mesafe;
                            Istekler[i].delay = Math.Round(SureHesapla(mesafe), 6);     // Math.Round sayesinde virgülden sonra 5 basamak gelecek
                            // istek1 bekleme süresi ve gecikme süresi atandı

                            Istekler[j].waitingTime = Math.Round(SureHesapla(r1denr2yemesafe), 6);
                            Istekler[j].delay = 0;

                            //lstEslesme.Items.Add("Request" + i + "-" + j + " eşleşmesi senaryo2 istek1 waiting->" + Istekler[i].waitingTime + " istek1 delay->" + Istekler[i].delay + " istek2 waiting->" + Istekler[j].waitingTime + " istek2 delay->" + Istekler[j].delay);
                        }
                        if (Istekler[i].delay <= 0.25 && Istekler[j].waitingTime <= 0.25 && Istekler[j].delay <= 0.25)  // 0.25 -> 15dk'ya tekabül ediyor.
                        {
                            RequestRequestMatch_Request1.Add(Istekler[i]);
                            RequestRequestMatch_Request2.Add(Istekler[j]);
                            lstEslesme.Items.Add("Request " + i + " <--> Request " + j);
                        }
                        Delay[i, j] = Istekler[i].delay + Istekler[j].delay;
                    }
                }
            }
        }

        private bool Travel(Vehicle v, Request[] atanacakIstekler)
        {
            lstEslesme2.Items.Add("----");
            if (v.atananIstekler.Count() < kapasiteSiniri)   // !! kapasite kontrolü yapılıyor.
            {
                Distance d = new Distance();
                double[] vehicleToRequestDistance = new double[atanacakIstekler.Count()];   // Araçtan isteklere olan mesafeleri sıralamak için kullanılıyor.
                string X = v.AnlikKonumX;
                string Y = v.AnlikKonumY;

                for (int i = 0; i < atanacakIstekler.Count(); i++)      // Araçtan isteklerin bulundukları konuma mesafelerinin hesaplanması
                {
                    vehicleToRequestDistance[i] = SureHesapla(d.Distance_Measure(v.AnlikKonumX + ", " + v.AnlikKonumY, atanacakIstekler[i].AlinanKoordinatX + ", " + atanacakIstekler[i].AlinanKoordinatY));
                }

                Request tempRequest;
                double tempDistance;

                for (int i = 0; i < vehicleToRequestDistance.Count(); i++)    // Araçlardan isteklerin anlık konumlarına göre isteklerin mesafe sıralaması yapılıyor.
                {
                    for (int j = 0; j < vehicleToRequestDistance.Count(); j++)
                    {
                        if (vehicleToRequestDistance[j] > vehicleToRequestDistance[i])
                        {
                            tempDistance = vehicleToRequestDistance[i];     // Aracın isteklere olan mesafesine göre sıralama yapılıyor.
                            vehicleToRequestDistance[i] = vehicleToRequestDistance[j];
                            vehicleToRequestDistance[j] = tempDistance;

                            tempRequest = atanacakIstekler[i];      // Yukarıda yapılan sıralamadaki değişiklikler request'e de uygulanıyor.
                            atanacakIstekler[i] = atanacakIstekler[j];
                            atanacakIstekler[j] = tempRequest;
                        }
                    }
                }

                for (int i = 0; i < atanacakIstekler.Count(); i++)
                {
                    try
                    {
                        atanacakIstekler[i].waitingTime = atanacakIstekler[i - 1].waitingTime + SureHesapla(d.Distance_Measure(X + ", " + Y, atanacakIstekler[i].AlinanKoordinatX + ", " + atanacakIstekler[i].AlinanKoordinatY));
                    }
                    catch (Exception hata)
                    {
                        atanacakIstekler[i].waitingTime = SureHesapla(d.Distance_Measure(X + ", " + Y, atanacakIstekler[i].AlinanKoordinatX + ", " + atanacakIstekler[i].AlinanKoordinatY));
                    }
                    X = atanacakIstekler[i].AlinanKoordinatX;
                    Y = atanacakIstekler[i].AlinanKoordinatY;
                    if (atanacakIstekler[i].waitingTime > waitingTimeSiniri)    // !! waitingTime kontrolü yapılıyor.
                        return false;
                }

                double lastestWaitingTime = atanacakIstekler[atanacakIstekler.Count() - 1].waitingTime;
                double[] vehicleToRequestTargetDistance = new double[atanacakIstekler.Count() + v.atananIstekler.Count()];
                double[] ikiHedefArasiMesafeler = new double[atanacakIstekler.Count() + v.atananIstekler.Count()];
                Request[] aracIstekler = new Request[v.atananIstekler.Count() + atanacakIstekler.Count()];
                for (int i = 0; i < aracIstekler.Count(); i++)      // aracIstekler diye ol
                {
                    aracIstekler[i] = new Request();
                }

                for (int i = 0; i < v.atananIstekler.Count(); i++)
                {
                    aracIstekler[i] = v.atananIstekler[i];
                    vehicleToRequestTargetDistance[i] = d.Distance_Measure(v.AnlikKonumX + ", " + v.AnlikKonumY, aracIstekler[i].HedefKoordinatX + ", " + aracIstekler[i].HedefKoordinatY);
                }
                for (int i = 0; i < atanacakIstekler.Count(); i++)      // Araçtan hedefe mesafe ölçülüyor ve isteğin konumu aracIstekler dizisine atanıyor.
                {
                    aracIstekler[v.atananIstekler.Count() + i] = atanacakIstekler[i];
                    vehicleToRequestTargetDistance[v.atananIstekler.Count() + i] = d.Distance_Measure(v.AnlikKonumX + ", " + v.AnlikKonumY, aracIstekler[i].HedefKoordinatX + ", " + aracIstekler[i].HedefKoordinatY);
                }

                for (int i = 0; i < vehicleToRequestTargetDistance.Count(); i++)
                {
                    for (int j = 0; j < vehicleToRequestTargetDistance.Count(); j++)
                    {
                        if (vehicleToRequestTargetDistance[j] > vehicleToRequestTargetDistance[i])
                        {
                            tempDistance = vehicleToRequestTargetDistance[i];
                            vehicleToRequestTargetDistance[i] = vehicleToRequestTargetDistance[j];
                            vehicleToRequestTargetDistance[j] = tempDistance;

                            tempRequest = aracIstekler[i];
                            aracIstekler[i] = aracIstekler[j];
                            aracIstekler[j] = tempRequest;
                        }
                    }
                }

                for (int i = 0; i < ikiHedefArasiMesafeler.Count(); i++)
                {
                    try
                    {
                        ikiHedefArasiMesafeler[i] = ikiHedefArasiMesafeler[i - 1] + SureHesapla(d.Distance_Measure(X + ", " + Y, aracIstekler[i].HedefKoordinatX + ", " + aracIstekler[i].HedefKoordinatY));
                    }
                    catch (Exception hata)
                    {
                        ikiHedefArasiMesafeler[i] = SureHesapla(d.Distance_Measure(X + ", " + Y, aracIstekler[i].HedefKoordinatX + ", " + aracIstekler[i].HedefKoordinatY));
                    }
                    X = aracIstekler[i].HedefKoordinatX;
                    Y = aracIstekler[i].HedefKoordinatY;
                }

                for (int i = 0; i < aracIstekler.Count(); i++)      // delay hesapla
                {
                    double istektenHedefeSure = SureHesapla(d.Distance_Measure(aracIstekler[i].AlinanKoordinatX + ", " + aracIstekler[i].AlinanKoordinatY, aracIstekler[i].HedefKoordinatX + ", " + aracIstekler[i].HedefKoordinatY));
                    aracIstekler[i].delay = lastestWaitingTime + ikiHedefArasiMesafeler[i] - aracIstekler[i].waitingTime - istektenHedefeSure;
                    if (aracIstekler[i].delay > delaySiniri)
                        return false;
                }

                globalWaitingTime = lastestWaitingTime;
                globalDelay = aracIstekler[aracIstekler.Count() - 1].delay;

                //deneme
                lstEslesme2.Items.Add("wT -> " + lastestWaitingTime);
                lstEslesme2.Items.Add("delay -> " + aracIstekler[aracIstekler.Count() - 1].delay);
                //deneme bitiş
                return true;
            }
            else
                return false;
        }

        private double SureHesapla(double mesafe)
        {
            return mesafe / 60;   // 60km sabit hızla gittiği varsayılmaktadır. Saat cinsinden sonuç bulunur.
        }
    }
}
