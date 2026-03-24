using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "C:\\temp\\input.svg";
        string outputPath = "C:\\temp\\output.emf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the SVG image
        using (Image image = Image.Load(inputPath))
        {
            // Configure vector rasterization options for EMF output
            VectorRasterizationOptions vectorOptions = new EmfRasterizationOptions
            {
                PageSize = image.Size,
                BackgroundColor = Color.White // optional background
            };

            // Set up EMF save options
            EmfOptions saveOptions = new EmfOptions
            {
                VectorRasterizationOptions = vectorOptions
            };

            // Save as EMF preserving vector fidelity
            image.Save(outputPath, saveOptions);
        }
    }
}