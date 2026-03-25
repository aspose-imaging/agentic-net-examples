using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "C:\\Images\\sample.cmx";
        string outputPath = "C:\\Images\\output.jpg";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Asynchronous conversion using async/await pattern
        var conversionTask = Task.Run(async () =>
        {
            // Yield to ensure async context
            await Task.Yield();

            // Load CMX image
            using (CmxImage cmxImage = (CmxImage)Image.Load(inputPath))
            {
                // Prepare JPEG options
                var jpegOptions = new JpegOptions();

                // Save as JPEG
                cmxImage.Save(outputPath, jpegOptions);
            }
        });

        // Wait for the conversion to complete
        conversionTask.GetAwaiter().GetResult();
    }
}