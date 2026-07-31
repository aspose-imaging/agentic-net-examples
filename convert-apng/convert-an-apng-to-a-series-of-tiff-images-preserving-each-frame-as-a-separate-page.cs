using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.apng";
            string outputPath = "output\\result.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the APNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to ApngImage to access frames (pages)
                ApngImage apng = (ApngImage)image;

                // Get dimensions from the first frame
                RasterImage firstFrame = (RasterImage)apng.Pages[0];
                int width = firstFrame.Width;
                int height = firstFrame.Height;

                // Configure TIFF options
                TiffOptions tiffOptions = new TiffOptions(Aspose.Imaging.FileFormats.Tiff.Enums.TiffExpectedFormat.Default);
                tiffOptions.Photometric = Aspose.Imaging.FileFormats.Tiff.Enums.TiffPhotometrics.Rgb;
                tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };

                // Create a multi-page TIFF image
                using (TiffImage tiffImage = (TiffImage)Image.Create(tiffOptions, width, height))
                {
                    // Add the first frame
                    tiffImage.AddFrame(new TiffFrame(firstFrame));

                    // Add remaining frames
                    for (int i = 1; i < apng.PageCount; i++)
                    {
                        RasterImage frame = (RasterImage)apng.Pages[i];
                        tiffImage.AddFrame(new TiffFrame(frame));
                    }

                    // Save the resulting TIFF file
                    tiffImage.Save(outputPath);
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
 * 1. When a developer needs to extract each animation frame from an APNG and store them as separate pages in a multi‑page TIFF for archival or printing workflows.
 * 2. When a web application must convert user‑uploaded animated PNGs into a TIFF document that can be opened by legacy desktop publishing software that only supports TIFF.
 * 3. When a medical imaging system requires converting animated PNG visualizations into a single TIFF file with each frame as a page for inclusion in patient reports.
 * 4. When a digital asset management tool needs to generate a searchable, multi‑page TIFF from an APNG so that each frame can be indexed individually by metadata.
 * 5. When an e‑learning platform wants to transform animated instructional graphics (APNG) into a multi‑page TIFF to embed them into PDF slide decks that preserve the sequence of steps.
 */