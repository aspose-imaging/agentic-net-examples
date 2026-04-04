using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\Images\input.svg";
        string outputPath = @"C:\Images\output.svg";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the vector image
        using (VectorImage vectorImage = Image.Load(inputPath) as VectorImage)
        {
            if (vectorImage == null)
            {
                Console.Error.WriteLine("Failed to load a vector image.");
                return;
            }

            // Configure background removal to treat white as the background color
            var bgSettings = new RemoveBackgroundSettings
            {
                Color1 = Color.White   // Preserve white foreground elements
            };

            // Remove the background using the specified settings
            vectorImage.RemoveBackground(bgSettings);

            // Save the processed image
            vectorImage.Save(outputPath);
        }
    }
}