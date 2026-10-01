// HOW-TO: Convert OTG to PNG with Gamma Correction Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.otg");
            string outputPath = Path.Combine("Output", "sample.png");

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (Image image = Image.Load(inputPath))
            {
                var rasterOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = image.Width,
                    PageHeight = image.Height
                };
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };
                image.Save(outputPath, pngOptions);
            }

            using (RasterImage raster = (RasterImage)Image.Load(outputPath))
            {
                raster.AdjustGamma(2.2f);
                raster.Save(outputPath);
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
 * 1. When you need to display an OTG vector diagram on the web, you can rasterize it to a PNG and adjust gamma so the colors appear with correct brightness across browsers.
 * 2. When a printing workflow requires converting proprietary OTG files to PNG thumbnails while ensuring the brightness matches the original design, this code automates the process in C#.
 * 3. When integrating a CAD viewer that only supports raster images, you can use this snippet to transform OTG drawings into PNGs and apply gamma correction for accurate visual representation.
 * 4. When building an automated asset pipeline that ingests OTG graphics and outputs PNG assets for mobile apps, the gamma adjustment ensures consistent appearance on devices with different display calibrations.
 * 5. When creating a batch conversion tool to prepare OTG files for machine‑learning image analysis, converting to PNG and normalizing gamma helps maintain consistent pixel intensity for reliable model training.
 */
