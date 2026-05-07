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
            // Hardcoded collection of EPS input files and corresponding PNG output files
            var files = new (string input, string output)[]
            {
                ("C:\\Images\\input1.eps", "C:\\Images\\output1.png"),
                ("C:\\Images\\input2.eps", "C:\\Images\\output2.png")
            };

            foreach (var (inputPath, outputPath) in files)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the EPS image
                using (var image = (EpsImage)Image.Load(inputPath))
                {
                    // Compute new dimensions applying a scaling factor of 1.5
                    int newWidth = (int)(image.Width * 1.5);
                    int newHeight = (int)(image.Height * 1.5);

                    // Resize the image (LanczosResample provides high-quality scaling)
                    image.Resize(newWidth, newHeight, ResizeType.LanczosResample);

                    // Save the resized image as PNG, preserving transparency
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