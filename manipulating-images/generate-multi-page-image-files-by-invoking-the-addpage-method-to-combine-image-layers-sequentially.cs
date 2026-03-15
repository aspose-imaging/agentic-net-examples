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
        // Validate input
        if (args.Length == 0)
        {
            Console.WriteLine("Please provide input image file paths as command-line arguments.");
            return;
        }

        // Output file path
        string outputPath = "multipage.tif";

        // Load the first image to obtain canvas dimensions
        int canvasWidth, canvasHeight;
        using (RasterImage first = (RasterImage)Image.Load(args[0]))
        {
            canvasWidth = first.Width;
            canvasHeight = first.Height;
        }

        // Configure TIFF creation options
        TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
        tiffOptions.Source = new FileCreateSource(outputPath, false);
        tiffOptions.Photometric = TiffPhotometrics.Rgb;
        tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };

        // Create the TIFF image (first page is a default blank frame)
        using (TiffImage tiffImage = (TiffImage)Image.Create(tiffOptions, canvasWidth, canvasHeight))
        {
            // Add each input image as a new page
            foreach (string path in args)
            {
                using (RasterImage page = (RasterImage)Image.Load(path))
                {
                    tiffImage.AddPage(page);
                }
            }

            // Remove the initial default frame
            var defaultFrame = tiffImage.ActiveFrame;
            tiffImage.ActiveFrame = tiffImage.Frames[1];
            tiffImage.RemoveFrame(0);
            defaultFrame.Dispose();

            // Save the multipage TIFF
            tiffImage.Save();
        }

        Console.WriteLine($"Multipage TIFF saved to {outputPath}");
    }
}