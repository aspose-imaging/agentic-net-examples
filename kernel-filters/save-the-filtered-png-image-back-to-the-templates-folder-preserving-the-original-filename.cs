using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input path
            string inputPath = @"templates\sample.png";

            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PNG save options (e.g., use Adaptive filter)
                PngOptions saveOptions = new PngOptions
                {
                    FilterType = Aspose.Imaging.FileFormats.Png.PngFilterType.Adaptive
                };

                // Preserve the original filename for the output
                string outputPath = inputPath;

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the filtered image back to the templates folder
                image.Save(outputPath, saveOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}