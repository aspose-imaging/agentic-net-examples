using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\input.emf";
        string outputPath = @"C:\Images\output.emf";

        // Check that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the EMF image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare rasterization options (e.g., set page size to original image size)
                EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
                {
                    PageSize = image.Size,
                    // Additional quality settings can be adjusted here
                    // For example, you could set TextRenderingHint, SmoothingMode, etc.
                };

                // Configure EMF save options
                EmfOptions saveOptions = new EmfOptions
                {
                    VectorRasterizationOptions = rasterOptions,
                    // Example of controlling compression (true for smaller size, false for higher fidelity)
                    Compress = false
                };

                // Save the image using the EMF options
                image.Save(outputPath, saveOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}