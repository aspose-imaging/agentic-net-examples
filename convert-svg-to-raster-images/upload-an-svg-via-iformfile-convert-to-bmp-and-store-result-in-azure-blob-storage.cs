using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input and output paths (relative to the executable directory)
            string inputPath = Path.Combine("Input", "sample.svg");
            // Verify that the input SVG file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputPath = Path.Combine("Output", "sample.bmp");
            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Convert and save as BMP
                var bmpOptions = new BmpOptions();
                image.Save(outputPath, bmpOptions);
            }

            // TODO: Upload the BMP file to Azure Blob storage.
            // In a real implementation, you would use Azure.Storage.Blobs SDK here.
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}