using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
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

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load the CMX vector image
        using (CmxImage cmx = (CmxImage)Image.Load(inputPath))
        {
            int width = cmx.Width;
            int height = cmx.Height;

            // Prepare TIFF options with a bound file source
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            tiffOptions.Source = new FileCreateSource(outputPath, false);
            tiffOptions.Photometric = TiffPhotometrics.Rgb;
            tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
            tiffOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;

            // Create the TIFF image (first frame will be created automatically)
            using (TiffImage tiffImage = (TiffImage)Image.Create(tiffOptions, width, height))
            {
                // Render the CMX content onto the first frame
                Graphics graphics = new Graphics(tiffImage);
                graphics.DrawImage(cmx, new Point(0, 0));

                // Add two blank pages
                for (int i = 0; i < 2; i++)
                {
                    TiffFrame blankFrame = new TiffFrame(tiffOptions, width, height);
                    tiffImage.AddFrame(blankFrame);
                }

                // Save the multi-page TIFF (file is already bound to the source)
                tiffImage.Save();
            }
        }
    }
}