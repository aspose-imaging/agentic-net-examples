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
            string inputPath = "Input/input.wmf";
            string outputPath = "Output/output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var rasterOptions = new WmfRasterizationOptions
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
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a legacy Windows Metafile (WMF) diagram needs to be displayed on a web page that only supports raster images, a developer can use this code to convert the WMF to a PNG with a white background.
 * 2. When an automated report generation system must embed vector graphics from WMF files into PDF or HTML outputs that require PNG thumbnails, this snippet provides the conversion step.
 * 3. When migrating an old desktop application’s assets to a cross‑platform mobile app, developers can batch‑process WMF icons into PNGs using this code to ensure consistent sizing and background.
 * 4. When a document management workflow receives user‑uploaded WMF files and needs to store preview images in a searchable image store, the code converts each WMF to a PNG while preserving the original dimensions.
 * 5. When a CI/CD pipeline validates that all WMF resources are correctly rendered with custom fonts, developers can extend this example to set a font folder and then generate PNGs for visual regression testing.
 */