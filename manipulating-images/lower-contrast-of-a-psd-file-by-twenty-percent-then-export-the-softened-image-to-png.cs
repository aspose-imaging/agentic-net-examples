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
            string inputPath = "input.psd";
            string outputPath = "output/output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                raster.AdjustContrast(-20f);

                var pngOptions = new PngOptions();
                raster.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to reduce the contrast of a Photoshop PSD file by 20 % before delivering a web‑friendly PNG preview, they can use this Aspose.Imaging C# code.
 * 2. When an automated build pipeline must generate low‑contrast thumbnails from layered PSD assets for a digital asset management system, the example shows how to adjust contrast and save as PNG.
 * 3. When a desktop application has to batch‑process client‑provided PSD designs to create softer PNG versions for print proofs, the code demonstrates the required raster image manipulation.
 * 4. When a content‑creation tool wants to export a PSD with reduced contrast to meet accessibility guidelines for low‑vision users, this snippet performs the adjustment and conversion in C#.
 * 5. When a cloud service needs to transform uploaded PSD files into PNGs with a 20 % contrast reduction to improve visual consistency across browsers, the example provides the necessary steps using Aspose.Imaging.
 */