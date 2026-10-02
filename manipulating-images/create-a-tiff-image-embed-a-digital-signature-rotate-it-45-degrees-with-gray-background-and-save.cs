// HOW-TO: Create TIFF Image With Digital Signature And Rotate 45 Degrees In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.tiff";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int width = 500;
            int height = 500;

            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            using (RasterImage image = (RasterImage)Image.Create(tiffOptions, width, height))
            {
                Aspose.Imaging.Color white = Aspose.Imaging.Color.FromArgb(255, 255, 255, 255);
                Aspose.Imaging.Color[] whitePixels = Enumerable.Repeat(white, width * height).ToArray();
                image.SavePixels(new Aspose.Imaging.Rectangle(0, 0, width, height), whitePixels);

                string password = "secret";
                image.EmbedDigitalSignature(password);

                Aspose.Imaging.Color gray = Aspose.Imaging.Color.FromArgb(255, 128, 128, 128);
                image.Rotate(45f, true, gray);

                image.Save(outputPath, tiffOptions);
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
 * 1. When you need to generate a secure TIFF document that can be verified later, you can embed a digital signature using Aspose.Imaging in C#.
 * 2. When a workflow requires adding a 45‑degree rotation to an image while preserving a gray fill color for the empty corners, this code demonstrates how to do it.
 * 3. When you must create a blank white canvas of a specific size before adding content, the example shows how to fill all pixels programmatically.
 * 4. When exporting processed images to the TIFF format with custom options, the snippet shows how to save the result using TiffOptions.
 * 5. When automating document preparation for compliance or archival purposes, embedding a password‑protected signature and rotating the page ensures both authenticity and proper orientation.
 */
