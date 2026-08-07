using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (var image = Image.Load(inputPath))
            {
                var raster = (RasterImage)image;

                string password = "secure123";
                int threshold = 80; // percentage threshold

                bool isSigned = raster.IsDigitalSigned(password, threshold);

                if (isSigned)
                    Console.WriteLine("Image is authentic (digital signature meets threshold).");
                else
                    Console.WriteLine("Image is NOT authentic (digital signature below threshold).");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. A developer can use this code to verify the authenticity of PNG product images uploaded by vendors before displaying them on an e‑commerce website.
 * 2. This snippet helps check whether scanned PNG documents received via email have a valid digital signature before archiving them in a records management system.
 * 3. During a mobile game build pipeline, a developer can ensure PNG assets have not been tampered with by comparing the signature confidence against a security threshold.
 * 4. In a health‑care application, the code validates the integrity of PNG medical images transferred between hospital systems by using Aspose.Imaging’s digital signature check.
 * 5. Marketing teams can automate compliance checks for PNG logos in promotional materials by confirming the digital signature meets an 80 % confidence level before publishing.
 */