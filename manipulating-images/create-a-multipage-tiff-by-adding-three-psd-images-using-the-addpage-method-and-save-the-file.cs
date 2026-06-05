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
        // Hardcoded input and output paths
        string inputPath1 = @"C:\Images\image1.psd";
        string inputPath2 = @"C:\Images\image2.psd";
        string inputPath3 = @"C:\Images\image3.psd";
        string outputPath = @"C:\Images\multipage.tif";

        try
        {
            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Verify each input file exists
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
            if (!File.Exists(inputPath3))
            {
                Console.Error.WriteLine($"File not found: {inputPath3}");
                return;
            }

            // Load the first PSD to obtain image dimensions
            using (RasterImage firstPage = (RasterImage)Image.Load(inputPath1))
            {
                int width = firstPage.Width;
                int height = firstPage.Height;

                // Set up TIFF creation options
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.Source = new FileCreateSource(outputPath, false);
                tiffOptions.Photometric = TiffPhotometrics.Rgb;
                tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };

                // Create an empty TIFF image with the dimensions of the first page
                using (TiffImage tiffImage = (TiffImage)Image.Create(tiffOptions, width, height))
                {
                    // Add the first page (already loaded)
                    tiffImage.AddPage(firstPage);

                    // Load and add the second PSD page
                    using (RasterImage secondPage = (RasterImage)Image.Load(inputPath2))
                    {
                        tiffImage.AddPage(secondPage);
                    }

                    // Load and add the third PSD page
                    using (RasterImage thirdPage = (RasterImage)Image.Load(inputPath3))
                    {
                        tiffImage.AddPage(thirdPage);
                    }

                    // Save the multipage TIFF
                    tiffImage.Save();
                }
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
 * 1. When a developer needs to archive a series of Photoshop PSD files as a single multipage TIFF for long‑term storage or compliance auditing.
 * 2. When a developer wants to generate a printable document that combines several design drafts (PSD) into one high‑resolution TIFF for a press workflow.
 * 3. When a developer must create a multipage TIFF to import into a document management system that only accepts TIFF while the source assets are PSD images.
 * 4. When a developer is building a batch conversion tool that consolidates multiple PSD pages into a single TIFF to reduce file‑handling overhead in a .NET application.
 * 5. When a developer needs to prepare a multipage TIFF for medical or scientific imaging archives where each PSD represents a separate slice or layer of a scanned specimen.
 */