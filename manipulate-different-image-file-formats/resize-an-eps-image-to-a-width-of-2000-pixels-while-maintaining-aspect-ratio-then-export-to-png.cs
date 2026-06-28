using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\Images\source.eps";
            string outputPath = @"C:\Images\result.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EPS image
            using (Image image = Image.Load(inputPath))
            {
                // Calculate new height to maintain aspect ratio for width = 2000
                int targetWidth = 2000;
                int originalWidth = image.Width;
                int originalHeight = image.Height;
                int targetHeight = (int)Math.Round((double)originalHeight * targetWidth / originalWidth);

                // Resize using Mitchell interpolation (you can choose another ResizeType if desired)
                image.Resize(targetWidth, targetHeight, ResizeType.Mitchell);

                // Save as PNG
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
 * 1. When a developer needs to generate high‑resolution web‑ready PNG thumbnails from vector EPS logos for a corporate website.
 * 2. When an e‑commerce platform must convert product EPS artwork to a fixed 2000‑pixel width PNG for print‑ready catalogs while preserving aspect ratio.
 * 3. When a desktop publishing tool automates the preparation of EPS illustrations for inclusion in a PDF report by resizing them to a consistent width and saving as PNG.
 * 4. When a batch‑processing script resizes EPS diagrams to 2000 pixels wide for faster loading in a mobile app, then exports them as PNG files.
 * 5. When a CI/CD pipeline validates and standardizes incoming EPS assets by resizing them to a 2000‑pixel width PNG before they are stored in a digital asset management system.
 */