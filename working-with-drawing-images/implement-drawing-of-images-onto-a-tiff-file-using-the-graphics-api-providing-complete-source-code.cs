using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath1 = "input1.jpg";
        string inputPath2 = "input2.png";
        string outputPath = "output.tif";

        // Verify input files exist
        if (!File.Exists(inputPath1))
        {
            Console.Error.WriteLine($"File not found: {inputPath1}");
            return;
        }
        if (!File.Exists(inputPath2))
        {
            Console.Error.WriteLine($"File not found: {inputPath2}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Configure TIFF options
        TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
        tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
        tiffOptions.Photometric = TiffPhotometrics.Rgb;
        tiffOptions.Compression = TiffCompressions.Lzw;
        tiffOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;

        // Create a blank TIFF canvas (800x600)
        using (Image tiffImage = Image.Create(tiffOptions, 800, 600))
        {
            // Initialize Graphics for drawing
            Graphics graphics = new Graphics(tiffImage);
            graphics.Clear(Color.White);

            // Load source images and draw them onto the TIFF canvas
            using (Image src1 = Image.Load(inputPath1))
            using (Image src2 = Image.Load(inputPath2))
            {
                // Draw first image at (0,0)
                graphics.DrawImage(src1, new Point(0, 0));

                // Draw second image to the right of the first image
                graphics.DrawImage(src2, new Point(src1.Width, 0));
            }

            // Save the resulting TIFF file
            tiffImage.Save(outputPath);
        }
    }
}