using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.ImageLoadOptions;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.cmx";
            string outputPath = "output.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load CMX image from a memory stream
            byte[] cmxData = File.ReadAllBytes(inputPath);
            using (var memoryStream = new MemoryStream(cmxData))
            {
                var streamContainer = new StreamContainer(memoryStream);
                var loadOptions = new CmxLoadOptions();

                using (var cmxImage = new CmxImage(streamContainer, loadOptions))
                {
                    // Prepare TIFF save options
                    var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

                    // Save directly to the output file without temporary files
                    cmxImage.Save(outputPath, tiffOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}