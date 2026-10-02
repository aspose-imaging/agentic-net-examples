// HOW-TO: Embed PNG Image as Base64 in HTML Email Using C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace ImageToEmail
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.png";
                string outputPath = "output/email.html";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        var options = new PngOptions();
                        image.Save(ms, options);
                        string base64 = Convert.ToBase64String(ms.ToArray());
                        string html = $"<html><body><img src=\"data:image/png;base64,{base64}\" alt=\"Embedded Image\"/></body></html>";
                        File.WriteAllText(outputPath, html);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to send a product screenshot in an automated marketing email without attaching separate files.
 * 2. When generating transactional emails that display a QR code inline for payment verification.
 * 3. When creating newsletters that embed promotional graphics directly in the HTML to avoid image blocking by email clients.
 * 4. When building a reporting system that inserts dynamically generated charts into email bodies for real‑time data visualization.
 * 5. When developing a notification service that includes a company logo as an embedded PNG to maintain brand consistency across all recipients.
 */
