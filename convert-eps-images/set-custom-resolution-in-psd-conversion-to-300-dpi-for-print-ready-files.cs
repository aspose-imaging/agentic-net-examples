using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Images\sample.jpg";
            string outputPath = @"C:\Images\output.psd";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if missing)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PSD save options with 300 dpi resolution
                PsdOptions psdOptions = new PsdOptions
                {
                    // Set horizontal and vertical resolution to 300 DPI
                    ResolutionSettings = new ResolutionSetting(300.0, 300.0)
                };

                // Save the image as a PSD file using the specified options
                image.Save(outputPath, psdOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}