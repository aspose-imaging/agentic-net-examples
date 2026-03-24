using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Temp\input.svg";
        string outputPath = @"C:\Temp\output.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the vector image (e.g., SVG, CDR, etc.)
        using (Image vectorImage = Image.Load(inputPath))
        {
            // Prepare BMP save options with vector rasterization settings
            var bmpOptions = new BmpOptions
            {
                // Define where the BMP file will be created
                Source = new FileCreateSource(outputPath, false),

                // Configure rasterization to match the source dimensions and preserve quality
                VectorRasterizationOptions = new VectorRasterizationOptions
                {
                    // Use white background; adjust as needed
                    BackgroundColor = Color.White,

                    // Set page size to source image size (preserve aspect ratio)
                    PageWidth = vectorImage.Width,
                    PageHeight = vectorImage.Height,

                    // Optional rendering hints for crisp output
                    SmoothingMode = SmoothingMode.None,
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel
                }
            };

            // Save the rasterized image as BMP
            vectorImage.Save(outputPath, bmpOptions);
        }
    }
}