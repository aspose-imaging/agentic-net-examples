using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.cmx";
        string outputPath = "output.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load CMX image (vector canvas)
        using (CmxImage cmx = (CmxImage)Image.Load(inputPath))
        {
            int width = cmx.Width;
            int height = cmx.Height;

            // Rasterize CMX to PNG in memory
            using (MemoryStream ms = new MemoryStream())
            {
                PngOptions pngOptions = new PngOptions();
                pngOptions.Source = new StreamSource(ms);
                cmx.Save(ms, pngOptions);
                ms.Position = 0;

                using (PngImage png = (PngImage)Image.Load(ms))
                {
                    // Create first TIFF frame from rasterized PNG
                    TiffFrame firstFrame = new TiffFrame((RasterImage)png);

                    // Prepare TIFF options for the output file
                    TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                    tiffOptions.Source = new FileCreateSource(outputPath, false);
                    tiffOptions.Photometric = TiffPhotometrics.Rgb;
                    tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };

                    // Create TIFF image with the first frame
                    using (TiffImage tiffImage = new TiffImage(firstFrame))
                    {
                        // Add blank pages (e.g., 2 blank pages)
                        int blankPages = 2;
                        for (int i = 0; i < blankPages; i++)
                        {
                            // Create a blank frame with the same dimensions
                            TiffFrame blankFrame = new TiffFrame(tiffOptions, width, height);

                            // Fill the blank frame with white color
                            Graphics graphics = new Graphics(blankFrame);
                            graphics.Clear(Color.White);

                            tiffImage.AddFrame(blankFrame);
                        }

                        // Save the multi-page TIFF (output path already bound in tiffOptions)
                        tiffImage.Save();
                    }
                }
            }
        }
    }
}