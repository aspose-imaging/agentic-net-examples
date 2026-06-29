using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input directory containing GIF files and output TIFF path
            string inputDirectory = @"C:\temp\gifs";
            string outputPath = @"C:\temp\output\multipage.tif";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Get all GIF files in the input directory
            string[] gifFiles = Directory.GetFiles(inputDirectory, "*.gif");

            if (gifFiles.Length == 0)
            {
                Console.Error.WriteLine("No GIF files found in the input directory.");
                return;
            }

            // Load each GIF file, checking existence
            List<RasterImage> gifImages = new List<RasterImage>();
            foreach (string gifPath in gifFiles)
            {
                if (!File.Exists(gifPath))
                {
                    Console.Error.WriteLine($"File not found: {gifPath}");
                    return;
                }

                // Load the GIF image as a RasterImage
                RasterImage img = (RasterImage)Image.Load(gifPath);
                gifImages.Add(img);
            }

            // Use dimensions of the first image for the TIFF canvas
            int width = gifImages[0].Width;
            int height = gifImages[0].Height;

            // Prepare TIFF creation options
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
            {
                Source = new FileCreateSource(outputPath, false),
                Photometric = TiffPhotometrics.Rgb,
                BitsPerSample = new ushort[] { 8, 8, 8 }
            };

            // Create a TIFF image with a default frame (will be removed later)
            using (TiffImage tiffImage = (TiffImage)Image.Create(tiffOptions, width, height))
            {
                // Add each GIF image as a separate TIFF frame
                foreach (RasterImage gifImg in gifImages)
                {
                    TiffFrame frame = new TiffFrame(gifImg);
                    tiffImage.AddFrame(frame);
                }

                // Remove the initially created default frame
                TiffFrame activeFrame = tiffImage.ActiveFrame;
                tiffImage.ActiveFrame = tiffImage.Frames[1];
                tiffImage.RemoveFrame(0);
                activeFrame.Dispose();

                // Save the multipage TIFF
                tiffImage.Save();
            }

            // Dispose loaded GIF images (frames already own them, but disposing is safe)
            foreach (var img in gifImages)
            {
                img.Dispose();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to archive a collection of animated GIF screenshots as a single multipage TIFF using Aspose.Imaging for .NET for long‑term storage or printing.
 * 2. When an application must convert individual GIF frames of a scanned document into a multipage TIFF to create a searchable PDF later in the workflow.
 * 3. When a medical imaging solution stores each slice of a GIF‑based scan as a separate page in a TIFF file to ensure compatibility with DICOM viewers.
 * 4. When a web service aggregates user‑uploaded GIF icons into one multipage TIFF so that a legacy reporting tool that only accepts TIFF files can display them.
 * 5. When a scheduled C# batch job consolidates daily GIF charts into a single multipage TIFF for easy email distribution to stakeholders.
 */