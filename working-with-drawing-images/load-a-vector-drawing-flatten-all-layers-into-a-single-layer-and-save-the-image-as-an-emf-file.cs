using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\Images\input_vector.svg";
        string outputPath = @"C:\Images\output.emf";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the vector drawing
        using (Image image = Image.Load(inputPath))
        {
            // Prepare rasterization options for EMF output
            var vectorOptions = new EmfRasterizationOptions
            {
                PageSize = image.Size // Preserve original size
            };

            var saveOptions = new EmfOptions
            {
                VectorRasterizationOptions = vectorOptions
            };

            // Save the flattened image as EMF
            image.Save(outputPath, saveOptions);
        }
    }
}