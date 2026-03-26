using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main()
    {
        // Hard‑coded list of WMF files to convert
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

            // Determine output JPEG path (same folder, .jpg extension)
            string outputPath = Path.ChangeExtension(inputPath, ".jpg");

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load WMF image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare rasterization options based on the source image size
                var rasterizationOptions = new WmfRasterizationOptions
                {
                    PageSize = image.Size
                };

                // JPEG save options with the rasterization settings
                var jpegOptions = new JpegOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Save as JPEG
                image.Save(outputPath, jpegOptions);
            }
        });
    }
}