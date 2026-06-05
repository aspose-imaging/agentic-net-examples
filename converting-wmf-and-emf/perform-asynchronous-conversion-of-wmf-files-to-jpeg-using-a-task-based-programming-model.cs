using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static async Task Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.wmf";
            string outputPath = @"C:\Images\sample.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Perform asynchronous conversion
            await ConvertWmfToJpegAsync(inputPath, outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    // Asynchronous conversion using Task.Run
    static Task ConvertWmfToJpegAsync(string inputPath, string outputPath)
    {
        return Task.Run(() =>
        {
            // Load the WMF image
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization options based on the source image size
                var rasterOptions = new WmfRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Set JPEG options with the rasterization settings
                var jpegOptions = new JpegOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save the image as JPEG
                image.Save(outputPath, jpegOptions);
            }
        });
    }
}