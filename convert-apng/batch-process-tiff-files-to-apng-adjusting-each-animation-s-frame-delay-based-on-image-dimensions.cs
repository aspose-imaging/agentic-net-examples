using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded list of TIFF files to process
            string[] inputPaths = {
                @"C:\Images\sample1.tif",
                @"C:\Images\sample2.tif"
            };

            foreach (string inputPath in inputPaths)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output path (same name with .apng.png extension)
                string outputPath = Path.ChangeExtension(inputPath, ".apng.png");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the TIFF image
                using (Image tiffImage = Image.Load(inputPath))
                {
                    // Compute frame delay based on image dimensions
                    uint frameDelay = (uint)((tiffImage.Width + tiffImage.Height) / 2);

                    // Set up APNG options with the calculated default frame time
                    ApngOptions apngOptions = new ApngOptions
                    {
                        DefaultFrameTime = frameDelay
                    };

                    // Export the multi‑page TIFF as an APNG animation
                    tiffImage.Save(outputPath, apngOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}