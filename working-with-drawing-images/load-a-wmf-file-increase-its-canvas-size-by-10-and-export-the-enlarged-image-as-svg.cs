using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\input.wmf";
        string outputPath = @"C:\Images\output.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the WMF image
        using (WmfImage wmfImage = (WmfImage)Image.Load(inputPath))
        {
            // Calculate new canvas size (increase by 10%)
            int newWidth = (int)Math.Ceiling(wmfImage.Width * 1.10);
            int newHeight = (int)Math.Ceiling(wmfImage.Height * 1.10);

            // Resize the canvas
            wmfImage.ResizeCanvas(new Rectangle(0, 0, newWidth, newHeight));

            // Prepare SVG save options
            SvgOptions saveOptions = new SvgOptions
            {
                TextAsShapes = true
            };

            // Configure rasterization options for the enlarged canvas
            WmfRasterizationOptions rasterOptions = new WmfRasterizationOptions
            {
                // Set the page size to match the new canvas dimensions
                PageSize = new Size(newWidth, newHeight),
                // Optional: set background color
                BackgroundColor = Aspose.Imaging.Color.White
            };

            saveOptions.VectorRasterizationOptions = rasterOptions;

            // Save the enlarged image as SVG
            wmfImage.Save(outputPath, saveOptions);
        }
    }
}