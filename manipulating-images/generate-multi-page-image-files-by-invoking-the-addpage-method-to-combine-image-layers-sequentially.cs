using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded input image paths
        string[] inputPaths = new string[]
        {
            @"C:\Images\input1.png",
            @"C:\Images\input2.png",
            @"C:\Images\input3.png"
        };

        // Validate input files
        foreach (string path in inputPaths)
        {
            if (!File.Exists(path))
            {
                Console.Error.WriteLine($"File not found: {path}");
                return;
            }
        }

        // Hardcoded output path
        string outputPath = @"C:\Images\output.tif";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the first image to obtain canvas size
        using (RasterImage firstImage = (RasterImage)Image.Load(inputPaths[0]))
        {
            // Prepare TIFF options with bound source
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
            {
                Source = new FileCreateSource(outputPath, false),
                Photometric = TiffPhotometrics.Rgb,
                BitsPerSample = new ushort[] { 8, 8, 8 }
            };

            // Create TIFF canvas with the size of the first image
            using (TiffImage tiff = (TiffImage)Image.Create(tiffOptions, firstImage.Width, firstImage.Height))
            {
                // Add the first image as the first page
                tiff.AddPage(firstImage);

                // Add remaining images as additional pages
                for (int i = 1; i < inputPaths.Length; i++)
                {
                    using (RasterImage img = (RasterImage)Image.Load(inputPaths[i]))
                    {
                        tiff.AddPage(img);
                    }
                }

                // Save the multi-page TIFF (bound to source, so no path needed)
                tiff.Save();
            }
        }
    }
}