using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main()
    {
        // Hard‑coded input JPG files
        string[] inputFiles = new[]
        {
            @"C:\Images\photo1.jpg",
            @"C:\Images\photo2.jpg",
            @"C:\Images\photo3.jpg"
        };

        // Verify each input file exists
        foreach (var inputPath in inputFiles)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Temporary WMZ (compressed WMF) file used as an intermediate container
        string tempWmzPath = @"C:\Images\combined.wmz";

        // Final PNG output file
        string outputPath = @"C:\Images\combined.png";

        // Ensure the output directory exists (unconditional)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // -----------------------------------------------------------------
        // Step 1: Create a multipage image from the JPG files
        // -----------------------------------------------------------------
        using (Image multipageImage = Image.Create(inputFiles))
        {
            // Prepare WMF options with compression (WMZ)
            var wmfOptions = new WmfOptions
            {
                Compress = true,
                VectorRasterizationOptions = new WmfRasterizationOptions
                {
                    // Use the size of the first page as the canvas size
                    PageSize = multipageImage.Size
                }
            };

            // Ensure the directory for the temporary WMZ exists
            Directory.CreateDirectory(Path.GetDirectoryName(tempWmzPath));

            // Save the multipage image into a compressed WMZ container
            multipageImage.Save(tempWmzPath, wmfOptions);
        }

        // -----------------------------------------------------------------
        // Step 2: Load the WMZ container and export it as a single PNG
        // -----------------------------------------------------------------
        using (Image wmzImage = Image.Load(tempWmzPath))
        {
            var pngOptions = new PngOptions
            {
                // For vector sources we need rasterization options
                VectorRasterizationOptions = new WmfRasterizationOptions
                {
                    PageSize = wmzImage.Size,
                    BackgroundColor = Color.White
                }
            };

            wmzImage.Save(outputPath, pngOptions);
        }

        Console.WriteLine("Combined PNG created successfully at: " + outputPath);
    }
}