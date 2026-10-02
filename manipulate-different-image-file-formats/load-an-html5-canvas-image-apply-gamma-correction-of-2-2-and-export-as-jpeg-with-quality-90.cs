// HOW-TO: Apply Gamma Correction and Save JPEG with Quality 90 in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                image.AdjustGamma(2.2f);

                Source source = new FileCreateSource(outputPath, false);
                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 90,
                    Source = source
                };

                image.Save(outputPath, jpegOptions);
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
 * 1. When you need to adjust the brightness of a PNG exported from an HTML5 canvas before delivering it as a high‑quality JPEG on a web site.
 * 2. When a photo‑editing application must apply a standard 2.2 gamma curve to images and then compress them for storage or transmission.
 * 3. When you are converting user‑generated PNG graphics to JPEG while preserving visual fidelity by setting the JPEG quality to 90.
 * 4. When an automated batch process has to ensure output folders exist, apply gamma correction, and save images in a format suitable for browsers.
 * 5. When you want to programmatically correct the gamma of raster images in C# and export them as JPEGs for use in email newsletters or PDFs.
 */
