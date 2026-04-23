using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\Images\sample.odg";
        string outputPath = @"C:\Images\sample.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the ODG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to the specific ODG image type
            OdgImage odgImage = (OdgImage)image;

            // Preserve original metadata (the same metadata object is kept for the rasterization process)
            // The metadata is automatically considered during the Save operation.
            // If needed, you could explicitly copy it using TrySetMetadata, but the Save method
            // retains the metadata for ODG → PNG conversion.

            // Prepare rasterization options for ODG → PNG conversion
            OdgRasterizationOptions rasterOptions = new OdgRasterizationOptions
            {
                // Use the original image size to keep the aspect ratio
                PageSize = odgImage.Size,
                BackgroundColor = Color.White
            };

            // Configure PNG save options and attach rasterization options
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save the image as PNG while keeping metadata
            odgImage.Save(outputPath, pngOptions);
        }
    }
}