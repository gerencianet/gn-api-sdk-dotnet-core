using System;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Drawing;

namespace Gerencianet.NETCore.SDK.Examples
{
    class PixGenerateQRCode
    {
        public static void Execute()
        {
            dynamic endpoints =  new Endpoints(JObject.Parse (File.ReadAllText ("credentials.json")));
                
            var param = new {
                id = 147
            };

            try {
                var response = endpoints.PixGenerateQRCode(param);
                Console.WriteLine(response);

                // Generate QRCode Image to JPEG Format
                JObject jsonResponse = JObject.Parse(response);
                string img = (string)jsonResponse["imagemQrcode"];
                img = img.Replace("data:image/png;base64,", "");
                
                var qrCodeImage = Image.FromStream(new MemoryStream(Convert.FromBase64String(img)));
                qrCodeImage.Save("QRCodeImage.jpg");

            } catch (GnException e) {
                Console.WriteLine(e.ErrorType);
                Console.WriteLine(e.Message);
            }
        }
    }
}