using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Images\input.psd";
            string outputPath = @"C:\Images\output.tif";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PSD image
            using (Image psdImage = Image.Load(inputPath))
            {
                // Prepare TIFF save options
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

                // If the PSD contains vector data, configure rasterization to render text as shapes
                if (psdImage is VectorImage)
                {
                    var rasterOptions = new EmfRasterizationOptions
                    {
                        // Render text as shapes (Auto mode preserves vector text)
                        RenderMode = EmfRenderMode.Auto,
                        PageSize = psdImage.Size,
                        BackgroundColor = Aspose.Imaging.Color.White
                    };
                    tiffOptions.VectorRasterizationOptions = rasterOptions;
                }

                // Save the image as TIFF
                psdImage.Save(outputPath, tiffOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}