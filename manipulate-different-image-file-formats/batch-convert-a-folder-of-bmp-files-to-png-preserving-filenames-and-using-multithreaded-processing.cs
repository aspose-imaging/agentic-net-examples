using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputFolder = @"C:\Images\BmpInput";
        string outputFolder = @"C:\Images\PngOutput";

        try
        {
            // Retrieve all BMP files in the input folder
            string[] bmpFiles = Directory.GetFiles(inputFolder, "*.bmp", SearchOption.TopDirectoryOnly);

            // Process files in parallel
            Parallel.ForEach(bmpFiles, bmpPath =>
            {
                // Verify the input file exists
                if (!File.Exists(bmpPath))
                {
                    Console.Error.WriteLine($"File not found: {bmpPath}");
                    return;
                }

                // Build the output PNG path, preserving the filename
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(bmpPath);
                string outputPath = Path.Combine(outputFolder, fileNameWithoutExt + ".png");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the BMP image
                using (Image image = Image.Load(bmpPath))
                {
                    // Define PNG save options (default settings)
                    var pngOptions = new PngOptions();

                    // Save the image as PNG
                    image.Save(outputPath, pngOptions);
                }
            });
        }
        catch (Exception ex)
        {
            // Report any unexpected errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}