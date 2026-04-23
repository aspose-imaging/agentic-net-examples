using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.emf";
        string outputPath = "output.emf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the vector image
        using (Image image = Image.Load(inputPath))
        {
            // Create vector rasterization options manually
            var vectorOptions = new EmfRasterizationOptions
            {
                PageSize = image.Size
            };

            // Set up EMF export options
            var exportOptions = new EmfOptions
            {
                VectorRasterizationOptions = vectorOptions
            };

            // Save as flattened EMF
            image.Save(outputPath, exportOptions);
        }
    }
}