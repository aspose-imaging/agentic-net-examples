using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.wmf";
            string outputPath = "output.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load WMF image
            using (WmfImage wmfImage = (WmfImage)Image.Load(inputPath))
            {
                // Configure PNG options with high‑resolution rasterization
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new WmfRasterizationOptions
                    {
                        // Increase page size for higher resolution (e.g., 2× original)
                        PageSize = new Aspose.Imaging.SizeF(wmfImage.Width * 2, wmfImage.Height * 2),
                        BackgroundColor = Aspose.Imaging.Color.White
                    }
                };

                // Save as PNG
                wmfImage.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}