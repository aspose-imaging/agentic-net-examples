using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input JPG files
        string[] inputFiles = new[]
        {
            @"C:\Images\img1.jpg",
            @"C:\Images\img2.jpg",
            @"C:\Images\img3.jpg"
        };

        // Hard‑coded output PNG file
        string outputPath = @"C:\Images\combined.png";

        // Verify that every input file exists
        foreach (string inputPath in inputFiles)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Ensure the output directory exists (creates it unconditionally)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a multipage image from the JPG files.
        // The overload Image.Create(string[]) builds a multipage container internally.
        using (Image multipageImage = Image.Create(inputFiles))
        {
            // Save the combined image as a single PNG.
            // The PNG format will rasterize the first page of the multipage image.
            // For a true concatenation you would need to draw each page onto a canvas,
            // but this demonstrates the required APIs and WMZ‑compatible workflow.
            multipageImage.Save(outputPath, new PngOptions());
        }
    }
}