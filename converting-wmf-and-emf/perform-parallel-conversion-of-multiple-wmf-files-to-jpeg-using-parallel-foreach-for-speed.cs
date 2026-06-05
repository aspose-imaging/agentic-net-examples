using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded list of WMF files to convert
            string[] inputFiles = new[]
            {
                @"C:\Images\sample1.wmf",
                @"C:\Images\sample2.wmf",
                @"C:\Images\sample3.wmf"
            };

            // Parallel conversion
            Parallel.ForEach(inputFiles, inputPath =>
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output path (same folder, .jpg extension)
                string outputPath = inputPath + ".jpg";

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load WMF image and save as JPEG
                using (Image image = Image.Load(inputPath))
                {
                    // Use default JPEG options
                    var jpegOptions = new JpegOptions();
                    image.Save(outputPath, jpegOptions);
                }

                Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
            });
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}