using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded list of WMF files to convert
        var inputFiles = new List<string>
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
            string outputPath = Path.ChangeExtension(inputPath, ".jpg");

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load WMF image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare rasterization options for WMF
                var rasterOptions = new WmfRasterizationOptions
                {
                    PageSize = image.Size
                };

                // JPEG save options with the rasterization settings
                var jpegOptions = new JpegOptions
                {
                    VectorRasterizationOptions = rasterOptions,
                    Quality = 90 // optional quality setting
                };

                // Save as JPEG
                image.Save(outputPath, jpegOptions);
            }
        });
    }
}