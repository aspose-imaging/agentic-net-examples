using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputFolder = "input";
            string outputFolder = "output";

            // Ensure the output folder exists
            Directory.CreateDirectory(outputFolder);

            // Get all EPS files in the input folder
            string[] epsFiles = Directory.GetFiles(inputFolder, "*.eps");

            foreach (string inputPath in epsFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output path with .png extension
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputFolder, fileNameWithoutExt + ".png");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load EPS image
                using (Image image = Image.Load(inputPath))
                {
                    // Calculate new dimensions (scale factor 2)
                    int newWidth = image.Width * 2;
                    int newHeight = image.Height * 2;

                    // Resize the image
                    image.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);

                    // Save as PNG preserving transparency
                    var pngOptions = new PngOptions();
                    image.Save(outputPath, pngOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}