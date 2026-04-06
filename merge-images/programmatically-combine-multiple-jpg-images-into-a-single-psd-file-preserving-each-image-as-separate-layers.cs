using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string[] inputPaths = new string[]
        {
            @"C:\Images\image1.jpg",
            @"C:\Images\image2.jpg",
            @"C:\Images\image3.jpg"
        };
        string outputPath = @"C:\Images\combined.psd";

        // Verify each input file exists
        foreach (var inputPath in inputPaths)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Load all JPG images
        List<Image> loadedImages = new List<Image>();
        foreach (var inputPath in inputPaths)
        {
            loadedImages.Add(Image.Load(inputPath));
        }

        // Create a multipage image; each page will become a separate layer in the PSD
        using (Image psdImage = Image.Create(loadedImages.ToArray()))
        {
            // Configure PSD save options (optional settings)
            PsdOptions psdOptions = new PsdOptions
            {
                CompressionMethod = Aspose.Imaging.FileFormats.Psd.CompressionMethod.RLE,
                ColorMode = Aspose.Imaging.FileFormats.Psd.ColorModes.Rgb
            };

            // Ensure the output directory exists (unconditional)
            string outDir = Path.GetDirectoryName(outputPath);
            if (string.IsNullOrEmpty(outDir))
            {
                outDir = ".";
            }
            Directory.CreateDirectory(outDir);

            // Save the combined image as a PSD file
            psdImage.Save(outputPath, psdOptions);
        }

        // Dispose the source images
        foreach (var img in loadedImages)
        {
            img.Dispose();
        }
    }
}