using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main()
    {
        // Hard‑coded input JPG files
        string[] inputPaths = new[]
        {
            @"C:\temp\image1.jpg",
            @"C:\temp\image2.jpg",
            @"C:\temp\image3.jpg"
        };

        // Hard‑coded output PNG file
        string outputPath = @"C:\temp\combined.png";

        // Verify each input file exists
        foreach (string inputPath in inputPaths)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // List to hold the WMF images after conversion
        List<Image> wmfImages = new List<Image>();

        // Convert each JPG to WMF and load the WMF image
        foreach (string jpgPath in inputPaths)
        {
            // Load the JPG image
            using (Image jpgImage = Image.Load(jpgPath))
            {
                // Prepare WMF save options with rasterization matching the source size
                var wmfRasterOptions = new WmfRasterizationOptions
                {
                    PageSize = jpgImage.Size
                };
                var wmfSaveOptions = new WmfOptions
                {
                    VectorRasterizationOptions = wmfRasterOptions
                };

                // Determine temporary WMF file path
                string wmfPath = Path.ChangeExtension(jpgPath, ".wmf");

                // Ensure the directory for the WMF file exists
                Directory.CreateDirectory(Path.GetDirectoryName(wmfPath));

                // Save the JPG as WMF
                jpgImage.Save(wmfPath, wmfSaveOptions);
            }

            // Load the generated WMF image and keep it for later combination
            Image wmfImage = Image.Load(Path.ChangeExtension(jpgPath, ".wmf"));
            wmfImages.Add(wmfImage);
        }

        // Combine all WMF images into a single multipage image
        using (Image combined = Image.Create(wmfImages.ToArray()))
        {
            // Save the combined image as PNG
            combined.Save(outputPath, new PngOptions());
        }

        // Dispose all loaded WMF images (except the combined one which is already disposed)
        foreach (var img in wmfImages)
        {
            img.Dispose();
        }
    }
}