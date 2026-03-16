using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Expect input and output file paths as arguments.
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: Program <inputTiffPath> <outputTiffPath>");
            return;
        }

        string inputPath = args[0];
        string outputPath = args[1];

        // Load the existing TIFF image.
        using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
        {
            // Prepare options for the new frame.
            TiffOptions frameOptions = new TiffOptions(TiffExpectedFormat.Default);
            frameOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
            frameOptions.Photometric = TiffPhotometrics.Rgb;
            frameOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;

            // Create a new blank frame matching the size of the existing image.
            TiffFrame newFrame = new TiffFrame(frameOptions, tiffImage.Width, tiffImage.Height);

            // Fill the new frame with a solid red color.
            Graphics graphics = new Graphics(newFrame);
            graphics.Clear(Color.Red);

            // Add the new frame to the TIFF image.
            tiffImage.AddFrame(newFrame);

            // Save the updated TIFF to the specified output path.
            tiffImage.Save(outputPath);
        }
    }
}