// HOW-TO: Scale EPS Image by 1.5 and Save as High Quality JPEG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.eps";
            string outputPath = "output\\scaled.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
            {
                float scale = 1.5f;
                var rasterOptions = new EpsRasterizationOptions
                {
                    PageWidth = epsImage.Width * scale,
                    PageHeight = epsImage.Height * scale
                };

                var jpegOptions = new JpegOptions
                {
                    Quality = 100,
                    VectorRasterizationOptions = rasterOptions
                };

                epsImage.Save(outputPath, jpegOptions);
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
 * 1. When you need to enlarge a vector EPS logo to 150 % and deliver it as a high‑resolution JPEG for web or print using C#.
 * 2. When a printing workflow requires converting EPS artwork to a JPEG thumbnail with a custom scale to preview the final size.
 * 3. When an e‑commerce platform must generate product images from EPS source files at a larger size while preserving maximum JPEG quality.
 * 4. When a document automation system has to rasterize scaled EPS diagrams into JPEGs for inclusion in PDF reports.
 * 5. When a legacy design asset in EPS format must be up‑scaled and saved as a JPEG for compatibility with image‑processing libraries that only support raster formats.
 */
