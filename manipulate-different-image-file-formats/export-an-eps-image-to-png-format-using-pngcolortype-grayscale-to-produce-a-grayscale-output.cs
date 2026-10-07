// HOW-TO: Convert EPS File to Grayscale PNG in C# with Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.eps";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (var epsImage = (Aspose.Imaging.FileFormats.Eps.EpsImage)Image.Load(inputPath))
            {
                var rasterOptions = new VectorRasterizationOptions
                {
                    PageWidth = epsImage.Width,
                    PageHeight = epsImage.Height
                };

                var pngOptions = new PngOptions
                {
                    ColorType = PngColorType.Grayscale,
                    VectorRasterizationOptions = rasterOptions
                };

                epsImage.Save(outputPath, pngOptions);
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
 * 1. When you need to generate a lightweight grayscale preview of a vector EPS illustration for a web thumbnail, you can rasterize it to PNG using C# and Aspose.Imaging.
 * 2. When a printing workflow requires converting EPS artwork to a grayscale PNG for proofing on monochrome printers, this code automates the conversion.
 * 3. When an e‑learning platform stores course diagrams as EPS and must deliver them as grayscale PNG images for accessibility compliance, the snippet provides the needed transformation.
 * 4. When a batch‑processing service must extract EPS logos and store them as grayscale PNG files to reduce file size before uploading to a CDN, the code handles the rasterization.
 * 5. When a desktop application needs to display EPS vector graphics in a UI component that only supports PNG and prefers grayscale rendering for a consistent look, this example shows how to perform the conversion.
 */
