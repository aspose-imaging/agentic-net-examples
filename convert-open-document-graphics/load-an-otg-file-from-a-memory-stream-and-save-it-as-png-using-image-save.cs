using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.OpenDocument;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.otg";
        string outputPath = "output.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load OTG file into a memory stream
            byte[] fileBytes = File.ReadAllBytes(inputPath);
            using (MemoryStream memoryStream = new MemoryStream(fileBytes))
            {
                // Wrap the memory stream in a StreamContainer required by OtgImage
                var streamContainer = new StreamContainer(memoryStream);

                // Load the OTG image from the stream container
                using (OtgImage otgImage = new OtgImage(streamContainer))
                {
                    // Prepare PNG save options with OTG rasterization settings
                    var pngOptions = new PngOptions();
                    var otgRaster = new OtgRasterizationOptions
                    {
                        PageSize = otgImage.Size
                    };
                    pngOptions.VectorRasterizationOptions = otgRaster;

                    // Save the image as PNG
                    otgImage.Save(outputPath, pngOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}