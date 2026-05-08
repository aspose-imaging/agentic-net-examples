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
            // Hardcoded input directory containing WMF files
            string inputDirectory = @"C:\Images\Input";
            // Hardcoded output directory for PNG files
            string outputDirectory = @"C:\Images\Output";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // List of WMF files to process (hardcoded for the example)
            string[] wmfFiles = new[]
            {
                "sample1.wmf",
                "sample2.wmf",
                "sample3.wmf"
            };

            foreach (var fileName in wmfFiles)
            {
                // Build full input and output paths
                string inputPath = Path.Combine(inputDirectory, fileName);
                string outputPath = Path.Combine(outputDirectory, Path.ChangeExtension(fileName, ".png"));

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the WMF image
                using (Image image = Image.Load(inputPath))
                {
                    // Configure rasterization options with a uniform background color (e.g., white)
                    var rasterOptions = new WmfRasterizationOptions
                    {
                        PageSize = image.Size,
                        BackgroundColor = Aspose.Imaging.Color.White
                    };

                    // Set PNG save options and attach rasterization options
                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = rasterOptions
                    };

                    // Save the rasterized PNG image
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