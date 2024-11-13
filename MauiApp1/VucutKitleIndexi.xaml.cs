using System;
namespace MauiApp1;

public partial class VucutKitleIndexi : ContentPage
{
	public VucutKitleIndexi()
	{
		InitializeComponent();
	}
    private void Hesapla_Clicked(object sender, EventArgs e)
    {
      
        if (!string.IsNullOrWhiteSpace(txtAgirlik.Text) && !string.IsNullOrWhiteSpace(txtBoy.Text))
        {
            double agirlik = Convert.ToDouble(txtAgirlik.Text);
            double boy = Convert.ToDouble(txtBoy.Text) / 100; 

            
            double vki = agirlik / (boy * boy);

            
            lblVKI.Text = $"V�cut Kitle �ndeksi: {vki:F2}";

            
            if (vki < 16)
                lblVKI.Text += "\nIleri Duzeyde Zayif";
            else if (vki >= 16 && vki <= 16.99)
                lblVKI.Text += "\nOrta Duzeyde Zayif";
            else if (vki >= 17 && vki <= 18.49)
                lblVKI.Text += "\nHafif Duzeyde Zayif";
            else if (vki >= 18.50 && vki <= 24.90)
                lblVKI.Text += "\nNormal Kilolu";
            else if (vki >= 25 && vki <= 29.99)
                lblVKI.Text += "\nHafif Sisman";
            else if (vki >= 30 && vki <= 34.99)
                lblVKI.Text += "\n1. Derecede Obez";
            else if (vki >= 35 && vki <= 39.99)
                lblVKI.Text += "\n2. Derecede Obez";
            else
                lblVKI.Text += "\n�leri D�zeyde Obez";
        }
        else
        {
            DisplayAlert("Uyari", "Lutfen agirlik ve boy degerlerini giriniz.", "Tamam");
        }
    }
}
