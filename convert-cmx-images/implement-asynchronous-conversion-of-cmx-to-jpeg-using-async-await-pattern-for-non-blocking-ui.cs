using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static async Task Main()
    {
        const string inputPath = @"c:\temp\sample.cmx";
        const string outputPath = @"c:\temp\output.jpg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load CMX image on a background thread
            CmxImage cmxImage = await Task.Run(() =>
                (CmxImage)Image.Load(inputPath));

            // Configure JPEG save options
            var jpegOptions = new JpegOptions();

            // Save as JPEG on a background thread
            await Task.Run(() => cmxImage.Save(outputPath, jpegOptions));

            // Clean up
            cmxImage.Dispose();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}