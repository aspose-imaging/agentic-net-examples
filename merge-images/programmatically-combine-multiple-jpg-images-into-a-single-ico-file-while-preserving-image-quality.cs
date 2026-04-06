using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Ico;

class Program
{
    static void Main()
    {
        // Hard‑coded input JPG files
        string[] inputPaths = new[]
        {
            @"C:\Images\icon1.jpg",
            @"C:\Images\icon2.jpg",
            @"C:\Images\icon3.jpg"
        };

        // Hard‑coded output ICO file
        string outputPath = @"C:\Images\combined.ico";

        // Verify each input file exists
        foreach (string inputPath in inputPaths)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Ensure the output directory exists (creates even if null -> current directory)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load the first image to obtain a base width/height for the ICO canvas
        int baseWidth, baseHeight;
        using (Image firstImg = Image.Load(inputPaths[0]))
        {
            baseWidth = firstImg.Width;
            baseHeight = firstImg.Height;
        }

        // Create ICO options (default: PNG format, 32 bpp)
        IcoOptions icoOptions = new IcoOptions();

        // Initialise the ICO image with the base dimensions
        using (IcoImage ico = new IcoImage(baseWidth, baseHeight, icoOptions))
        {
            // Add each JPG as a page/frame in the ICO
            foreach (string inputPath in inputPaths)
            {
                using (Image img = Image.Load(inputPath))
                {
                    // AddPage converts the image to a 32‑bit PNG entry automatically
                    ico.AddPage(img);
                }
            }

            // Save the combined ICO file
            ico.Save(outputPath);
        }
    }
}