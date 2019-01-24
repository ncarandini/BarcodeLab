using Barcode.Generator;
using Barcode.Generator.Common;
using Barcode.Generator.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BarcodeLab
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void CreaBarcodeButton_Clicked(object sender, EventArgs e)
        {
            var barcodeWriter = new BarcodeWriterPixelData
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new EncodingOptions
                {
                    Width = 200,
                    Height = 200,
                    Margin = 0
                }
            };

            PixelData pixelData = barcodeWriter.Write(BarcodeText.Text);
            byte[] bmpArray = BitmapConverter.FromPixelData(pixelData);

            BarcodeImage.Source = ImageSource.FromStream(() => new MemoryStream(bmpArray));
        }
    }
}
