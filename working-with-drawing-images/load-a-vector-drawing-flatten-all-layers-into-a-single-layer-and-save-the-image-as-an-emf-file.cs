using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.svg";
        string outputPath = "output.emf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the vector drawing
            using (Image image = Image.Load(inputPath))
            {
                // Create rasterization options for EMF export
                var vectorOptions = new EmfRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Set up EMF save options
                var emfOptions = new EmfOptions
                {
                    VectorRasterizationOptions = vectorOptions
                };

                // Save as EMF (flattened into a single layer)
                image.Save(outputPath, emfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}