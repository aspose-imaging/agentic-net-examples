using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Ico;

class Program
{
    static void Main()
    {
        // Hard‑coded input image paths
        string[] inputPaths = { @"C:\Images\icon16.png", @"C:\Images\icon32.png", @"C:\Images\icon64.png" };
        // Hard‑coded output ICO path
        string outputPath = @"C:\Images\myIcon.ico";

        // Verify each input file exists
        foreach (var inputPath in inputPaths)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create default ICO options (32‑bit PNG frames)
        var icoOptions = new IcoOptions();

        // Create an empty ICO image with a base size (e.g., 256x256)
        using (var icoImage = new IcoImage(256, 256, icoOptions))
        {
            // Load each source image and add it as a page to the ICO
            foreach (var inputPath in inputPaths)
            {
                using (Image srcImage = Image.Load(inputPath))
                {
                    // Add the image using default IcoOptions (converted to 32‑bit PNG)
                    icoImage.AddPage(srcImage);
                }
            }

            // Save the assembled ICO file
            icoImage.Save(outputPath);
        }
    }
}