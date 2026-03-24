using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\sample.emf";
        string outputPath = @"C:\Images\sample.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the vector image (EMF or WMF)
        using (Image image = Image.Load(inputPath))
        {
            // Determine the file type and set appropriate rasterization options
            string ext = Path.GetExtension(inputPath).ToLowerInvariant();

            if (ext == ".emf")
            {
                // EMF specific rasterization options
                var rasterOptions = new EmfRasterizationOptions
                {
                    PageSize = image.Size // Preserve original size
                };

                // Save as PNG using the rasterization options
                var saveOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                image.Save(outputPath, saveOptions);
            }
            else if (ext == ".wmf")
            {
                // WMF specific rasterization options
                var rasterOptions = new WmfRasterizationOptions
                {
                    PageSize = image.Size // Preserve original size
                };

                // Save as PNG using the rasterization options
                var saveOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                image.Save(outputPath, saveOptions);
            }
            else
            {
                // Unsupported format handling
                Console.Error.WriteLine($"Unsupported input format: {ext}");
                return;
            }
        }
    }
}