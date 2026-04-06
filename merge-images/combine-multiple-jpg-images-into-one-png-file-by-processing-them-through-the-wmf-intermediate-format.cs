using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main()
    {
        // Hard‑coded input JPG files
        string[] jpgPaths = new[]
        {
            @"C:\Images\photo1.jpg",
            @"C:\Images\photo2.jpg",
            @"C:\Images\photo3.jpg"
        };

        // Temporary WMF files (intermediate format)
        string[] wmfPaths = new string[jpgPaths.Length];

        for (int i = 0; i < jpgPaths.Length; i++)
        {
            string jpgPath = jpgPaths[i];

            // Input file existence check
            if (!File.Exists(jpgPath))
            {
                Console.Error.WriteLine($"File not found: {jpgPath}");
                return;
            }

            // Load JPG image
            using (Image jpgImage = Image.Load(jpgPath))
            {
                // Define WMF output path
                string wmfPath = Path.ChangeExtension(jpgPath, ".wmf");
                wmfPaths[i] = wmfPath;

                // Ensure output directory exists (unconditional)
                Directory.CreateDirectory(Path.GetDirectoryName(wmfPath) ?? ".");

                // Prepare rasterization options matching the source image size
                var wmfRasterOptions = new WmfRasterizationOptions
                {
                    PageSize = jpgImage.Size
                };

                // Save as WMF using vector rasterization options
                jpgImage.Save(wmfPath, new WmfOptions { VectorRasterizationOptions = wmfRasterOptions });
            }
        }

        // Create a multipage image from the WMF files
        using (Image multipageImage = Image.Create(wmfPaths))
        {
            // Define final PNG output path
            string outputPngPath = @"C:\Images\combined_output.png";

            // Ensure output directory exists (unconditional)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPngPath) ?? ".");

            // Save the combined image as PNG
            multipageImage.Save(outputPngPath, new PngOptions());
        }
    }
}