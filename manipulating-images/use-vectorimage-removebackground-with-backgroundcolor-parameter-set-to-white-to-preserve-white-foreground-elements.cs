using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\input.svg";
        string outputPath = @"C:\Images\output.svg";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the vector image
            using (VectorImage vectorImage = (VectorImage)Image.Load(inputPath))
            {
                // Configure background removal settings to treat white as background
                var bgSettings = new RemoveBackgroundSettings
                {
                    Color1 = Aspose.Imaging.Color.White // set background color to white
                };

                // Remove the background using the configured settings
                vectorImage.RemoveBackground(bgSettings);

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the processed image
                vectorImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}