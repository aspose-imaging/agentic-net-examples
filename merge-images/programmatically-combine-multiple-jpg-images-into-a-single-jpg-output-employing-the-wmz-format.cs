using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input JPG files
        string[] inputPaths = new[]
        {
            @"C:\Images\img1.jpg",
            @"C:\Images\img2.jpg",
            @"C:\Images\img3.jpg"
        };

        // Hardcoded output WMZ file (compressed WMF)
        string outputPath = @"C:\Images\combined.wmz";

        // Verify each input file exists
        foreach (var inputPath in inputPaths)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a multipage image from the JPG files
        using (Image multipageImage = Image.Create(inputPaths))
        {
            // Prepare WMF options with compression (WMZ)
            var wmfOptions = new WmfOptions
            {
                Compress = true,
                // Set rasterization options so each page is rendered at its original size
                VectorRasterizationOptions = new WmfRasterizationOptions
                {
                    PageSize = multipageImage.Size
                }
            };

            // Save the combined image as a compressed WMZ file
            multipageImage.Save(outputPath, wmfOptions);
        }
    }
}