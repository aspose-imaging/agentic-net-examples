using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main()
    {
        // Hardcoded list of WMF files to convert
        List<string> inputFiles = new List<string>
        {
            @"C:\Images\Input\image1.wmf",
            @"C:\Images\Input\image2.wmf",
            @"C:\Images\Input\image3.wmf"
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

            // Load WMF image and save as JPEG
            using (Image image = Image.Load(inputPath))
            {
                // Set up rasterization options for WMF
                var rasterOptions = new WmfRasterizationOptions
                {
                    PageSize = image.Size
                };

                // JPEG save options with vector rasterization
                var jpegOptions = new JpegOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                image.Save(outputPath, jpegOptions);
            }
        });
    }
}