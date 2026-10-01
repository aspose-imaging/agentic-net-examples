// HOW-TO: Convert ODG to BMP with 150 DPI Resolution in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.odg");
            string outputPath = Path.Combine("Output", "sample.bmp");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                var options = new BmpOptions();
                options.ResolutionSettings = new Aspose.Imaging.ResolutionSetting(150, 150);
                image.Save(outputPath, options);
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
 * 1. When you need to generate a high‑resolution BMP preview of an ODG diagram for inclusion in a Windows desktop application.
 * 2. When exporting OpenDocument graphics to BMP for legacy systems that require a fixed 150 DPI raster image.
 * 3. When preparing ODG drawings for printing on devices that expect BMP files with a specific DPI setting.
 * 4. When automating batch conversion of ODG files to BMP thumbnails with consistent resolution for a digital asset management workflow.
 * 5. When integrating Aspose.Imaging in a C# service that converts user‑uploaded ODG files to BMP at 150 DPI for downstream image analysis.
 */
