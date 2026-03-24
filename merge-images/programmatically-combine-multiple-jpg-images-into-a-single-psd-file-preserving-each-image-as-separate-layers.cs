using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main()
    {
        // Hardcoded input JPG image paths
        string[] inputPaths = new string[]
        {
            @"C:\Images\image1.jpg",
            @"C:\Images\image2.jpg",
            @"C:\Images\image3.jpg"
        };

        // Hardcoded output PSD path
        string outputPath = @"C:\Images\combined.psd";

        // Verify each input file exists
        foreach (var path in inputPaths)
        {
            if (!File.Exists(path))
            {
                Console.Error.WriteLine($"File not found: {path}");
                return;
            }
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a multipage image; each page will become a separate layer in the PSD
        using (Image multipageImage = Image.Create(inputPaths))
        {
            // Configure PSD saving options (optional)
            PsdOptions psdOptions = new PsdOptions
            {
                CompressionMethod = Aspose.Imaging.FileFormats.Psd.CompressionMethod.RLE,
                ColorMode = Aspose.Imaging.FileFormats.Psd.ColorModes.Rgb,
                Version = 6
            };

            // Save the multipage image as a PSD file
            multipageImage.Save(outputPath, psdOptions);
        }
    }
}