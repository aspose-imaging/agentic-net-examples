using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output folders
            string inputFolder = @"C:\InputWmf";
            string outputFolder = @"C:\OutputBmp";

            // Get all WMF files in the input folder
            string[] wmfFiles = Directory.GetFiles(inputFolder, "*.wmf");

            foreach (string inputPath in wmfFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output BMP path preserving the original file name
                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputFolder, fileName + ".bmp");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the WMF image
                using (Image image = Image.Load(inputPath))
                {
                    // Set rasterization options to keep original dimensions
                    var rasterOptions = new WmfRasterizationOptions
                    {
                        PageSize = image.Size
                    };

                    // Configure BMP save options with the rasterization settings
                    var bmpOptions = new BmpOptions
                    {
                        VectorRasterizationOptions = rasterOptions
                    };

                    // Save as BMP
                    image.Save(outputPath, bmpOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}