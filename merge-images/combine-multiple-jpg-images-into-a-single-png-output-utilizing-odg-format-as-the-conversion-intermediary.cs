using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        // Hard‑coded input JPG files
        string[] inputPaths = {
            @"C:\Images\image1.jpg",
            @"C:\Images\image2.jpg",
            @"C:\Images\image3.jpg"
        };

        // Hard‑coded output PNG file
        string outputPath = @"C:\Images\combined.png";

        // Verify each input file exists
        foreach (string inputPath in inputPaths)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Temporary folder for ODG intermediary files
        string tempOdgFolder = Path.Combine(Path.GetTempPath(), "OdgTemp");
        Directory.CreateDirectory(tempOdgFolder);

        // Convert each JPG to ODG and collect the ODG file paths
        string[] odgPaths = new string[inputPaths.Length];
        for (int i = 0; i < inputPaths.Length; i++)
        {
            string jpgPath = inputPaths[i];
            string odgPath = Path.Combine(tempOdgFolder, $"page{i + 1}.odg");
            odgPaths[i] = odgPath;

            // Load JPG image
            using (Image jpgImage = Image.Load(jpgPath))
            {
                // Save as ODG (extension determines format)
                jpgImage.Save(odgPath);
            }
        }

        // Create a multipage image from the ODG files
        using (Image multipageImage = Image.Create(odgPaths))
        {
            // Prepare PNG save options with ODG rasterization settings
            PngOptions pngOptions = new PngOptions();

            // ODG rasterization options (background color and page size)
            OdgRasterizationOptions rasterOptions = new OdgRasterizationOptions
            {
                BackgroundColor = Color.White,
                PageSize = multipageImage.Size
            };

            pngOptions.VectorRasterizationOptions = rasterOptions;

            // Save the combined image as a single PNG
            multipageImage.Save(outputPath, pngOptions);
        }

        // Optional: clean up temporary ODG files
        try
        {
            Directory.Delete(tempOdgFolder, true);
        }
        catch
        {
            // Ignored – cleanup failure should not affect the main result
        }
    }
}