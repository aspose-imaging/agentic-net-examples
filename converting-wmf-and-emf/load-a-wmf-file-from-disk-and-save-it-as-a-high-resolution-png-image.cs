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
            string inputPath = "input.wmf";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var pngOptions = new PngOptions();
                image.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to convert legacy Windows Metafile (WMF) graphics into high‑resolution PNG files for web display or documentation, they can use this code.
 * 2. When an application must batch‑process vector icons stored as WMF and generate raster PNG assets for mobile apps, the snippet provides the necessary C# conversion logic.
 * 3. When a reporting tool generates charts in WMF format but the final PDF requires embedded PNG images, this code enables the format transformation using Aspose.Imaging.
 * 4. When a migration project moves old Windows‑based UI resources from WMF to PNG to support cross‑platform .NET Core applications, the example shows how to load and save the images.
 * 5. When an automated build pipeline needs to validate that WMF files are correctly rendered by converting them to PNG and comparing pixel data, this code supplies the conversion step.
 */