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
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"c:\temp\sample.cmx";
            string outputPath = @"c:\temp\output.jpg";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CMX image on a background thread
            CmxImage cmxImage = await Task.Run(() =>
            {
                // Image.Load returns a generic Image; cast to CmxImage
                return (CmxImage)Image.Load(inputPath);
            });

            // Prepare JPEG save options (default options are sufficient for a basic conversion)
            var jpegOptions = new JpegOptions();

            // Save the image as JPEG on a background thread
            await Task.Run(() =>
            {
                cmxImage.Save(outputPath, jpegOptions);
            });

            // Dispose the image to release resources
            cmxImage.Dispose();

            Console.WriteLine($"Conversion completed: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}