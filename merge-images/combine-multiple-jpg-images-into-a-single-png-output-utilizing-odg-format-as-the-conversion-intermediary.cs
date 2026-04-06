using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input JPG files
        string[] inputPaths = new string[]
        {
            @"C:\temp\img1.jpg",
            @"C:\temp\img2.jpg",
            @"C:\temp\img3.jpg"
        };

        // Hard‑coded output PNG file
        string outputPath = @"C:\temp\combined.png";

        // Verify each input file exists
        foreach (string inputPath in inputPaths)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Temporary folder for ODG intermediary files
        string tempOdgFolder = Path.Combine(Path.GetTempPath(), "OdgTemp");
        Directory.CreateDirectory(tempOdgFolder);

        // Convert each JPG to ODG and collect the ODG file paths
        string[] odgPaths = new string[inputPaths.Length];
        for (int i = 0; i < inputPaths.Length; i++)
        {
            string jpgPath = inputPaths[i];
            string odgPath = Path.Combine(tempOdgFolder, $"temp{i}.odg");
            odgPaths[i] = odgPath;

            // Load JPG image
            using (Image jpgImage = Image.Load(jpgPath))
            {
                // Save as ODG (format inferred from extension)
                jpgImage.Save(odgPath);
            }
        }

        // Create a multipage image from the ODG files
        using (Image combinedImage = Image.Create(odgPaths))
        {
            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Save the combined image as a single PNG
            combinedImage.Save(outputPath, new PngOptions());
        }
    }
}