using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Emf.EmfPlus.Objects;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.emf";
        string outputPath = @"C:\Images\output_blur.emf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EMF image
        using (Image img = Image.Load(inputPath))
        {
            EmfImage emf = img as EmfImage;
            if (emf == null)
            {
                Console.Error.WriteLine("The loaded file is not an EMF image.");
                return;
            }

            // Create a blur effect with desired parameters
            EmfPlusBlurEffect blurEffect = new EmfPlusBlurEffect
            {
                BlurRadius = 10f,   // radius in pixels (0.0 – 255.0)
                ExpandEdge = true   // expand bitmap edges to accommodate blur
            };

            // Add the blur effect to the image's records collection (if available)
            var records = emf.Records;
            if (records != null)
            {
                records.Add(blurEffect);
            }

            // Save the processed EMF image
            emf.Save(outputPath);
        }
    }
}